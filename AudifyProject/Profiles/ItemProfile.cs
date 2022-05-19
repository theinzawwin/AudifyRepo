using AudifyProject.Models;
using AudifyProject.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudifyProject.Profiles
{
    public class ItemProfile:Profile
    {
        public ItemProfile()
        {
            CreateMap<Author, AuthorViewModel>();
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Item, ItemViewModel>()
                .ForMember(des => des.AuthorName, opt => opt.MapFrom(src => src.Author.Name))
                .ForMember(des => des.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(des => des.CoverFile, opt => opt.Ignore())
                .ForMember(des => des.CoverFileName, opt => opt.MapFrom(src=>src.CoverFile))
                ;
            CreateMap<Chapter, ChapterViewModel>()
                .ForMember(des=>des.File,opt=>opt.Ignore())
                .ForMember(des=> des.FileName,opt=> opt.MapFrom(src=>src.FilePath))
                ;
        }
    }
}
