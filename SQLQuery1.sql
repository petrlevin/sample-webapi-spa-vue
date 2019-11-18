CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	[DepartmentId] INT NOT NULL,
	[UserName] varchar(15) NOT NULL

)