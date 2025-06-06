using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiCalculusApp.Classes
{
    public class PiRuntime
    {
        private readonly List<Task> _runningProcesses = new();

        public PiChannel<T> CreateChannel<T>(string? name = null) where T : class => new(name);

        public void Spawn(PiProcess process)
        {
            var task = process.RunAsync();
            _runningProcesses.Add(task);
        }

        public async Task WaitAllAsync() => await Task.WhenAll(_runningProcesses);
    }
}
