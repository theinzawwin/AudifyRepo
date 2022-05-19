using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AudifyProject.Models
{
    [Table("FavoriteItems")]
    public class FavoriteItem
    {
        [Key]
        public long Id { get; set; }
        public long ItemId { get; set; }
        [ForeignKey("ItemId")]
        public Item Item { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Status { get; set; }
    }
}
