using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.RetourType
{
    public class DayIntervals
    {
         public   DateTime day { get; set; }
         public  List<Interval> intervals { get; set; }
    }
}