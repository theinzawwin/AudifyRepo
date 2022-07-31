using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AudifyProject.Models
{
    public class AdsIncome
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string DeviceId { get; set; }
        public string UserId { get; set; }
        public int Amount { get; set; }
        public string AdType { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
    }
}
