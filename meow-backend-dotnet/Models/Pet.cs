namespace meowBackendDotnet.Models
{
    public enum Sex
    {
        Male, Female
    }
    public class Pet : EntityBase
    {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Breed { get; set; }
        public Sex Sex { get; set; } = Sex.Male;
        public string? ChipNumber { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool IsVaccine { get; set; } = false;

        public DateTime? LastFeed { get; set; } = DateTime.UtcNow;
        public DateTime? LastWalk { get; set; } = DateTime.UtcNow;
        public DateTime? LastMedication { get; set; } = DateTime.UtcNow;


        public void UpdateLastFeed(DateTime newTime) => this.LastFeed = newTime;

        public void UpdateLastWalk(DateTime newTime) => this.LastWalk = newTime;

        public void UpdateLastMedication(DateTime newTime) => this.LastMedication = newTime;
    }
}
