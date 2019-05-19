using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    [Table(Name = "Data.Samples2")]
    public class Colours2
    {
        [Column(IsPrimaryKey = true)]
        public int ID { get; set; }
        [Column]
        public string Color { get; set; }
    }
}
