using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AudifyProject.Models
{
    [Table("AuthorFollowers")]
    public class AuthorFollower
    {
        [Key]
        public long Id { get; set; }
        public long AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }
        public DateTime FollowDate { get; set; }
        public bool Status { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
