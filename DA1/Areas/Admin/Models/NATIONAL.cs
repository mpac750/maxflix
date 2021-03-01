using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DA1.Areas.Admin.Models
{
    public class NATIONAL
    {
       
        public int NationalId { get; set; }
        [Display(Name = "Quốc Gia")]
        public string NationalName { get; set; }
        public virtual ICollection<Movie> MOVIEs { get; set; }
    }
}
