using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Rocket_Elevator_RESTApi.Models
{
    public class Column 
    {
        public int id { get; set; }
        public string status { get; set; }
        
        public virtual int battery_id { get; set; }
        public  Battery Battery { get; set;}
        public virtual ICollection<Elevator> Elevators { get; }
        


    }
}