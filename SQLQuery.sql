Create DataBase HUANTECH
GO
use HUANTECH
Go
Create table export_stock
(
	ExportId int identity(0,1) primary key,	
	ExportStatus int default 0, -- Hàng trả về là 1 mặc định là 0
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
	BillStatus int,
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
	CommodityId int,	--ID hàng
	ImportFrom nvarchar(200),
	ImportQuantity int,
	ImportPrice decimal(10,2),
	ImportStatus int default 0,
	UserImport varchar(10),
	TimeUpdate datetime default getdate()
)
Go

Create PROC USP_GetOrCreateBillId
AS
BEGIN
    BEGIN TRANSACTION;

    DECLARE @ExistingBillId INT;
    
    -- Kiểm tra xem có Bill nào có BillStatus = 0 hay không
    SELECT TOP 1 @ExistingBillId = BillId
    FROM bill WITH (UPDLOCK, HOLDLOCK) -- Lock dòng để tránh xung đột
    WHERE BillStatus = 0;

    -- Nếu không có Bill nào có BillStatus = 0, tạo một Bill mới và trả về BillId
    IF @ExistingBillId IS NULL
    BEGIN
        INSERT INTO bill (BillStatus,TotalCost)
        VALUES (0,0);
        SET @ExistingBillId = SCOPE_IDENTITY();
    END;

    -- Hoàn thành transaction
    COMMIT TRANSACTION;

    -- Trả về BillId tìm thấy hoặc mới tạo
    SELECT @ExistingBillId AS BillId;
END;
Go

Create PROC USP_UseBillId(@BillId int)
AS
BEGIN
    BEGIN TRANSACTION;

	DECLARE @BillStatus int;
    
    -- Kiểm tra xem có Bill nào có BillStatus = 0 hay không
    SELECT TOP 1 @BillStatus = BillStatus
    FROM bill WITH (UPDLOCK, HOLDLOCK) -- Lock dòng để tránh xung đột
    WHERE BillId = @BillId;
	
	IF @BillStatus = 0
	BEGIN
		UPDATE bill SET BillStatus = 1 WHERE BillId = @BillId;
		SELECT * FROM bill WHERE BillId = @BillId;
		COMMIT;
	END
	ELSE 
	BEGIN
		ROLLBACK;
		RETURN NULL;
	END;
END;

Go

Create PROC USP_AddCart 
(@BillId int, @CommodityId int, @Unitprice decimal(10,2), @Quantity int,@Note nvarchar(200))
AS
BEGIN
	BEGIN TRANSACTION
		DECLARE @CompateStock int;
		Select @CompateStock = StockQuantity From commodity WITH (UPDLOCK, HOLDLOCK) Where CommodityId = @CommodityId;
		if @CompateStock >= @Quantity
			BEGIN
				Insert Into [export_stock] ([BillId],[CommodityId],[UnitPrice],[Quantity],[Note]) Values ( @BillId , @CommodityId , @UnitPrice , @Quantity , @Note );
				Update commodity Set StockQuantity = StockQuantity - @Quantity Where CommodityId = @CommodityId;
				Update bill Set TotalCost = TotalCost + (@Quantity * @Unitprice) Where BillId = @BillId;
				COMMIT;
			END
		else
			ROLLBACK; 
END
Go