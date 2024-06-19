var builder = DistributedApplication.CreateBuilder(args);

var databases = builder.AddPostgres("databases")
                      .WithPgAdmin();

var productsDatabase = databases.AddDatabase("products");

builder.AddProject<Projects.API>("api")
       .WithReference(productsDatabase);

builder.Build().Run();