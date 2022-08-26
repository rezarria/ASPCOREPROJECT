﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WEB.Models
{
    [Table("tbl_VaiTro")]
    public partial class TblVaiTro
    {
        [Key]
        [Column("ID_VaiTro")]
        public long IdVaiTro { get; set; }
        [Column("ID")]
        [StringLength(255)]
        [Unicode(false)]
        public string Id { get; set; } = null!;
        [StringLength(255)]
        public string? Ten { get; set; }
    }
}
