using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudifyProject.ViewModels
{
    public class ItemViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
       
        public string Description { get; set; }
        public int TotalReview { get; set; }
        public int TotalPage { get; set; }
        public double Duration { get; set; }
        public Boolean HasChapter { get; set; }
        public Boolean Status { get; set; }
        public long AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string CategoryName { get; set; }
        public long CategoryId { get; set; }
        public IFormFile CoverFile { get; set; }
        public string CoverFileName { get; set; }
        public string CreatedBy { get; set; }
        public List<ChapterViewModel> Chapters { get; set; }
    }
}
