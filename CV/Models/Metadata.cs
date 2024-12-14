using System;

namespace CV.Models
{
    public class Metadata
    {
        public string Id { get; set; }
        public bool Private { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CollectionId { get; set; }
        public string Name { get; set; }
    }
}
