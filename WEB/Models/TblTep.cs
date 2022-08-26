using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WEB.Models
{
    [Table("tbl_Tep")]
    public partial class TblTep
    {
        public TblTep()
        {
            TblTepTaiKhoans = new HashSet<TblTepTaiKhoan>();
        }

        [Key]
        [Column("ID_Tep")]
        public long IdTep { get; set; }
        [Column("ID_Owner")]
        public long IdOwner { get; set; }
        public string DuongDan { get; set; } = null!;

        [ForeignKey("IdOwner")]
        [InverseProperty("TblTeps")]
        public virtual TblTaiKhoan IdOwnerNavigation { get; set; } = null!;
        [InverseProperty("IdTep1")]
        public virtual ICollection<TblTepTaiKhoan> TblTepTaiKhoans { get; set; }
    }
}
