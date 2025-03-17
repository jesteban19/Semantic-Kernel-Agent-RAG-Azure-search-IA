using AgentRGHNTT.Plugins;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.AzureOpenAI;
using Microsoft.SemanticKernel.Connectors.OpenAI;

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var kernel = Kernel.CreateBuilder();
kernel.Plugins.AddFromType<SearchVectorPlugin>();
var promptSettings = new AzureOpenAIPromptExecutionSettings()
{
    ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
};


builder.Services.AddSingleton(kernel.Build());
builder.Services.AddSingleton(promptSettings);

var chatService = new AzureOpenAIChatCompletionService(Environment.GetEnvironmentVariable("MODEL_IA")!,
    Environment.GetEnvironmentVariable("OPENIA_URL")!, Environment.GetEnvironmentVariable("OPENIA_KEY")!);

builder.Services.AddTransient(x => chatService);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
