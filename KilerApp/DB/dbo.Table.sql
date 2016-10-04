CREATE TABLE [dbo].[Lied]
(
	[LiedID] INT NOT NULL PRIMARY KEY,
	[Titel] NCHAR(64),
	[Duur] INT,
	[BandID] INT, 
    CONSTRAINT [FK_Lied_BandID] FOREIGN KEY ([BandID]) REFERENCES [Band]([BandID]) 
)