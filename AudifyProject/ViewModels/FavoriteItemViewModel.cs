using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudifyProject.ViewModels
{
    public class FavoriteItemViewModel
    {
        public long Id { get; set; }
        public long ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TotalReview { get; set; }
        public int TotalPage { get; set; }

        public string CoverFileName { get; set; }
    }
}
