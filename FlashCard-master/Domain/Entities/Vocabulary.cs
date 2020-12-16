using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Vocalbulary : EntityBase, IAggregateRoot
    {
        public int ID { get; set; }
        public string define { get; set; }
        public string explain { get; set; }
        public string image { get; set; }
    }
}