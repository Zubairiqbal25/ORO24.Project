using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inlogic.Pos.Entities
{
    public class Login
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
    }
    public class Users
    {
        [Column("UserId",Order =1)]
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? id { get; set; }
        [Required]
        public string? name { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string? confirmPassword { get; set; }
        public string? role { get; set; }

    }

}