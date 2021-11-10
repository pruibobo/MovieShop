using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class FavoriteRequestModel
    {
        public int movieId { get; set; }
        public int userId { get; set; }
    }
}
