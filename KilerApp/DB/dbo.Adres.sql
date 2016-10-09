CREATE TABLE [dbo].[Adres]
(
	[ID] INT NOT NULL PRIMARY KEY,
	[Straatnaam] nchar(64),
	[Huisnummer] int not null,
	[Postcode] nchar(64) not null,
	[Stad] nchar(64)
)
