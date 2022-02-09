using RestApi.Models;

namespace RestApi.Repo
{
    public class InMemRobotRepo : IRobot
    {
        private List<Robot> _robots;
        public InMemRobotRepo() {
            _robots = new() { new Robot { Id = Guid.NewGuid(), Name = "5G throwaBot", IsActive = true, MaxSpeed = false , X=0, Y=0 } };
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
           return _robots;
        }

        public void MoveRobot(Guid id, Robot robot)
        {
            var robotIndex=_robots.FindIndex(x=>x.Id==id);
            if(robotIndex>-1)
                _robots[robotIndex]= robot;
           
        }
    }
}
