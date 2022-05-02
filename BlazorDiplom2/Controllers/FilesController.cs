using Microsoft.AspNetCore.Mvc;

namespace BlazorDiplom2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IWebHostEnvironment Env;
        public FilesController(IWebHostEnvironment env)
        {
            Env = env;
        }

        //[HttpPost]
        //public bool Disco([FromForm] IEnumerable<IFormFile> files)
        //{
        //    Console.WriteLine("File uploaded!");
        //    return true;
        //}
        [HttpGet]
        public bool Get()
        {
            Console.WriteLine("File uploaded!");
            return true;
        }


        //[HttpPost]
        //public bool Post([FromForm] IEnumerable<IFormFile> files)
        //{
        //    Console.WriteLine("File uploaded!");
        //    return true;
        //}

        //[HttpPost]
        //public async Task<bool> Upload([FromForm] IEnumerable<IFormFile> files)
        //{
        //    //example logic to save files
        //    bool result = false;
        //    FileStream ms = null;
        //    foreach (IFormFile file in files)
        //    {
        //        try
        //        {
        //            string path = "full path and file name";
        //            ms = System.IO.File.Create(path);
        //            await file.CopyToAsync(ms);
        //            await ms.DisposeAsync();
        //            result = true;
        //        }
        //        catch
        //        {
        //            result = false;
        //        }
        //    }
        //    return result;
        //}

        [HttpPost]
        public async Task<bool> Upload([FromForm] MultipartFormDataContent obje)
        {
            //example logic to save files
            bool result = false;
            FileStream ms = null;
           
            return true;
        }
    }
}
