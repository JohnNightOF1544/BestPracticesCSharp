using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BestPracticesCsharp.Models
{
    public partial class Employee
    {
        [Key]
        [Column("Sys_Id")]
        [StringLength(50)]
        public string SysId { get; set; } = Guid.NewGuid().ToString();
        [StringLength(50)]
        public string Firstname { get; set; } = null!;
        [StringLength(50)]
        public string Middlename { get; set; } = null!;
        [StringLength(50)]
        public string Lastname { get; set; } = null!;
        public DateTimeOffset Birthdate { get; set; }
        [StringLength(50)]
        public string Address { get; set; } = null!;
        public bool Active { get; set; }
    }
}
