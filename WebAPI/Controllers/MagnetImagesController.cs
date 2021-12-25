using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MagnetImagesController : ControllerBase
    {
        IMagnetImageService _magnetImageService;

        public MagnetImagesController(IMagnetImageService magnetImageService)
        {
            _magnetImageService = magnetImageService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] MagnetImage magnetImage)
        {
            var result = _magnetImageService.Add(file, magnetImage);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromForm(Name = ("Id"))] int magnetImageId)
        {

            var magnetImage = _magnetImageService.Get(magnetImageId).Data;

            var result = _magnetImageService.Delete(magnetImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm(Name = ("Image"))] IFormFile file, [FromForm(Name = ("Id"))] int magnetImageId)
        {
            var magnetImage = _magnetImageService.Get(magnetImageId).Data;
            var result = _magnetImageService.Update(file, magnetImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _magnetImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById([FromForm(Name = ("Id"))] int id)
        {
            var result = _magnetImageService.Get(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getimagesbymagnetid")]
        public IActionResult GetImagesById([FromForm(Name = ("MagnetImageId"))] int magnetImageId)
        {
            var result = _magnetImageService.GetImagesByMagnetId(magnetImageId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
