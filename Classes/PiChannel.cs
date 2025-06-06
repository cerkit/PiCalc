using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace PiCalculusApp.Classes
{
    public class PiChannel<T>
        where T : class
    {
        public string Name { get; }
        private readonly Channel<T> _channel;

        public PiChannel(string name = null)
        {
            Name = name ?? Guid.NewGuid().ToString();
            _channel = Channel.CreateUnbounded<T>();
        }

        public async Task SendAsync(T message) => await _channel.Writer.WriteAsync(message);
        public async Task<T> ReceiveAsync() => await _channel.Reader.ReadAsync();

    }
}
