using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudifyProject.ViewModels
{
    public class AuthorViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Remark { get; set; }
        public bool Status { get; set; }
        public String Profile { get; set; }
        public int TotalAudio { get; set; }
        public List<ItemViewModel> Items { get; set; }
        public bool IsFollow { get; set; }
        public int FollowQty { get; set; }
    }
}
