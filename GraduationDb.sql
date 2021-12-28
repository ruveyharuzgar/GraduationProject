CREATE TABLE Magnets(
	Id int PRIMARY KEY IDENTITY(1,1),
	CategoryId int,
	ColorId int,
	UnitPrice decimal,
	Quantity int,
	Description nvarchar(25),
	Text nvarchar(25)
	FOREIGN KEY (ColorId) REFERENCES Colors(ColorId),
	FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId) 
)
CREATE TABLE Categories(
	CategoryId int PRIMARY KEY IDENTITY(1,1),
	CategoryName nvarchar(25),
)
CREATE TABLE Colors(
	ColorId int PRIMARY KEY IDENTITY(1,1),
	ColorName nvarchar(25),
)

/*CREATE TABLE Users(
	Id int PRIMARY KEY IDENTITY(1,1),
	FirstName nvarchar(50),
	LastName nvarchar(50),
	Email nvarchar(50),
	Password nvarchar(50)
)
*/
CREATE TABLE Customers(
	Id int PRIMARY KEY IDENTITY(1,1),
	UserId int,
	CompanyName nvarchar(50),
	FOREIGN KEY (UserId) REFERENCES Users(Id)
)
CREATE TABLE Orders(
	Id int PRIMARY KEY IDENTITY(1,1),
	MagnetId int,
	CustomerId int,
	OrderDate datetime,
	ShippedDate datetime,
	FOREIGN KEY (MagnetId) REFERENCES Magnets(Id),
	FOREIGN KEY (CustomerId) REFERENCES Customers(Id)
)

CREATE TABLE MagnetImages(
	Id int PRIMARY KEY IDENTITY(1,1),
	MagnetId int,
	ImagePath nvarchar(MAX),
	Date datetime,
	FOREIGN KEY (MagnetId) REFERENCES Magnets(Id),
)
//T-SQL
CREATE TABLE [dbo].[Users]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] VARCHAR(50) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
    [Email] VARCHAR(50) NOT NULL, 
    [PasswordHash] VARBINARY(500) NOT NULL, 
    [PasswordSalt] VARBINARY(500) NOT NULL, 
    [Status] BIT NOT NULL
)

CREATE TABLE [dbo].[OperationClaims]
(   
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(250) NOT NULL
)

CREATE TABLE [dbo].[UserOperationClaims]
(
    [Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL, 
    [OperationClaimId] INT NOT NULL
)
