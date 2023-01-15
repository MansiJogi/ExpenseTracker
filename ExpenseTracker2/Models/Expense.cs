using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace ExpenseTracker2.Models
{
    [Table("Expenses")]
    public class Expense
    {
        public Expense()
        {
            this.Amount = 0.0f;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long exId { get; set; }

        [Required(ErrorMessage = "Title Required")]
        [StringLength(50)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description Required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Date & Time Required")]
        [Display(Name = "Date & Time")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = false)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage ="category Name required")]
        [Display(Name = "Category Name")]
        public int catId { get; set; }
        [ForeignKey("catId")]
        public virtual Category Categories { get; set; }

        [Required(ErrorMessage = "Amount Required")]
        public float Amount { get; set; }


        

    }
}