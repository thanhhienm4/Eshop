USE [master]
GO
/****** Object:  Database [EshopSolution]    Script Date: 2/27/2021 2:30:21 PM ******/
CREATE DATABASE [EshopSolution]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EshopSolution', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\EshopSolution.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EshopSolution_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\EshopSolution_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EshopSolution] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EshopSolution].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EshopSolution] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EshopSolution] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EshopSolution] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EshopSolution] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EshopSolution] SET ARITHABORT OFF 
GO
ALTER DATABASE [EshopSolution] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [EshopSolution] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EshopSolution] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EshopSolution] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EshopSolution] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EshopSolution] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EshopSolution] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EshopSolution] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EshopSolution] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EshopSolution] SET  ENABLE_BROKER 
GO
ALTER DATABASE [EshopSolution] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EshopSolution] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EshopSolution] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EshopSolution] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EshopSolution] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EshopSolution] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [EshopSolution] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EshopSolution] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EshopSolution] SET  MULTI_USER 
GO
ALTER DATABASE [EshopSolution] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EshopSolution] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EshopSolution] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EshopSolution] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EshopSolution] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EshopSolution] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [EshopSolution] SET QUERY_STORE = OFF
GO
USE [EshopSolution]
GO
/****** Object:  User [admin]    Script Date: 2/27/2021 2:30:21 PM ******/
CREATE USER [admin] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2/27/2021 2:30:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppConfigs]    Script Date: 2/27/2021 2:30:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppConfigs](
	[Key] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_AppConfigs] PRIMARY KEY CLUSTERED 
