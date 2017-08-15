using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.NodeServices;
using System.Threading.Tasks;

namespace NodeServicesExample.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly INodeServices _nodeServices;

        public ValuesController(INodeServices nodeServices)
        {
            _nodeServices = nodeServices;
        }

        [HttpGet("add")]
        public async Task<long> Add(int x = 11, int y = 31)
        {
            return await _nodeServices.InvokeAsync<long>("Scripts/Add.js", x, y);
        }

        [HttpGet("eval")]
        public async Task<string> Multiply(string expression = "6 * 7")
        {
            return await _nodeServices.InvokeAsync<string>("Scripts/Eval.js", expression);
        }

        [HttpGet("qr")]
        public async Task<IActionResult> QR(string text = "42")
        {
            var data = await _nodeServices.InvokeAsync<byte[]>("Scripts/QR.js", text);
            return File(data, "image/png");
        }
    }
}
