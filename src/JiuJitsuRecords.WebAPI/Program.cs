using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Types;
using JiuJitsuRecords.WebAPI;
using JiuJitsuRecords.WebAPI.Schemas;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Inject (DI) services
builder.Services.ConfigureApplicationDependencies();

// inject GraphQL schema (The base schema for the base endpoint)
builder.Services.AddSingleton<ISchema, JiujiteirosSchema>(services => new JiujiteirosSchema(new SelfActivatingServiceProvider(services)));

// register GraphQL
builder.Services.AddGraphQL(options =>
                    options.ConfigureExecution((opt, next) =>
                    {
                        opt.EnableMetrics = true;
                        return next(opt);
                    }).AddSystemTextJson()
                );
// default setup
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "GraphQLDotNet.WebAPI", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GraphQLDotNet.WebAPI v1"));
    // add altair UI to development only
    app.UseGraphQLAltair();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Define o schema a ser usado pelo GraphQL no endereço padrão
app.UseGraphQL<ISchema>();

app.Run();
