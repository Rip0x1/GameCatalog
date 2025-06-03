using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int UserID { get; set; }
        public int GameID { get; set; }
        public string ReviewText { get; set; }
        public float Rating { get; set; }
        public DateTime ReviewDate { get; set; }
        public string UserName { get; set; } 
        public string GameTitle { get; set; } 
    }


}
