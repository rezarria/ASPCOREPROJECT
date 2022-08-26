using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WEB.Models
{
    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Username { get; set; } = null!;
        [MaxLength(61)]
        public byte[] Password { get; set; } = null!;
    }
}
