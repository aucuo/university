using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using System.Collections.Generic;
using Newtonsoft.Json; // Для сериализации в JSON

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DataController : Controller
    {
        [HttpGet]
        public FileContentResult Get()
        {
            var file = "D:\\Desktop\\Learning\\SPP\\2pract\\WebAPI\\wwwroot\\json\\jsontest.json";
            Byte[] b = System.IO.File.ReadAllBytes(file);
            return File(b, "application/json");
        }
    }
}
