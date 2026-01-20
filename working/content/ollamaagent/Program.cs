using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using OllamaSharp;

var endpoint = Environment.GetEnvironmentVariable("OLLAMA_ENDPOINT") ?? "http://localhost:11434";
var modelName = Environment.GetEnvironmentVariable("OLLAMA_MODEL_NAME") ?? "{Your Model Name}";


var chatClient = new OllamaApiClient(new Uri(endpoint), modelName);

// Get a chat client for Ollama and use it to construct an AIAgent.
AIAgent agent = new ChatClientAgent(
    chatClient,
    instructions: "You are good at telling jokes",
    name: "Joker"
).AsBuilder()
.Build();

// Invoke the agent and output the text result.
Console.WriteLine(await agent.RunAsync("Tell me a joke about a pirate."));