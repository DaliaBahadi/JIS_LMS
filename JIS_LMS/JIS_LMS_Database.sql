USE [master]
GO
/****** Object:  Database [LibraryManagementSystem]    Script Date: 12/10/2020 11:13:51 PM ******/
CREATE DATABASE [LibraryManagementSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LibraryManagementSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\LibraryManagementSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LibraryManagementSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\LibraryManagementSystem_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [LibraryManagementSystem] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LibraryManagementSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LibraryManagementSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LibraryManagementSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LibraryManagementSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LibraryManagementSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LibraryManagementSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [LibraryManagementSystem] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LibraryManagementSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LibraryManagementSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LibraryManagementSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LibraryManagementSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LibraryManagementSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LibraryManagementSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LibraryManagementSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LibraryManagementSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LibraryManagementSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LibraryManagementSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LibraryManagementSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LibraryManagementSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LibraryManagementSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LibraryManagementSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LibraryManagementSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LibraryManagementSystem] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LibraryManagementSystem] SET RECOVERY FULL 
GO
ALTER DATABASE [LibraryManagementSystem] SET  MULTI_USER 
GO
ALTER DATABASE [LibraryManagementSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LibraryManagementSystem] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LibraryManagementSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LibraryManagementSystem] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LibraryManagementSystem] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'LibraryManagementSystem', N'ON'
GO
ALTER DATABASE [LibraryManagementSystem] SET QUERY_STORE = OFF
GO
USE [LibraryManagementSystem]
GO
/****** Object:  Table [dbo].[Library_Material]    Script Date: 12/10/2020 11:13:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Library_Material](
	[LibraryMaterialId] [int] IDENTITY(1,1) NOT NULL,
	[AccessionNumber] [int] NOT NULL,
	[DateAcquired] [date] NULL,
	[DateRecorded] [date] NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[NumberOfPages] [int] NULL,
	[SourceOfFund] [nvarchar](150) NULL,
	[CostPrice] [decimal](8, 2) NULL,
	[YearPublished] [nvarchar](4) NOT NULL,
	[Language] [int] NOT NULL,
	[SubjectTranslationInEnglish] [nvarchar](max) NULL,
	[Genre] [nvarchar](80) NOT NULL,
	[Subject] [nvarchar](80) NOT NULL,
	[CityPublished] [nvarchar](80) NULL,
	[AgeLevel] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[ImageFile] [nvarchar](max) NULL,
	[DOIURL] [nvarchar](max) NULL,
	[RestrictionType] [int] NULL,
	[LibraryMaterialType] [int] NOT NULL,
	[PublisherId] [int] NULL,
	[DonorId] [int] NOT NULL,
	[LibraryId] [int] NULL,
 CONSTRAINT [PK_LibraryMaterial] PRIMARY KEY CLUSTERED 
(
	[LibraryMaterialId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Donor]    Script Date: 12/10/2020 11:13:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Donor](
	[DonorId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[MiddleName] [nvarchar](30) NULL,
	[LastName] [nvarchar](30) NOT NULL,
	[Email] [nvarchar](100) NULL,
	[Mobile] [nvarchar](15) NULL,
 CONSTRAINT [PK_Donor] PRIMARY KEY CLUSTERED 
(
	[DonorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[List_Donor]    Script Date: 12/10/2020 11:13:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[List_Donor]
AS
SELECT        dbo.Donor.FirstName, dbo.Donor.LastName, dbo.Library_Material.DateAcquired, dbo.Library_Material.Title
FROM            dbo.Donor INNER JOIN
                         dbo.Library_Material ON dbo.Donor.DonorId = dbo.Library_Material.DonorId
GO
/****** Object:  Table [dbo].[Library]    Script Date: 12/10/2020 11:13:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Library](
	[LibraryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Section] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[AddressId] [int] NOT NULL,
	[LibrarianId] [int] NOT NULL,
 CONSTRAINT [PK_Library] PRIMARY KEY CLUSTERED 
(
	[LibraryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hold]    Script Date: 12/10/2020 11:13:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hold](
	[HoldId] [int] IDENTITY(1,1) NOT NULL,
	[HoldDateTime] [datetime2](7) NOT NULL,
	[ExpiryDateTime] [datetime2](7) NOT NULL,
	[PickupDateTime] [datetime2](7) NOT NULL,
	[HoldStatus] [bit] NOT NULL,
	[Remark] [nvarchar](max) NULL,
	[LibraryMaterialId] [int] NOT NULL,
	[PatronId] [int] NOT NULL,
 CONSTRAINT [PK_Hold] PRIMARY KEY CLUSTERED 
(
	[HoldId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patron]    Script Date: 12/10/2020 11:13:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patron](
	[PatronId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[MiddleName] [nvarchar](30) NOT NULL,
	[LastName] [nvarchar](30) NOT NULL,
	[Gender] [int] NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[PrimaryContactNumber] [nvarchar](15) NOT NULL,
	[SecondaryContactNumber] [nvarchar](15) NULL,
	[PrimaryEmail] [nvarchar](100) NOT NULL,
	[SecondaryEmail] [nvarchar](100) NULL,
	[Language] [int] NOT NULL,
	[Section] [int] NOT NULL,
	[ImageFile] [nvarchar](max) NULL,
	[Remark] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
	[RegistrationDate] [date] NOT NULL,
	[UserName] [nvarchar](10) NOT NULL,
	[Password] [nvarchar](15) NOT NULL,
	[PatronType] [int] NOT NULL,
	[LibraryId] [int] NOT NULL,
	[AddressId] [int] NOT NULL,
 CONSTRAINT [PK_Patron] PRIMARY KEY CLUSTERED 
(
	[PatronId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[List_Hold]    Script Date: 12/10/2020 11:13:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[List_Hold]
AS
SELECT        dbo.Library.Name, dbo.Hold.PickupDateTime, dbo.Hold.ExpiryDateTime, dbo.Library_Material.Title, dbo.Patron.FirstName, dbo.Patron.LastName
FROM            dbo.Hold INNER JOIN
                         dbo.Library_Material ON dbo.Hold.LibraryMaterialId = dbo.Library_Material.LibraryMaterialId INNER JOIN
                         dbo.Patron ON dbo.Hold.PatronId = dbo.Patron.PatronId INNER JOIN
                         dbo.Library ON dbo.Library_Material.LibraryId = dbo.Library.LibraryId AND dbo.Patron.LibraryId = dbo.Library.LibraryId
GO
/****** Object:  Table [dbo].[Borrowing]    Script Date: 12/10/2020 11:13:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Borrowing](
	[BorrowingId] [int] IDENTITY(1,1) NOT NULL,
	[BorrowingDateTime] [datetime2](7) NOT NULL,
	[DueDateTime] [datetime2](7) NOT NULL,
	[ReturnDateTime] [datetime2](7) NULL,
	[RenwalDateTime] [datetime2](7) NULL,
	[SignatureFile] [nvarchar](max) NOT NULL,
	[Remark] [nvarchar](max) NULL,
	[LibraryMaterialId] [int] NOT NULL,
	[PatronId] [int] NOT NULL,
 CONSTRAINT [PK_Borrowing] PRIMARY KEY CLUSTERED 
(
	[BorrowingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[List_Borrowing]    Script Date: 12/10/2020 11:13:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[List_Borrowing]
AS
SELECT        dbo.Borrowing.BorrowingDateTime, dbo.Borrowing.DueDateTime, dbo.Library_Material.Title, dbo.Patron.FirstName, dbo.Patron.LastName
FROM            dbo.Borrowing INNER JOIN
                         dbo.Library_Material ON dbo.Borrowing.LibraryMaterialId = dbo.Library_Material.LibraryMaterialId INNER JOIN
                         dbo.Patron ON dbo.Borrowing.PatronId = dbo.Patron.PatronId
GO
/****** Object:  Table [dbo].[Student]    Script Date: 12/10/2020 11:13:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[PatronId] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
	[ClassYear] [nvarchar](5) NOT NULL,
	[ClassName] [nvarchar](5) NOT NULL,
	[AgeLevel] [int] NOT NULL,
	[HomeRoomTeacher] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[PatronId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[List_Student]    Script Date: 12/10/2020 11:13:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[List_Student]
AS
SELECT        dbo.Patron.FirstName, dbo.Patron.MiddleName, dbo.Patron.LastName, dbo.Patron.ImageFile, dbo.Student.StudentId
FROM            dbo.Patron INNER JOIN
                         dbo.Student ON dbo.Patron.PatronId = dbo.Student.PatronId
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 12/10/2020 11:13:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[PatronId] [int] NOT NULL,
	[EmployeeId] [int] NOT NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[PatronId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[List_Teacher]    Script Date: 12/10/2020 11:13:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[List_Teacher]
AS
SELECT        dbo.Patron.FirstName, dbo.Patron.MiddleName, dbo.Patron.LastName, dbo.Teacher.EmployeeId, dbo.Patron.ImageFile
FROM            dbo.Teacher INNER JOIN
                         dbo.Patron ON dbo.Teacher.PatronId = dbo.Patron.PatronId
GO
/****** Object:  Table [dbo].[Parent]    Script Date: 12/10/2020 11:13:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parent](
	[ParentId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[MiddleName] [nvarchar](30) NOT NULL,
	[LastName] [nvarchar](30) NOT NULL,
	[Gender] [int] NOT NULL,
	[Relation] [int] NOT NULL,
	[PrimaryContactNumber] [nvarchar](15) NOT NULL,
	[SecondaryContactNumber] [nvarchar](15) NULL,
	[PrimaryEmail] [nvarchar](100) NOT NULL,
	[SecondaryEmail] [nvarchar](100) NULL,
	[Language] [int] NOT NULL,
	[AddressId] [int] NOT NULL,
 CONSTRAINT [PK_Parent] PRIMARY KEY CLUSTERED 
(
	[ParentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[List_Parent]    Script Date: 12/10/2020 11:13:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[List_Parent]
AS
SELECT        FirstName, MiddleName, LastName, PrimaryContactNumber, PrimaryEmail
FROM            dbo.Parent
GO
/****** Object:  View [dbo].[List_Library]    Script Date: 12/10/2020 11:13:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[List_Library]
AS
SELECT        Name, Section, Status, Description
FROM            dbo.Library
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/10/2020 11:13:51 PM ******/
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
/****** Object:  Table [dbo].[Address]    Script Date: 12/10/2020 11:13:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[AddressId] [int] IDENTITY(5,1) NOT NULL,
	[BuildingNumber] [int] NOT NULL,
	[UnitNumber] [int] NULL,
	[StreetName] [nvarchar](max) NOT NULL,
	[ZipCode] [nvarchar](10) NULL,
	[City] [nvarchar](100) NOT NULL,
	[Country] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 12/10/2020 11:13:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author](
	[AuthorId] [int] IDENTITY(904,1) NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[LastName] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED 
(
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 12/10/2020 11:13:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[LibraryMaterialId] [int] NOT NULL,
	[ISBN] [nvarchar](25) NOT NULL,
	[Edition] [int] NULL,
	[BookType] [int] NOT NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[LibraryMaterialId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CD_DVD_BR]    Script Date: 12/10/2020 11:13:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CD_DVD_BR](
	[LibraryMaterialId] [int] NOT NULL,
	[ISBN] [nvarchar](25) NOT NULL,
	[Format] [nvarchar](80) NOT NULL,
	[Runtime] [nvarchar](50) NULL,
	[Quality] [nvarchar](80) NULL,
	[Subtitles] [nvarchar](100) NULL,
	[Type] [int] NOT NULL,
 CONSTRAINT [PK_CD_DVD_BR] PRIMARY KEY CLUSTERED 
(
	[LibraryMaterialId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 12/10/2020 11:13:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[MiddleName] [nvarchar](30) NULL,
	[LastName] [nvarchar](30) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Mobile] [nvarchar](15) NOT NULL,
	[Language] [int] NOT NULL,
	[Gender] [int] NOT NULL,
	[PhoneExtension] [nvarchar](15) NULL,
	[UserName] [nvarchar](10) NOT NULL,
	[Password] [nvarchar](15) NOT NULL,
	[EmployeeType] [int] NOT NULL,
 CONSTRAINT [PK_Librarian] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Journal]    Script Date: 12/10/2020 11:13:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Journal](
	[LibraryMaterialId] [int] NOT NULL,
	[ISSN] [nvarchar](15) NOT NULL,
	[Volume] [int] NULL,
	[Issue] [int] NULL,
	[JournalType] [int] NOT NULL,
 CONSTRAINT [PK_Journal] PRIMARY KEY CLUSTERED 
(
	[LibraryMaterialId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LibraryMaterial_Author]    Script Date: 12/10/2020 11:13:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LibraryMaterial_Author](
	[LibraryMaterialId] [int] NOT NULL,
	[AuthorId] [int] NOT NULL,
 CONSTRAINT [PK_LibraryMaterial_Author] PRIMARY KEY CLUSTERED 
(
	[LibraryMaterialId] ASC,
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notification]    Script Date: 12/10/2020 11:13:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notification](
	[NotificationId] [int] IDENTITY(1,1) NOT NULL,
	[NotificationDateTime] [datetime2](7) NOT NULL,
	[MessageContent] [nvarchar](max) NOT NULL,
	[NotificationType] [int] NOT NULL,
	[PatronId] [int] NOT NULL,
	[LibrarianId] [int] NOT NULL,
	[TimeSlotId] [int] NOT NULL,
 CONSTRAINT [PK_Notification] PRIMARY KEY CLUSTERED 
(
	[NotificationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Publisher]    Script Date: 12/10/2020 11:13:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publisher](
	[PublisherId] [int] IDENTITY(805,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Publisher] PRIMARY KEY CLUSTERED 
(
	[PublisherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 12/10/2020 11:13:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[ScheduleId] [int] IDENTITY(1,1) NOT NULL,
	[Year] [nvarchar](4) NOT NULL,
	[Semester] [nvarchar](20) NOT NULL,
	[ClassName] [nvarchar](5) NOT NULL,
	[ClassYear] [nvarchar](5) NOT NULL,
	[PatronId] [int] NOT NULL,
 CONSTRAINT [PK_Schedule] PRIMARY KEY CLUSTERED 
(
	[ScheduleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student_Parent]    Script Date: 12/10/2020 11:13:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student_Parent](
	[PatronId] [int] NOT NULL,
	[ParentId] [int] NOT NULL,
 CONSTRAINT [PK_Student_Parent] PRIMARY KEY CLUSTERED 
(
	[PatronId] ASC,
	[ParentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Time_Slot]    Script Date: 12/10/2020 11:13:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Time_Slot](
	[TimeSlotId] [int] IDENTITY(1,1) NOT NULL,
	[WeekDay] [int] NOT NULL,
	[StartTime] [time](7) NOT NULL,
	[EndTime] [time](7) NOT NULL,
	[Year] [nvarchar](4) NOT NULL,
	[Semester] [nvarchar](20) NOT NULL,
	[Reserved] [bit] NOT NULL,
	[ScheduleId] [int] NOT NULL,
	[LibraryId] [int] NOT NULL,
 CONSTRAINT [PK_Time_Slot] PRIMARY KEY CLUSTERED 
(
	[TimeSlotId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex_Author_Name]    Script Date: 12/10/2020 11:13:51 PM ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex_Author_Name] ON [dbo].[Author]
(
	[FirstName] ASC,
	[LastName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex_Book_ISBN]    Script Date: 12/10/2020 11:13:51 PM ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex_Book_ISBN] ON [dbo].[Book]
(
	[ISBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex_CD_DVD_BR_ISBN]    Script Date: 12/10/2020 11:13:51 PM ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex_CD_DVD_BR_ISBN] ON [dbo].[CD_DVD_BR]
(
	[ISBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex_Donor_FirstName]    Script Date: 12/10/2020 11:13:51 PM ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex_Donor_FirstName] ON [dbo].[Donor]
(
	[FirstName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex_Donor_LastName]    Script Date: 12/10/2020 11:13:51 PM ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex_Donor_LastName] ON [dbo].[Donor]
(
	[LastName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex_Donor_MiddleName]    Script Date: 12/10/2020 11:13:51 PM ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex_Donor_MiddleName] ON [dbo].[Donor]
(
	[MiddleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex_Donor_Mobile]    Script Date: 12/10/2020 11:13:51 PM ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex_Donor_Mobile] ON [dbo].[Donor]
(
	[Mobile] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex_Journal_ISSN]    Script Date: 12/10/2020 11:13:51 PM ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex_Journal_ISSN] ON [dbo].[Journal]
(
	[ISSN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex_library_Name]    Script Date: 12/10/2020 11:13:51 PM ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex_library_Name] ON [dbo].[Library]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NonClusteredIndex_LibraryMateialType]    Script Date: 12/10/2020 11:13:51 PM ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex_LibraryMateialType] ON [dbo].[Library_Material]
(
	[LibraryMaterialType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NonClusteredIndex_LibraryMaterial_AcessionNumber]    Script Date: 12/10/2020 11:13:51 PM ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex_LibraryMaterial_AcessionNumber] ON [dbo].[Library_Material]
(
	[AccessionNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NonClusteredIndex_LibraryMaterial_AgeLevel]    Script Date: 12/10/2020 11:13:51 PM ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex_LibraryMaterial_AgeLevel] ON [dbo].[Library_Material]
(
	[AgeLevel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex_LibraryMaterial_Genre]    Script Date: 12/10/2020 11:13:51 PM ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex_LibraryMaterial_Genre] ON [dbo].[Library_Material]
(
	[Genre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex_LibraryMaterial_Subject]    Script Date: 12/10/2020 11:13:51 PM ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex_LibraryMaterial_Subject] ON [dbo].[Library_Material]
(
	[Subject] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex_Parent_FirstName]    Script Date: 12/10/2020 11:13:51 PM ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex_Parent_FirstName] ON [dbo].[Parent]
(
	[FirstName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex_Parent_LastName]    Script Date: 12/10/2020 11:13:51 PM ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex_Parent_LastName] ON [dbo].[Parent]
(
	[LastName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex_Parent_MiddleName]    Script Date: 12/10/2020 11:13:51 PM ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex_Parent_MiddleName] ON [dbo].[Parent]
(
	[MiddleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex_Parent_PrimaryContactNumber]    Script Date: 12/10/2020 11:13:51 PM ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex_Parent_PrimaryContactNumber] ON [dbo].[Parent]
(
	[PrimaryContactNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex_Patron_FirstName]    Script Date: 12/10/2020 11:13:51 PM ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex_Patron_FirstName] ON [dbo].[Patron]
(
	[FirstName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex_Patron_LastName]    Script Date: 12/10/2020 11:13:51 PM ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex_Patron_LastName] ON [dbo].[Patron]
(
	[LastName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex_Patron_MiddleName]    Script Date: 12/10/2020 11:13:51 PM ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex_Patron_MiddleName] ON [dbo].[Patron]
(
	[MiddleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NonClusteredIndex_Patron_Section]    Script Date: 12/10/2020 11:13:51 PM ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex_Patron_Section] ON [dbo].[Patron]
(
	[Section] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex_Publisher_Name]    Script Date: 12/10/2020 11:13:51 PM ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex_Publisher_Name] ON [dbo].[Publisher]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex__Student_ClassName]    Script Date: 12/10/2020 11:13:51 PM ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex__Student_ClassName] ON [dbo].[Student]
(
	[ClassName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [NonClusteredIndex_ClassYear]    Script Date: 12/10/2020 11:13:51 PM ******/
