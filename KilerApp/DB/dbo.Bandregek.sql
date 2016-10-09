CREATE TABLE [dbo].[Bandregel]
(
	[ID] INT NOT NULL PRIMARY KEY,
	[MuzikantID] int,
	[BandID] int, 
    CONSTRAINT [FK_Bandregel_ToMuzikant] FOREIGN KEY ([MuzikantID]) REFERENCES [Muzikant]([ID]), 
    CONSTRAINT [FK_Bandregel_ToBand] FOREIGN KEY ([BandID]) REFERENCES [Band]([ID])
)
