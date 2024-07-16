namespace Journal.Api.Models
{
    public class JournalModel
    {
        public Guid Id { get; set; }
        public string Issn { get; set; }
        public string Name { get; set; }
        public int QualisId { get; set; }
        public string Url { get; set; }
        public bool? Apc { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
