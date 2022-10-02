using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Phantom.API.Common.Helpers;
using Phantom.API.Model;
using Phantom.API.Model.Dto;

namespace Phantom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IBaseResponse<object> _baseResponse;

        public OrderController(IWebHostEnvironment environment, IBaseResponse<object> baseResponse)
        {
            _baseResponse = baseResponse;
        }

        [HttpPost]
        [Route("Order")]
        public async Task<IActionResult> MakeOrder([FromBody] OrderDto model )
        {

            if (model == null || !ModelState.IsValid)
            {
                return StatusCode(400, await _baseResponse.CustomErroMessage("400", "Paramaeters Cannot be Empty"));
            }

            //
            //obj._fileAPI.ImgName = "\\Upload\\" + objFile.files.FileName;
            //if (objFile.files.Length > 0)
            //{
            //    if (!Directory.Exists(_environment.WebRootPath + "\\Upload"))
            //    {
            //        Directory.CreateDirectory(_environment.WebRootPath + "\\Upload\\");
            //    }
            //    using (FileStream filestream = System.IO.File.Create(_environment.WebRootPath + "\\Upload\\" + objFile.files.FileName))
            //    {
            //        objFile.files.CopyTo(filestream);
            //        filestream.Flush();
            //        //  return "\\Upload\\" + objFile.files.FileName;
            //    }
            //}
            return null;
        }
    }
}
