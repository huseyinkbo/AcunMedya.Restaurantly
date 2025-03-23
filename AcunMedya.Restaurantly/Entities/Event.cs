using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcunMedya.Restaurantly.Entities
{
    public class Event
    {
        public int EventId { get; set; }

        public string EventName { get; set; }

        public string EventPrice { get; set; }

        public string EventDescription { get; set; }
        public string EventDescription2 { get; set; }

        public string EventDescription3 { get; set; }
        public string ImageUrl { get; set; }


    }
}