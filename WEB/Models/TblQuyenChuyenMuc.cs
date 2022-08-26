using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WEB.Models
{
    [Table("tbl_QuyenChuyenMuc")]
    public partial class TblQuyenChuyenMuc
    {
        [Key]
        [Column("ID_TaiKhoan")]
        public long IdTaiKhoan { get; set; }
        [Key]
        [Column("ID_ChuyenMuc")]
        public long IdChuyenMuc { get; set; }
        [StringLength(255)]
        public string Ten { get; set; } = null!;
        public bool TinhTrang { get; set; }
        public bool VietBai { get; set; }
        public bool DuyetBai { get; set; }
        public bool SuaBai { get; set; }
        public bool XoaBai { get; set; }

        [ForeignKey("IdChuyenMuc")]
        [InverseProperty("TblQuyenChuyenMucs")]
        public virtual TblChuyenMuc IdChuyenMucNavigation { get; set; } = null!;
        [ForeignKey("IdTaiKhoan")]
        [InverseProperty("TblQuyenChuyenMucs")]
        public virtual TblTaiKhoan IdTaiKhoanNavigation { get; set; } = null!;
    }
}
