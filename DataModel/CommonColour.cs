using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    [Table(Name = "Data.CommonColours")]
    public class CommonColour
    {
        [Column(IsPrimaryKey = true)]
        public int ID { get; set; }
        [Column]
        public string Color { get; set; }
    }
}