(
	[Key] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppRoleClaims]    Script Date: 2/27/2021 2:30:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AppRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppRoles]    Script Date: 2/27/2021 2:30:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppRoles](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[NormalizedName] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Description] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_AppRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppUserClaims]    Script Date: 2/27/2021 2:30:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AppUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppUserLogins]    Script Date: 2/27/2021 2:30:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUserLogins](
	[UserId] [uniqueidentifier] NOT NULL,
	[LoginProvider] [nvarchar](max) NULL,
	[ProviderKey] [nvarchar](max) NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
 CONSTRAINT [PK_AppUserLogins] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppUserRoles]    Script Date: 2/27/2021 2:30:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUserRoles](
	[UserId] [uniqueidentifier] NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_AppUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppUsers]    Script Date: 2/27/2021 2:30:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUsers](
	[Id] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[NormalizedUserName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[NormalizedEmail] [nvarchar](max) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[FirstName] [nvarchar](200) NOT NULL,
	[LastName] [nvarchar](200) NOT NULL,
	[Dob] [datetime2](7) NOT NULL,
	[Avatar] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_AppUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AppUserTokens]    Script Date: 2/27/2021 2:30:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUserTokens](
	[UserId] [uniqueidentifier] NOT NULL,
	[LoginProvider] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AppUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carts]    Script Date: 2/27/2021 2:30:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Carts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 2/27/2021 2:30:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SortOrder] [int] NOT NULL,
	[IsShowOnHome] [bit] NOT NULL,
	[ParentId] [int] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategoryTranslations]    Script Date: 2/27/2021 2:30:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryTranslations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[SeoDescription] [nvarchar](500) NULL,
	[SeoTitle] [nvarchar](200) NULL,
	[LanguageId] [varchar](5) NOT NULL,
	[SeoAlias] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_CategoryTranslations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 2/27/2021 2:30:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Email] [nvarchar](200) NOT NULL,
	[PhoneNumber] [nvarchar](200) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Languages]    Script Date: 2/27/2021 2:30:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
	[Id] [varchar](5) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[IsDefault] [bit] NOT NULL,
 CONSTRAINT [PK_Languages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 2/27/2021 2:30:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 2/27/2021 2:30:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [datetime2](7) NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[ShipName] [nvarchar](max) NOT NULL,
	[ShipAddress] [nvarchar](max) NOT NULL,
	[ShipEmail] [nvarchar](max) NOT NULL,
	[ShipPhoneNumber] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductImages]    Script Date: 2/27/2021 2:30:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[ImagePath] [nvarchar](200) NOT NULL,
	[Caption] [nvarchar](200) NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[SortOrder] [int] NOT NULL,
	[FileSize] [bigint] NOT NULL,
 CONSTRAINT [PK_ProductImages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductInCategories]    Script Date: 2/27/2021 2:30:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductInCategories](
	[ProductId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_ProductInCategories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 2/27/2021 2:30:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Price] [decimal](18, 4) NOT NULL,
	[OriginalPrice] [decimal](18, 2) NOT NULL,
	[Stock] [int] NOT NULL,
	[ViewCount] [int] NOT NULL,
	[DateCreated] [datetime2](7) NOT NULL,
	[IsFeatured] [bit] NOT NULL,
	[ThumnailId] [int] NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductTranslations]    Script Date: 2/27/2021 2:30:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductTranslations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[Details] [nvarchar](500) NOT NULL,
	[SeoDescription] [nvarchar](max) NULL,
	[SeoTitle] [nvarchar](max) NULL,
	[SeoAlias] [nvarchar](200) NULL,
	[LanguageId] [varchar](5) NOT NULL,
 CONSTRAINT [PK_ProductTranslations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Promotions]    Script Date: 2/27/2021 2:30:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promotions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FromDate] [datetime2](7) NOT NULL,
	[ToDate] [datetime2](7) NOT NULL,
	[ApplyForAll] [bit] NOT NULL,
	[DiscountPercent] [int] NULL,
	[DiscountAmount] [decimal](18, 2) NULL,
	[ProductIds] [nvarchar](max) NULL,
	[ProductCategoryIds] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Promotions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Slides]    Script Date: 2/27/2021 2:30:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slides](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Desciption] [nvarchar](200) NOT NULL,
	[Url] [nvarchar](200) NOT NULL,
	[Image] [nvarchar](200) NOT NULL,
	[SortOrder] [int] NOT NULL,
	[status] [int] NOT NULL,
 CONSTRAINT [PK_Slides] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 2/27/2021 2:30:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TransactionDate] [datetime2](7) NOT NULL,
	[ExternalTransactionId] [nvarchar](max) NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Fee] [decimal](18, 2) NOT NULL,
	[Result] [nvarchar](max) NULL,
	[Message] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
	[Provider] [nvarchar](max) NULL,
	[UserId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200818115737_SeedIdentityUser', N'5.0.0-preview.7.20365.15')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200821020836_ChangeSaveFile', N'5.0.0-preview.7.20365.15')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200901090430_update_fix_data', N'5.0.0-preview.7.20365.15')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201102143435_Initial', N'5.0.0-preview.7.20365.15')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210105155926_Homedatas', N'5.0.0-preview.7.20365.15')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210105161501_HomeData', N'5.0.0-preview.7.20365.15')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210106070258_Edit_Slide', N'5.0.0-preview.7.20365.15')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210107054117_update_languageId', N'5.0.0-preview.7.20365.15')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210125121318_update-order', N'5.0.0-preview.7.20365.15')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210204102604_1', N'5.0.0-preview.7.20365.15')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210204124050_config_thumnail', N'5.0.0-preview.7.20365.15')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210205153749_add_avatar', N'5.0.0-preview.7.20365.15')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210219142958_update_product', N'5.0.0-preview.7.20365.15')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210220050459_add-thunnailproduct', N'5.0.0-preview.7.20365.15')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210221032607_ProductImage.Isdefault', N'5.0.0-preview.7.20365.15')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210227071902_add_status_to_product_and_user', N'5.0.0-preview.7.20365.15')
