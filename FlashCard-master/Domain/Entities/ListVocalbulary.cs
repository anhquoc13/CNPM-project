using Domain.Entities.Common;

namespace Domain.Entities
{
    public class ListVocalbulary : EntityBase, IAggregateRoot
    {
        public int IDcourse { get; set; }
        public int IDvocab { get; set; }
    }
}