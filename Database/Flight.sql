create database Flight 
use Flight

create table SANBAY 
(
	MaSanBay varchar(50),
	TenSanBay nvarchar(100),
	PRIMARY KEY (MaSanBay)
);
go

insert into SANBAY values ('TSN','Tân Sơn Nhất');
insert into SANBAY values ('NB','Nội Bài');
insert into SANBAY values ('PQ','Phú Quốc');
insert into SANBAY values ('DN','Đà Nẵng');
go

create table CHUYENBAY
(
	MaChuyenBay varchar(50),
	DonGia int,
	MaSanBayDen varchar(50),
	MaSanBayDi varchar(50),
	NgayGio datetime,
	ThoiGianBay time,
	PRIMARY KEY (MaChuyenBay),
	FOREIGN KEY (MaSanBayDen) REFERENCES SANBAY(MaSanBay),
	FOREIGN KEY (MaSanBayDi) REFERENCES SANBAY(MaSanBay)
);
go

insert into CHUYENBAY (MaChuyenBay,DonGia,MaSanBayDen,MaSanBayDi) values ('VJ001',500000,'TSN','NB');
insert into CHUYENBAY (MaChuyenBay,DonGia,MaSanBayDen,MaSanBayDi) values ('VJ002',400000,'NB','DN');
insert into CHUYENBAY (MaChuyenBay,DonGia,MaSanBayDen,MaSanBayDi) values ('VJ003',500000,'PQ','NB');
insert into CHUYENBAY (MaChuyenBay,DonGia,MaSanBayDen,MaSanBayDi) values ('VNAL241',650000,'TSN','PQ');
insert into CHUYENBAY (MaChuyenBay,DonGia,MaSanBayDen,MaSanBayDi) values ('VNAL248',550000,'DN','TSN');
insert into CHUYENBAY (MaChuyenBay,DonGia,MaSanBayDen,MaSanBayDi) values ('VNAL251',450000,'NB','DN');
insert into CHUYENBAY values ('VNAL224',300000,'NB','PQ','5/20/2020 06:00:00 PM', '2:00:00'); 

go
create table SANBAYTRUNGGIAN
(
	MaChuyenBay varchar(50),
	MaSanBay varchar(50),
	ThoiGianDung time,
	GhiChu nvarchar(255),
	PRIMARY KEY (MaChuyenBay, MaSanBay),
	FOREIGN KEY (MaChuyenBay) REFERENCES CHUYENBAY(MaChuyenBay),
	FOREIGN KEY (MaSanBay) REFERENCES SANBAY(MaSanBay)
);
go

insert into SANBAYTRUNGGIAN (MaChuyenBay,MaSanBay,GhiChu) values ('VJ001','DN','Sân bay trung gian 1');
insert into SANBAYTRUNGGIAN (MaChuyenBay,MaSanBay,GhiChu) values ('VJ001','PQ','Sân bay trung gian 2');
insert into SANBAYTRUNGGIAN (MaChuyenBay,MaSanBay,GhiChu) values ('VNAL241','DN','0:10:00','Sân bay trung gian 1');
go
--update SANBAYTRUNGGIAN set ThoiGianDung='0:10:00' where (MaChuyenBay = 'VNAL241') ; -- đã chạy

create table DANHSACHVE
(
	HangVe varchar(50),
	TiLe float,
	PRIMARY KEY (HangVe)
);
go
--delete from DANHSACHGHE 

insert into DANHSACHVE values ('Hang 1',1)
insert into DANHSACHVE values ('Hang 2',2)
go


create table DANHSACHGHE
(
	MaChuyenBay varchar(50),
	HangVe varchar(50),
	TongSoGhe int,
	SoGheTrong int,
	PRIMARY KEY (MaChuyenBay, HangVe),
	FOREIGN KEY (MaChuyenBay) REFERENCES CHUYENBAY(MaChuyenBay),
	FOREIGN KEY (HangVe) REFERENCES DANHSACHVE(HangVe)
);
go
--delete from DANHSACHGHE
insert into DANHSACHGHE values ('VJ001','Hang 1',20,20);
insert into DANHSACHGHE values ('VJ001','Hang 2',40,40);
insert into DANHSACHGHE values ('VJ002','Hang 1',30,30);
insert into DANHSACHGHE values ('VJ002','Hang 2',30,30);
insert into DANHSACHGHE values ('VNAL241','Hang 1',20,20);
insert into DANHSACHGHE values ('VNAL241','Hang 2',40,39);
go

