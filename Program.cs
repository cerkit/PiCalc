using System;
using System.Threading.Tasks;

namespace PiCalculusMqttTemplate
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting Pi Calculus MQTT Process...");
            var runtime = new MqttRuntime();
            await runtime.StartAsync();
        }
    }
}
