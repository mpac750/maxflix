using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DA1.Areas.Admin.Models;
using DA1.Areas.Users.Models;
using DA1.Models;
using Microsoft.AspNetCore.Identity;

namespace DA1.Helper
{
    public class ModelHelper:Profile
    {
        public ModelHelper()
        {
            CreateMap<MovieViewModel, Movie>().ReverseMap();
            CreateMap<Movie, MovieViewModel>().ReverseMap();
            CreateMap<CATEGORY, CategoryViewModel>().ReverseMap();
            CreateMap<CategoryViewModel,CATEGORY>().ReverseMap();
            CreateMap<NATIONAL, NationalViewModel>().ReverseMap();
            CreateMap<NationalViewModel, NATIONAL>().ReverseMap();



        }
    }
}
