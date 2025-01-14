var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Tracker_Api>("tracker-api");

builder.Build().Run();
