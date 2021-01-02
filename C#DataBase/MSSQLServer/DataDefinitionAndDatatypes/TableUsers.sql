-- Problem 8

USE Minions
-- START
CREATE TABLE Users(
	Id BIGINT PRIMARY KEY IDENTITY NOT NULL,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX) CHECK(DATALENGTH(ProfilePicture) <= 900 * 1024),
	LastLoginTime DATETIME2 NOT NULL,
	IsDelited BIT NOT NULL
)

INSERT INTO Users(Username, [Password], LastLoginTime, IsDelited)
VALUES
('Pesho', '123456', '05.19.2020', 0),
('Pesho1', '123456', '05.19.2020', 1),
('Pesho2', '123456', '05.19.2020', 0),
('Pesho3', '123456', '05.19.2020', 0),
('Pesho4', '123456', '05.19.2020', 1)

--END
SELECT * FROM Users

-- Problem 9

ALTER TABLE Users
DROP CONSTRAINT [PK__Users__3214EC075269AE13]

ALTER TABLE Users
ADD CONSTRAINT PK_Users_CompositeIdUsername
PRIMARY KEY(Id, Username)

--Problem 10

ALTER TABLE Users
ADD CONSTRAINT CK_Users_PasswordLenght
CHECK(LEN([Password]) >= 5)

-- Problem 11

ALTER TABLE Users
ADD CONSTRAINT DF_Users_LastLoginTime
DEFAULT GETDATE() FOR LastLoginTime

--Problem 12

ALTER TABLE Users
DROP CONSTRAINT [PK_Users_CompositeIdUsername]

ALTER TABLE Users
ADD CONSTRAINT PK_Users_Id
PRIMARY KEY(Id)

ALTER TABLE Users
ADD CONSTRAINT CK_Users_UsernameLenght
CHECK (LEN(Username) >= 3)