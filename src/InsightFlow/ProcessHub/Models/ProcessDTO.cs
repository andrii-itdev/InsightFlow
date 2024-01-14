namespace ProcessHub.API.Models
{
    public record ProcessDTO
    {
        public Guid ProcessKey { get; set; } = Guid.NewGuid();
    }
}
