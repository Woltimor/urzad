using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Urzad.Services;

namespace Urzad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {

        [HttpGet("{filename}")]
        public async Task<IActionResult> Download(string filename)
        {
                        if (filename == null)
                            return Content("filename not present");

                            var path = Path.Combine(
                                               Directory.GetCurrentDirectory(), "wwwroot" + @"\UploadFiles", filename);
                            var memory = new MemoryStream();
                            using (var stream = new FileStream(path, FileMode.Open))
                            {
                                await stream.CopyToAsync(memory);
                            }
                            memory.Position = 0;
                            byte[] fileBytes = System.IO.File.ReadAllBytes(path);
                            return File(fileBytes, "application/x-msdownload", filename);

     

        }


    }
}