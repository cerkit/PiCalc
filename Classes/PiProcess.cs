using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiCalculusApp.Classes
{
    public class PiProcess
    {
        public Func<Task> Behavior { get; }

        public PiProcess(Func<Task> behavior) => Behavior = behavior;
        public Task RunAsync() => Behavior();
    }
}
