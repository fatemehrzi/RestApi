namespace RestApi.Dtos
{
    public record CreateOrMoveRobotDTO
    {
        public string? Name { get; set; }
        public bool IsActive { get; set; }
        public bool MaxSpeed { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

    }
}
