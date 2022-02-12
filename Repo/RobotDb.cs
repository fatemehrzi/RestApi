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
            _db.Robots.Add(robot);
            _db.SaveChanges();
           
        }

        public void DeleteRobot(int id)
        {
            var robot = _db.Robots.Where(x => x.Id == id).FirstOrDefault();
            _db.Robots.Remove(robot);
            _db.SaveChanges();
        }

        public Robot GetRobot(int id)
        {
            var robot = _db.Robots.Where(x=>x.Id==id).FirstOrDefault();
            return robot;   
        }

        public IEnumerable<Robot> GetRobots()
        {
           return _db.Robots;
        }

        public void MoveRobot(int id,bool maxSpeed,double x,double y)
        {
            var robot = _db.Robots.Where(z => z.Id == id).FirstOrDefault();
            robot.MaxSpeed = maxSpeed;
            robot.X = x;
            robot.Y = y;
            _db.SaveChanges();
           
        }
    }
}
