using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudifyProject.ViewModels
{
    public class AuthorFollowViewModel
    {
        public long Id { get; set; }
        public long AuthorId { get; set; }
        public string AuthorName { get; set; }
        public bool Status { get; set; }
        public DateTime FollowDate { get; set; }
    }
}
