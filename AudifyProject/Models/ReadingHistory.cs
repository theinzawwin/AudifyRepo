using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AudifyProject.Models
{
    [Table("ReadingHistory")]
    public class ReadingHistory
    {
        [Key]
        public long Id { get; set; }
        public Guid ChapterId { get; set; }
        [ForeignKey("ChapterId")]
        public Chapter Chapter { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ReadTime { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Status { get; set; }

    }
}
