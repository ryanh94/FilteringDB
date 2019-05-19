using System.Data.Linq.Mapping;

namespace Interview
{
    [Table(Name = "Data.Samples2")]
    public class DataModelSample2
    {
        [Column(IsPrimaryKey = true)]
        public int ID { get; set; }
        [Column]
        public string Color { get; set; }
    }
}
