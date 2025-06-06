using MQTTnet;
using MQTTnet.Client;
using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PiCalculusMqttTemplate
{
    public class MqttRuntime
    {
        private IMqttClient _client;

        public async Task StartAsync()
        {
            var factory = new MqttFactory();
            _client = factory.CreateMqttClient();

            var options = new MqttClientOptionsBuilder()
                .WithTcpServer("localhost", 1883)
                .WithClientId("PiClient")
                .Build();

            _client.ConnectedAsync += async e =>
            {
                Console.WriteLine("Connected to broker.");
                await _client.SubscribeAsync(new MqttClientSubscribeOptionsBuilder()
                    .WithTopicFilter("channel/discover")
                    .Build());
            };

            _client.ApplicationMessageReceivedAsync += e =>
            {
                var payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                try
                {
                    var message = JsonSerializer.Deserialize<PiMessage>(payload);
                    if (message?.Type == "channel_offer")
                    {
                        Console.WriteLine($"Subscribing to offered channel: {message.Channel}");
                        return _client.SubscribeAsync(new MqttClientSubscribeOptionsBuilder()
                            .WithTopicFilter(message.Channel)
                            .Build());
                    }
                    else
                    {
                        Console.WriteLine($"Received: {payload}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to parse message: {ex.Message}");
                }

                return Task.CompletedTask;
            };

            await _client.ConnectAsync(options);
        }
    }
}
