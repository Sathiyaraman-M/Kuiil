var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("kuiil-postgres")
    .WithDataVolume("kuiil-postgres-data")
    .AddDatabase("kuiil", "kuiil");

builder.AddProject<Projects.Kuiil_Books>("kuiil-books")
    .WithReference(postgres)
    .WaitFor(postgres);

var vectorDB = builder.AddQdrant("vectordb")
    .WithDataVolume("kuiil-vectordb-data");

builder.AddProject<Projects.Kuiil_UI>("kuiil-ui")
    .WithReference(vectorDB)
    .WaitFor(vectorDB);

await builder.Build().RunAsync();
