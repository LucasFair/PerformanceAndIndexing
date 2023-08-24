--CREATE DATABASE performanceDB;
--GO

USE performanceDB;
GO

DROP TABLE tblRandom;
GO


CREATE TABLE tblRandom (
perfID int IDENTITY(1, 1) NOT NULL PRIMARY KEY,
perfRndNum int NOT NULL
);
GO



BULK INSERT tblRandom
FROM 'C:\Users\Fair\Documents\SQL\Output\RandomNumbersListNEW.txt'
WITH (
FIRSTROW = 0,
FIELDTERMINATOR = '\n',
ROWTERMINATOR = '\n'
);



SELECT *
FROM tblRandom;
