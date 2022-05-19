using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudifyProject.ViewModels
{
    public class ChapterViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IFormFile File { get; set; }
        public string FileName { get; set; }
        public long ItemId { get; set; }
    }
}
