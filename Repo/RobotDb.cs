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
            _robots.Add(robot);
           
        }

        public void DeleteRobot(Guid id)
        {
            var robotIndex = _robots.FindIndex(x => x.Id == id);
            if (robotIndex > -1)
                _robots.RemoveAt(robotIndex);
        }

        public Robot GetRobot(Guid id)
        {
            var robot = _robots.Where(x=>x.Id==id).SingleOrDefault();
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
