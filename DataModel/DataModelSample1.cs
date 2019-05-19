using System.Data.Linq.Mapping;

namespace Interview
{
    [Table(Name = "Data.Samples1")]
    public class DataModelSample1
    {
        [Column(IsPrimaryKey = true)]
        public int ID { get; set; }
        [Column]
        public string Color { get; set; }
    }
}
