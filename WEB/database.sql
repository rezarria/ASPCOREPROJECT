USE [master]

GO

CREATE DATABASE [Web]

GO

USE [Web]

GO

CREATE TABLE [tbl_BaiViet](
	[ID_BaiViet] [bigint] IDENTITY(1,1) NOT NULL,
	[ThucDon] [nvarchar](200) NULL,
	[TieuDe] [nvarchar](250) NULL,
	[TrichDan] [nvarchar](500) NULL,
	[NoiDung] [ntext] NULL,
	[HinhAnh] [nvarchar](800) NULL,
	[LienKet] [nvarchar](350) NULL,
	[TacGia] [nvarchar](100) NULL,
	[TrangThai] [int] NULL,
	[ThuTu] [int] NULL,
	[GhiChu] [nvarchar](150) NULL,
	[TrenCung] [int] NULL,
	[DuoiCung] [int] NULL,
	[BenTrai] [int] NULL,
	[BenPhai] [int] NULL,
	[NamGiua] [int] NULL,
	[TinNong] [int] NULL,
	[TrinhDien] [int] NULL,
	[TrangChu] [int] NULL,
	[NguoiTao] [bigint] NULL,
	[NgayTao] [datetime] NULL,
	[NguoiSua] [bigint] NULL,
	[NgaySua] [datetime] NULL,
	[NguoiDuyet] [bigint] NULL,
	[NgayDuyet] [datetime] NULL,
	[NguoiDang] [bigint] NULL,
	[NgayDang] [datetime] NULL,
	[NgonNgu] [int] NULL,
	[CacThe] [nvarchar](250) NULL,
	[LinhVuc] [nvarchar](50) NULL,
	[DiaDiem] [nvarchar](250) NULL,
	[ThoiGian] [nvarchar](50) NULL,
	[DonVi] [nvarchar](50) NULL,
	[NganhHoc] [nvarchar](50) NULL,
	[NamHoc] [int] NULL,
	[PhienBan] [nvarchar](50) NULL,
	[ID_DonVi] [bigint] NULL,
	[ID_ChuyenMuc] [bigint] NULL,
    CONSTRAINT [PK__BaiViet] PRIMARY KEY ([ID_BaiViet])
)

GO

CREATE TABLE [tbl_ChuyenMuc](
	[ID_ChuyenMuc] [bigint] IDENTITY(1,1) NOT NULL,
	[ID] [nvarchar](10) NOT NULL,
	[TiengViet] [nvarchar](200) NULL,
	[TiengAnh] [nvarchar](200) NULL,
	[CapBac] [int] NULL,
	[ThuocMuc] [nvarchar](10) NULL,
	[ThuTu] [int] NULL,
	[ChoPhepCapNhat] [int] NULL,
	[TrangThai_VN] [int] NULL,
	[TrangThai_EN] [int] NULL,
	[ViTri] [int] NULL,
	[Loai] [nvarchar](50) NULL,
	[LienKet] [nvarchar](350) NULL,
	[NgayTao] [datetime] NULL,
	[NguoiTao] [bigint] NULL,
	[NgaySua] [datetime] NULL,
	[NguoiSua] [bigint] NULL,
	[MoTa] [nvarchar](max) NULL,
	[GhiChu] [nvarchar](50) NULL,
	[BieuTuong] [nvarchar](50) NULL,
	[TrangChu] [int] NULL,
	[BenTrai] [int] NULL,
	[BenPhai] [int] NULL,
	[TrenCung] [int] NULL,
	[DuoiCung] [int] NULL,
	[GiuaTrang] [int] NULL,
	[SiteMap] [int] NULL,
	[MacDinh] [int] NULL,
	[HinhAnh] [nvarchar](350) NULL,
	[BaoGom] [nvarchar](200) NULL,
	[TrangMoi] [int] NULL,
	[ID_DonVi] [bigint] NULL,
    CONSTRAINT [PK_ChuyenMuc] PRIMARY KEY ([ID_ChuyenMuc])
)

GO

CREATE TABLE [tbl_DonVi_CauHinh](
	[ID_DonVi] [bigint] IDENTITY(1,1) NOT NULL,
	[TenDonVi] [nvarchar](250) NULL,
	[SubDomain] [nvarchar](250) NULL,
	[Email] [nvarchar](50) NULL,
	[DienThoai] [nvarchar](50) NULL,
	[Logo] [nvarchar](100) NULL,
	[DiaChi] [nvarchar](250) NULL,
	[TrangChu] [nvarchar](250) NULL,
	[NguoiQuanLy] [nvarchar](250) NULL,
	[BanQuyen] [nvarchar](250) NULL,
	[ID_DonViGoc] [int] NULL,
    CONSTRAINT [PK__DonVi_CauHinh] PRIMARY KEY ([ID_DonVi])
)

GO

