using Domain.Entities.Common;

namespace Domain.Entities
{
    public class DetailFolder : EntityBase, IAggregateRoot
    {
        public int IDfolder { get; set; }
        public int IDcourse { get; set; }
        public int status { get; set; }
    }
}