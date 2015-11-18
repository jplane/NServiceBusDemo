
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NServiceBus;
using TaiJi.Common.Commands;
using TaiJi.Common;
using TaiJi.Common.Events;

namespace TaiJi.JobEngine
{
    internal static class Engine
    {
        private static ConcurrentDictionary<Guid, JobInstance> _jobs = new ConcurrentDictionary<Guid, JobInstance>();

        public static void StartJob(StartJobCommand command, IBus bus)
        {
            var job = new JobInstance
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Payload = command.Payload
            };

            _jobs[job.Id] = job;

            job.Start(bus.Publish);
        }

        public static void CancelJob(CancelJobCommand command)
        {
            JobInstance job = null;

            if (_jobs.TryGetValue(command.Id, out job))
            {
                job.Cancel();
            }
        }

        public static Job GetJobStatus(JobStatusQuery query)
        {
            JobInstance job = null;

            if (_jobs.TryGetValue(query.Id, out job) == false)
            {
                return null;
            }

            return job.ToJob();
        }

        public static IEnumerable<Job> GetJobInstances()
        {
            return _jobs.Values.Select(instance => instance.ToJob());
        }

        public static IEnumerable<string> GetJobTypes()
        {
            yield return "JobA";
            yield return "JobB";
            yield return "JobC";
        }
    }

    internal class JobInstance
    {
        private static Random _randomizer = new Random(Environment.TickCount);
        
        private DateTimeOffset? _started = null;
        private TimeSpan? _duration = null;
        private Task _main = null;
        private CancellationTokenSource _tokenSource = null;
        private JobStatus _status = JobStatus.NotStarted;
        
        public Job ToJob()
        {
            return new Job
            {
                Id = this.Id,
                Name = this.Name,
                Payload = this.Payload,
                Started = this.Started,
                Duration = this.Duration,
                Status = this.Status
            };
        }

        public JobInstance()
        {
        }

        public string Name { get; set; }

        public Guid Id { get; set; }

        public string Payload { get; set; }

        public DateTimeOffset? Started
        {
            get { return _started; }
        }

        public TimeSpan? Duration
        {
            get
            {
                if (_started != null)
                {
                    return _duration ?? DateTimeOffset.UtcNow.Subtract(_started.Value);
                }
                else
                {
                    return null;
                }
            }
        }

        public JobStatus Status
        {
            get { return _status; }
        }

        public void Start(Action<Event> eventHandler)
        {
            if (_main != null)
            {
                return;
            }

            _tokenSource = new CancellationTokenSource();
            
            _main = new Task(() =>
            {
                if (_tokenSource.IsCancellationRequested)
                {
                    _status = JobStatus.Canceled;

                    eventHandler(new JobCanceledEvent
                    {
                        Id = this.Id,
                        Name = this.Name
                    });
                }
                else
                {
                    _status = JobStatus.Starting;
                    _started = DateTimeOffset.UtcNow;

                    eventHandler(new JobStartingEvent
                    {
                        Id = this.Id,
                        Name = this.Name
                    });
                }
            }, _tokenSource.Token);

            _main.ContinueWith(_ => Thread.Sleep(_randomizer.Next(2000, 10000)))
                 .ContinueWith(_ =>
                 {
                     if (_tokenSource.IsCancellationRequested)
                     {
                         _status = JobStatus.Canceled;

                         eventHandler(new JobCanceledEvent
                         {
                             Id = this.Id,
                             Name = this.Name
                         });
                     }
                     else
                     {
                         _status = JobStatus.Started;

                         eventHandler(new JobStartedEvent
                         {
                             Id = this.Id,
                             Name = this.Name
                         });
                     }
                 })
                 .ContinueWith(_ => Thread.Sleep(_randomizer.Next(10000, 30000)))
                 .ContinueWith(_ =>
                 {
                     if (_tokenSource.IsCancellationRequested)
                     {
                         _status = JobStatus.Canceled;

                         eventHandler(new JobCanceledEvent
                         {
                             Id = this.Id,
                             Name = this.Name
                         });
                     }
                     else
                     {
                         _status = JobStatus.Completed;
                         _duration = DateTimeOffset.UtcNow.Subtract(_started.Value);

                         eventHandler(new JobCompletedEvent
                         {
                             Id = this.Id,
                             Name = this.Name
                         });
                     }
                 });

            _main.Start();
        }

        public void Cancel()
        {
            _tokenSource.Cancel();
        }
    }
}
