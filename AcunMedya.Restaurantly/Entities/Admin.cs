﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AcunMedya.Restaurantly.Entities
{
    public class Admin
    {
        public int AdminId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string ImageUrl { get; set; }
        public string Email { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile {  get; set; }

        [NotMapped]
        public string CurrentPassword { get; set; }

        [NotMapped]
        public string NewPassword { get; set; }

        [NotMapped]
        public string ConfirmPassword { get; set; }
    }
}