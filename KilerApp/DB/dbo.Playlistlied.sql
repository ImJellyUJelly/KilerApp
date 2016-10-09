CREATE TABLE [dbo].[Playlistliedje]
(
	[ID] INT NOT NULL PRIMARY KEY,
	[LiedID] int,
	[PlaylistID] int, 
    CONSTRAINT [FK_Playlistliedje_ToLied] FOREIGN KEY ([LiedID]) REFERENCES [Lied]([ID]), 
    CONSTRAINT [FK_Playlistliedje_ToPlaylist] FOREIGN KEY ([PlaylistID]) REFERENCES [Playlist]([ID])
)
