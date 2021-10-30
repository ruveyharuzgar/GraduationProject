CREATE TABLE Magnets(
	Id int PRIMARY KEY IDENTITY(1,1),
	CategoryId int,
	ColorId int,
	Price decimal,
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