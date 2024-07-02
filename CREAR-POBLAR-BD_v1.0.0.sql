-- Verificar si la base de datos no existe y crearla
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'KPS-BlioNet')
BEGIN
    CREATE DATABASE "KPS-BlioNet";
END
GO

-- Cambiar el contexto a la base de datos recién creada
USE "KPS-BlioNet";
GO

-- Crear la tabla telefono con los campos numero y extension
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Books')
BEGIN
    CREATE TABLE Books (
		Id INT PRIMARY KEY IDENTITY(1,1),
		Title NVARCHAR(255) NOT NULL,
		Author NVARCHAR(255) NOT NULL,
		ISBN NVARCHAR(50) NOT NULL,
		AvailableCopies INT NOT NULL,
		Genre NVARCHAR(100),
		PublicationDate DATE
	);


	CREATE TABLE Users (
		Id INT PRIMARY KEY IDENTITY(1,1),
		UserName NVARCHAR(255) NOT NULL,
		Name NVARCHAR(255) NOT NULL,
		Email NVARCHAR(255) NOT NULL,
		Password NVARCHAR(255) NOT NULL,
		Address NVARCHAR(255)
	);


	CREATE TABLE Roles (
		Id INT PRIMARY KEY IDENTITY(1,1),
		RoleName NVARCHAR(100) NOT NULL,
		Description NVARCHAR(255)
	);


	CREATE TABLE UserRoles (
		UserId INT NOT NULL,
		RoleId INT NOT NULL,
		FOREIGN KEY (UserId) REFERENCES Users(Id),
		FOREIGN KEY (RoleId) REFERENCES Roles(Id),
		PRIMARY KEY (UserId, RoleId)
	);


	CREATE TABLE Loans (
		Id INT PRIMARY KEY IDENTITY(1,1),
		UserId INT NOT NULL,
		LoanDate DATETIME NOT NULL,
		ExpectedReturnDate DATETIME NOT NULL,
		ActualReturnDate DATETIME,
		Status NVARCHAR(50) NOT NULL, 
		FOREIGN KEY (UserId) REFERENCES Users(Id)
	);


	CREATE TABLE LoanBooks (
		LoanId INT NOT NULL,
		BookId INT NOT NULL,
		FOREIGN KEY (LoanId) REFERENCES Loans(Id),
		FOREIGN KEY (BookId) REFERENCES Books(Id),
		PRIMARY KEY (LoanId, BookId)
	);


	-- Insertar 5 usuarios 
	INSERT INTO Users (UserName, Name, Email, Password, Address)
    VALUES 
        ('juanperez', 'Juan Pérez', 'juanperez@example.com', 'contrasena123', 'Calle Principal 123, Ciudad de México'),
        ('mariagomez', 'María Gómez', 'mariagomez@example.com', 'contrasena123', 'Avenida Reforma 456, Ciudad de México'),
        ('carloslopez', 'Carlos López', 'carloslopez@example.com', 'contrasena123', 'Boulevard Insurgentes 789, Ciudad de México'),
        ('anagarcia', 'Ana García', 'anagarcia@example.com', 'contrasena123', 'Calle Juárez 101, Ciudad de México'),
        ('luisfernandez', 'Luis Fernández', 'luisfernandez@example.com', 'contrasena123', 'Calle Hidalgo 202, Ciudad de México');

	-- Insertar los roles
	INSERT INTO Roles (RoleName, Description) 
    VALUES 
        ('Admin', 'Administrador del sistema'),
        ('Librarian', 'Bibliotecario'),
        ('Member', 'Usuario registrado'),
        ('Guest', 'Invitado');

	-- Vincular los roles 
	INSERT INTO UserRoles (UserId, RoleId)
    VALUES 
        (1, 1),
        (1, 2),
        (2, 2),
        (3, 3),
        (4, 4),
        (5, 3);

	-- Insertar libros
	INSERT [dbo].[Books] ([Title], [Author], [ISBN], [AvailableCopies], [Genre], [PublicationDate]) 
	VALUES 
        (N'Cien años de soledad', N'Gabriel García Márquez', N'9786071131155', 3, N'Realismo mágico', CAST(N'2024-06-18' AS Date)),
        (N'El código Da Vinci', N'Dan Brown', N'0307474275', 2, N'Suspense', CAST(N'2024-06-22' AS Date)),
        (N'Orgullo y prejuicio', N'Jane Austen', N'9788491812925', 5, N'Romance clásico', CAST(N'2024-05-13' AS Date)),
        (N'1984', N'George Orwell', N'0451524934', 6, N'Distopía', CAST(N'2024-06-23' AS Date)),
        (N'Harry Potter y la piedra filosofal', N'J.K. Rowling', N'8478884459', 2, N'Fantasía', CAST(N'2024-06-11' AS Date)),
        (N'Los pilares de la Tierra', N'Ken Follett', N'0451225244', 3, N'Histórico', CAST(N'2024-06-10' AS Date));

END
GO