create table PHIEUDATCHO
(
	MaPhieuDatCho varchar(50),
	MaChuyenBay varchar(50),
	HangVe varchar(50),
	GiaTien int,
	TrangThai bit,
	NgayHuy datetime,
	HoTen nvarchar(255),
	CMND varchar(10),
	SDT varchar(12)
	PRIMARY KEY (MaPhieuDatCho),
	FOREIGN KEY (MaChuyenBay)  REFERENCES CHUYENBAY(MaChuyenBay),
	FOREIGN KEY (HangVe) REFERENCES DANHSACHVE(HangVe)
);
go
--giá tiền bên code chèn vô hè ?
--delete from PHIEUDATCHO

insert into PHIEUDATCHO (MaPhieuDatCho,MaChuyenBay,HangVe,TrangThai,HoTen,CMND,SDT) 
values ('VNAL241.01','VNAL241','Hang 1',1,'Guyễn Đức Xun Lun','1852168','027438383838');
insert into PHIEUDATCHO (MaPhieuDatCho,MaChuyenBay,HangVe,TrangThai,HoTen,CMND,SDT) 
values ('VNAL241.02','VNAL241','Hang 2',0,'Guyễn Đức Xun Lun','1852168','027438383838');

create table VECHUYENBAY
(
	MaVeChuyenBay varchar(50),
	MaChuyenBay varchar(50),
	HangVe varchar(50),
	GiaTien int,
	HoTen nvarchar(255),
	CMND varchar(10),
	SDT varchar(12)
	PRIMARY KEY (MaVeChuyenBay),
	FOREIGN KEY (MaChuyenBay)  REFERENCES CHUYENBAY(MaChuyenBay),
	FOREIGN KEY (HangVe) REFERENCES DANHSACHVE(HangVe)
);
go

--delete from VECHUYENBAY
insert into VECHUYENBAY values ('VNAL241.01','VNAL241','Hạng 1',700000,'Guyễn Đức Xun Lun','1852168','027438383838');
go

create table BAOCAO
(
	MaBaoCao varchar(50),
	MaChuyenBay varchar(50),
	DoanhThu int,
	PRIMARY KEY (MaBaoCao),
	FOREIGN KEY (MaChuyenBay)  REFERENCES CHUYENBAY(MaChuyenBay)
);
go
delete from BAOCAO

go

create table THAMSO
(
	TenThamSo nvarchar(100),
	GiaTri int,
	PRIMARY KEY (TenThamSo)
);
go
--delete from THAMSO

insert into THAMSO values ('ThoiGianBayToiThieu',30); -- đơn vị phút
insert into THAMSO values ('SoSanBayTrungGianToiDa',2);
insert into THAMSO values ('ThoiGianDungToiThieu',10); -- đơn vị phút
insert into THAMSO values ('ThoiGianDungToiDa',20); -- đơn vị phút
insert into THAMSO values ('ThoiGianChoPhepDatVe',1);
insert into THAMSO values ('ChoPhepHuyVe',1 );
go
-- ??? D: ??? whể am ai? wat í thít?
create table CHUCNANG
(
	MaChucNang varchar(50),
	TenChucNang nvarchar(100),
	TenManHinhDuocLoad nvarchar(100),
	PRIMARY KEY (MaChucNang)
);
go
-- mấy cái ni XL tự phân nha 
create table NHOMNGUOIDUNG
(
	MaNhom varchar(50),
	TenNhom nvarchar(100),
	PRIMARY KEY (MaNhom)
);
go

create table NGUOIDUNG
(
	TenDangNhap varchar(50),
	MatKhau varchar(50),
	MaNhom varchar(50),
	PRIMARY KEY (TenDangNhap),
	FOREIGN KEY (MaNhom) REFERENCES NHOMNGUOIDUNG(MaNhom)
);
go

create table PHANQUYEN
(
	MaChucNang varchar(50),
	MaNhom varchar(50),
	PRIMARY KEY (MaChucNang, MaNhom),
	FOREIGN KEY (MaNhom) REFERENCES NHOMNGUOIDUNG(MaNhom),
	FOREIGN KEY (MaChucNang) REFERENCES CHUCNANG(MaChucNang)
);
go


 
