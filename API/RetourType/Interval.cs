using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.RetourType
{
    public class Interval
    {
      public DateTime debut ;
      public DateTime fin;

        public Interval(DateTime dateTime1, DateTime dateTime2)
        {
            this.debut = dateTime1;
            this.fin = dateTime2;
        }
        

    }
}