using BL.DTOs.GET;
using BL.DTOs.POST;
using BL.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RobotAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurvivorController : ControllerBase
    {
        private readonly SurvivorBL _survivorBL;
        public SurvivorController(SurvivorBL survivorBL)
        {
            _survivorBL = survivorBL;
        }

        [HttpPost("add-survivor")]
        public async Task<IActionResult> AddSurvivor([FromBody] AddSurvivorDto addSurvivorDto)
        {
            await _survivorBL.AddSurvivor(addSurvivorDto);
            return Ok("Survivor Added");
        }

        [HttpGet("get-survivors")]
        public async Task<IActionResult> GetSurvivorsAsync()
        {
            var survivors = await _survivorBL.GetSurvivorsAsync();
            return Ok(survivors);
        }

        [HttpGet("get-survivor/{IDNumber}")]
        public async Task<IActionResult> FindSurvivorAsync(string IDNumber)
        {
            var survivor = await _survivorBL.FindSurvivorAsync(IDNumber);
            return Ok(survivor);
        }

        [HttpPut("update-survivor")]
        public async Task<IActionResult> UpdateSurvivor(string IDNumber, string lastLocation)
        {
             await _survivorBL.UpdateSurvivor(IDNumber, lastLocation);
            return Ok();

        }



        [HttpPost("report-infection")]
        public async Task<IActionResult> ReportInfection(string reportingSurvivorIdNumber, string reportedSurvivorIdNumber)
        {
            var success = await _survivorBL.ReportInfection(reportingSurvivorIdNumber, reportedSurvivorIdNumber);
            if (success)
                return Ok();
            else
                return NotFound();
        }

        [HttpGet("statistics")]
        public async Task<IActionResult> GetStatistics()
        {
            var statistics = await _survivorBL.GetStatistics();
            return Ok(statistics);
        }
    }
}
