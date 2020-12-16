using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class GroupFolder : EntityBase, IAggregateRoot
    {
        [Key]
        public int ID { get; set; }
        public int IDfolder { get; set; }
        public int IDclass { get; set; }
        public int status { get; set; }
    }
}