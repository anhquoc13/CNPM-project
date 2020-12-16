using Domain.Entities.Common;

namespace Domain.Entities
{
    public class TestOFCourse : EntityBase, IAggregateRoot
    {
        public int ID { get; set; }
        public int IDcourse { get; set; }
        public float scores { get; set; }
    }
}