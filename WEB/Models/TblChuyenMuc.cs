using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WEB.Models
{
    [Table("tbl_ChuyenMuc")]
    public partial class TblChuyenMuc
    {
        public TblChuyenMuc()
        {
            TblBaiViets = new HashSet<TblBaiViet>();
            TblQuyenChuyenMucs = new HashSet<TblQuyenChuyenMuc>();
        }

        [Key]
        [Column("ID_ChuyenMuc")]
        public long IdChuyenMuc { get; set; }
        [Column("ID")]
        [StringLength(10)]
        public string Id { get; set; } = null!;
        [StringLength(200)]
        public string? TiengViet { get; set; }
        [StringLength(200)]
        public string? TiengAnh { get; set; }
        public int? CapBac { get; set; }
        [StringLength(10)]
        public string? ThuocMuc { get; set; }
        public int? ThuTu { get; set; }
        public int? ChoPhepCapNhat { get; set; }
        [Column("TrangThai_VN")]
        public int? TrangThaiVn { get; set; }
        [Column("TrangThai_EN")]
        public int? TrangThaiEn { get; set; }
        public int? ViTri { get; set; }
        [StringLength(50)]
        public string? Loai { get; set; }
        [StringLength(350)]
        public string? LienKet { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayTao { get; set; }
        public long? NguoiTao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgaySua { get; set; }
        public long? NguoiSua { get; set; }
        public string? MoTa { get; set; }
        [StringLength(50)]
        public string? GhiChu { get; set; }
        [StringLength(50)]
        public string? BieuTuong { get; set; }
        public int? TrangChu { get; set; }
        public int? BenTrai { get; set; }
        public int? BenPhai { get; set; }
        public int? TrenCung { get; set; }
        public int? DuoiCung { get; set; }
        public int? GiuaTrang { get; set; }
        public int? SiteMap { get; set; }
        public int? MacDinh { get; set; }
        [StringLength(350)]
        public string? HinhAnh { get; set; }
        [StringLength(200)]
        public string? BaoGom { get; set; }
        public int? TrangMoi { get; set; }
        [Column("ID_DonVi")]
        public long? IdDonVi { get; set; }

        [ForeignKey("IdDonVi")]
        [InverseProperty("TblChuyenMucs")]
        public virtual TblDonViCauHinh? IdDonViNavigation { get; set; }
        [InverseProperty("IdChuyenMucNavigation")]
        public virtual ICollection<TblBaiViet> TblBaiViets { get; set; }
        [InverseProperty("IdChuyenMucNavigation")]
        public virtual ICollection<TblQuyenChuyenMuc> TblQuyenChuyenMucs { get; set; }
    }
}
