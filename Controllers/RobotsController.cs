using Microsoft.AspNetCore.Mvc;
using RestApi.Dtos;
using RestApi.Models;
using RestApi.Repo;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("robots")]
    public class RobotsController: ControllerBase
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
                .Select(x => new RobotDTO { Id = x.Id, Name = x.Name, IsActive = x.IsActive, MaxSpeed = x.MaxSpeed , X=x.X, Y=x.Y})
                .ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<RobotDTO> GetRobots(Guid id)
        {
            var robot = _RobotRepo.GetRobot(id);
            if (robot == null)
                return NotFound();
            var robotDTO = new RobotDTO 
            { Id = robot.Id, Name = robot.Name, IsActive = robot.IsActive, MaxSpeed = robot.MaxSpeed, X = robot.X, Y = robot.Y };
                
            return robotDTO;
        }

        [HttpPost]
        public ActionResult CreateRobot(CreateOrMoveRobotDTO robot)
        {
            var myRobot=new Robot();
            myRobot.Id= Guid.NewGuid();
            myRobot.Name = robot.Name;
            myRobot.IsActive = robot.IsActive;
            myRobot.MaxSpeed = robot.MaxSpeed;
            myRobot.X = robot.X;
            myRobot.Y = robot.Y;

            _RobotRepo.CreateRobot(myRobot);

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult MoveRobot(Guid id,CreateOrMoveRobotDTO robot)
        {
            var myRobot = _RobotRepo.GetRobot(id);

            if (myRobot==null)
                return NotFound();
            myRobot.Name = robot.Name;
            myRobot.IsActive = robot.IsActive;
            myRobot.MaxSpeed = robot.MaxSpeed;
            myRobot.X= robot.X;
            myRobot.Y= robot.Y;

            _RobotRepo.MoveRobot(id,myRobot);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteRobot(Guid id) 
        {
            var myRobot = _RobotRepo.GetRobot(id);

            if (myRobot == null)
                return NotFound();
            _RobotRepo.DeleteRobot(id);
            return Ok();
        }
    }
}
