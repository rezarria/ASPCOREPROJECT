using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WEB.Models
{
    [Table("tbl_LienKetNgoai")]
    public partial class TblLienKetNgoai
    {
        [Key]
        [Column("ID_LienKet")]
        public long IdLienKet { get; set; }
        [StringLength(250)]
        public string? TenLienKet { get; set; }
        [StringLength(250)]
        public string? LienKet { get; set; }
        [StringLength(150)]
        public string? BieuTuong { get; set; }
        [StringLength(50)]
        public string? MauNen { get; set; }
        [Column("ID_DonVi")]
        public long? IdDonVi { get; set; }

        [ForeignKey("IdDonVi")]
        [InverseProperty("TblLienKetNgoais")]
        public virtual TblDonViCauHinh? IdDonViNavigation { get; set; }
    }
}
