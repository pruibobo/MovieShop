using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class ReviewRequestModel
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public string reviewText { get; set; }
        public decimal Rating { get; set; }
    }
}
