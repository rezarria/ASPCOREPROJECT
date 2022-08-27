using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEB.Models
{
    [Table("tbl_BaiViet")]
    public partial class TblBaiViet
    {
        [Key]
        [Column("ID_BaiViet")]
        public long IdBaiViet { get; set; }
        [StringLength(200)]
        public string? ThucDon { get; set; }
        [StringLength(250)]
        public string? TieuDe { get; set; }
        [StringLength(500)]
        public string? TrichDan { get; set; }
        [Column(TypeName = "ntext")]
        public string? NoiDung { get; set; }
        [StringLength(800)]
        public string? HinhAnh { get; set; }
        [StringLength(350)]
        public string? LienKet { get; set; }
        [StringLength(100)]
        public string? TacGia { get; set; }
        public int? TrangThai { get; set; }
        public int? ThuTu { get; set; }
        [StringLength(150)]
        public string? GhiChu { get; set; }
        public int? TrenCung { get; set; }
        public int? DuoiCung { get; set; }
        public int? BenTrai { get; set; }
        public int? BenPhai { get; set; }
        public int? NamGiua { get; set; }
        public int? TinNong { get; set; }
        public int? TrinhDien { get; set; }
        public int? TrangChu { get; set; }
        public long? NguoiTao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayTao { get; set; }
        public long? NguoiSua { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgaySua { get; set; }
        public long? NguoiDuyet { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayDuyet { get; set; }
        public long? NguoiDang { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayDang { get; set; }
        public int? NgonNgu { get; set; }
        [StringLength(250)]
        public string? CacThe { get; set; }
        [StringLength(50)]
        public string? LinhVuc { get; set; }
        [StringLength(250)]
        public string? DiaDiem { get; set; }
        [StringLength(50)]
        public string? ThoiGian { get; set; }
        [StringLength(50)]
        public string? DonVi { get; set; }
        [StringLength(50)]
        public string? NganhHoc { get; set; }
        public int? NamHoc { get; set; }
        [StringLength(50)]
        public string? PhienBan { get; set; }
        [Column("ID_DonVi")]
        public long? IdDonVi { get; set; }
        [Column("ID_ChuyenMuc")]
        public long? IdChuyenMuc { get; set; }

        [ForeignKey("IdChuyenMuc")]
        [InverseProperty("TblBaiViets")]
        public virtual TblChuyenMuc? IdChuyenMucNavigation { get; set; }
        [ForeignKey("IdDonVi")]
        [InverseProperty("TblBaiViets")]
        public virtual TblDonViCauHinh? IdDonViNavigation { get; set; }
    }
}
