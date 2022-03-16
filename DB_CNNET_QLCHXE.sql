create database DB_CNNET_QLCHXE
go
use DB_CNNET_QLCHXE

create table QuanTriVien
(
	TenDangNhap varchar(50) not null,
	MatKhau varchar(50) not null,
	MaNV int unique,
	QuyenHan varchar(50),
	constraint PK_QuanTriVien primary key (TenDangNhap)
)

create table KhachHang
(
	MaKH int identity(1,1),
	TenKH nvarchar(50) not null,
	DiaChi nvarchar(100) not null,
	DienThoai varchar(10),
	Email varchar(50),
	constraint PK_KhachHang primary key (MaKH)
)

create table NhanVien
(
	MaNV int identity(1,1),
	TenNV nvarchar(50) not null,
	NgaySinh datetime not null,
	GioiTinh nvarchar(5) not null,
	DiaChi nvarchar(100) not null,
	DienThoai varchar(10),
	Email varchar(50),
	constraint PK_NhanVien primary key (MaNV)
)

create table NhaSanXuat
(
	MaNSX int identity(1,1),
	TenNSX nvarchar(50),	
	XuatXu nvarchar(50),
	constraint PK_NhaSanXuat primary key (MaNSX)
)

create table MatHang
(
	MaHang int identity(1,1), 
	TenHang nvarchar(100),
	MaNSX int,
	GiaBan int,
	TonKho int,
	HinhAnh varchar(100),
	constraint PK_MatHang primary key (MaHang)
)

create table HoaDonBan
(
	MaHD int identity(1,1),
	MaNV int,
	MaKH int,
	NgayBan datetime,
	TriGia int,
	TinhTrang nvarchar(50),
	constraint PK_HoaDonBan primary key (MaHD)
)

create table ChiTietHoaDonBan
(
	MaHD int,
	MaHang int,
	SoLuong int,
	ThanhTien float,
	constraint PK_ChiTietHoaDon primary key (MaHD, MaHang)
)

insert into QuanTriVien values
('ngocson', 'F2D136EA22A5B6E0ED0120A03AB795C2', 1, 'Admin'),
('triem', '9CBF8A4DCB8E30682B927F352D6559A0', 2, 'NhanVien')

set dateformat dmy
insert into NhanVien values
(N'Ngọc Sơn', '29/09/2001', N'Nam', N'TPHCM', '0123456789', 'ngocson@gmail.com'),
(N'Trí Em', '06/09/2001', N'Nam', N'TPHCM', '0123456789', 'triem@gmail.com')

insert into KhachHang values
(N'Văn A', N'TPHCM', '0912345678', 'a@gmail.com'),
(N'Văn B', N'Hà Nội', '0912345672', 'b@gmail.com'),
(N'Văn C', N'Huế', '0912345671', 'c@gmail.com'),
(N'Văn D', N'Đà Nẵng', '0912345670', 'd@gmail.com'),
(N'Văn E', N'TPHCM', '0912345679', 'e@gmail.com')

select * from KhachHang

insert into NhaSanXuat values
('Bugatti', N'Pháp'),
('Koenigsegg', N'Thụy Điển'),
('McLaren', N'Anh'),
('Ferrari', N'Ý'),
('Lamborghini', N'Ý')

insert into MatHang values
('Bugatti Divo', 1, 5400000, 15, 'bugatti_divo.jpg'),
('Bugatti La Voiture Noire', 1, 18900000, 5, 'Bugatti-La-Voiture-Noire.jpg'),
('Ferrari 488 Pista', 4, 350000, 10, 'ferrari488pista.jpg'),
('Ferrari FXX-K', 4, 2600000, 20, 'ferrari-fxx-k.jpg'),
('Koenigsegg Jesko', 2, 3800000, 25, 'koenigsegg-jesko.jpg'),
('Koenigsegg Regera', 2, 1900000, 30, 'koenigsegg-regera.jpg'),
('Lamborghini Centenario', 5, 1920000, 70, 'lamborghini-centenario.jpg'),
('Lamborghini Sian', 5, 2640000, 40, 'lamborghini-sian.jpg'),
('McLaren Senna', 3, 360000, 55, 'McLaren_Senna.jpg'),
('Mclaren 600LT', 3, 300000, 12, 'mclaren600lt.jpg')

alter table QuanTriVien
add constraint FK_QuanTriVien_NhanVien foreign key (MaNV) references NhanVien(MaNV)

alter table MatHang add 
constraint FK_MatHang_NSX foreign key (MaNSX) references NhaSanXuat(MaNSX)

alter table HoaDonBan add
constraint FK_HoaDonBan_NhanVien foreign key (MaNV) references NhanVien(MaNV),
constraint FK__HoaDonBan_KhachHang foreign key (MaKH) references KhachHang(MaKH)

alter table ChiTietHoaDonBan add
constraint FK_CTHDB_HoaDonBan foreign key (MaHD) references HoaDonBan(MaHD),
constraint FK_CTHDB_MatHang foreign key (MaHang) references MatHang(MaHang)

-- Trigger cập nhật số lượng mặt hàng tồn kho khi thêm/xoá/sửa một chi tiết hoá đơn bán
-- Bảng ChiTietHoaDonBan
-- Trigger khi thêm mới
create trigger TRIG_BanHang_CTHD on ChiTietHoaDonBan
for insert 
as
	begin
		update MatHang
		set TonKho = TonKho - (select SoLuong from inserted where MaHang = s.MaHang)
		from MatHang s join inserted 
		on s.MaHang = inserted.MaHang
	end
go

-- Trigger khi xoá
create trigger TRIG_HuyBan_CTHD on ChiTietHoaDonBan
for delete 
as
	begin
		update MatHang
		set TonKho = TonKho + (select SoLuong from deleted where deleted.MaHang = s.MaHang)
		from MatHang s join deleted 
		on s.MaHang = deleted.MaHang
	end
go

-- Trigger khi sửa
create trigger TRIG_CapNhatDonBan_CTHD on ChiTietHoaDonBan
for update 
as
	begin
		update MatHang
		set TonKho = TonKho + (select SoLuong from deleted where deleted.MaHang = s.MaHang) - (select SoLuong from inserted where MaHang = s.MaHang)
		from MatHang s join deleted 
		on s.MaHang = deleted.MaHang
	end
go

create trigger TRIG_CapNhatTriGiaHD_CTHD on ChiTietHoaDonBan
for insert 
as
	begin
		update HoaDonBan
		set TriGia = TriGia + inserted.ThanhTien
		from HoaDonBan s join inserted 
		on s.MaHD = inserted.MaHD
	end
go

create proc SP_DoanhThuTrongNgay 
@NgayBan varchar(20)
as
begin
	select h.TenHang, sum(SoLuong) as SoLuong, sum(ThanhTien) as ThanhTien
	from ChiTietHoaDonBan cthd, HoaDonBan hd, MatHang h
	where cthd.MaHD = hd.MaHD and cthd.MaHang = h.MaHang and cast(hd.NgayBan as date) = @NgayBan
	group by h.TenHang
end
go

create proc SP_HoaDonTrongNgay 
@NgayLap varchar(20)
as
begin
	select * from HoaDonBan 
	where cast(NgayBan as date) = @NgayLap
end
go

create proc SP_HoaDonTrongThang
@Thang varchar(20)
as
begin
	select * from HoaDonBan 
	where month(NgayBan) = @Thang
end
go