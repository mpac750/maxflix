using DA1.Areas.Users.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DA1.Models
{
    
    public class MovieViewModel
    {
        [Key]
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string MovieImage { get; set; }
        public string MovieVideo { get; set; }

        public double MoviePoint { get; set; }
        public string MovieTrailer { get; set; }
        public string MovieDesc { get; set; }
        public string MovieTime { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public virtual CategoryViewModel CategoryViewModel { get; set; }
        public Nullable<int> NationalId { get; set; }
        public virtual NationalViewModel NationalViewModel { get; set; }
    }
}
