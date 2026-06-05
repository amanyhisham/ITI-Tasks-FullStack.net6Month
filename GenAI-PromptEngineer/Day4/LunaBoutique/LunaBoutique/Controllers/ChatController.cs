using LunaBoutique.Models;
using LunaBoutique.Services;
using Microsoft.AspNetCore.Mvc;

namespace LunaBoutique.Controllers
{
    public class ChatController : Controller
    {
        private readonly IAnthropicService _anthropicService;

        public ChatController(IAnthropicService anthropicService)
        {
            _anthropicService = anthropicService;
        }

        [HttpPost]
        public async Task<IActionResult> Send([FromBody] ChatRequest request)
        {
            try
            {
                var response = await _anthropicService.GetResponseAsync(
                    request.Message,
                    request.History ?? new List<ChatMessage>()
                );
                return Json(new { success = true, message = response });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "عذراً، حدث خطأ. حاولي مرة أخرى! 💕" });
            }
        }
    }
}