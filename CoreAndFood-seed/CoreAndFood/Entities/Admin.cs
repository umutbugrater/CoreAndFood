﻿using System.ComponentModel.DataAnnotations;

namespace CoreAndFood.Entities
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [StringLength(20)]
        public string UserName { get; set; }


        [StringLength(20)]
        public string Password { get; set; }


        [StringLength(1)]
        public string AdminRole { get; set; }
    }
}
