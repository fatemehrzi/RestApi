namespace RestApi.Dtos
{
    public record CreateRobotDTO
    {
        public string? Name { get; set; }
        public bool IsActive { get; set; }
        public bool MaxSpeed { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public byte[] Image { get; set; }

        public byte[] Video { get; set; }

    }

    public record MoveRobotDTO
    {
        public int Id { get; set; }
        public bool MaxSpeed { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

    }
}
