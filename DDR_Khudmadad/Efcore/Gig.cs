using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DDR_Khudmadad.Efcore
{
    [Table("Gig")]
    public class Gig
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int gigId { get; set; }

        //Foreign Key
        public int creatorId { get; set; }
        public Users Creator { get; set; }

        public string gigName { get; set; }
        public string description { get; set; }

        [DataType(DataType.DateTime)]
        public string deadline { get; set; }

        //TODO: Add Document Field

        [DataType(DataType.Currency)]
        public double pay { get; set; }

        public ICollection<Offers> offer { get; set; }
    }
}
