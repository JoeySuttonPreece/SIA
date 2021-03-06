﻿CREATE TABLE [dbo].[Scan]
(
	[Barcode] NVARCHAR(11) NOT NULL,
	[DateTime] DATETIME NOT NULL,
	[ClassID] INT NOT NULL,
	[Lat] DECIMAL(9, 6) NOT NULL,
	[Long] DECIMAL(9, 6) NOT NULL,
	PRIMARY KEY (Barcode, DateTime),
	FOREIGN KEY (ClassID) REFERENCES [Class],
	FOREIGN KEY (Barcode) REFERENCES Student
)
