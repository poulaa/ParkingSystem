using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace parking_system.Models
{
    public class park_slot
    {
        public int id { get; set; }
        public string day { get; set; }
        public char spot { get; set; }
        public int licen_number { get; set; }
        public int car_owner_id { get; set; }

        [ForeignKey("car_owner_id")]
        public car_owner car_owner { get; set; }    

    }
}
