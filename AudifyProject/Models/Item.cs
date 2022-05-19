using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AudifyProject.Models
{
    [Table("Item")]
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "text")]
        public string Description { get; set; }
        public int TotalReview { get; set; }
        public int TotalPage { get; set; }
        public double Duration { get; set; }
        public long CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public long AuthorId { get; set; }
        public Author Author { get; set; }
        public Boolean HasChapter { get; set; }
        public Boolean Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public List<Chapter> Chapters { get; set; }
        public string CoverFile { get; set; }
        public int CoverType { get; set; }
    }
}
