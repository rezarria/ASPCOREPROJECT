using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEB.Models
{
    [Table("tbl_TepTaiKhoan")]
    public partial class TblTepTaiKhoan
    {
        [Key]
        [Column("ID_Tep")]
        public long IdTep { get; set; }
        [Key]
        [Column("ID_TaiKhoan")]
        public long IdTaiKhoan { get; set; }
        public bool Read { get; set; }
        public bool Write { get; set; }
        public bool Locked { get; set; }
        public bool Acess { get; set; }
        public bool ShowOnly { get; set; }
        public bool Visible { get; set; }

        [ForeignKey("IdTep")]
        [InverseProperty("TblTepTaiKhoans")]
        public virtual TblTep IdTep1 { get; set; } = null!;
        [ForeignKey("IdTep")]
        [InverseProperty("TblTepTaiKhoans")]
        public virtual TblTaiKhoan IdTepNavigation { get; set; } = null!;
    }
}
