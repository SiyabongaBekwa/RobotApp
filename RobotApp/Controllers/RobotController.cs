using BL.DTOs.POST;
using BL.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RobotAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RobotController : ControllerBase
    {
        private readonly RobotBL _robotBL;
        public RobotController(RobotBL robotBL)
        {
            _robotBL = robotBL;
        }

        [HttpPost("add-robot")]
        public async Task<IActionResult> AddRobot([FromBody] AddRobotDto addRobotDto)
        {
            await _robotBL.AddRobot(addRobotDto);
            return Ok("Robot Added");
        }

        [HttpGet("get-robots")]
        public async Task<IActionResult> GetRobotsAsync()
        {
            var robots = await _robotBL.GetRobotsAsync();
            return Ok(robots);
        }

        [HttpGet("get-robot/{Model}")]
        public async Task<IActionResult> FindSurvivorAsync(string Model)
        {
            var robot = await _robotBL.FindRobotAsync(Model);
            return Ok(robot);
        }
    }
}
