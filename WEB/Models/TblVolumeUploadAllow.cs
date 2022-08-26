using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WEB.Models
{
    [Table("tbl_Volume__UploadAllow")]
    public partial class TblVolumeUploadAllow
    {
        [Key]
        [Column("ID_Volume__UploadAllow")]
        public long IdVolumeUploadAllow { get; set; }
        [Column("ID_Volume")]
        public long IdVolume { get; set; }
        public string Value { get; set; } = null!;

        [ForeignKey("IdVolume")]
        [InverseProperty("TblVolumeUploadAllows")]
        public virtual TblVolume IdVolumeNavigation { get; set; } = null!;
    }
}
