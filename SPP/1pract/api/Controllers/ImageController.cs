using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageController : ControllerBase
    {
        [HttpGet(Name = "GetImage")]
        public FileContentResult Get()
        {
            Byte[] b = System.IO.File.ReadAllBytes(@"D:\\Downloads\\1671918503542-01-min.jpg");      
            return File(b, "image/jpeg");
        }
    }
}