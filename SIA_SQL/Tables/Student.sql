﻿CREATE TABLE [dbo].[Student]
(
	[Barcode] NVARCHAR(11) NOT NULL,
	[Number] NVARCHAR(12) NOT NULL,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(100) NOT NULL,
	PRIMARY KEY (Barcode)
)
