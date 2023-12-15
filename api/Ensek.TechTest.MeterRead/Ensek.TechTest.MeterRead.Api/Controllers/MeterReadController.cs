using Ensek.TechTest.MeterRead.Api.Util;
using Ensek.TechTest.MeterRead.Domain.Models;
using Ensek.TechTest.MeterRead.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ensek.TechTest.MeterRead.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeterReadController : ControllerBase
    {
        private readonly IMeterReadService _meterReadingService;

        public MeterReadController(IMeterReadService meterReadingService)
        {
            _meterReadingService = meterReadingService;
        }

        [HttpPost]
        [Route("meter-reading-uploads")]
        public async Task<IActionResult> Upload(List<IFormFile> file)
        {
            if (file == null || !file.Any())
            {
                return BadRequest("No file found in request");
            }

            var formFile = file.First();
            var fileextension = Path.GetExtension(formFile.FileName);
            if (fileextension == ".csv")
            {
                using (var targetStream = await UploadControllerHelper.BuildMemoryStream(formFile))
                {
                    if (targetStream == null)
                    {
                        return BadRequest();
                    }

                    var uploadResponse = await _meterReadingService.UploadCsv(targetStream);

                    return Ok(uploadResponse);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateReading(MeterReadingDto meterData)
        {
            if (meterData == null)
            {
                return BadRequest("Meterdata is null");
            }

            var meterCreated = await _meterReadingService.CreateReading(meterData);

            return meterCreated
                ? Ok("Meter reading created successfully")
                : BadRequest("Failed to create meter reading.");
        }
    }
}
