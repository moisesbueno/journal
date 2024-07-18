namespace Journal.Api.Models
{
    public class JournalResponse
    {
        public JournalResponse(string name, DateTime createdAt)
        {
            Name = name;
            CreatedAt = createdAt;
        }
        public string Name { get; private set; }

        public DateTime CreatedAt { get; private set; }
    }
}
