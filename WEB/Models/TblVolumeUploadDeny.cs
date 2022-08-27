using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEB.Models
{
    [Table("tbl_Volume__UploadDeny")]
    public partial class TblVolumeUploadDeny
    {
        [Key]
        [Column("ID_Volume__UploadDeny")]
        public long IdVolumeUploadDeny { get; set; }
        [Column("ID_Volume")]
        public long IdVolume { get; set; }
        public string Value { get; set; } = null!;

        [ForeignKey("IdVolume")]
        [InverseProperty("TblVolumeUploadDenies")]
        public virtual TblVolume IdVolumeNavigation { get; set; } = null!;
    }
}
