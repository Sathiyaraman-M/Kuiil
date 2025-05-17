# Kuill

An experimental attempt to replace traditional CRUD UI with a chat interface.

## Getting Started

### Prerequisites

- .NET 9.0 SDK
- Docker
- Visual Studio or Visual Studio Code (with C# Dev Kit) or JetBrains Rider
- Ollama with models `llama3.1:8b` and `nomic-embed-text:latest`

### Running the application

To start the application, run the following command in the terminal:

```bash
dotnet run --project Kuiil.AppHost/Kuiil.AppHost.csproj
```

Alternatively, you can start the `Kuiil.AppHost` project in Visual Studio or Rider.

This will start the application by running the following resources:

- `Kuiil.UI` (Web-based Chat UI)
- `Kuiil.Books` (RESTful API for Books CRUD)
- PostgreSQL Database (For `Kuiil.Books`)
- Qdrant Vector Database (For `Kuiil.UI`)

Once the Aspire AppHost is running, you can access the Chat UI at `https://localhost:7070`.

For other resources, you can refer them at Aspire Dashbord running at `https://localhost:17068`.