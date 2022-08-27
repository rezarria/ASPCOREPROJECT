using Microsoft.EntityFrameworkCore;

namespace WEB.Models
{
    public partial class WebContext : DbContext
    {
        public WebContext()
        {
        }

        public WebContext(DbContextOptions<WebContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblBaiViet> TblBaiViets { get; set; } = null!;
        public virtual DbSet<TblChuyenMuc> TblChuyenMucs { get; set; } = null!;
        public virtual DbSet<TblDonViCauHinh> TblDonViCauHinhs { get; set; } = null!;
        public virtual DbSet<TblLienKetNgoai> TblLienKetNgoais { get; set; } = null!;
        public virtual DbSet<TblQuyenChuyenMuc> TblQuyenChuyenMucs { get; set; } = null!;
        public virtual DbSet<TblTaiKhoan> TblTaiKhoans { get; set; } = null!;
        public virtual DbSet<TblTep> TblTeps { get; set; } = null!;
        public virtual DbSet<TblTepTaiKhoan> TblTepTaiKhoans { get; set; } = null!;
        public virtual DbSet<TblVaiTro> TblVaiTros { get; set; } = null!;
        public virtual DbSet<TblVolume> TblVolumes { get; set; } = null!;
        public virtual DbSet<TblVolumeUploadAllow> TblVolumeUploadAllows { get; set; } = null!;
        public virtual DbSet<TblVolumeUploadDeny> TblVolumeUploadDenies { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=127.0.0.1;user id=sa;password=Qw123456;encrypt=false;database=Web;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblBaiViet>(entity =>
            {
                entity.HasKey(e => e.IdBaiViet)
                    .HasName("PK__BaiViet");

                entity.HasOne(d => d.IdChuyenMucNavigation)
                    .WithMany(p => p.TblBaiViets)
                    .HasForeignKey(d => d.IdChuyenMuc)
                    .HasConstraintName("FK__BaiViet__ChuyenMuc");

                entity.HasOne(d => d.IdDonViNavigation)
                    .WithMany(p => p.TblBaiViets)
                    .HasForeignKey(d => d.IdDonVi)
                    .HasConstraintName("FK__BaiViet__DonVi_CauHinh");
            });

            modelBuilder.Entity<TblChuyenMuc>(entity =>
            {
                entity.HasKey(e => e.IdChuyenMuc)
                    .HasName("PK_ChuyenMuc");

                entity.HasOne(d => d.IdDonViNavigation)
                    .WithMany(p => p.TblChuyenMucs)
                    .HasForeignKey(d => d.IdDonVi)
                    .HasConstraintName("FK__DonVi_CauHinh");
            });

            modelBuilder.Entity<TblDonViCauHinh>(entity =>
            {
                entity.HasKey(e => e.IdDonVi)
                    .HasName("PK__DonVi_CauHinh");
            });

            modelBuilder.Entity<TblLienKetNgoai>(entity =>
            {
                entity.HasKey(e => e.IdLienKet)
                    .HasName("PK__tbl_Lien__D6F4067A07608928");

                entity.HasOne(d => d.IdDonViNavigation)
                    .WithMany(p => p.TblLienKetNgoais)
                    .HasForeignKey(d => d.IdDonVi)
                    .HasConstraintName("FK__tbl_LienK__ID_Do__2F10007B");
            });

            modelBuilder.Entity<TblQuyenChuyenMuc>(entity =>
            {
                entity.HasKey(e => new { e.IdTaiKhoan, e.IdChuyenMuc })
                    .HasName("PK__QuyenChuyenMuc");

                entity.Property(e => e.Ten).HasDefaultValueSql("(N'Chưa đặt')");

                entity.HasOne(d => d.IdChuyenMucNavigation)
                    .WithMany(p => p.TblQuyenChuyenMucs)
                    .HasForeignKey(d => d.IdChuyenMuc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__QuyenChuyenMuc__ChuyenMuc");

                entity.HasOne(d => d.IdTaiKhoanNavigation)
                    .WithMany(p => p.TblQuyenChuyenMucs)
                    .HasForeignKey(d => d.IdTaiKhoan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__QuyenChuyenMuc__TaiKhoan");
            });

            modelBuilder.Entity<TblTaiKhoan>(entity =>
            {
                entity.HasKey(e => e.IdTaiKhoan)
                    .HasName("PK__TaiKhoan");

                entity.Property(e => e.Salt).IsFixedLength();
            });

            modelBuilder.Entity<TblTep>(entity =>
            {
                entity.HasOne(d => d.IdOwnerNavigation)
                    .WithMany(p => p.TblTeps)
                    .HasForeignKey(d => d.IdOwner)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tep__TaiKhoan");
            });

            modelBuilder.Entity<TblTepTaiKhoan>(entity =>
            {
                entity.HasKey(e => new { e.IdTep, e.IdTaiKhoan });

                entity.HasOne(d => d.IdTepNavigation)
                    .WithMany(p => p.TblTepTaiKhoans)
                    .HasForeignKey(d => d.IdTep)
                    .HasConstraintName("FK_TepTaikhoan__TaiKhoan");

                entity.HasOne(d => d.IdTep1)
                    .WithMany(p => p.TblTepTaiKhoans)
                    .HasForeignKey(d => d.IdTep)
                    .HasConstraintName("FK_TepTaiKhoan__Tep");
            });

            modelBuilder.Entity<TblVaiTro>(entity =>
            {
                entity.HasKey(e => e.IdVaiTro)
                    .HasName("PK_VaiTro");
            });

            modelBuilder.Entity<TblVolume>(entity =>
            {
                entity.Property(e => e.DirectorySeparatorChar).IsFixedLength();
            });

            modelBuilder.Entity<TblVolumeUploadAllow>(entity =>
            {
                entity.HasOne(d => d.IdVolumeNavigation)
                    .WithMany(p => p.TblVolumeUploadAllows)
                    .HasForeignKey(d => d.IdVolume)
                    .HasConstraintName("FK_Volume__UploadAllow");
            });

            modelBuilder.Entity<TblVolumeUploadDeny>(entity =>
            {
                entity.HasOne(d => d.IdVolumeNavigation)
                    .WithMany(p => p.TblVolumeUploadDenies)
                    .HasForeignKey(d => d.IdVolume)
                    .HasConstraintName("FK_Volume__UploadDeny");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
