CREATE DATABASE HOSPITALSYSTEM_DB
GO
USE HOSPITALSYSTEM_DB
GO
CREATE TABLE Yoneticiler(
ID int IDENTITY(1,1),
Isim nvarchar(50),
Soyisim nvarchar(50),
TelNo nvarchar(15),
Mail nvarchar(50),
Sifre nvarchar(50),
Durum bit,
Silinmis bit,
CONSTRAINT pk_Yonetici PRIMARY KEY (ID)
)
GO
INSERT INTO Yoneticiler(Isim,Soyisim,TelNo,Mail,Sifre,Durum,Silinmis) 
VALUES('Okan','Berber','5355271723','okan.berber@outlook.com.tr','1234',1,0)
GO
CREATE TABLE Doktorlar(
ID int IDENTITY(1,1),
Isim nvarchar(50),
Soyisim nvarchar(50),
Alani nvarchar(50),
TelNo nvarchar(15),
Mail nvarchar(50),
Sifre nvarchar(50),
Durum bit,
Silinmis bit,
CONSTRAINT pk_Doktor PRIMARY KEY (ID),
)
GO
CREATE TABLE Hastaliklar(
ID INT IDENTITY(1,1),
Isim nvarchar(50),
CONSTRAINT pk_Hastalik PRIMARY KEY(ID),
)
GO
CREATE TABLE Eczacilar(
ID int IDENTITY(1,1),
Isim nvarchar(50),
Soyisim nvarchar(50),
Mail nvarchar(50),
Sifre nvarchar(50),
Durum bit,
Silinmis bit,
CONSTRAINT pk_Eczaci PRIMARY KEY(ID),
)
GO
CREATE TABLE Ilaclar(
ID int IDENTITY(1,1),
Isim nvarchar(50),
SKT nvarchar(20),
Adet int,
BirimFiyat int,
CONSTRAINT pk_Ilac PRIMARY KEY(ID),
)
GO
CREATE TABLE Receteler(
ID int IDENTITY(1,1),
IlaclarID int,
Isim nvarchar(50),
OlusturmaTarihi Datetime,
CONSTRAINT pk_Recete PRIMARY KEY(ID),
CONSTRAINT fk_Ilac FOREIGN KEY (IlaclarID) REFERENCES Ilaclar(ID),
)
GO
CREATE TABLE Hastalar(
ID int IDENTITY(1,1),
ReceteID int,
Isim nvarchar(50),
Soyisim nvarchar(50),
TCK nvarchar(11),
TelNo nvarchar(15),
Sikayet nvarchar,
Teshis nvarchar(50),
Tarih DateTime,
Durum bit,
Silinmis bit,
CONSTRAINT pk_Hasta PRIMARY KEY (ID),
CONSTRAINT fk_Recete FOREIGN KEY (ReceteID) REFERENCES Receteler(ID),
)