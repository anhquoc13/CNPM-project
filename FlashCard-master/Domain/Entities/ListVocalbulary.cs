using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class listVocabulary
    {
        [Key]
        public int ID { get; set; }
        public int IDcourse { get; set; }
        public int IDvocab { get; set; }
    }
}