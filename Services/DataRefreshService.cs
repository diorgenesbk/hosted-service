using hosted_service.Hosted;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace hosted_service.Services
{
    public class DataRefreshService : HostedService
    {
        private readonly RandomStringService RandomStringService;

        public DataRefreshService(RandomStringService randomStringProvider)
        {
            RandomStringService = randomStringProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await RandomStringService.UpdateString(cancellationToken);
                await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
            }
        }
    }
}
