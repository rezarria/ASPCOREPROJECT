using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEB.Models
{
    [Table("tbl_TaiKhoan")]
    public partial class TblTaiKhoan
    {
        public TblTaiKhoan()
        {
            TblQuyenChuyenMucs = new HashSet<TblQuyenChuyenMuc>();
            TblTepTaiKhoans = new HashSet<TblTepTaiKhoan>();
            TblTeps = new HashSet<TblTep>();
        }

        [Key]
        [Column("ID_TaiKhoan")]
        public long IdTaiKhoan { get; set; }
        [StringLength(255)]
        public string? HoVaTen { get; set; }
        public string? HinhAnh { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgaySinh { get; set; }
        [StringLength(254)]
        public string? Email { get; set; }
        [StringLength(255)]
        public string? MatKhau { get; set; }
        [MaxLength(16)]
        public byte[]? Salt { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ThoiGianDangNhap { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ThoiGianDangXuat { get; set; }

        [InverseProperty("IdTaiKhoanNavigation")]
        public virtual ICollection<TblQuyenChuyenMuc> TblQuyenChuyenMucs { get; set; }
        [InverseProperty("IdTepNavigation")]
        public virtual ICollection<TblTepTaiKhoan> TblTepTaiKhoans { get; set; }
        [InverseProperty("IdOwnerNavigation")]
        public virtual ICollection<TblTep> TblTeps { get; set; }
    }
}
