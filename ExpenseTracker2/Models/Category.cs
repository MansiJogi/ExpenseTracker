using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ExpenseTracker2.Models
{
    [Table("Categories")]
    public class Category
    {
        public Category()
        {
            this.catExpLimit = 0.0f;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int catId { get; set; }

        [Required(ErrorMessage = "Category Name Required")]
        [Display(Name = "Category Name")]
        public string catName { get; set; }

        [Required(ErrorMessage = "Category Expense Limit Required")]
        [Display(Name = "Category Expense Limit")]
        public float catExpLimit { get; set; }
    }
}