using PiCalculusApp.Classes;

var runtime = new PiRuntime();

// Channel a: used to send other channels
var a = runtime.CreateChannel<PiChannel<string>>("a");

// Process 1: Sender - creates channel b and sends it over a
var sender = new PiProcess(async () =>
{
    var b = runtime.CreateChannel<string>("b");
    await a.SendAsync(b);
    Console.WriteLine("Sender sent channel 'b' over channel 'a'");

    await Task.Delay(100); // ensure receiver has time to get 'b'

    await b.SendAsync("Hello over dynamic channel!");
    Console.WriteLine("Sender sent message on channel 'b'");
});

// Process 2: Receiver - receives channel from 'a' and listens on it
var receiver = new PiProcess(async () =>
{
    var receivedChannel = await a.ReceiveAsync();
    Console.WriteLine("Receiver received channel 'b'");

    var message = await receivedChannel.ReceiveAsync();
    Console.WriteLine($"Receiver got message: {message}");
});

runtime.Spawn(sender);
runtime.Spawn(receiver);

await runtime.WaitAllAsync();