using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFinance.Domain.Entities
{
    public class Product
    {


        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Production Date")]
        public DateTime DateProd { get; set; }

        [DataType(DataType.MultilineText)]
        public String Description { get; set; }

        [MaxLength(21, ErrorMessage = "La taille max est 25")] //Taille ColumN BD
        [StringLength(45)] //User Input 
        [Required]
        public String Name { get; set; }

        [DataType(DataType.Currency)]
        public Double Price { get; set; }

        [Range(0, Int32.MaxValue)] //Interval
        public int Quantity { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category maCategory { get; set; }
        public int? CategoryId { get; set; }

        public virtual ICollection<Provider> providers { get; set; }

    }
}
