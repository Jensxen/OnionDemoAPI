using Microsoft.Extensions.Hosting;
using OnionDemo.Application.Command;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace OnionDemo.Application.Command
{
    public class PendingAddressChecker : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public PendingAddressChecker(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Start background task
            Task.Run(() => DoWork(cancellationToken), cancellationToken);
            return Task.CompletedTask;
        }

        private async Task DoWork(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var addressValidationCommand = scope.ServiceProvider.GetRequiredService<IAddressValidationCommand>();
                    // Use addressValidationCommand to perform work
                }

                await Task.Delay(TimeSpan.FromMinutes(1), cancellationToken); // Adjust the delay as needed
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            // Stop background task
            return Task.CompletedTask;
        }
    }
}