CREATE NONCLUSTERED INDEX [NonClusteredIndex_ClassYear] ON [dbo].[Student]
(
	[ClassYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NonClusteredIndex_StudentId]    Script Date: 12/10/2020 11:13:51 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [NonClusteredIndex_StudentId] ON [dbo].[Student]
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [NonClusteredIndex_Teacher_EmployeeId]    Script Date: 12/10/2020 11:13:51 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [NonClusteredIndex_Teacher_EmployeeId] ON [dbo].[Teacher]
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Book] ADD  CONSTRAINT [DF_Book_BookType]  DEFAULT ((1)) FOR [BookType]
GO
ALTER TABLE [dbo].[CD_DVD_BR] ADD  CONSTRAINT [DF_CD_DVD_BR_Type]  DEFAULT ((1)) FOR [Type]
GO
ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [DF_Employee_Language]  DEFAULT ((1)) FOR [Language]
GO
ALTER TABLE [dbo].[Hold] ADD  CONSTRAINT [DF_Hold_HoldStatus]  DEFAULT ((0)) FOR [HoldStatus]
GO
ALTER TABLE [dbo].[Journal] ADD  CONSTRAINT [DF_Journal_JournalType]  DEFAULT ((1)) FOR [JournalType]
GO
ALTER TABLE [dbo].[Library] ADD  CONSTRAINT [DF_Library_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Library_Material] ADD  CONSTRAINT [DF_LibraryMaterial_Language]  DEFAULT ((1)) FOR [Language]
GO
ALTER TABLE [dbo].[Library_Material] ADD  CONSTRAINT [DF_LibraryMaterial_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Library_Material] ADD  CONSTRAINT [DF_LibraryMaterial_LibraryMateralType]  DEFAULT ((1)) FOR [LibraryMaterialType]
GO
ALTER TABLE [dbo].[Parent] ADD  CONSTRAINT [DF_Parent_Language]  DEFAULT ((2)) FOR [Language]
GO
ALTER TABLE [dbo].[Patron] ADD  CONSTRAINT [DF_Patron_Language]  DEFAULT ((1)) FOR [Language]
GO
ALTER TABLE [dbo].[Patron] ADD  CONSTRAINT [DF_Patron_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Time_Slot] ADD  CONSTRAINT [DF_Time_Slot_Reserved]  DEFAULT ((0)) FOR [Reserved]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_LibraryMaterial] FOREIGN KEY([LibraryMaterialId])
REFERENCES [dbo].[Library_Material] ([LibraryMaterialId])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_LibraryMaterial]
GO
ALTER TABLE [dbo].[Borrowing]  WITH CHECK ADD  CONSTRAINT [FK_Borrowing_LibraryMaterial] FOREIGN KEY([LibraryMaterialId])
REFERENCES [dbo].[Library_Material] ([LibraryMaterialId])
GO
ALTER TABLE [dbo].[Borrowing] CHECK CONSTRAINT [FK_Borrowing_LibraryMaterial]
GO
ALTER TABLE [dbo].[Borrowing]  WITH CHECK ADD  CONSTRAINT [FK_Borrowing_Patron] FOREIGN KEY([PatronId])
REFERENCES [dbo].[Patron] ([PatronId])
GO
ALTER TABLE [dbo].[Borrowing] CHECK CONSTRAINT [FK_Borrowing_Patron]
GO
ALTER TABLE [dbo].[CD_DVD_BR]  WITH CHECK ADD  CONSTRAINT [FK_CD_DVD_BR_LibraryMaterial] FOREIGN KEY([LibraryMaterialId])
REFERENCES [dbo].[Library_Material] ([LibraryMaterialId])
GO
ALTER TABLE [dbo].[CD_DVD_BR] CHECK CONSTRAINT [FK_CD_DVD_BR_LibraryMaterial]
GO
ALTER TABLE [dbo].[Hold]  WITH CHECK ADD  CONSTRAINT [FK_Hold_LibraryMaterial] FOREIGN KEY([LibraryMaterialId])
REFERENCES [dbo].[Library_Material] ([LibraryMaterialId])
GO
ALTER TABLE [dbo].[Hold] CHECK CONSTRAINT [FK_Hold_LibraryMaterial]
GO
ALTER TABLE [dbo].[Hold]  WITH CHECK ADD  CONSTRAINT [FK_Hold_Patron] FOREIGN KEY([PatronId])
REFERENCES [dbo].[Patron] ([PatronId])
GO
ALTER TABLE [dbo].[Hold] CHECK CONSTRAINT [FK_Hold_Patron]
GO
ALTER TABLE [dbo].[Journal]  WITH CHECK ADD  CONSTRAINT [FK_Journal_LibraryMaterial] FOREIGN KEY([LibraryMaterialId])
REFERENCES [dbo].[Library_Material] ([LibraryMaterialId])
GO
ALTER TABLE [dbo].[Journal] CHECK CONSTRAINT [FK_Journal_LibraryMaterial]
GO
ALTER TABLE [dbo].[Library]  WITH CHECK ADD  CONSTRAINT [FK_Library_Address] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Address] ([AddressId])
GO
ALTER TABLE [dbo].[Library] CHECK CONSTRAINT [FK_Library_Address]
GO
ALTER TABLE [dbo].[Library]  WITH CHECK ADD  CONSTRAINT [FK_Library_Librarian] FOREIGN KEY([LibrarianId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[Library] CHECK CONSTRAINT [FK_Library_Librarian]
GO
ALTER TABLE [dbo].[Library_Material]  WITH CHECK ADD  CONSTRAINT [FK_LibraryMaterial_Donor] FOREIGN KEY([DonorId])
REFERENCES [dbo].[Donor] ([DonorId])
GO
ALTER TABLE [dbo].[Library_Material] CHECK CONSTRAINT [FK_LibraryMaterial_Donor]
GO
ALTER TABLE [dbo].[Library_Material]  WITH CHECK ADD  CONSTRAINT [FK_LibraryMaterial_Library] FOREIGN KEY([LibraryId])
REFERENCES [dbo].[Library] ([LibraryId])
GO
ALTER TABLE [dbo].[Library_Material] CHECK CONSTRAINT [FK_LibraryMaterial_Library]
GO
ALTER TABLE [dbo].[Library_Material]  WITH CHECK ADD  CONSTRAINT [FK_LibraryMaterial_Publisher] FOREIGN KEY([PublisherId])
REFERENCES [dbo].[Publisher] ([PublisherId])
GO
ALTER TABLE [dbo].[Library_Material] CHECK CONSTRAINT [FK_LibraryMaterial_Publisher]
GO
ALTER TABLE [dbo].[LibraryMaterial_Author]  WITH CHECK ADD  CONSTRAINT [FK_LibraryMaterial_Author_Author] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Author] ([AuthorId])
GO
ALTER TABLE [dbo].[LibraryMaterial_Author] CHECK CONSTRAINT [FK_LibraryMaterial_Author_Author]
GO
ALTER TABLE [dbo].[LibraryMaterial_Author]  WITH CHECK ADD  CONSTRAINT [FK_LibraryMaterial_Author_LibraryMaterial] FOREIGN KEY([LibraryMaterialId])
REFERENCES [dbo].[Library_Material] ([LibraryMaterialId])
GO
ALTER TABLE [dbo].[LibraryMaterial_Author] CHECK CONSTRAINT [FK_LibraryMaterial_Author_LibraryMaterial]
GO
ALTER TABLE [dbo].[Notification]  WITH CHECK ADD  CONSTRAINT [FK_Notification_Librarian] FOREIGN KEY([LibrarianId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[Notification] CHECK CONSTRAINT [FK_Notification_Librarian]
GO
ALTER TABLE [dbo].[Notification]  WITH CHECK ADD  CONSTRAINT [FK_Notification_Patron] FOREIGN KEY([PatronId])
REFERENCES [dbo].[Patron] ([PatronId])
GO
ALTER TABLE [dbo].[Notification] CHECK CONSTRAINT [FK_Notification_Patron]
GO
ALTER TABLE [dbo].[Notification]  WITH CHECK ADD  CONSTRAINT [FK_Notification_Time_Slot] FOREIGN KEY([TimeSlotId])
REFERENCES [dbo].[Time_Slot] ([TimeSlotId])
GO
ALTER TABLE [dbo].[Notification] CHECK CONSTRAINT [FK_Notification_Time_Slot]
GO
ALTER TABLE [dbo].[Parent]  WITH CHECK ADD  CONSTRAINT [FK_Parent_Address] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Address] ([AddressId])
GO
ALTER TABLE [dbo].[Parent] CHECK CONSTRAINT [FK_Parent_Address]
GO
ALTER TABLE [dbo].[Patron]  WITH CHECK ADD  CONSTRAINT [FK_Patron_Address] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Address] ([AddressId])
GO
ALTER TABLE [dbo].[Patron] CHECK CONSTRAINT [FK_Patron_Address]
GO
ALTER TABLE [dbo].[Patron]  WITH CHECK ADD  CONSTRAINT [FK_Patron_Library] FOREIGN KEY([LibraryId])
REFERENCES [dbo].[Library] ([LibraryId])
GO
ALTER TABLE [dbo].[Patron] CHECK CONSTRAINT [FK_Patron_Library]
GO
ALTER TABLE [dbo].[Schedule]  WITH CHECK ADD  CONSTRAINT [FK_Schedule_Patron] FOREIGN KEY([PatronId])
REFERENCES [dbo].[Patron] ([PatronId])
GO
ALTER TABLE [dbo].[Schedule] CHECK CONSTRAINT [FK_Schedule_Patron]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Patron] FOREIGN KEY([PatronId])
REFERENCES [dbo].[Patron] ([PatronId])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Patron]
GO
ALTER TABLE [dbo].[Student_Parent]  WITH CHECK ADD  CONSTRAINT [FK_Student_Parent_Parent] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Parent] ([ParentId])
GO
ALTER TABLE [dbo].[Student_Parent] CHECK CONSTRAINT [FK_Student_Parent_Parent]
GO
ALTER TABLE [dbo].[Student_Parent]  WITH CHECK ADD  CONSTRAINT [FK_Student_Parent_Student] FOREIGN KEY([PatronId])
REFERENCES [dbo].[Student] ([PatronId])
GO
ALTER TABLE [dbo].[Student_Parent] CHECK CONSTRAINT [FK_Student_Parent_Student]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Patron] FOREIGN KEY([PatronId])
REFERENCES [dbo].[Patron] ([PatronId])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_Patron]
GO
ALTER TABLE [dbo].[Time_Slot]  WITH CHECK ADD  CONSTRAINT [FK_Time_Slot_Library] FOREIGN KEY([LibraryId])
REFERENCES [dbo].[Library] ([LibraryId])
GO
ALTER TABLE [dbo].[Time_Slot] CHECK CONSTRAINT [FK_Time_Slot_Library]
GO
ALTER TABLE [dbo].[Time_Slot]  WITH CHECK ADD  CONSTRAINT [FK_Time_Slot_Schedule] FOREIGN KEY([ScheduleId])
REFERENCES [dbo].[Schedule] ([ScheduleId])
GO
ALTER TABLE [dbo].[Time_Slot] CHECK CONSTRAINT [FK_Time_Slot_Schedule]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [CK_Book_ISBN] CHECK  (([ISBN] like '[0-9][0-9][0-9]-[0-9]-[0-9][0-9]-[0-9][0-9][0-9][0-9][0-9][0-9]-[0-9]'))
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [CK_Book_ISBN]
GO
ALTER TABLE [dbo].[CD_DVD_BR]  WITH CHECK ADD  CONSTRAINT [CK_CD_DVD_BR_ISBN] CHECK  (([ISBN] like '[0-9][0-9][0-9]-[0-9]-[0-9][0-9]-[0-9][0-9][0-9][0-9][0-9][0-9]-[0-9]'))
GO
ALTER TABLE [dbo].[CD_DVD_BR] CHECK CONSTRAINT [CK_CD_DVD_BR_ISBN]
GO
ALTER TABLE [dbo].[Donor]  WITH CHECK ADD  CONSTRAINT [CK_Donor_Mobille] CHECK  (([Mobile] like '0[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[Donor] CHECK CONSTRAINT [CK_Donor_Mobille]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [CK_Employee_Mobile] CHECK  (([Mobile] like '0[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [CK_Employee_Mobile]
GO
ALTER TABLE [dbo].[Journal]  WITH CHECK ADD  CONSTRAINT [CK_Journal_ISSN] CHECK  (([ISSN] like '[0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[Journal] CHECK CONSTRAINT [CK_Journal_ISSN]
GO
ALTER TABLE [dbo].[Parent]  WITH CHECK ADD  CONSTRAINT [CK_Parent_PrimaryContactNumber] CHECK  (([PrimaryContactNumber] like '0[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[Parent] CHECK CONSTRAINT [CK_Parent_PrimaryContactNumber]
GO
ALTER TABLE [dbo].[Parent]  WITH CHECK ADD  CONSTRAINT [CK_Parent_SecondaryContactNumber] CHECK  (([SecondaryContactNumber] like '0[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[Parent] CHECK CONSTRAINT [CK_Parent_SecondaryContactNumber]
GO
ALTER TABLE [dbo].[Patron]  WITH CHECK ADD  CONSTRAINT [CK_Patron_PrimaryContactNumber] CHECK  (([PrimaryContactNumber] like '0[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[Patron] CHECK CONSTRAINT [CK_Patron_PrimaryContactNumber]
GO
ALTER TABLE [dbo].[Patron]  WITH CHECK ADD  CONSTRAINT [CK_Patron_SecondaryContactNumber] CHECK  (([SecondaryContactNumber] like '0[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'))
GO
ALTER TABLE [dbo].[Patron] CHECK CONSTRAINT [CK_Patron_SecondaryContactNumber]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Borrowing"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 232
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Library_Material"
            Begin Extent = 
               Top = 6
               Left = 270
               Bottom = 136
               Right = 504
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "Patron"
            Begin Extent = 
               Top = 6
               Left = 542
               Bottom = 136
               Right = 772
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'List_Borrowing'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'List_Borrowing'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Donor"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Library_Material"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 480
            End
            DisplayFlags = 280
            TopColumn = 2
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'List_Donor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'List_Donor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Hold"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 216
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Library_Material"
            Begin Extent = 
               Top = 6
               Left = 254
               Bottom = 136
               Right = 488
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "Patron"
            Begin Extent = 
               Top = 6
               Left = 526
               Bottom = 136
               Right = 756
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "Library"
            Begin Extent = 
               Top = 6
               Left = 794
               Bottom = 136
               Right = 964
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'List_Hold'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'List_Hold'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Library"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 163
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 2
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'List_Library'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'List_Library'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Parent"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 268
            End
            DisplayFlags = 280
            TopColumn = 8
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'List_Parent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'List_Parent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Patron"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 268
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Student"
            Begin Extent = 
               Top = 6
               Left = 306
               Bottom = 136
               Right = 501
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'List_Student'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'List_Student'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Teacher"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 102
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Patron"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 476
            End
            DisplayFlags = 280
            TopColumn = 9
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'List_Teacher'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'List_Teacher'
GO
USE [master]
GO
ALTER DATABASE [LibraryManagementSystem] SET  READ_WRITE 
GO
