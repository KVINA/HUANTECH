Create DataBase HUANTECH
GO
use HUANTECH
Go
Create table export_stock
(
	ExportId int identity(0,1) primary key,	
	BillId int,
	CommodityId int,
	UnitPrice decimal(10, 2) NULL,
	Quantity int,
	Note nvarchar(200),
)
Go
Create table bill
(
	BillId int identity(0,1) primary key,
	BillDate Date,
	Seller varchar(10),
	TotalCost decimal(10, 2),
	Customer nvarchar(200),
	Phone varchar(15),
	HomeAddress nvarchar(200),
	Email nvarchar(200),		
	TimeUpdate datetime default GetDate()
)
Go
Create table account
(
	SerialId int identity(0,1),
	Username varchar(10) primary key,
	Password nvarchar(50),
	Roles nvarchar(100),
	Status int default 0
)
Go
Create table commodity_group
(
	GroupId int identity(0,1) primary key,
	GroupName nvarchar(50),
	Description nvarchar(200),
	UserUpdate varchar(10),
	TimeUpdate datetime default getdate()
)
Go
Create table commodity
(
	CommodityId int IDENTITY(0,1),
	GroupId int NULL,
	CommodityName nvarchar(100) primary key,
	DescriptionCommodity nvarchar(200) NULL,
	CellingPrice decimal(10, 2) NULL,
	StockQuantity int NULL,
	Unit nvarchar(10),
	UserUpdate varchar(10),
	TimeUpdate datetime default getdate()
)
Go
Create table import_stock
(
	SerialID int identity (0,1) primary key, --
	ImportDate Date,
	CommodityId int,	--ID h�ng
	ImportFrom nvarchar(200),
	ImportQuantity int,
	ImportPrice decimal(10,2),
	ImportStatus int default 0,
	UserImport varchar(10),
	TimeUpdate datetime default getdate()
)