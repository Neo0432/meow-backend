namespace PawsBackendDotnet.Models.Entities
{
    public class EntityBase
    {
        public Guid ID { get; private set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? DeletedAt { get; set; }
    }
}
