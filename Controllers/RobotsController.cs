using Microsoft.AspNetCore.Mvc;
using RestApi.Dtos;
using RestApi.Models;
using RestApi.Repo;

namespace RestApi.Controllers
{
    // [ApiController]
    [Route("robots")]
    public class RobotsController : ControllerBase
    {
        private IRobot _RobotRepo;
        public RobotsController(IRobot robotRepo)
        {
            _RobotRepo = robotRepo;
            //_RobotRepo = new InMemRobotRepo();

        }
        [HttpGet]
        public ActionResult<IEnumerable<RobotDTO>> GetRobots()
        {
            return _RobotRepo.GetRobots()
                .Select(x => new RobotDTO { Id = x.Id, Name = x.Name, IsActive = x.IsActive, MaxSpeed = x.MaxSpeed, X = x.X, Y = x.Y })
                .ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<RobotDTO> GetRobots(int id)
        {
            var robot = _RobotRepo.GetRobot(id);
            if (robot == null)
                return NotFound();
            var robotDTO = new RobotDTO
            { Id = robot.Id, Name = robot.Name, IsActive = robot.IsActive, MaxSpeed = robot.MaxSpeed, X = robot.X, Y = robot.Y };

            return robotDTO;
        }

        [HttpPost]
        public ActionResult CreateRobot(CreateRobotDTO robot)
        {
            var myRobot = new Robot
            {
                Name = robot.Name,
                IsActive = robot.IsActive,
                MaxSpeed = robot.MaxSpeed,
                X = robot.X,
                Y = robot.Y,
                Image = robot.Image
            };

            _RobotRepo.CreateRobot(myRobot);

            return Ok();
        }

        [HttpPut]
        public ActionResult MoveRobot([FromBody] MoveRobotDTO robot)
        {

            _RobotRepo.MoveRobot(robot.Id, robot.MaxSpeed, robot.X, robot.Y);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRobot(int id)
        {
            await _RobotRepo.DeleteRobot(id);
            return Ok();
        }

        [HttpPost]
        [Route("api/upload")]
        public async Task<IActionResult> Upload(IFormFile file, [FromServices] IWebHostEnvironment env)
        {
            var id = Convert.ToInt32(Request.Headers["id"]);
            var filePath = Path.Combine(env.ContentRootPath, "Files", file.FileName);
            //using var stream = System.IO.File.Create(filePath);
            //stream.Position = 0;

            using var memory=new MemoryStream();
            await file.CopyToAsync(memory);
            _RobotRepo.AddImage(id,memory.ToArray());

            return Ok();
        }

    }
}
