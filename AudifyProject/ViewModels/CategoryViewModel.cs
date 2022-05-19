using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudifyProject.ViewModels
{
    public class CategoryViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
        public List<ItemViewModel> Items { get; set; }
    }
}
