var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("kuiil-postgres")
    .WithVolume("kuiil-postgres-data", "/var/lib/postgresql/data")
    .AddDatabase("kuiil", "kuiil");

builder.AddProject<Projects.Kuiil_Books>("kuiil-books")
    .WithReference(postgres);

await builder.Build().RunAsync();
