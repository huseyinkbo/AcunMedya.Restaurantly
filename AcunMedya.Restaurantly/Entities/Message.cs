using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcunMedya.Restaurantly.Entities
{
    public class Message
    {
        public int MessageId { get; set; }
        public string Name { get; set; }
        public DateTime SendDate { get; set; }
        public string Messages { get; set; }
        public string Icon { get; set; }
        public string IconColor { get; set; }
        public bool IsRead { get; set; }
    }
}