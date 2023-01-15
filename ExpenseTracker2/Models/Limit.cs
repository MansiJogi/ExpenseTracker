using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker2.Models
{
    [Table("Total_Limit")]
    public class Limit
    {
        public Limit()
        {
            this.totLimit = 0.0f;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required(ErrorMessage ="Total Limit Required")]
        public float totLimit { get; set; }

    }
}