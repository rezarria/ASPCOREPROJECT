using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WEB.Models
{
    [Table("tbl_DonVi_CauHinh")]
    public partial class TblDonViCauHinh
    {
        public TblDonViCauHinh()
        {
            TblBaiViets = new HashSet<TblBaiViet>();
            TblChuyenMucs = new HashSet<TblChuyenMuc>();
            TblLienKetNgoais = new HashSet<TblLienKetNgoai>();
        }

        [Key]
        [Column("ID_DonVi")]
        public long IdDonVi { get; set; }
        [StringLength(250)]
        public string? TenDonVi { get; set; }
        [StringLength(250)]
        public string? SubDomain { get; set; }
        [StringLength(50)]
        public string? Email { get; set; }
        [StringLength(50)]
        public string? DienThoai { get; set; }
        [StringLength(100)]
        public string? Logo { get; set; }
        [StringLength(250)]
        public string? DiaChi { get; set; }
        [StringLength(250)]
        public string? TrangChu { get; set; }
        [StringLength(250)]
        public string? NguoiQuanLy { get; set; }
        [StringLength(250)]
        public string? BanQuyen { get; set; }
        [Column("ID_DonViGoc")]
        public int? IdDonViGoc { get; set; }

        [InverseProperty("IdDonViNavigation")]
        public virtual ICollection<TblBaiViet> TblBaiViets { get; set; }
        [InverseProperty("IdDonViNavigation")]
        public virtual ICollection<TblChuyenMuc> TblChuyenMucs { get; set; }
        [InverseProperty("IdDonViNavigation")]
        public virtual ICollection<TblLienKetNgoai> TblLienKetNgoais { get; set; }
    }
}
