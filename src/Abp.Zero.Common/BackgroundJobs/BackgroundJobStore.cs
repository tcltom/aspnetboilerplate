﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Timing;

namespace Abp.BackgroundJobs
{
    /// <summary>
    /// Implements <see cref="IBackgroundJobStore"/> using repositories.
    /// </summary>
    public class BackgroundJobStore : IBackgroundJobStore, ITransientDependency
    {
        private readonly IRepository<BackgroundJobInfo, long> _backgroundJobRepository;

        public BackgroundJobStore(IRepository<BackgroundJobInfo, long> backgroundJobRepository)
        {
            _backgroundJobRepository = backgroundJobRepository;
        }

        public Task<BackgroundJobInfo> GetAsync(long jobId)
        {
            return _backgroundJobRepository.GetAsync(jobId);
        }

        public Task InsertAsync(BackgroundJobInfo jobInfo)
        {
            return _backgroundJobRepository.InsertAsync(jobInfo);
        }

        [UnitOfWork]
        public virtual Task<List<BackgroundJobInfo>> GetWaitingJobsAsync(int maxResultCount)
        {
            var waitingJobs = _backgroundJobRepository.GetAll()
                .Where(t => !t.IsAbandoned && t.NextTryTime <= Clock.Now)
                .OrderBy(t => t.Priority,SqlSugar.OrderByType.Desc)
                .OrderBy(t => t.TryCount)
                .OrderBy(t => t.NextTryTime)
                .Take(maxResultCount)
                .ToList();

            return Task.FromResult(waitingJobs);
        }

        public Task DeleteAsync(BackgroundJobInfo jobInfo)
        {
            return _backgroundJobRepository.DeleteAsync(jobInfo);
        }

        public Task UpdateAsync(BackgroundJobInfo jobInfo)
        {
            return _backgroundJobRepository.UpdateAsync(jobInfo);
        }
    }
}
