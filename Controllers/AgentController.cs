using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.AzureOpenAI;

namespace AgentRGHNTT.Controllers
{
    public class PayloadRequest
    {
        public string Message { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly AzureOpenAIChatCompletionService _chatService;
        private readonly AzureOpenAIPromptExecutionSettings _settings;
        private readonly Kernel _kernel;
        public AgentController(AzureOpenAIChatCompletionService service, AzureOpenAIPromptExecutionSettings settings,
            Kernel kernel)
        {
            _chatService = service;
            _settings = settings;
            _kernel = kernel;
        }

        [HttpPost("message-assist")]
        public async Task<IActionResult> MessageProcess(PayloadRequest payload)
        {

            ChatHistory chatMessageContents = new ChatHistory();

            chatMessageContents.AddAssistantMessage(@"
                Eres un asistente que brinda informacion sobre un PDF de malla cargado en una base de datos.
                Puedes ayudar con información sobre roles, metas de la empresa y cursos.
                Cualquier otra pregunta que no tiene el tema detallado anteriormente, responde amablemente que no puedes responder.
                ");

            chatMessageContents.AddUserMessage(payload.Message);
            var response = await _chatService.GetChatMessageContentsAsync(chatMessageContents,_settings,_kernel);
            return Ok(response);
        }
        [HttpPost("message-assist-free")]
        public async Task<IActionResult> MessageProcessFree(PayloadRequest payload)
        {

            ChatHistory chatMessageContents = new ChatHistory();
            chatMessageContents.AddUserMessage(payload.Message);
            var response = await _chatService.GetChatMessageContentsAsync(chatMessageContents, _settings, _kernel);
            return Ok(response);
        }
    }
}
