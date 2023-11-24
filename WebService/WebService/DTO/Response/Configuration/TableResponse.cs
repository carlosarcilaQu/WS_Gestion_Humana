using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Response.Configuration
{
    public class TableResponse
    {
        public long Id { get; set; }

        public string Name { get; set; } = null!;

        public bool? Active { get; set; }

        public DateTime RegisterDate { get; set; }
    }
}
