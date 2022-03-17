using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactAppBackend.Database.Models
{
    public class Contact
    {

        [Key()]
        public int Id { get; set; }

        public string Title { get; set; }

        public string PhoneNumber { get; set; }

        public string Adress { get; set; }

        public string Province { get; set; }

        public string District { get; set; }


        [ForeignKey("OwnerId")]
        public virtual User Owner { get; set; }
        
        public int OwnerId { get; set; }

    }
}
