using System.Net.Mime;

namespace BusinessLogic.Messages.Models
{
    public class MessageBusiness
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public byte[] SizeMessage { get; set; } = new byte[4];
        public ContentType ContentType { get; set; } = null!;
        public DateTime TimeStamp { get; set; }

    }
}
