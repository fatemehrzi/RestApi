using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApi.Models
{
    public class Robot
    {
        
    
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
        public bool MaxSpeed { get; set; }
        public double X { get; set; }

        public double Y { get; set; }

        public byte[] Image { get; set; }

    }
}
