using Domain.Entities.Common;

namespace Domain.Entities
{
    public class Folder : EntityBase, IAggregateRoot
    {
        public int ID { get; set; }
        public string IDuser { get; set; }
        public string name { get; set; }
        public string describe { get; set; }
        public string link { get; set; }
    }
}