using System;
using Microsoft.CodeAnalysis.CSharp;
using System.Threading;
using System.Threading.Tasks;
using SampleResourceManagementApp.Utilities.DisposeActions;

namespace SampleResourceManagementApp.Threading
{
    public static class SemaphoreSlimExtension
    {
        public static async Task<IDisposable> LockAsync(this SemaphoreSlim semaphoreSlim)
        {
            await semaphoreSlim.WaitAsync();
            return GetDispose(semaphoreSlim);
        }

        private static IDisposable GetDispose(this SemaphoreSlim semaphoreSlim)
        {
            return new DisposeAction(() =>
            {
                semaphoreSlim.Release();
            });
        }
    }
}
