USE [VideoGameStoreDB]
GO
/****** Object:  StoredProcedure [dbo].[GeneradorPuntajeRandom]    Script Date: 15/10/2024 10:20:02 a. m. ******/
DROP PROCEDURE [dbo].[GeneradorPuntajeRandom]
GO
ALTER TABLE [dbo].[Videojuegos] DROP CONSTRAINT [FK_Videojuegos_Usuarios]
GO
ALTER TABLE [dbo].[Calificaciones] DROP CONSTRAINT [FK_Calificaciones_Videojuegos]
GO
ALTER TABLE [dbo].[Calificaciones] DROP CONSTRAINT [FK_Calificaciones_Usuarios_Actualizacion]
GO
ALTER TABLE [dbo].[Calificaciones] DROP CONSTRAINT [FK_Calificaciones_Usuarios]
GO
ALTER TABLE [dbo].[Videojuegos] DROP CONSTRAINT [DF_Videojuego_FechaActualizacion]
GO
ALTER TABLE [dbo].[Videojuegos] DROP CONSTRAINT [DF_Videojuego_Puntaje]
GO
ALTER TABLE [dbo].[Usuarios] DROP CONSTRAINT [DF_Usuario_FechaCreacion]
GO
ALTER TABLE [dbo].[Calificaciones] DROP CONSTRAINT [DF_Calificaciones_FechaActualizacion]
GO
ALTER TABLE [dbo].[Calificaciones] DROP CONSTRAINT [DF_Calificaciones_Puntaje]
GO
/****** Object:  Table [dbo].[Videojuegos]    Script Date: 15/10/2024 10:20:02 a. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Videojuegos]') AND type in (N'U'))
DROP TABLE [dbo].[Videojuegos]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 15/10/2024 10:20:02 a. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Usuarios]') AND type in (N'U'))
DROP TABLE [dbo].[Usuarios]
GO
/****** Object:  Table [dbo].[Calificaciones]    Script Date: 15/10/2024 10:20:02 a. m. ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Calificaciones]') AND type in (N'U'))
DROP TABLE [dbo].[Calificaciones]
GO
USE [master]
GO
/****** Object:  Database [VideoGameStoreDB]    Script Date: 15/10/2024 10:20:02 a. m. ******/
DROP DATABASE [VideoGameStoreDB]
GO
/****** Object:  Database [VideoGameStoreDB]    Script Date: 15/10/2024 10:20:02 a. m. ******/
CREATE DATABASE [VideoGameStoreDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'VideoGameStoreDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\VideoGameStoreDB.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'VideoGameStoreDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\VideoGameStoreDB_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [VideoGameStoreDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [VideoGameStoreDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [VideoGameStoreDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [VideoGameStoreDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [VideoGameStoreDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [VideoGameStoreDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [VideoGameStoreDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [VideoGameStoreDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [VideoGameStoreDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [VideoGameStoreDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [VideoGameStoreDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [VideoGameStoreDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [VideoGameStoreDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [VideoGameStoreDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [VideoGameStoreDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [VideoGameStoreDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [VideoGameStoreDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [VideoGameStoreDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [VideoGameStoreDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [VideoGameStoreDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [VideoGameStoreDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [VideoGameStoreDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [VideoGameStoreDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [VideoGameStoreDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [VideoGameStoreDB] SET RECOVERY FULL 
GO
ALTER DATABASE [VideoGameStoreDB] SET  MULTI_USER 
GO
ALTER DATABASE [VideoGameStoreDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [VideoGameStoreDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [VideoGameStoreDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [VideoGameStoreDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [VideoGameStoreDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [VideoGameStoreDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'VideoGameStoreDB', N'ON'
GO
ALTER DATABASE [VideoGameStoreDB] SET QUERY_STORE = OFF
GO
USE [VideoGameStoreDB]
GO
/****** Object:  Table [dbo].[Calificaciones]    Script Date: 15/10/2024 10:20:02 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calificaciones](
	[Id] [uniqueidentifier] NOT NULL,
	[IdVideojuego] [int] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[Puntaje] [decimal](3, 2) NOT NULL,
	[FechaActualizacion] [datetime] NOT NULL,
	[IdUsuarioActualizacion] [int] NOT NULL,
 CONSTRAINT [PK_Calificaciones] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 15/10/2024 10:20:02 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [nvarchar](30) NOT NULL,
	[Email] [nvarchar](30) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
	[FechaModificacion] [datetime] NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Videojuegos]    Script Date: 15/10/2024 10:20:02 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Videojuegos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Compania] [nvarchar](50) NOT NULL,
	[AnioLanzamiento] [nvarchar](4) NOT NULL,
	[Precio] [money] NOT NULL,
	[Puntaje] [decimal](3, 2) NOT NULL,
	[FechaActualizacion] [datetime] NOT NULL,
	[IdUsuarioActualizacion] [int] NOT NULL,
 CONSTRAINT [PK_Videojuego] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([Id], [NombreUsuario], [Email], [Password], [FechaCreacion], [FechaModificacion]) VALUES (1, N'administrador', N'a@a.net', N'3b612c75a7b5048a435fb6ec81e52ff92d6d795a8b5a9c17070f6a63c97a53b2', CAST(N'2024-10-10T10:06:50.200' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
SET IDENTITY_INSERT [dbo].[Videojuegos] ON 

INSERT [dbo].[Videojuegos] ([Id], [Nombre], [Compania], [AnioLanzamiento], [Precio], [Puntaje], [FechaActualizacion], [IdUsuarioActualizacion]) VALUES (1, N'Dark Souls', N'From Software', N'2011', 39.9900, CAST(0.00 AS Decimal(3, 2)), CAST(N'2024-10-11T11:01:33.050' AS DateTime), 1)
INSERT [dbo].[Videojuegos] ([Id], [Nombre], [Compania], [AnioLanzamiento], [Precio], [Puntaje], [FechaActualizacion], [IdUsuarioActualizacion]) VALUES (2, N'Sekiro: Shadows Die Twice', N'From Software', N'2019', 59.9900, CAST(0.00 AS Decimal(3, 2)), CAST(N'2024-10-11T11:01:33.057' AS DateTime), 1)
INSERT [dbo].[Videojuegos] ([Id], [Nombre], [Compania], [AnioLanzamiento], [Precio], [Puntaje], [FechaActualizacion], [IdUsuarioActualizacion]) VALUES (3, N'Bloodborne', N'From Software', N'2015', 19.9900, CAST(0.00 AS Decimal(3, 2)), CAST(N'2024-10-11T11:01:33.057' AS DateTime), 1)
INSERT [dbo].[Videojuegos] ([Id], [Nombre], [Compania], [AnioLanzamiento], [Precio], [Puntaje], [FechaActualizacion], [IdUsuarioActualizacion]) VALUES (4, N'Demon''s Souls', N'From Software', N'2009', 39.9900, CAST(0.00 AS Decimal(3, 2)), CAST(N'2024-10-11T11:01:33.057' AS DateTime), 1)
INSERT [dbo].[Videojuegos] ([Id], [Nombre], [Compania], [AnioLanzamiento], [Precio], [Puntaje], [FechaActualizacion], [IdUsuarioActualizacion]) VALUES (5, N'Cuphead', N'StudioMDHR', N'2017', 19.9900, CAST(0.00 AS Decimal(3, 2)), CAST(N'2024-10-11T11:01:33.057' AS DateTime), 1)
INSERT [dbo].[Videojuegos] ([Id], [Nombre], [Compania], [AnioLanzamiento], [Precio], [Puntaje], [FechaActualizacion], [IdUsuarioActualizacion]) VALUES (6, N'Contra', N'Konami', N'1987', 6.9900, CAST(0.00 AS Decimal(3, 2)), CAST(N'2024-10-11T11:01:33.060' AS DateTime), 1)
INSERT [dbo].[Videojuegos] ([Id], [Nombre], [Compania], [AnioLanzamiento], [Precio], [Puntaje], [FechaActualizacion], [IdUsuarioActualizacion]) VALUES (7, N'Nioh', N'Koei Tecmo', N'2017', 19.9900, CAST(0.00 AS Decimal(3, 2)), CAST(N'2024-10-11T11:01:33.060' AS DateTime), 1)
INSERT [dbo].[Videojuegos] ([Id], [Nombre], [Compania], [AnioLanzamiento], [Precio], [Puntaje], [FechaActualizacion], [IdUsuarioActualizacion]) VALUES (8, N'Celeste', N'Extremely OK Games', N'2018', 7.9900, CAST(0.00 AS Decimal(3, 2)), CAST(N'2024-10-11T11:01:33.060' AS DateTime), 1)
INSERT [dbo].[Videojuegos] ([Id], [Nombre], [Compania], [AnioLanzamiento], [Precio], [Puntaje], [FechaActualizacion], [IdUsuarioActualizacion]) VALUES (9, N'Battletoads', N'Rare', N'1991', 5.9900, CAST(0.00 AS Decimal(3, 2)), CAST(N'2024-10-11T11:01:33.060' AS DateTime), 1)
INSERT [dbo].[Videojuegos] ([Id], [Nombre], [Compania], [AnioLanzamiento], [Precio], [Puntaje], [FechaActualizacion], [IdUsuarioActualizacion]) VALUES (10, N'Blasphemous', N'Team17', N'2019', 24.9900, CAST(0.00 AS Decimal(3, 2)), CAST(N'2024-10-11T11:01:33.060' AS DateTime), 1)
INSERT [dbo].[Videojuegos] ([Id], [Nombre], [Compania], [AnioLanzamiento], [Precio], [Puntaje], [FechaActualizacion], [IdUsuarioActualizacion]) VALUES (11, N'Teenage Mutant Ninja Turtles', N'Konami', N'1989', 12.9900, CAST(0.00 AS Decimal(3, 2)), CAST(N'2024-10-11T11:01:33.060' AS DateTime), 1)
INSERT [dbo].[Videojuegos] ([Id], [Nombre], [Compania], [AnioLanzamiento], [Precio], [Puntaje], [FechaActualizacion], [IdUsuarioActualizacion]) VALUES (12, N'Ninja Gaiden Black', N'Koei Tecmo', N'2005', 25.9900, CAST(0.00 AS Decimal(3, 2)), CAST(N'2024-10-11T11:01:33.060' AS DateTime), 1)
INSERT [dbo].[Videojuegos] ([Id], [Nombre], [Compania], [AnioLanzamiento], [Precio], [Puntaje], [FechaActualizacion], [IdUsuarioActualizacion]) VALUES (13, N'Ghosts ''n Goblins', N'Capcom', N'1985', 6.9900, CAST(0.00 AS Decimal(3, 2)), CAST(N'2024-10-11T11:01:33.060' AS DateTime), 1)
INSERT [dbo].[Videojuegos] ([Id], [Nombre], [Compania], [AnioLanzamiento], [Precio], [Puntaje], [FechaActualizacion], [IdUsuarioActualizacion]) VALUES (14, N'Salt and Sanctuary', N'Ska Studios', N'2016', 17.9900, CAST(0.00 AS Decimal(3, 2)), CAST(N'2024-10-11T11:01:33.060' AS DateTime), 1)
INSERT [dbo].[Videojuegos] ([Id], [Nombre], [Compania], [AnioLanzamiento], [Precio], [Puntaje], [FechaActualizacion], [IdUsuarioActualizacion]) VALUES (15, N'Dark Souls III', N'From Software', N'2016', 59.9900, CAST(0.00 AS Decimal(3, 2)), CAST(N'2024-10-11T11:01:33.063' AS DateTime), 1)
INSERT [dbo].[Videojuegos] ([Id], [Nombre], [Compania], [AnioLanzamiento], [Precio], [Puntaje], [FechaActualizacion], [IdUsuarioActualizacion]) VALUES (16, N'Super Meat Boy', N'Direct2Drive', N'2010', 5.9900, CAST(0.00 AS Decimal(3, 2)), CAST(N'2024-10-11T11:01:33.063' AS DateTime), 1)
INSERT [dbo].[Videojuegos] ([Id], [Nombre], [Compania], [AnioLanzamiento], [Precio], [Puntaje], [FechaActualizacion], [IdUsuarioActualizacion]) VALUES (17, N'Dark Souls II', N'From Software', N'2014', 39.9900, CAST(0.00 AS Decimal(3, 2)), CAST(N'2024-10-11T11:01:33.063' AS DateTime), 1)
INSERT [dbo].[Videojuegos] ([Id], [Nombre], [Compania], [AnioLanzamiento], [Precio], [Puntaje], [FechaActualizacion], [IdUsuarioActualizacion]) VALUES (18, N'Hollow Knight', N'Team Cherry', N'2017', 14.9900, CAST(0.00 AS Decimal(3, 2)), CAST(N'2024-10-11T11:01:33.063' AS DateTime), 1)
INSERT [dbo].[Videojuegos] ([Id], [Nombre], [Compania], [AnioLanzamiento], [Precio], [Puntaje], [FechaActualizacion], [IdUsuarioActualizacion]) VALUES (19, N'Super Mario Maker 2', N'Nintendo', N'2019', 59.9900, CAST(0.00 AS Decimal(3, 2)), CAST(N'2024-10-11T11:01:33.063' AS DateTime), 1)
INSERT [dbo].[Videojuegos] ([Id], [Nombre], [Compania], [AnioLanzamiento], [Precio], [Puntaje], [FechaActualizacion], [IdUsuarioActualizacion]) VALUES (20, N'Elder Ring', N'From Software', N'2022', 69.9900, CAST(0.00 AS Decimal(3, 2)), CAST(N'2024-10-11T11:01:33.063' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Videojuegos] OFF
GO
ALTER TABLE [dbo].[Calificaciones] ADD  CONSTRAINT [DF_Calificaciones_Puntaje]  DEFAULT ((0)) FOR [Puntaje]
GO
ALTER TABLE [dbo].[Calificaciones] ADD  CONSTRAINT [DF_Calificaciones_FechaActualizacion]  DEFAULT (getdate()) FOR [FechaActualizacion]
GO
ALTER TABLE [dbo].[Usuarios] ADD  CONSTRAINT [DF_Usuario_FechaCreacion]  DEFAULT (getdate()) FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[Videojuegos] ADD  CONSTRAINT [DF_Videojuego_Puntaje]  DEFAULT ((0)) FOR [Puntaje]
GO
ALTER TABLE [dbo].[Videojuegos] ADD  CONSTRAINT [DF_Videojuego_FechaActualizacion]  DEFAULT (getdate()) FOR [FechaActualizacion]
GO
ALTER TABLE [dbo].[Calificaciones]  WITH CHECK ADD  CONSTRAINT [FK_Calificaciones_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([Id])
GO
ALTER TABLE [dbo].[Calificaciones] CHECK CONSTRAINT [FK_Calificaciones_Usuarios]
GO
ALTER TABLE [dbo].[Calificaciones]  WITH CHECK ADD  CONSTRAINT [FK_Calificaciones_Usuarios_Actualizacion] FOREIGN KEY([IdUsuarioActualizacion])
REFERENCES [dbo].[Usuarios] ([Id])
GO
ALTER TABLE [dbo].[Calificaciones] CHECK CONSTRAINT [FK_Calificaciones_Usuarios_Actualizacion]
GO
ALTER TABLE [dbo].[Calificaciones]  WITH CHECK ADD  CONSTRAINT [FK_Calificaciones_Videojuegos] FOREIGN KEY([IdVideojuego])
REFERENCES [dbo].[Videojuegos] ([Id])
GO
ALTER TABLE [dbo].[Calificaciones] CHECK CONSTRAINT [FK_Calificaciones_Videojuegos]
GO
ALTER TABLE [dbo].[Videojuegos]  WITH CHECK ADD  CONSTRAINT [FK_Videojuegos_Usuarios] FOREIGN KEY([IdUsuarioActualizacion])
REFERENCES [dbo].[Usuarios] ([Id])
GO
ALTER TABLE [dbo].[Videojuegos] CHECK CONSTRAINT [FK_Videojuegos_Usuarios]
GO
/****** Object:  StoredProcedure [dbo].[GeneradorPuntajeRandom]    Script Date: 15/10/2024 10:20:03 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE   PROCEDURE [dbo].[GeneradorPuntajeRandom] 
	-- Add the parameters for the stored procedure here
	@cantidad int = 0,
	@codError int output,
	@mensajeError nvarchar(50) output 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF(@cantidad <= 0 OR @cantidad > 1000000)
	BEGIN
		SET @codError = 1;
		SET @mensajeError = 'El valor ingresado no es válido'
		RETURN;
	END
	DECLARE @i int = 1, @idUsuario int = 0;
	DECLARE @puntajeRandom DECIMAL(3,2) = 0;
	DECLARE @nicknameRandom NVARCHAR(30) = '';
	DECLARE @idVideojuego decimal = 0;
	DECLARE @correoRandom NVARCHAR(10);
	DECLARE @password NVARCHAR(100) = '3b612c75a7b5048a435fb6ec81e52ff92d6d795a8b5a9c17070f6a63c97a53b2';

	WHILE(@i <= @cantidad)
	BEGIN
		
		SELECT @puntajeRandom = ROUND(RAND(CHECKSUM(NEWID())) * (5), 2); --Random de 0 a 5 con dos decimales
		SELECT @nicknameRandom = LEFT(REPLACE(REPLACE(REPLACE((SELECT CRYPT_GEN_RANDOM(30) FOR XML PATH(''), BINARY BASE64), '+', ''), '/', ''), '=', '') + REPLACE(NEWID(), '-', ''), 30); --Random de usuarios (30)
		SELECT @idVideojuego = ROUND(RAND(CHECKSUM(NEWID())) * (19) + 1, 0); --Random de id de 1 a 20
		SELECT @correoRandom = LEFT(REPLACE(REPLACE(REPLACE((SELECT CRYPT_GEN_RANDOM(10) FOR XML PATH(''), BINARY BASE64), '+', ''), '/', ''), '=', '') + REPLACE(NEWID(), '-', ''), 10) + '@mail.com'; --Random de usuarios (10)				
				
		INSERT INTO Usuarios VALUES(@nicknameRandom,@correoRandom,@password,GETDATE(),null);
		SELECT @idUsuario = SCOPE_IDENTITY();		
		INSERT INTO Calificaciones VALUES(NEWID(),@idVideojuego,@idUsuario,@puntajeRandom,GETDATE(),@idUsuario);
				
		UPDATE v SET Puntaje = (select AVG(c1.Puntaje) FROM Calificaciones c1
								WHERE c1.IdVideojuego = @idVideojuego) 
		FROM Videojuegos v		
		WHERE v.Id = @idVideojuego

		SET @i = @i + 1;		
	END
	IF(@i > @cantidad)
	BEGIN		
		SET @codError = 0;
		SET @mensajeError = null;
	END
END
GO
USE [master]
GO
ALTER DATABASE [VideoGameStoreDB] SET  READ_WRITE 
GO
