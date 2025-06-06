# PiCalc.NET
## .NET Template for Pi Calculus over MQTT

See [the docs](https://PiCalc.net)

This project provides a .NET 8 Console Application template inspired by the **Pi Calculus** model of concurrency. It uses MQTT for dynamic message-passing and models **channel mobility** through topic subscriptions.

## 📦 Template Features

- 📡 MQTT messaging with [MQTTnet](https://github.com/dotnet/MQTTnet)
- 🔁 Dynamic topic discovery and channel subscription (simulating channel mobility)
- 🧠 JSON-encoded messages with structured metadata
- ♻️ Reactive process simulation using C#
- 🛠️ .NET 8 support and NuGet-compatible project template

---

## 🧰 Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- MQTT broker (e.g. [Mosquitto](https://mosquitto.org/download/))
- Internet access (for NuGet restore)

---

## 🚀 Getting Started

### 🔧 Install the Template

Clone or download the NuGet-compatible ZIP file and run:

```bash
dotnet new -i ./PiCalculusMqttTemplate-NuGet.zip
```

### 🧪 Create a Project from the Template

```bash
dotnet new pi-mqtt -n MyMqttApp
cd MyMqttApp
dotnet run
```

---

## 🧬 Message Format

Messages are exchanged in structured JSON format to mimic typed communication:

```json
{
  "type": "channel_offer" | "message",
  "channel": "channel/topic/name",
  "payload": "optional payload",
  "meta": {
    "correlationId": "guid",
    "timestamp": "ISO 8601 timestamp"
  }
}
```

- `channel_offer`: Invites a process to dynamically subscribe
- `message`: General message on a dynamic channel

---

## 🧠 Pi Calculus Concepts Modeled

| Concept           | Implementation                                 |
|------------------|--------------------------------------------------|
| Process          | `.NET Task`-based runtime with message loop     |
| Channel          | MQTT topic string                               |
| Message Passing  | JSON messages via `MQTTnet` library             |
| Channel Mobility | Subscribing to a topic received in a message    |
| Guarded Choice   | Basic type checking for message type            |

---

## 📁 Project Structure

```
PiCalculusMqttTemplate/
├── Program.cs              # Entry point
├── MqttRuntime.cs          # Handles MQTT client logic
├── MqttPiProcess.cs        # Represents a Pi-style process
├── PiMessage.cs            # JSON message model and metadata
├── PiCalculusMqttTemplate.csproj
└── .template.config/
    └── template.json       # Metadata for dotnet CLI template
```

---

## 📜 License

This template is licensed under the **MIT License**.  
Use freely for education, commercial, or experimentation.

---

## ✍️ Author

Created by **Michael Earls**  
Contributions welcome! Open an issue or PR.
