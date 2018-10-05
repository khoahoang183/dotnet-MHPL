use master
go
create database QLVS
go
use QLVS
go
create table VeSo
(
	MaVS int IDENTITY,
	Tinh nvarchar(100),
	Thu varchar(20),
	primary key (MaVS)
)
go
create table DaiLy
(
	MaDL int IDENTITY,
	Ten nvarchar(100),
	DiaChi nvarchar(100),
	DienThoai nvarchar(20),
	primary key(MaDL),
)
go
create table PhanPhoi
(
	MaPP int IDENTITY,
	MaVS int,
	MaDL int,
	Ngay Date,
	SLGiao int,
	SLBan int,	
	primary key(MaPP)
)
go
create table SoLuongDangKy
(
	MaSLDK int IDENTITY(1,1),
	MaDL int,
	Ngay Date,
	SLDangKy int,	
	primary key(MaSLDK)
)
go
alter table PhanPhoi
add constraint FK_PhanPhoi_VeSo
foreign key (MaVS)
references VeSo(MaVS)
go
alter table PhanPhoi
add constraint FK_PhanPhoi_DaiLy
foreign key (MaDL)
references DaiLy(MaDL)
go
alter table SoLuongDangKy
add constraint FK_SoLuongDangKy_DaiLy
foreign key (MaDL)
references DaiLy(MaDL)
go
insert into VeSo(Tinh,Thu)
values(N'Bình Dương',N'hai'),
		(N'Long An',N'ba'),
		(N'TPHCM',N'tư'),
		(N'Cần Thơ',N'sáu'),
		(N'Đồng Tháp',N'tư')
go
insert into DaiLy(Ten,DiaChi,DienThoai)
values (N'Đại Lý 1',N'123 đường abc TPHCM','01254897541'),
	   (N'Đại Lý 2',N'456 đường efg TPHCM','01253213212'),
	   (N'Đại Lý 3',N'789 đường hij TPHCM','01245678688')
go	   
insert into PhanPhoi(MaVS,MaDL,Ngay,SLGiao,SLBan)
values (1,1,'20180101',100,90),
	   (5,2,'20180101',100,60),
	   (4,3,'20180101',100,70)

