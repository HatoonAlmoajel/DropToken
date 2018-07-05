USE DropTokenDB



ALTER TABLE [dbo].[Games]
ADD CONSTRAINT FK_Games_Players_PlayerId1
FOREIGN KEY (Player1)
REFERENCES Players(PlayerId)

ALTER TABLE [dbo].[Games]
ADD CONSTRAINT FK_Games_Players_PlayerId2
FOREIGN KEY (Player2)
REFERENCES Players(PlayerId)