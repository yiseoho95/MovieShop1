using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models.Request
{
    public class MovieCreateRequestModel
    {
        public string Title { get; set; }
        public string OverView { get; set; }
        
        //? in c# is same thing as 'nullable'
        public decimal? Budget { get; set; }
        public decimal? Revenue { get; set; }
    }
}
