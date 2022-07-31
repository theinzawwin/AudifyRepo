using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudifyProject.ViewModels
{
    public class SearchItemViewModel
    {
        public List<ItemViewModel> Items { get; set; }
        public List<AuthorViewModel> Authors { get; set; }
    }
}
