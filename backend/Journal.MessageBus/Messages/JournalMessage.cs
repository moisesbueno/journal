namespace Journal.MessageBus.Messages
{
    public class JournalMessage
    {
        public JournalMessage()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; }
        public string Name { get; set; }
        public string Qualis2019 { get; set; }
        public string Issn { get; set; }
    }
}
