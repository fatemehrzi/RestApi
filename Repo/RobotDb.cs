using RestApi.Data;
using RestApi.Models;

namespace RestApi.Repo
{
    public class RobotDb : IRobot
    {
        private List<Robot> _robots;

        private readonly AppDbContext _db;
        public RobotDb(AppDbContext db)
        {
            _db = db;
        }

        public void CreateRobot(Robot robot)
        {
            robot.Id= Guid.NewGuid();
            _db.Robots.Add(robot);
            _db.SaveChanges();
           
        }

        public void DeleteRobot(Guid id)
        {
            var robot = _db.Robots.Where(x => x.Id.ToString() == id.ToString()).FirstOrDefault();
            _db.Robots.Remove(robot);
            _db.SaveChanges();
        }

        public Robot GetRobot(Guid id)
        {
            var robot = _db.Robots.Where(x=>x.Id.ToString() == id.ToString()).SingleOrDefault();
            return robot;   
        }

        public IEnumerable<Robot> GetRobots()
        {
           return _db.Robots;
        }

        public void MoveRobot(Guid id, Robot robot)
        {
            var robotIndex=_robots.FindIndex(x=>x.Id==id);
            if(robotIndex>-1)
                _robots[robotIndex]= robot;
           
        }
    }
}
