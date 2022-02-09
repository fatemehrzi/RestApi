using System.ComponentModel.DataAnnotations;

namespace RestApi.Dtos
{
    public class RobotDTO
    {
        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool MaxSpeed { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

    }
}