CREATE TABLE [tbl_LienKetNgoai](
	[ID_LienKet] [bigint] IDENTITY(1,1) NOT NULL,
	[TenLienKet] [nvarchar](250) NULL,
	[LienKet] [nvarchar](250) NULL,
	[BieuTuong] [nvarchar](150) NULL,
	[MauNen] [nvarchar](50) NULL,
	[ID_DonVi] [bigint] NULL,
    PRIMARY KEY ([ID_LienKet])
)
GO
CREATE TABLE [tbl_TaiKhoan](
	[ID_TaiKhoan] [bigint] IDENTITY(1,1) NOT NULL,
	[HoVaTen] [nvarchar](255) NULL,
	[HinhAnh] [nvarchar](max) NULL,
	[NgaySinh] [datetime] NULL,
	[Email] [nvarchar](254) NULL,
	[MatKhau] [nvarchar](255) NULL,
	[Salt] [binary](16) NULL,
	[ThoiGianDangNhap] [datetime] NULL,
	[ThoiGianDangXuat] [datetime] NULL,
    CONSTRAINT [PK__TaiKhoan] PRIMARY KEY ([ID_TaiKhoan])
)

GO

ALTER TABLE [tbl_BaiViet]  WITH CHECK ADD  CONSTRAINT [FK__BaiViet__ChuyenMuc] FOREIGN KEY([ID_ChuyenMuc])
REFERENCES [tbl_ChuyenMuc] ([ID_ChuyenMuc])

GO

ALTER TABLE [tbl_BaiViet] CHECK CONSTRAINT [FK__BaiViet__ChuyenMuc]

GO

ALTER TABLE [tbl_BaiViet]  WITH CHECK ADD  CONSTRAINT [FK__BaiViet__DonVi_CauHinh] FOREIGN KEY([ID_DonVi])
REFERENCES [tbl_DonVi_CauHinh] ([ID_DonVi])

GO

ALTER TABLE [tbl_BaiViet] CHECK CONSTRAINT [FK__BaiViet__DonVi_CauHinh]

GO

ALTER TABLE [tbl_ChuyenMuc]  WITH CHECK ADD  CONSTRAINT [FK__DonVi_CauHinh] FOREIGN KEY([ID_DonVi])
REFERENCES [tbl_DonVi_CauHinh] ([ID_DonVi])

GO

ALTER TABLE [tbl_ChuyenMuc] CHECK CONSTRAINT [FK__DonVi_CauHinh]

GO

ALTER TABLE [tbl_LienKetNgoai]  WITH CHECK ADD FOREIGN KEY([ID_DonVi])
REFERENCES [tbl_DonVi_CauHinh] ([ID_DonVi])

GO

CREATE TABLE [dbo].[tbl_QuyenChuyenMuc](
	[ID_TaiKhoan] [bigint] NOT NULL,
	[ID_ChuyenMuc] [bigint] NOT NULL,
	[Ten] [nvarchar](255) NOT NULL,
	[TinhTrang] [bit] NOT NULL,
	[VietBai] [bit] NOT NULL,
	[DuyetBai] [bit] NOT NULL,
	[SuaBai] [bit] NOT NULL,
	[XoaBai] [bit] NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[tbl_QuyenChuyenMuc] ADD  CONSTRAINT [PK__QuyenChuyenMuc] PRIMARY KEY 
(
	[ID_TaiKhoan],
	[ID_ChuyenMuc]
)

GO

ALTER TABLE [dbo].[tbl_QuyenChuyenMuc] ADD  DEFAULT (N'Chưa đặt') FOR [Ten]
GO
ALTER TABLE [dbo].[tbl_QuyenChuyenMuc] ADD  DEFAULT ((0)) FOR [TinhTrang]
GO
ALTER TABLE [dbo].[tbl_QuyenChuyenMuc] ADD  DEFAULT ((0)) FOR [VietBai]
GO
ALTER TABLE [dbo].[tbl_QuyenChuyenMuc] ADD  DEFAULT ((0)) FOR [DuyetBai]
GO
ALTER TABLE [dbo].[tbl_QuyenChuyenMuc] ADD  DEFAULT ((0)) FOR [SuaBai]
GO
ALTER TABLE [dbo].[tbl_QuyenChuyenMuc] ADD  DEFAULT ((0)) FOR [XoaBai]
GO
ALTER TABLE [dbo].[tbl_QuyenChuyenMuc]  WITH CHECK ADD  CONSTRAINT [FK__QuyenChuyenMuc__ChuyenMuc] FOREIGN KEY([ID_ChuyenMuc])
REFERENCES [dbo].[tbl_ChuyenMuc] ([ID_ChuyenMuc])
GO
ALTER TABLE [dbo].[tbl_QuyenChuyenMuc] CHECK CONSTRAINT [FK__QuyenChuyenMuc__ChuyenMuc]
GO
ALTER TABLE [dbo].[tbl_QuyenChuyenMuc]  WITH CHECK ADD  CONSTRAINT [FK__QuyenChuyenMuc__TaiKhoan] FOREIGN KEY([ID_TaiKhoan])
REFERENCES [dbo].[tbl_TaiKhoan] ([ID_TaiKhoan])
GO
ALTER TABLE [dbo].[tbl_QuyenChuyenMuc] CHECK CONSTRAINT [FK__QuyenChuyenMuc__TaiKhoan]

GO

create table [tbl_VaiTro]
(
    [ID_VaiTro] bigint identity(1,1),
    [ID] varchar(255) not null,
    [Ten] nvarchar(255) null
    constraint [PK_VaiTro] primary key ([ID_VaiTro])
)

GO

CREATE TABLE [tbl_Tep] (
    [ID_Tep]   BIGINT         IDENTITY (1, 1) NOT NULL,
	[ID_Owner] BIGINT         NOT NULL,
    [DuongDan] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_tbl_Tep] PRIMARY KEY CLUSTERED ([ID_Tep] ASC),
	CONSTRAINT [FK_Tep__TaiKhoan] FOREIGN KEY ([ID_Owner]) REFERENCES [dbo].[tbl_TaiKhoan] ([ID_TaiKhoan])
);

