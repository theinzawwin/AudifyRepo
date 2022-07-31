using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudifyProject.ViewModels
{
    public class ReadHistoryViewModel
    {
        public long Id { get; set; }
        public Guid ChapterId { get; set; }
        public long AudioId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CoverFileName { get; set; }
        public int TotalReview { get; set; }
        public int TotalPage { get; set; }
        public double Duration { get; set; }
        public int ReadTime { get; set; }
    }
}
