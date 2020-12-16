using Domain.Entities.Common;

namespace Domain.Entities
{
    public class MemberOF : EntityBase, IAggregateRoot
    {
        public string IDuser { get; set; }
        public int IDclass { get; set; }
    }
}