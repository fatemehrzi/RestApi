using System.ComponentModel.DataAnnotations;

namespace RestApi.Models
{
    public class Robot
    {
        [Required]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
        public bool MaxSpeed { get; set; }
        public double X { get; set; }

        public double Y { get; set; }

    }
}
