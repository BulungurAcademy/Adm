var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Adm>("adm");

builder.Build().Run();
