using Domain.Entities.Common;

namespace Domain.Entities
{
    public class TestOfFolder : EntityBase, IAggregateRoot
    {
        public int ID { get; set; }
        public int IDgrfolder { get; set; }
        public float scores { get; set; }
    }
}