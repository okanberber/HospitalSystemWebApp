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

CONSTRAINT pk_Yonetici PRIMARY KEY (ID)
)
GO
INSERT INTO Yoneticiler(Isim,Soyisim,TelNo,Mail,Sifre) 
VALUES('Okan','Berber','5355271723','okan.berber@outlook.com.tr','1234')
GO
CREATE TABLE Doktorlar(
ID int IDENTITY(1,1),
Isim nvarchar(50),
Soyisim nvarchar(50),
Alani nvarchar(50),
TelNo nvarchar(15),
Mail nvarchar(50),
Sifre nvarchar(50),

CONSTRAINT pk_Doktor PRIMARY KEY (ID),
)
GO
INSERT INTO Doktorlar (Isim,Soyisim,Alani,TelNo,Mail,Sifre) VALUES('okan','berber','kardioloji','5355271723','okan.berber@outlook.com.tr','1234')
GO
CREATE TABLE Eczacilar(
ID int IDENTITY(1,1),
Isim nvarchar(50),
Soyisim nvarchar(50),
Mail nvarchar(50),
Sifre nvarchar(50),

CONSTRAINT pk_Eczaci PRIMARY KEY(ID),
)
GO
INSERT INTO Eczacilar (Isim,Soyisim,Mail,Sifre) VALUES('okan','berber','okan.berber@outlook.com.tr','1234')
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
INSERT INTO Ilaclar (Isim,SKT,Adet,BirimFiyat) VALUES ('ASPIRIN','20.02.2025',200,3)
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
INSERT INTO Receteler (IlaclarID,Isim,OlusturmaTarihi) VALUES(1,'1234','07.10.2024')
GO
CREATE TABLE Hastalar(
ID int IDENTITY(1,1),
ReceteID int,
Isim nvarchar(50),
Soyisim nvarchar(50),
TCK nvarchar(11),
TelNo nvarchar(15),
Sikayet nvarchar(200),
Teshis nvarchar(50),
Tarih DateTime,
CONSTRAINT pk_Hasta PRIMARY KEY (ID),
CONSTRAINT fk_Recete FOREIGN KEY (ReceteID) REFERENCES Receteler(ID),
)
GO
INSERT INTO Hastalar (ReceteID,Isim,Soyisim,TCK,TelNo,Sikayet,Teshis,Tarih) VALUES(1,'okan','berber','12345678901','5355271723','baþ aðrýsý','grip','07.10.2024')