var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Adm>("adm");

builder.AddProject<Projects.Adm_Sdk_Api>("adm-sdk-api");

builder.Build().Run();
