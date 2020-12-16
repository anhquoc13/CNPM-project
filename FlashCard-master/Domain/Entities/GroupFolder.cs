using Domain.Entities.Common;

namespace Domain.Entities
{
    public class GroupFolder : EntityBase, IAggregateRoot
    {
        public int ID { get; set; }
        public int IDfolder { get; set; }
        public int IDclass { get; set; }
        public int status { get; set; }
    }
}