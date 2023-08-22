Create DataBase HUANTECH
GO
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
	UserUpdate varchar(10),
	TimeUpdate datetime default getdate()
)