using RestApi.Models;

namespace RestApi.Repo
{
    public interface IRobot
    {
        public IEnumerable<Robot> GetRobots();
        public Robot GetRobot(int id);
        public void CreateRobot(Robot robot);
        public void MoveRobot(int id, bool maxSpeed, double x, double y);
        public Task DeleteRobot(int id);
        public void AddImage(int id, byte[] fileData);

    }
}
