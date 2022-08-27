using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEB.Models
{
    [Table("tbl_Volume")]
    public partial class TblVolume
    {
        public TblVolume()
        {
            TblVolumeUploadAllows = new HashSet<TblVolumeUploadAllow>();
            TblVolumeUploadDenies = new HashSet<TblVolumeUploadDeny>();
        }

        [Key]
        [Column("ID_Volume")]
        public long IdVolume { get; set; }
        public bool UploadOverwrite { get; set; }
        public bool CopyOverwrite { get; set; }
        public bool IsShowOnly { get; set; }
        public bool IsReadOnly { get; set; }
        public bool IsLocked { get; set; }
        public int? MaxUploadFiles { get; set; }
        public int MaxUploadConnections { get; set; }
        public double? MaxUploadSize { get; set; }
        public double? MaxUploadSizeInKb { get; set; }
        public double? MaxUploadSizeInMb { get; set; }
        [StringLength(1)]
        [Unicode(false)]
        public string DirectorySeparatorChar { get; set; } = null!;
        public int ThumbnailSize { get; set; }
        public string StartDirectory { get; set; } = null!;
        public string ThumbUrl { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string VolumeId { get; set; } = null!;
        public string RootDirectory { get; set; } = null!;
        public string TempDirectory { get; set; } = null!;
        public string ThumbnailDirectory { get; set; } = null!;

        [InverseProperty("IdVolumeNavigation")]
        public virtual ICollection<TblVolumeUploadAllow> TblVolumeUploadAllows { get; set; }
        [InverseProperty("IdVolumeNavigation")]
        public virtual ICollection<TblVolumeUploadDeny> TblVolumeUploadDenies { get; set; }
    }
}
