using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ELearning.Models
{
    public class Filter
    {
       public byte searchBuoi { get; set; }
       public byte searchThu { get; set; }
       public long searchHocphi { get; set; }
       public IEnumerable<Buoi> searchBuois { get; set; }
       public IEnumerable<Thu> searchThus { get; set; }
    }
}