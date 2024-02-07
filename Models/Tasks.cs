using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
    public class Tasks
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public int Status_ID { get; set; }
        //public Statuses Statuses { get; set; }
    }

}
