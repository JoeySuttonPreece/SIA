CREATE TABLE [dbo].[Label]
(
	[ClassID] INT NOT NULL,
	[Name] NVARCHAR(50),
	PRIMARY KEY (ClassID, Name),
	FOREIGN KEY (ClassID) REFERENCES [Class]
)
