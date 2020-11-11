using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Rocket_Elevator_RESTApi.Models
{
    
    public partial class Battery
    {
 
        public int id { get; set; }
        public string status { get; set; }

        public virtual int building_id { get; set;}
        public  Building Building { get; set;}

        public virtual ICollection<Column> Columns { get; set;}

    }
}