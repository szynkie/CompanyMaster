USE [master]
GO
/****** Object:  Database [CompaniesDatabase]    Script Date: 14.02.2021 20:48:47 ******/
CREATE DATABASE [CompaniesDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CompaniesDatabase', FILENAME = N'C:\Users\OEM\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\CompaniesDatabase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CompaniesDatabase_log', FILENAME = N'C:\Users\OEM\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\CompaniesDatabase.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CompaniesDatabase] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CompaniesDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CompaniesDatabase] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [CompaniesDatabase] SET ANSI_NULLS ON 
GO
ALTER DATABASE [CompaniesDatabase] SET ANSI_PADDING ON 
GO
ALTER DATABASE [CompaniesDatabase] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [CompaniesDatabase] SET ARITHABORT ON 
GO
ALTER DATABASE [CompaniesDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CompaniesDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CompaniesDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CompaniesDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CompaniesDatabase] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [CompaniesDatabase] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [CompaniesDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CompaniesDatabase] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [CompaniesDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CompaniesDatabase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CompaniesDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CompaniesDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CompaniesDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CompaniesDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CompaniesDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CompaniesDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CompaniesDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CompaniesDatabase] SET RECOVERY FULL 
GO
ALTER DATABASE [CompaniesDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [CompaniesDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CompaniesDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CompaniesDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CompaniesDatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CompaniesDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CompaniesDatabase] SET QUERY_STORE = OFF
GO
USE [CompaniesDatabase]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [CompaniesDatabase]
GO
/****** Object:  Table [dbo].[BusinessSegments]    Script Date: 14.02.2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BusinessSegments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BusinessSegment] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 14.02.2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[Id] [int] IDENTITY(0,1) NOT NULL,
	[FullName] [varchar](50) NOT NULL,
	[Street] [varchar](50) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[Country] [int] NOT NULL,
	[BusinessSegmentFK] [int] NOT NULL,
	[TypeFK] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 14.02.2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Country] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Types]    Script Date: 14.02.2021 20:48:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Types](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BusinessSegments] ON 

INSERT [dbo].[BusinessSegments] ([Id], [BusinessSegment]) VALUES (1, N'Retail Sale')
INSERT [dbo].[BusinessSegments] ([Id], [BusinessSegment]) VALUES (2, N'Food')
INSERT [dbo].[BusinessSegments] ([Id], [BusinessSegment]) VALUES (3, N'Transport')
INSERT [dbo].[BusinessSegments] ([Id], [BusinessSegment]) VALUES (4, N'Services')
INSERT [dbo].[BusinessSegments] ([Id], [BusinessSegment]) VALUES (5, N'Other')
SET IDENTITY_INSERT [dbo].[BusinessSegments] OFF
GO
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([Id], [Country]) VALUES (1, N'Poland')
INSERT [dbo].[Countries] ([Id], [Country]) VALUES (2, N'Germany')
INSERT [dbo].[Countries] ([Id], [Country]) VALUES (3, N'France')
INSERT [dbo].[Countries] ([Id], [Country]) VALUES (4, N'Ukraine')
SET IDENTITY_INSERT [dbo].[Countries] OFF
GO
SET IDENTITY_INSERT [dbo].[Types] ON 

INSERT [dbo].[Types] ([Id], [Type]) VALUES (1, N'Single Location')
INSERT [dbo].[Types] ([Id], [Type]) VALUES (2, N'Global Headquarter')
INSERT [dbo].[Types] ([Id], [Type]) VALUES (3, N'Branch')
SET IDENTITY_INSERT [dbo].[Types] OFF
GO
ALTER TABLE [dbo].[Companies]  WITH CHECK ADD FOREIGN KEY([BusinessSegmentFK])
REFERENCES [dbo].[BusinessSegments] ([Id])
GO
ALTER TABLE [dbo].[Companies]  WITH CHECK ADD FOREIGN KEY([Country])
REFERENCES [dbo].[Countries] ([Id])
GO
ALTER TABLE [dbo].[Companies]  WITH CHECK ADD FOREIGN KEY([TypeFK])
REFERENCES [dbo].[Types] ([Id])
GO
USE [master]
GO
ALTER DATABASE [CompaniesDatabase] SET  READ_WRITE 
GO
