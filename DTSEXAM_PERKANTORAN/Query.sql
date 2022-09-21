--DATABASE
CREATE DATABASE ExamPerkantoran

--MOVE TO DATABASE
USE ExamPerkantoran

--TABLE
CREATE TABLE Karyawan (
	IdKaryawan int Primary Key Identity(1,1),
	NIK varchar (6) Unique,
	NamaKaryawan varchar (20) Not Null,
	Alamat varchar (50) Not Null,
	IdJabatan int Not Null
	);

CREATE TABLE Jabatan (
	IdJabatan int Primary Key,
	NamaJabatan Varchar (50)  Not Null,
	GajiPokok Numeric (18,0)  Not Null
	);

CREATE TABLE Absensi (
	IdAbsensi int Identity(1,1) Primary Key,
	IdKaryawan int  Not Null,
	JamMasuk datetime  Not Null,
	JamPulang datetime  Not Null
	);

CREATE TABLE Login (
	NIK varchar (6) Unique,
	Password varchar(20)  Not Null
	); 

--ADD FOREIGN KEY
alter table Karyawan add foreign key (IdJabatan) references Jabatan (IdJabatan);
alter table Karyawan add foreign key (NIK) references Login (NIK);
alter table Absensi add foreign key (IdKaryawan) references Karyawan (IdKaryawan);


--INSERT DATA

INSERT INTO Jabatan Values (111, 'CEO', 30000000);
INSERT INTO Jabatan Values (222, 'SENIOR MANAJER', 25000000);
INSERT INTO Jabatan Values (333, 'PROGRAMMER', 15000000);


INSERT INTO Login Values (130990, 'Admin');
INSERT INTO Login Values (230691, 'Admin');
INSERT INTO Login Values (011295, 'Admin');


INSERT INTO Karyawan (NIK, NamaKaryawan, Alamat, IdJabatan) Values (130990, 'Abdul', 'Jakarta', 111);
INSERT INTO Karyawan (NIK, NamaKaryawan, Alamat, IdJabatan) Values (230691, 'Kalid', 'Jakarta', 222);
INSERT INTO Karyawan (NIK, NamaKaryawan, Alamat, IdJabatan) Values (011295, 'Risqi', 'Jakarta', 333);

INSERT INTO Absensi Values (10, 08.00, 18.00);
INSERT INTO Absensi Values (20, 08.15, 18.30);
INSERT INTO Absensi Values (30, 08.07, 18.50);

--SELECT
select * from Jabatan
select * from Karyawan
select * from Absensi
select * from Login

--UPDATE
UPDATE Karyawan SET NamaKaryawan = 'Zulkifki', Alamat = 'Padang' Where IdKaryawan = 2
UPDATE Karyawan SET NamaKaryawan = 'MEGAWATI', Alamat = 'Yogyakarta' Where IdKaryawan = 3

--SELECT ORDER BY
select * from Karyawan order by IdKaryawan DESC;

--SELECT JOIN
select * From Karyawan Join Jabatan on Karyawan.IdJabatan = Jabatan.IdJabatan;