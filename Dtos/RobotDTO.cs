using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApi.Dtos
{
    public class RobotDTO
    {
      
      
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool MaxSpeed { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

    }
}
