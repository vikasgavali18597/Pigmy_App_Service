namespace G_Pigmy.App.Models
{
    public class Agent
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Code { get; set; } = string.Empty;

        public string BranchCode { get; set; } = string.Empty;

        public string? Mobile { get; set; }
    }
}
