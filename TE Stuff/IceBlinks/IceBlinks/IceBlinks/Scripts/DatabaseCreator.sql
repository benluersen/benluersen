USE master;
GO

IF EXISTS(select * from  sys.databases where name = 'IceBlinks')
DROP DATABASE IceBlinks;
GO

/****** Object:  Database [IceBlinks]    Script Date: 12/11/2019 12:20:43 PM ******/
CREATE DATABASE [IceBlinks]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'IceBlinks', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\IceBlinks.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'IceBlinks_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\IceBlinks_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [IceBlinks] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [IceBlinks].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [IceBlinks] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [IceBlinks] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [IceBlinks] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [IceBlinks] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [IceBlinks] SET ARITHABORT OFF 
GO
ALTER DATABASE [IceBlinks] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [IceBlinks] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [IceBlinks] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [IceBlinks] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [IceBlinks] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [IceBlinks] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [IceBlinks] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [IceBlinks] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [IceBlinks] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [IceBlinks] SET  ENABLE_BROKER 
GO
ALTER DATABASE [IceBlinks] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [IceBlinks] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [IceBlinks] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [IceBlinks] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [IceBlinks] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [IceBlinks] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [IceBlinks] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [IceBlinks] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [IceBlinks] SET  MULTI_USER 
GO
ALTER DATABASE [IceBlinks] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [IceBlinks] SET DB_CHAINING OFF 
GO
ALTER DATABASE [IceBlinks] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [IceBlinks] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [IceBlinks] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [IceBlinks] SET QUERY_STORE = OFF
GO
USE [IceBlinks]
GO
/****** Object:  Table [dbo].[Academics]    Script Date: 12/11/2019 12:20:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Academics](
	[Id] [int] IDENTITY NOT NULL,
	[ProfileId] [int] NOT NULL,
	[Degree] [varchar](35) NOT NULL,
	[Institution] [varchar](64) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[Graduated] [bit] NOT NULL,
	[Major] [varchar](64) NOT NULL,
 CONSTRAINT [pk_Academics_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 12/11/2019 12:20:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Address] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[State] [varchar](3) NULL,
	[Postal_code] [varchar](10) NULL,
	[UserId] [int] NULL,
 CONSTRAINT [pk_Address_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CareerExperience]    Script Date: 12/11/2019 12:20:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CareerExperience](
	[Id] [int] IDENTITY NOT NULL,
	[ProfileId] [int] NOT NULL,
	[Title] [varchar](64) NOT NULL,
	[Employer] [varchar](128) NOT NULL,
	[Industry] [varchar](64) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[JobDescription] [varchar](1000) NOT NULL,
 CONSTRAINT [pk_CareerExperience_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Portfolio]    Script Date: 12/11/2019 12:20:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Portfolio](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProfileId] [int] NOT NULL,
	[ProjectTitle] [varchar](128) NOT NULL,
	[ProjectDescription] [varchar](max) NOT NULL,
	[ProjectLink] [varchar](max) NOT NULL,
 CONSTRAINT [pk_Portfolio_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PortfolioTech]    Script Date: 12/11/2019 12:20:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PortfolioTech](
	[PortfolioId] [int] NOT NULL,
	[TechNameId] [int] NOT NULL,
 CONSTRAINT unique_portfolioTech UNIQUE ([PortfolioId],[TechNameId]),
 CONSTRAINT [pk_PortfolioTech] PRIMARY KEY CLUSTERED 
(
	[PortfolioId] ASC,
	[TechNameId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profile]    Script Date: 12/11/2019 12:20:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profile](
	[Id] [int] IDENTITY NOT NULL,
	[UserId] [int] NULL,
	[Cohort] [int] NOT NULL,
	[Summary] [varchar](max) NULL,
	[SoftSkills] [varchar](255) NULL,
	[Interests] [varchar](450) NULL,
	[PhotoLink] [varchar](255) NULL,
	[Searchable] [bit] NOT NULL,
	[ContactPreference] [varchar](6) NOT NULL,
 CONSTRAINT contactPreference_check CHECK (ContactPreference IN ('Phone', 'Email')),
 CONSTRAINT [pk_Profile_Id] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 12/11/2019 12:20:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] NOT NULL,
	[Role] [varchar](16) NULL,
 CONSTRAINT [pk_Role_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TechName]    Script Date: 12/11/2019 12:20:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TechName](
	[Id] [int] IDENTITY NOT NULL,
	[Name] [varchar](32) NOT NULL,
 CONSTRAINT [pk_TechName_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 12/11/2019 12:20:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleID] [int] NULL,
	[FirstName] [varchar](32) NOT NULL,
	[LastName] [varchar](32) NOT NULL,
	[Email] [varchar](64) NOT NULL,
	[Phone] [varchar](20) NULL,
	[Hash] [varchar](64) NOT NULL,
	[Salt] [varchar](64) NOT NULL,
 CONSTRAINT [pk_User_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Role] ([Id], [Role]) VALUES (1, N'admin')
GO
INSERT [dbo].[Role] ([Id], [Role]) VALUES (2, N'student')
GO
INSERT [dbo].[Role] ([Id], [Role]) VALUES (3, N'employer')
GO
INSERT [dbo].[Role] ([Id], [Role]) VALUES (4, N'staff')
GO

--Setup default admin account
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([Id], [RoleID], [FirstName], [LastName], [Email], [Phone], [Hash], [Salt]) VALUES (1, 1, N'admin', N'', N'admin', N'', N'68YcfX24mq+ZTJxQKK/PVOfW11k=', N'+eJBgFsNpHvU4HuIIeJqsQ==')
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO

ALTER TABLE [dbo].[Academics]  WITH CHECK ADD  CONSTRAINT [fk_Academics_UserId] FOREIGN KEY([ProfileId])
REFERENCES [dbo].[Profile] ([Id])
GO
ALTER TABLE [dbo].[Academics] CHECK CONSTRAINT [fk_Academics_UserId]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [fk_Address_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [fk_Address_User]
GO
ALTER TABLE [dbo].[CareerExperience]  WITH CHECK ADD  CONSTRAINT [fk_CareerExperience_ProfileId] FOREIGN KEY([ProfileId])
REFERENCES [dbo].[Profile] ([Id])
GO
ALTER TABLE [dbo].[CareerExperience] CHECK CONSTRAINT [fk_CareerExperience_ProfileId]
GO
ALTER TABLE [dbo].[Portfolio]  WITH CHECK ADD  CONSTRAINT [fk_Portfolio_ProfileId] FOREIGN KEY([ProfileId])
REFERENCES [dbo].[Profile] ([Id])
GO
ALTER TABLE [dbo].[Portfolio] CHECK CONSTRAINT [fk_Portfolio_ProfileId]
GO
ALTER TABLE [dbo].[PortfolioTech]  WITH CHECK ADD  CONSTRAINT [fk_PortfolioTech_Portfolio] FOREIGN KEY([PortfolioId])
REFERENCES [dbo].[Portfolio] ([Id])
GO
ALTER TABLE [dbo].[PortfolioTech] CHECK CONSTRAINT [fk_PortfolioTech_Portfolio]
GO
ALTER TABLE [dbo].[PortfolioTech]  WITH CHECK ADD  CONSTRAINT [fk_PortfolioTech_Tech] FOREIGN KEY([TechNameId])
REFERENCES [dbo].[TechName] ([Id])
GO
ALTER TABLE [dbo].[PortfolioTech] CHECK CONSTRAINT [fk_PortfolioTech_Tech]
GO
ALTER TABLE [dbo].[Profile]  WITH CHECK ADD  CONSTRAINT [fk_Profile] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Profile] CHECK CONSTRAINT [fk_Profile]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [fk_User_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [fk_User_Role]
GO
ALTER TABLE [dbo].[Profile]  WITH CHECK ADD  CONSTRAINT [chk_ContactPreference] CHECK  (([ContactPreference]='Email' OR [ContactPreference]='Phone'))
GO
ALTER TABLE [dbo].[Profile] CHECK CONSTRAINT [chk_ContactPreference]
GO
ALTER TABLE [dbo].[Role]  WITH CHECK ADD  CONSTRAINT [chk_Role] CHECK  (([Role]='Student' OR [Role]='Staff' OR [Role]='Employer' OR [Role]='Admin'))
GO
ALTER TABLE [dbo].[Role] CHECK CONSTRAINT [chk_Role]
GO
USE [master]
GO
ALTER DATABASE [IceBlinks] SET  READ_WRITE 
GO
