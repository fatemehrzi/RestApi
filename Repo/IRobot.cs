using RestApi.Models;

namespace RestApi.Repo
{
    public interface IRobot
    {
        public IEnumerable<Robot> GetRobots();
        public Robot GetRobot(Guid id);
        public void CreateRobot(Robot robot);
        public void MoveRobot(Guid id, Robot robot);
        public void DeleteRobot(Guid id);

    }
}
