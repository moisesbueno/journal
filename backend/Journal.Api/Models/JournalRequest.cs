using System.Xml.Linq;

namespace Journal.Api.Models
{
    public class JournalRequest
    {
        public string Issn { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
