CREATE TABLE [dbo].[Muzikant]
(
	[ID] INT NOT NULL PRIMARY KEY,
	[AdresID] int,
	[Emailadres] nchar(64) unique,
	[Telefoonnummer] int, 
    CONSTRAINT [FK_Muzikant_ToAdres] FOREIGN KEY ([AdresID]) REFERENCES [Adres]([ID])
)
