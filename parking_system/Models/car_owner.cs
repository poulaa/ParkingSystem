using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace parking_system.Models
{
    public class car_owner
    {
        [Key]
        public int car_owner_id { get; set; }
        public string name { get; set; }
        public int licen_number { get; set; }
      
       
       
    }
}