GO

CREATE TABLE [tbl_TepTaiKhoan] (
    [ID_Tep]      BIGINT NOT NULL,
    [ID_TaiKhoan] BIGINT NOT NULL,
    [Read]        BIT    NOT NULL,
    [Write]       BIT    NOT NULL,
    [Locked]      BIT    NOT NULL,
	[Acess]      BIT    NOT NULL,
    [ShowOnly]    BIT    NOT NULL,
    [Visible]     BIT    NOT NULL,
    CONSTRAINT [PK_tbl_TepTaiKhoan] PRIMARY KEY CLUSTERED ([ID_Tep] ASC, [ID_TaiKhoan] ASC),
    CONSTRAINT [FK_TepTaikhoan__TaiKhoan] FOREIGN KEY ([ID_Tep]) REFERENCES [dbo].[tbl_TaiKhoan] ([ID_TaiKhoan]) ON DELETE CASCADE,
    CONSTRAINT [FK_TepTaiKhoan__Tep] FOREIGN KEY ([ID_Tep]) REFERENCES [dbo].[tbl_Tep] ([ID_Tep]) ON DELETE CASCADE
);

GO

CREATE TABLE [dbo].[tbl_Volume] (
    [ID_Volume]              BIGINT         IDENTITY (1, 1) NOT NULL,
    [UploadOverwrite]        BIT            NOT NULL,
    [CopyOverwrite]          BIT            NOT NULL,
    [IsShowOnly]             BIT            NOT NULL,
    [IsReadOnly]             BIT            NOT NULL,
    [IsLocked]               BIT            NOT NULL,
    [MaxUploadFiles]         INT            NULL,
    [MaxUploadConnections]   INT            NOT NULL,
    [MaxUploadSize]          FLOAT (53)     NULL,
    [MaxUploadSizeInKb]      FLOAT (53)     NULL,
    [MaxUploadSizeInMb]      FLOAT (53)     NULL,
    [DirectorySeparatorChar] CHAR (1)       NOT NULL,
    [ThumbnailSize]          INT            NOT NULL,
    [StartDirectory]         NVARCHAR (MAX) NOT NULL,
    [ThumbUrl]               NVARCHAR (MAX) NOT NULL,
    [Name]                   NVARCHAR (MAX) NOT NULL,
    [VolumeId]               NVARCHAR (MAX) NOT NULL,
    [RootDirectory]          NVARCHAR (MAX) NOT NULL,
    [TempDirectory]          NVARCHAR (MAX) NOT NULL,
    [ThumbnailDirectory]     NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_tbl_Volume] PRIMARY KEY CLUSTERED ([ID_Volume] ASC)
);

GO

CREATE TABLE [dbo].[tbl_Volume__UploadAllow] (
    [ID_Volume__UploadAllow] BIGINT         IDENTITY (1, 1) NOT NULL,
    [ID_Volume]              BIGINT         NOT NULL,
    [Value]                  NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_tbl_Volume__UploadAllow] PRIMARY KEY CLUSTERED ([ID_Volume__UploadAllow] ASC),
    CONSTRAINT [FK_Volume__UploadAllow] FOREIGN KEY ([ID_Volume]) REFERENCES [dbo].[tbl_Volume] ([ID_Volume]) ON DELETE CASCADE
);

GO

CREATE TABLE [dbo].[tbl_Volume__UploadDeny] (
    [ID_Volume__UploadDeny] BIGINT         IDENTITY (1, 1) NOT NULL,
    [ID_Volume]             BIGINT         NOT NULL,
    [Value]                 NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_tbl_Volume__UploadDeny] PRIMARY KEY CLUSTERED ([ID_Volume__UploadDeny] ASC),
    CONSTRAINT [FK_Volume__UploadDeny] FOREIGN KEY ([ID_Volume]) REFERENCES [dbo].[tbl_Volume] ([ID_Volume]) ON DELETE CASCADE
);

GO