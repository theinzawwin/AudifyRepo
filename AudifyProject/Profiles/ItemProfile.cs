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
            CreateMap<Author, AuthorViewModel>().ForMember(des=>des.TotalAudio,opt=>opt.MapFrom(src=>src.Items.Count));
            CreateMap<Author, AuthorFormViewModel>()
                .ForMember(des => des.File, opt => opt.Ignore());
                
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
            CreateMap<AuthorFollower, AuthorFollowViewModel>().ForMember(des => des.AuthorName, opt => opt.MapFrom(src => src.Author.Name));
            CreateMap<FavoriteItem, FavoriteItemViewModel>()
                .ForMember(des=>des.Name, opt=> opt.MapFrom(src=>src.Item.Name))
                .ForMember(des => des.CoverFileName, opt => opt.MapFrom(src => src.Item.CoverFile))
                ;

            CreateMap<ReadingHistory, ReadHistoryViewModel>()
                .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Chapter.Item.Name))
                .ForMember(des => des.CoverFileName, opt => opt.MapFrom(src => src.Chapter.Item.CoverFile))
                .ForMember(des => des.AudioId, opt => opt.MapFrom(src => src.Chapter.Item.Id))
                .ForMember(des => des.TotalReview, opt => opt.MapFrom(src => src.Chapter.Item.TotalReview))
                .ForMember(des => des.Description, opt => opt.MapFrom(src => src.Chapter.Item.Description))
                .ForMember(des=>des.Duration, opt => opt.MapFrom(src => src.Chapter.Item.Duration))
                .ForMember(des => des.TotalPage, opt => opt.MapFrom(src => src.Chapter.Item.TotalPage))
                ;
                
        }
    }
}
