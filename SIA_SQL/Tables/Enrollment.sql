CREATE TABLE [dbo].[Enrollment]
(
	[ClassID] INT NOT NULL,
	[Barcode] NVARCHAR(11),
	PRIMARY KEY (ClassID, Barcode),
	FOREIGN KEY (ClassID) REFERENCES [Class],
	FOREIGN KEY (Barcode) REFERENCES Student
)
