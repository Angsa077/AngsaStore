﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AngsaStore.Services.Models
{
    public class MasterUser
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Photo { get; set; }
        public int RoleId { get; set; }
        public Nullable<DateTime> InsertedDatetime { get; set; }
        public Nullable<DateTime> UpdatedDatetime { get; set; }
    }
}