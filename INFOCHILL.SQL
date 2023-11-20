SET DATEFORMAT YMD

/*dropear bd*/
if db_id('INFOCHILL') is not null
	begin
		use master
		drop database INFOCHILL
	end

/*crear*/
CREATE DATABASE INFOCHILL
GO

/*usar*/

USE INFOCHILL
go


/*crear tabla usuario*/
CREATE   TABLE TB_USUARIO(
codUsu int primary key identity(1,1), 
idUsu VARCHAR(20) not null,
contraUsu VARCHAR(20) not null,
nomCli VARCHAR(30) NULL,
apeCli VARCHAR(30) NULL,
dniCli CHAR(8) NULL,
tlfCli CHAR(9) NOT NULL,
correoCli CHAR(100) NULL,
estado char(10) NULL CHECK (estado IN('ACTIVO','RETIRADO'))
)

select*from TB_USUARIO



/*crear tabla admin*/
CREATE TABLE TB_ADMIN(
idAdmin int primary key identity(1,1) not null,
codAdmin varchar(10) not null,
passAdmin varchar(20) not null
)
select*from TB_ADMIN
insert into TB_ADMIN values('ziahra','12345')
insert into TB_ADMIN values('esteban','joel')
insert into TB_ADMIN values('admin','123')


/*crear tabla proveedor*/
CREATE TABLE TB_PROVEEDOR  (
codProveedor int primary key identity(1,1) not null,
razSocial VARCHAR(80)NOT NULL,
dirProveedor VARCHAR(100)NOT NULL,
tlfProveedor CHAR(15) NULL,
repVenta VARCHAR(80) NOT NULL
)
select*from TB_PROVEEDOR


/*crear tabla producto*/
CREATE TABLE  TB_PRODUCTO(
idPro int primary key identity(1,1) not null,
desPro  VARCHAR(50)NOT NULL,
prePro MONEY NOT NULL,
stkAct INT NOT NULL,
stkMin INT NOT NULL,
catePro VARCHAR(50) NULL CHECK (catePro IN ('Bebidas','Snacks','Postres','Fast Food')),
)

SELECT*FROM TB_PRODUCTO
insert into TB_PRODUCTO values('Agua','2','200','50','Bebidas')
insert into TB_PRODUCTO values('Keke','2.50','150','50','Snacks')
insert into TB_PRODUCTO values('Frugos del Valle','2','100','50','Bebidas')


Create table TB_FACTURA(
idFac int primary key identity(1,1) not null,
codUsu int NOT NULL  REFERENCES TB_USUARIO,
fechaReg date not null
)
drop table TB_FACTURA
drop table TB_DETALLE_FACTURA


CREATE TABLE  TB_DETALLE_FACTURA(
idFac int not null REFERENCES TB_FACTURA,
idDet int primary key identity(1,1) not null,
idPro INT NOT NULL REFERENCES TB_PRODUCTO,
CAN_VEN INT NOT NULL, 
PRE_VEN money not null
)

SELECT*FROM TB_FACTURA
SELECT*FROM TB_DETALLE_FACTURA