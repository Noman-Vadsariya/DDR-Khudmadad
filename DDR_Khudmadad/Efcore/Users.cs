using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DDR_Khudmadad.Efcore
{
    [Table("Users")]
    public class Users
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int userId { get; set; }

        [AllowNull]
        public int roleId { get; set; }
        public Roles Role { get; set; }

        public string userName { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string password { get; set; }
        public string dob { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(11)]
        public string phoneNumber { get; set; }

        [AllowNull]
        public string? description { get; set; }

        public ICollection<Offers> offer { get; set; }
        public List<Gig> gig { get; set; }
    }
}
