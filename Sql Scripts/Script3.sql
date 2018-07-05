CREATE TABLE [dbo].[Moves] ( 
    [MoveId] INT IDENTITY (1, 1) NOT NULL,
    [Col] INT NOT NULL,
	

	[Result] NVARCHAR (50) DEFAULT 'InProgress' , 
	[TimeStamp] Datetime NOT NULL DEFAULT CURRENT_TIMESTAMP, 
    

	[PlayerId] INT NOT NULL,
	[GameId] INT NOT NULL
    CONSTRAINT [PK_dbo.Moves] PRIMARY KEY CLUSTERED ([MoveId] ASC), 
	
    CONSTRAINT [FK_dbo.Moves_dbo.Games_GameId] FOREIGN KEY ([GameId]) REFERENCES [dbo].[Games] ([GameId]) ON DELETE CASCADE ,

    CONSTRAINT [FK_dbo.Moves_dbo.Players_PlayerId] FOREIGN KEY ([PlayerId]) REFERENCES [dbo].[Players] ([PlayerId]) ON DELETE CASCADE,
	
	


	


); 