GO
INSERT [dbo].[AppConfigs] ([Key], [Value]) VALUES (N'HomeDescription', N'This is description of EshopSolution')
INSERT [dbo].[AppConfigs] ([Key], [Value]) VALUES (N'HomeKeyword', N'This is keyword of EshopSolution')
INSERT [dbo].[AppConfigs] ([Key], [Value]) VALUES (N'HomeTitle', N'This is home page of EshopSolution')
GO
INSERT [dbo].[AppRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [Description]) VALUES (N'20fbd6d9-c730-444c-b002-68a70ffec883', N'customer', N'customer', N'451CDF1E-F1C8-4FBA-89B2-0606811B2C96
', N'customer')
INSERT [dbo].[AppRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp], [Description]) VALUES (N'8d04dce2-969a-435d-bba4-df3f325983dc', N'admin', N'admin', N'40fb310e-4ded-4ed5-ae1d-dd77dc961131', N'Administrator role')
GO
INSERT [dbo].[AppUserRoles] ([UserId], [RoleId]) VALUES (N'ff792c13-53b1-4b03-be2e-08d8818bed75', N'20fbd6d9-c730-444c-b002-68a70ffec883')
INSERT [dbo].[AppUserRoles] ([UserId], [RoleId]) VALUES (N'ff792c13-53b1-4b03-be2e-08d8818bed75', N'8d04dce2-969a-435d-bba4-df3f325983dc')
INSERT [dbo].[AppUserRoles] ([UserId], [RoleId]) VALUES (N'85dbd34f-a505-4f23-b606-08d8a628c5eb', N'20fbd6d9-c730-444c-b002-68a70ffec883')
INSERT [dbo].[AppUserRoles] ([UserId], [RoleId]) VALUES (N'85dbd34f-a505-4f23-b606-08d8a628c5eb', N'8d04dce2-969a-435d-bba4-df3f325983dc')
INSERT [dbo].[AppUserRoles] ([UserId], [RoleId]) VALUES (N'6d05bb5e-84da-453a-14f9-08d8bc408576', N'20fbd6d9-c730-444c-b002-68a70ffec883')
INSERT [dbo].[AppUserRoles] ([UserId], [RoleId]) VALUES (N'6d05bb5e-84da-453a-14f9-08d8bc408576', N'8d04dce2-969a-435d-bba4-df3f325983dc')
INSERT [dbo].[AppUserRoles] ([UserId], [RoleId]) VALUES (N'69bd714f-9576-45ba-b5b7-f00649be00de', N'20fbd6d9-c730-444c-b002-68a70ffec883')
INSERT [dbo].[AppUserRoles] ([UserId], [RoleId]) VALUES (N'69bd714f-9576-45ba-b5b7-f00649be00de', N'8d04dce2-969a-435d-bba4-df3f325983dc')
GO
INSERT [dbo].[AppUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [Dob], [Avatar], [Status]) VALUES (N'ff792c13-53b1-4b03-be2e-08d8818bed75', N'Mistake', N'MISTAKE', N'Kroos@gmail.com', N'KROOS@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEG+OOitNugl5T/NoxT4PasjTfPT3NwM2FvK4bXWx1sLN1cZN1VyZiVuXp0kz5wwf8Q==', N'FVOPX55NA56RTWP7UQSLYI25TA24F33D', N'112e21c6-26f8-499d-b4ab-a26cb6017ede', N'0912312905', 0, 0, NULL, 1, 0, N'Hien', N'Nguyen Thanh', CAST(N'1995-02-07T00:00:00.0000000' AS DateTime2), NULL, 1)
INSERT [dbo].[AppUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [Dob], [Avatar], [Status]) VALUES (N'4150bab9-f8cc-4099-4823-08d8a621e8eb', N'Kroos', N'KROOS', N'tony@gmail.com', N'TONY@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEPeTvOJ9VXeALG+lM76sjl3o8ViBxwrKa8Sn3toQKvK64p/4fpcgCVr1w/xWmec1zA==', N'L6XBSJ4PM5RBPE4YK2BHWB2PT2JPO6XZ', N'77c43de0-1312-4782-a504-615226d57918', N'0787878787', 0, 0, NULL, 1, 0, N'Tony', N'Kroos', CAST(N'1990-02-05T00:00:00.0000000' AS DateTime2), NULL, 1)
INSERT [dbo].[AppUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [Dob], [Avatar], [Status]) VALUES (N'85dbd34f-a505-4f23-b606-08d8a628c5eb', N'Khanhhuong', N'KHANHHUONG', N'khanhHuong123@goo.vn', N'KHANHHUONG123@GOO.VN', 0, N'AQAAAAEAACcQAAAAEHmZwrWWeH14ah+Au6GOwGhYLkby8J9FQZSxfEvo7VEWaYnNb9/1enFgPTnWkRf17g==', N'VPYJPN2BZVLZI5A3IVXTHKJGHBOL67TZ', N'cf0c2143-4701-41cb-953d-0bcef8cfa587', N'09129090909', 0, 0, NULL, 1, 0, N'Huong', N'Nguyen ', CAST(N'1999-03-06T00:00:00.0000000' AS DateTime2), NULL, 1)
INSERT [dbo].[AppUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [Dob], [Avatar], [Status]) VALUES (N'6d05bb5e-84da-453a-14f9-08d8bc408576', N'Hien', N'HIEN', N'thanhhienm4@gmail.com', N'THANHHIENM4@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEDuxFC/QhkRoel36h/OaNrjHuK2+34Nvyi0dEd68dXbxlHSqz3TuMdf8jISietb5OA==', N'CGI5M65GZBS7FZQ3HBJPGS3XKFBAFYEH', N'7a01ced2-7381-4230-8c02-f1ceacbd4f60', N'0912413904', 0, 0, NULL, 1, 0, N'Hien', N'Nguyen Thanh', CAST(N'2000-02-19T00:00:00.0000000' AS DateTime2), NULL, 1)
INSERT [dbo].[AppUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [Dob], [Avatar], [Status]) VALUES (N'34d7bac8-20df-43df-8823-08d8bc871494', N'khanhquynh', N'KHANHQUYNH', N'khanhquynh@gmail.com', N'KHANHQUYNH@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEEmc+2D85MI6V0bSvZakGyafJFKQDMg+3C+XAcDB1pO7ZNLNh4N7GMVqsIQd5Dzsog==', N'UNVET4CPJWXXB356WQ53HX773VYM5PVZ', N'eaaaa125-6b3e-4f2f-902e-7db6cc4550bf', N'09090090909', 0, 0, NULL, 1, 0, N'Thị Khánh Quỳnh', N'Trần ', CAST(N'2002-02-06T00:00:00.0000000' AS DateTime2), NULL, 1)
INSERT [dbo].[AppUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [Dob], [Avatar], [Status]) VALUES (N'69bd714f-9576-45ba-b5b7-f00649be00de', N'admin', N'ADMIN', N'Mistake4@gmail.com', N'MISTAKE4@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEBbEKC2kbMSKXNevi/RZFDKLrNXagzutW/XIV7ZbJorGUrIPmXaLspjJJxli55yUdw==', N'', N'f633befd-e25e-40c3-8072-70fda314cfe3', N'0912413908', 1, 0, CAST(N'2021-01-31T10:44:12.4309342+00:00' AS DateTimeOffset), 0, 4, N'Hien', N'Nguyen Thanh', CAST(N'2020-01-31T00:00:00.0000000' AS DateTime2), NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [SortOrder], [IsShowOnHome], [ParentId], [Status]) VALUES (3, 3, 1, NULL, 1)
INSERT [dbo].[Categories] ([Id], [SortOrder], [IsShowOnHome], [ParentId], [Status]) VALUES (4, 4, 1, NULL, 1)
INSERT [dbo].[Categories] ([Id], [SortOrder], [IsShowOnHome], [ParentId], [Status]) VALUES (1007, 1, 1, NULL, 1)
INSERT [dbo].[Categories] ([Id], [SortOrder], [IsShowOnHome], [ParentId], [Status]) VALUES (1008, 0, 1, 1007, 1)
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[CategoryTranslations] ON 

