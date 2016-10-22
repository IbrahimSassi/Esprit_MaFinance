using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.Domain.Entities
{
    public class Provider
    {

        [Key]
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }
        public bool IsApproved { get; set; }

        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password hasnt pass 8 cara")]
        [Required]
        public String Password { get; set; }
        public String UserName { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        [Required]
        [Compare("Password", ErrorMessage = "Password confirmation doesn't match Password")]
        public String ConfirmPassword { get; set; }


        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        public virtual ICollection<Product> products { get; set; }


    }
}
