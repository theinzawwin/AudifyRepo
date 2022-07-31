using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudifyProject.ViewModels
{
    public class AuthorFormViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Remark { get; set; }
        public bool Status { get; set; }
        public IFormFile File { get; set; }
        public string Profile { get; set; }
        public string CreatedBy { get; set; }
    }
}
