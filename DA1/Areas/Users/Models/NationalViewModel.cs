using DA1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DA1.Areas.Users.Models
{
    public class NationalViewModel
    {
        [Key]
        public int NationalId { get; set; }
        [Display(Name = "Quốc Gia")]
        public string NationalName { get; set; }
        public virtual ICollection<MovieViewModel> MovieViewModels { get; set; }
    }
}
