create database HR 
go
use HR
go 
create table Employee_2119110262(IdEmployee int,
Name nvarchar(255),
DateBirth DATE, 
Gender int ,
PlaceBirth nvarchar(50),
IdDepartment nvarchar(50),)
go
create table Department_2119110262(IdDepartment nvarchar(50),
Name nvarchar(255))
go
insert into Employee_2119110262 values (55618,'Tran Tiến','10/05/2001',1,'Ha Noi','IT')
insert into Employee_2119110262 values (55618,'Nguyễn Cường','11/07/1996',0,'Đắk Lắk','KT')
insert into Employee_2119110262 values (55617,'Nguyễn Hào','10/05/2001',1,'Ha Noi','KSNB')

insert into Department_2119110262 values ('IT','công nghệ thông tin')
insert into Department_2119110262 values ('KT','Kế Toán')
insert into Department_2119110262 values ('KSNB','kiểm soát nội bộ')