INSERT [dbo].[CategoryTranslations] ([Id], [CategoryId], [Name], [SeoDescription], [SeoTitle], [LanguageId], [SeoAlias]) VALUES (5, 3, N'Bàn phím cơ', N'Bàn phím cơ chính hãng', N'Bàn phím cơ chính hãng', N'vi', N'ban-phim-co')
INSERT [dbo].[CategoryTranslations] ([Id], [CategoryId], [Name], [SeoDescription], [SeoTitle], [LanguageId], [SeoAlias]) VALUES (1009, 1007, N'Điện thoại', N'Điện thoại', N'Dien Thoai', N'vi', N'Dien Thoai')
INSERT [dbo].[CategoryTranslations] ([Id], [CategoryId], [Name], [SeoDescription], [SeoTitle], [LanguageId], [SeoAlias]) VALUES (1010, 1008, N'Iphone', N'Iphone', N'Iphone', N'vi', N'Iphone')
SET IDENTITY_INSERT [dbo].[CategoryTranslations] OFF
GO
INSERT [dbo].[Languages] ([Id], [Name], [IsDefault]) VALUES (N'en', N'English', 0)
INSERT [dbo].[Languages] ([Id], [Name], [IsDefault]) VALUES (N'vi', N'Tiếng Việt', 1)
GO
INSERT [dbo].[OrderDetails] ([OrderId], [ProductId], [Quantity], [Price]) VALUES (1, 9, 12, CAST(20000000.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([OrderId], [ProductId], [Quantity], [Price]) VALUES (2, 9, 10, CAST(20000000.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([OrderId], [ProductId], [Quantity], [Price]) VALUES (3, 9, 8, CAST(2000000.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([OrderId], [ProductId], [Quantity], [Price]) VALUES (4, 4, 1, CAST(1700000.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([OrderId], [ProductId], [Quantity], [Price]) VALUES (4, 26, 1, CAST(22900000.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([OrderId], [ProductId], [Quantity], [Price]) VALUES (5, 3, 1, CAST(1500000.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([OrderId], [ProductId], [Quantity], [Price]) VALUES (5, 4, 1, CAST(1700000.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([OrderId], [ProductId], [Quantity], [Price]) VALUES (5, 25, 1, CAST(20000000.00 AS Decimal(18, 2)))
INSERT [dbo].[OrderDetails] ([OrderId], [ProductId], [Quantity], [Price]) VALUES (5, 26, 9, CAST(22900000.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [OrderDate], [UserId], [ShipName], [ShipAddress], [ShipEmail], [ShipPhoneNumber], [Status]) VALUES (1, CAST(N'2021-01-25T10:14:24.4131935' AS DateTime2), N'6d05bb5e-84da-453a-14f9-08d8bc408576', N'Hien', N'phan thiet', N'thanhhienm4@gmail.com', N'0912413904', 4)
INSERT [dbo].[Orders] ([Id], [OrderDate], [UserId], [ShipName], [ShipAddress], [ShipEmail], [ShipPhoneNumber], [Status]) VALUES (2, CAST(N'2020-09-25T10:18:54.9871383' AS DateTime2), N'6d05bb5e-84da-453a-14f9-08d8bc408576', N'Hien', N'phan thiet', N'thanhhienm4@gmail.com', N'0912413904', 3)
INSERT [dbo].[Orders] ([Id], [OrderDate], [UserId], [ShipName], [ShipAddress], [ShipEmail], [ShipPhoneNumber], [Status]) VALUES (3, CAST(N'2020-10-25T10:20:38.4111343' AS DateTime2), N'6d05bb5e-84da-453a-14f9-08d8bc408576', N'Hien', N'phan thiet', N'thanhhienm4@gmail.com', N'0912413904', 2)
INSERT [dbo].[Orders] ([Id], [OrderDate], [UserId], [ShipName], [ShipAddress], [ShipEmail], [ShipPhoneNumber], [Status]) VALUES (4, CAST(N'2020-11-25T10:29:18.2882517' AS DateTime2), N'6d05bb5e-84da-453a-14f9-08d8bc408576', N'nguyen thanh hien', N'ho chi minh', N'mish@gmail.com', N'0919889990', 1)
INSERT [dbo].[Orders] ([Id], [OrderDate], [UserId], [ShipName], [ShipAddress], [ShipEmail], [ShipPhoneNumber], [Status]) VALUES (5, CAST(N'2020-12-26T15:24:34.9497879' AS DateTime2), N'6d05bb5e-84da-453a-14f9-08d8bc408576', N'Cao Thanh', N'Binh dinh', N'thanh@goo.vn', N'0990123485', 0)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductImages] ON 

INSERT [dbo].[ProductImages] ([Id], [ProductId], [ImagePath], [Caption], [DateCreated], [SortOrder], [FileSize]) VALUES (3, 4, N'dd4c6964-bc28-4bc2-b047-3af7abf858e8.jpg', N'Thumbnail image', CAST(N'2020-11-05T20:14:40.2838371' AS DateTime2), 1, 376734)
INSERT [dbo].[ProductImages] ([Id], [ProductId], [ImagePath], [Caption], [DateCreated], [SortOrder], [FileSize]) VALUES (6, 9, N'5aaeb131-b889-47f4-ba70-34e0758df6e2.jpg', N'Thumbnail image', CAST(N'2020-12-22T10:46:02.0667604' AS DateTime2), 1, 50183)
INSERT [dbo].[ProductImages] ([Id], [ProductId], [ImagePath], [Caption], [DateCreated], [SortOrder], [FileSize]) VALUES (22, 25, N'3670664a-ec19-4675-b543-9fb2baf36bed.jpg', N'Thumbnail image', CAST(N'2020-12-22T11:58:18.6581663' AS DateTime2), 0, 87199)
INSERT [dbo].[ProductImages] ([Id], [ProductId], [ImagePath], [Caption], [DateCreated], [SortOrder], [FileSize]) VALUES (23, 26, N'b138da23-8370-4e19-83db-3f74b83bd822.jpg', N'Thumbnail image', CAST(N'2021-01-10T14:17:09.5507865' AS DateTime2), 1, 58802)
INSERT [dbo].[ProductImages] ([Id], [ProductId], [ImagePath], [Caption], [DateCreated], [SortOrder], [FileSize]) VALUES (26, 29, N'9cf61004-1945-4cbf-81e9-3c9164274c15.jpg', N'Thumbnail image', CAST(N'2021-01-29T14:20:38.4257790' AS DateTime2), 1, 56862)
INSERT [dbo].[ProductImages] ([Id], [ProductId], [ImagePath], [Caption], [DateCreated], [SortOrder], [FileSize]) VALUES (38, 4, N'9542cab4-5b16-43c5-b7f1-ac9d02fa90e6.jpg', N'Black', CAST(N'2021-02-21T09:42:38.9209500' AS DateTime2), 0, 37470)
INSERT [dbo].[ProductImages] ([Id], [ProductId], [ImagePath], [Caption], [DateCreated], [SortOrder], [FileSize]) VALUES (41, 3, N'662e329c-b0c9-47fd-a09d-4d6a96be8c0f.webp', N'RGB', CAST(N'2021-02-26T22:57:29.9983396' AS DateTime2), 0, 38304)
INSERT [dbo].[ProductImages] ([Id], [ProductId], [ImagePath], [Caption], [DateCreated], [SortOrder], [FileSize]) VALUES (42, 26, N'49f1395a-be69-48eb-b781-f80fbc8a910a.jpg', N'Green', CAST(N'2021-02-26T22:59:33.8442341' AS DateTime2), 0, 50186)
SET IDENTITY_INSERT [dbo].[ProductImages] OFF
GO
INSERT [dbo].[ProductInCategories] ([ProductId], [CategoryId]) VALUES (3, 3)
INSERT [dbo].[ProductInCategories] ([ProductId], [CategoryId]) VALUES (4, 3)
INSERT [dbo].[ProductInCategories] ([ProductId], [CategoryId]) VALUES (9, 1007)
INSERT [dbo].[ProductInCategories] ([ProductId], [CategoryId]) VALUES (25, 1007)
INSERT [dbo].[ProductInCategories] ([ProductId], [CategoryId]) VALUES (26, 1007)
INSERT [dbo].[ProductInCategories] ([ProductId], [CategoryId]) VALUES (26, 1008)
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Price], [OriginalPrice], [Stock], [ViewCount], [DateCreated], [IsFeatured], [ThumnailId], [Status]) VALUES (3, CAST(1500000.0000 AS Decimal(18, 4)), CAST(1500000.00 AS Decimal(18, 2)), 10, 0, CAST(N'2020-11-05T20:13:46.7144318' AS DateTime2), 1, 41, 1)
INSERT [dbo].[Products] ([Id], [Price], [OriginalPrice], [Stock], [ViewCount], [DateCreated], [IsFeatured], [ThumnailId], [Status]) VALUES (4, CAST(1700000.0000 AS Decimal(18, 4)), CAST(1700000.00 AS Decimal(18, 2)), 100, 0, CAST(N'2020-11-05T20:14:40.2838222' AS DateTime2), 0, 3, 1)
INSERT [dbo].[Products] ([Id], [Price], [OriginalPrice], [Stock], [ViewCount], [DateCreated], [IsFeatured], [ThumnailId], [Status]) VALUES (9, CAST(20000000.0000 AS Decimal(18, 4)), CAST(20000000.00 AS Decimal(18, 2)), 20, 0, CAST(N'2020-12-22T10:46:02.0661304' AS DateTime2), 0, 6, 1)
INSERT [dbo].[Products] ([Id], [Price], [OriginalPrice], [Stock], [ViewCount], [DateCreated], [IsFeatured], [ThumnailId], [Status]) VALUES (25, CAST(20000000.0000 AS Decimal(18, 4)), CAST(20000000.00 AS Decimal(18, 2)), 13, 0, CAST(N'2020-12-22T11:58:15.2281164' AS DateTime2), 1, 22, 1)
INSERT [dbo].[Products] ([Id], [Price], [OriginalPrice], [Stock], [ViewCount], [DateCreated], [IsFeatured], [ThumnailId], [Status]) VALUES (26, CAST(22900000.0000 AS Decimal(18, 4)), CAST(22900000.00 AS Decimal(18, 2)), 20, 0, CAST(N'2021-01-10T14:17:09.5498421' AS DateTime2), 1, 23, 1)
INSERT [dbo].[Products] ([Id], [Price], [OriginalPrice], [Stock], [ViewCount], [DateCreated], [IsFeatured], [ThumnailId], [Status]) VALUES (29, CAST(8000000.0000 AS Decimal(18, 4)), CAST(8000000.00 AS Decimal(18, 2)), 10, 0, CAST(N'2021-01-29T14:20:38.4239659' AS DateTime2), 0, 26, 1)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductTranslations] ON 

INSERT [dbo].[ProductTranslations] ([Id], [ProductId], [Name], [Description], [Details], [SeoDescription], [SeoTitle], [SeoAlias], [LanguageId]) VALUES (12, 3, N'KeyCool KC 84', N'KeyCool KC 84', N'KeyCool KC 84', N'KeyCool KC 84', N'KeyCool KC 84', N'KeyCool KC 84', N'vi')
INSERT [dbo].[ProductTranslations] ([Id], [ProductId], [Name], [Description], [Details], [SeoDescription], [SeoTitle], [SeoAlias], [LanguageId]) VALUES (13, 4, N'IKBC CD87', N'IKBC CD87', N'IKBC CD87', N'IKBC CD87', N'IKBC CD87', N'IKBC CD87', N'vi')
INSERT [dbo].[ProductTranslations] ([Id], [ProductId], [Name], [Description], [Details], [SeoDescription], [SeoTitle], [SeoAlias], [LanguageId]) VALUES (19, 9, N'Google Pixel 5', N'Google Pixel 5', N'Google Pixel 5', N'Google Pixel 5', N'Google Pixel 5', N'Google Pixel 5', N'vi')
INSERT [dbo].[ProductTranslations] ([Id], [ProductId], [Name], [Description], [Details], [SeoDescription], [SeoTitle], [SeoAlias], [LanguageId]) VALUES (20, 25, N'Experia 5 Mark II', N'Experia 5 Mark II', N'Experia 5 Mark II', N'Experia 5 Mark II', N'Experia 5 Mark II', N'Experia 5 Mark II', N'vi')
INSERT [dbo].[ProductTranslations] ([Id], [ProductId], [Name], [Description], [Details], [SeoDescription], [SeoTitle], [SeoAlias], [LanguageId]) VALUES (21, 4, N'IKBC CD87', N'IKBC CD87', N'IKBC CD87', N'IKBC CD87', N'IKBC CD87', N'IKBC CD87', N'en')
INSERT [dbo].[ProductTranslations] ([Id], [ProductId], [Name], [Description], [Details], [SeoDescription], [SeoTitle], [SeoAlias], [LanguageId]) VALUES (22, 26, N'', N'', N'', N'', N'', N'', N'en')
INSERT [dbo].[ProductTranslations] ([Id], [ProductId], [Name], [Description], [Details], [SeoDescription], [SeoTitle], [SeoAlias], [LanguageId]) VALUES (23, 26, N'Iphone 12', N'Điện thoai sang chảnh', N'Điện thoại chính hãng ', NULL, NULL, NULL, N'vi')
INSERT [dbo].[ProductTranslations] ([Id], [ProductId], [Name], [Description], [Details], [SeoDescription], [SeoTitle], [SeoAlias], [LanguageId]) VALUES (26, 3, N'Keyboard KeyCool KC 84', N'KeyCool KC 84', N'KeyCool KC 84', N'KeyCool KC 84', N'KeyCool KC 84', N'KeyCool KC 84', N'en')
INSERT [dbo].[ProductTranslations] ([Id], [ProductId], [Name], [Description], [Details], [SeoDescription], [SeoTitle], [SeoAlias], [LanguageId]) VALUES (29, 29, N'', N'', N'', N'', N'', N'', N'en')
INSERT [dbo].[ProductTranslations] ([Id], [ProductId], [Name], [Description], [Details], [SeoDescription], [SeoTitle], [SeoAlias], [LanguageId]) VALUES (30, 29, N'Oppo Reno 4', N'Oppo Reno 4', N'Oppo Reno 4', N'Oppo Reno 4', N'Oppo Reno 4', N'Oppo Reno 4', N'vi')
SET IDENTITY_INSERT [dbo].[ProductTranslations] OFF
GO
SET IDENTITY_INSERT [dbo].[Slides] ON 

INSERT [dbo].[Slides] ([Id], [Name], [Desciption], [Url], [Image], [SortOrder], [status]) VALUES (1, N'First product', N'Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.,', N'#', N'themes/images/carousel/4.png', 1, 1)
INSERT [dbo].[Slides] ([Id], [Name], [Desciption], [Url], [Image], [SortOrder], [status]) VALUES (2, N'First product', N'Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.,', N'#', N'themes/images/carousel/1.png', 1, 1)
SET IDENTITY_INSERT [dbo].[Slides] OFF
GO
/****** Object:  Index [IX_Carts_ProductId]    Script Date: 2/27/2021 2:30:22 PM ******/
CREATE NONCLUSTERED INDEX [IX_Carts_ProductId] ON [dbo].[Carts]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Carts_UserId]    Script Date: 2/27/2021 2:30:22 PM ******/
CREATE NONCLUSTERED INDEX [IX_Carts_UserId] ON [dbo].[Carts]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_CategoryTranslations_CategoryId]    Script Date: 2/27/2021 2:30:22 PM ******/
CREATE NONCLUSTERED INDEX [IX_CategoryTranslations_CategoryId] ON [dbo].[CategoryTranslations]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_CategoryTranslations_LanguageId]    Script Date: 2/27/2021 2:30:22 PM ******/
CREATE NONCLUSTERED INDEX [IX_CategoryTranslations_LanguageId] ON [dbo].[CategoryTranslations]
(
	[LanguageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderDetails_ProductId]    Script Date: 2/27/2021 2:30:22 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderDetails_ProductId] ON [dbo].[OrderDetails]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_UserId]    Script Date: 2/27/2021 2:30:22 PM ******/
CREATE NONCLUSTERED INDEX [IX_Orders_UserId] ON [dbo].[Orders]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductImages_ProductId]    Script Date: 2/27/2021 2:30:22 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductImages_ProductId] ON [dbo].[ProductImages]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductInCategories_ProductId]    Script Date: 2/27/2021 2:30:22 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductInCategories_ProductId] ON [dbo].[ProductInCategories]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_ThumnailId]    Script Date: 2/27/2021 2:30:22 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Products_ThumnailId] ON [dbo].[Products]
(
	[ThumnailId] ASC
)
WHERE ([ThumnailId] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_ProductTranslations_LanguageId]    Script Date: 2/27/2021 2:30:22 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductTranslations_LanguageId] ON [dbo].[ProductTranslations]
(
	[LanguageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductTranslations_ProductId]    Script Date: 2/27/2021 2:30:22 PM ******/
CREATE NONCLUSTERED INDEX [IX_ProductTranslations_ProductId] ON [dbo].[ProductTranslations]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Transactions_UserId]    Script Date: 2/27/2021 2:30:22 PM ******/
CREATE NONCLUSTERED INDEX [IX_Transactions_UserId] ON [dbo].[Transactions]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AppUsers] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Categories] ADD  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((0)) FOR [ViewCount]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Carts]  WITH CHECK ADD  CONSTRAINT [FK_Carts_AppUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AppUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Carts] CHECK CONSTRAINT [FK_Carts_AppUsers_UserId]
GO
ALTER TABLE [dbo].[Carts]  WITH CHECK ADD  CONSTRAINT [FK_Carts_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Carts] CHECK CONSTRAINT [FK_Carts_Products_ProductId]
GO
ALTER TABLE [dbo].[CategoryTranslations]  WITH CHECK ADD  CONSTRAINT [FK_CategoryTranslations_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CategoryTranslations] CHECK CONSTRAINT [FK_CategoryTranslations_Categories_CategoryId]
GO
ALTER TABLE [dbo].[CategoryTranslations]  WITH CHECK ADD  CONSTRAINT [FK_CategoryTranslations_Languages_LanguageId] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Languages] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CategoryTranslations] CHECK CONSTRAINT [FK_CategoryTranslations_Languages_LanguageId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders_OrderId]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Products_ProductId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_AppUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AppUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_AppUsers_UserId]
GO
ALTER TABLE [dbo].[ProductImages]  WITH CHECK ADD  CONSTRAINT [FK_ProductImages_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductImages] CHECK CONSTRAINT [FK_ProductImages_Products_ProductId]
GO
ALTER TABLE [dbo].[ProductInCategories]  WITH CHECK ADD  CONSTRAINT [FK_ProductInCategories_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductInCategories] CHECK CONSTRAINT [FK_ProductInCategories_Categories_CategoryId]
GO
ALTER TABLE [dbo].[ProductInCategories]  WITH CHECK ADD  CONSTRAINT [FK_ProductInCategories_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductInCategories] CHECK CONSTRAINT [FK_ProductInCategories_Products_ProductId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_ProductImages_ThumnailId] FOREIGN KEY([ThumnailId])
REFERENCES [dbo].[ProductImages] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_ProductImages_ThumnailId]
GO
ALTER TABLE [dbo].[ProductTranslations]  WITH CHECK ADD  CONSTRAINT [FK_ProductTranslations_Languages_LanguageId] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Languages] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductTranslations] CHECK CONSTRAINT [FK_ProductTranslations_Languages_LanguageId]
GO
ALTER TABLE [dbo].[ProductTranslations]  WITH CHECK ADD  CONSTRAINT [FK_ProductTranslations_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductTranslations] CHECK CONSTRAINT [FK_ProductTranslations_Products_ProductId]
GO
ALTER TABLE [dbo].[Transactions]  WITH CHECK ADD  CONSTRAINT [FK_Transactions_AppUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AppUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Transactions] CHECK CONSTRAINT [FK_Transactions_AppUsers_UserId]
GO
USE [master]
GO
ALTER DATABASE [EshopSolution] SET  READ_WRITE 
GO
