USE DropTokenDB



CREATE TABLE [dbo].[Players] ( 
    [PlayerId] INT IDENTITY (1, 1) NOT NULL, 
    [FirstName] NVARCHAR (200) NULL, 
	 [Gender] NVARCHAR (200) NULL, 
	  [LastName] NVARCHAR (200) NULL, 
	   [Email] NVARCHAR (200) NULL, 
	    [Registerd] Datetime NOT NULL DEFAULT CURRENT_TIMESTAMP, 
     CONSTRAINT [PK_dbo.Players] PRIMARY KEY CLUSTERED ([PlayerId] ASC) 

); 
 
CREATE TABLE [dbo].[Games] ( 
    [GameId] INT IDENTITY (1, 1) NOT NULL, 
    [Player1] INT NOT NULL, 
	[Player2] INT NOT NULL, 
    [Status] NVARCHAR (50) NOT NULL DEFAULT 'InProgress'
	
    CONSTRAINT [PK_dbo.Games] PRIMARY KEY CLUSTERED ([GameId] ASC) 
	

   ); 



 
