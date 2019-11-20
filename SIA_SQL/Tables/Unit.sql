CREATE TABLE [dbo].[Unit]
(
	[ClusterID] INT NOT NULL,
	[Code] NVARCHAR(100) NOT NULL,
	PRIMARY KEY (ClusterID, Code),
	FOREIGN KEY (ClusterID) REFERENCES Cluster
)
