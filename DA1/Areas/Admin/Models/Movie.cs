using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DA1.Areas.Admin.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        [Display(Name = "Tên Phim")]
        public string MovieName { get; set; }
        [Display(Name = "Hình Ảnh")]
        public string MovieImage { get; set; }
        [Display(Name = "Phim")]
        public string MovieVideo { get; set; }
        [Display(Name = "IMDB")]
        public double MoviePoint { get; set; }
        [Display(Name = "Trailer")]
        public string MovieTrailer { get; set; }
        [Display(Name = "Nội Dung")]
        public string MovieDesc { get; set; }
        [Display(Name = "Thời Lượng")]
        public string MovieTime { get; set; }
   
        public Nullable<int> CategoryId { get; set; }

        public Nullable<int> NationalId { get; set; }
        [Display(Name = "Thể Loại")]
        public virtual CATEGORY CATEGORY { get; set; }
        [Display(Name = "Quốc Gia")]
        public virtual NATIONAL NATIONAL { get; set; }

    }
}
