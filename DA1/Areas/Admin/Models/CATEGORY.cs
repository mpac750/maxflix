using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DA1.Areas.Admin.Models
{
    public class CATEGORY
    {
        public int CategoryId { get; set; }
        [Display(Name ="Tên thể loại")]
        public string CategoryName { get; set; }
        public virtual ICollection<Movie> MOVIEs { get; set; }
    }
}
