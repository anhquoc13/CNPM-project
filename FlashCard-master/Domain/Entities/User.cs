using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class User : EntityBase, IAggregateRoot
    {
        [Key]
        public string Id { get; set; }
        public string ID { get; set; }
        public string tagname { get; set; }
        public string email { get; set; }
        public string passwd { get; set; }
        public string contry { get; set; }
        public string avatar { get; set; }
        public string createdDay { get; set; }
        public string disableDay { get; set; }
        public string role { get; set; }
        public int status { get; set; }
    }
}