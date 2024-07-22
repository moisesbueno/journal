namespace Journal.MessageBus
{

    [QueueNameAttribute("journal-queue")]
    public class JournalQueue
    {
        public JournalQueue()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get;}
        public string Name { get; set; }
    }

    public class QueueNameAttribute : Attribute
    {
        public QueueNameAttribute(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }
    }
}
