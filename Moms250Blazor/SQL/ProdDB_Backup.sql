/****** Object:  Database [Moms250Blazor]    Script Date: 2/12/2024 1:40:44 AM ******/
--CREATE DATABASE [Moms250Blazor]  (EDITION = 'Basic', SERVICE_OBJECTIVE = 'Basic', MAXSIZE = 2 GB) WITH CATALOG_COLLATION = SQL_Latin1_General_CP1_CI_AS, LEDGER = OFF;
--GO
--ALTER DATABASE [Moms250Blazor] SET COMPATIBILITY_LEVEL = 150
--GO
--ALTER DATABASE [Moms250Blazor] SET ANSI_NULL_DEFAULT OFF 
--GO
--ALTER DATABASE [Moms250Blazor] SET ANSI_NULLS OFF 
--GO
--ALTER DATABASE [Moms250Blazor] SET ANSI_PADDING OFF 
--GO
--ALTER DATABASE [Moms250Blazor] SET ANSI_WARNINGS OFF 
--GO
--ALTER DATABASE [Moms250Blazor] SET ARITHABORT OFF 
--GO
--ALTER DATABASE [Moms250Blazor] SET AUTO_SHRINK OFF 
--GO
--ALTER DATABASE [Moms250Blazor] SET AUTO_UPDATE_STATISTICS ON 
--GO
--ALTER DATABASE [Moms250Blazor] SET CURSOR_CLOSE_ON_COMMIT OFF 
--GO
--ALTER DATABASE [Moms250Blazor] SET CONCAT_NULL_YIELDS_NULL OFF 
--GO
--ALTER DATABASE [Moms250Blazor] SET NUMERIC_ROUNDABORT OFF 
--GO
--ALTER DATABASE [Moms250Blazor] SET QUOTED_IDENTIFIER OFF 
--GO
--ALTER DATABASE [Moms250Blazor] SET RECURSIVE_TRIGGERS OFF 
--GO
--ALTER DATABASE [Moms250Blazor] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
--GO
--ALTER DATABASE [Moms250Blazor] SET ALLOW_SNAPSHOT_ISOLATION ON 
--GO
--ALTER DATABASE [Moms250Blazor] SET PARAMETERIZATION SIMPLE 
--GO
--ALTER DATABASE [Moms250Blazor] SET READ_COMMITTED_SNAPSHOT ON 
--GO
--ALTER DATABASE [Moms250Blazor] SET  MULTI_USER 
--GO
--ALTER DATABASE [Moms250Blazor] SET ENCRYPTION ON
--GO
--ALTER DATABASE [Moms250Blazor] SET QUERY_STORE = ON
--GO
--ALTER DATABASE [Moms250Blazor] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 7), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 10, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
--GO
/*** The scripts of database scoped configurations in Azure should be executed inside the target database connection. ***/
GO
-- ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 8;
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2/12/2024 1:40:44 AM ******/
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
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 2/12/2024 1:40:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 2/12/2024 1:40:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 2/12/2024 1:40:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 2/12/2024 1:40:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 2/12/2024 1:40:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 2/12/2024 1:40:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
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
	[Active] [bit] NOT NULL,
	[AppAngel] [bit] NOT NULL,
	[ApplicationUserId] [int] IDENTITY(1,1) NOT NULL,
	[Chapter] [nvarchar](max) NULL,
	[Comments] [nvarchar](max) NULL,
	[Coordinator] [bit] NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[FullName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[ManagerId] [nvarchar](max) NULL,
	[Modified] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](max) NOT NULL,
	[NationalChair] [bit] NOT NULL,
	[PreferencesAndSkills] [nvarchar](max) NULL,
	[Residence] [nvarchar](max) NULL,
	[SeniorCoordinator] [bit] NOT NULL,
	[State] [nvarchar](max) NULL,
	[Volunteer] [bit] NOT NULL,
	[RadzenDataGridPageSizePref] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 2/12/2024 1:40:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Assignments]    Script Date: 2/12/2024 1:40:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assignments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ApplicantFullName] [nvarchar](350) NULL,
	[ApplicantFName] [nvarchar](150) NULL,
	[ApplicantLName] [nvarchar](150) NULL,
	[ApplicantState] [char](2) NULL,
	[ApplicantChapter] [nvarchar](50) NULL,
	[ApplicationType] [nvarchar](50) NULL,
	[ApplicationStatus] [nvarchar](50) NULL,
	[ApplicationDateAssigned] [datetime2](7) NULL,
	[ChapterContact] [nvarchar](150) NULL,
	[Registrar] [bit] NULL,
	[ChapterContactEmail] [nvarchar](255) NULL,
	[VerifyingGenie] [nvarchar](150) NULL,
	[FirstReview] [datetime2](7) NULL,
	[DateOfLastAIRLetter] [datetime2](7) NULL,
	[ResponseDate] [datetime2](7) NULL,
	[DateComplete] [datetime2](7) NULL,
	[NCUpdateRequested] [bit] NULL,
	[HelpRequest] [bit] NULL,
	[ReassignmentRequest] [bit] NULL,
	[AAARequest] [bit] NULL,
	[ARTRequest] [bit] NULL,
	[SeniorCoordinatorRequest] [bit] NULL,
	[CoordinatorRequest] [bit] NULL,
	[ReturnRequest] [bit] NULL,
	[DocReceived] [bit] NULL,
	[PermissionLetter] [bit] NULL,
	[SelectedCoordinator] [nvarchar](max) NULL,
	[StateProblem] [nvarchar](max) NULL,
	[Notes] [nvarchar](max) NULL,
	[LastContactWithChapterDate] [datetime2](7) NULL,
	[MemberInitials] [nvarchar](10) NULL,
	[VolunteerContactChapter] [bit] NULL,
	[SpecialTeamRequest] [bit] NULL,
	[PatriotNumber] [nvarchar](10) NULL,
	[PatriotName] [nvarchar](150) NULL,
	[NewChildOfPatriot] [bit] NULL,
	[NewPatriot] [bit] NULL,
	[Correction] [bit] NULL,
	[Created] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](150) NOT NULL,
	[Modified] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Assignments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Attachments]    Script Date: 2/12/2024 1:40:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attachments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AssignmentID] [int] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Type] [nvarchar](150) NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](150) NOT NULL,
	[Modified] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Attachments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AttachmentsForAll]    Script Date: 2/12/2024 1:40:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttachmentsForAll](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Group] [nvarchar](250) NOT NULL,
	[Type] [nvarchar](150) NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](150) NOT NULL,
	[Modified] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_AttachmentsForAll] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExceptionLog]    Script Date: 2/12/2024 1:40:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExceptionLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NULL,
	[StackTrace] [nvarchar](max) NULL,
	[Object] [nvarchar](max) NULL,
	[Created] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](150) NOT NULL,
	[Modified] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_ExceptionLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State]    Script Date: 2/12/2024 1:40:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[StateAb] [char](2) NOT NULL,
	[Name] [nvarchar](150) NULL,
	[Created] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](150) NOT NULL,
	[Modified] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[StateAb] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Volunteers]    Script Date: 2/12/2024 1:40:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Volunteers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AppUserId] [int] NOT NULL,
	[AssignmentId] [int] NOT NULL,
	[DateAssigned] [datetime2](7) NOT NULL,
	[LeadVolunteer] [bit] NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](150) NOT NULL,
	[Modified] [datetime2](7) NOT NULL,
	[ModifiedBy] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Volunteers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'00000000000000_CreateIdentitySchema', N'8.0.0')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240101003630_Initial', N'8.0.0')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240101004712_AddRestOfDatabase', N'8.0.0')
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240101012713_AddRadzenDataGridPageSizePrefToUser', N'8.0.0')
GO
SET IDENTITY_INSERT [dbo].[AspNetUsers] ON 
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Active], [AppAngel], [ApplicationUserId], [Chapter], [Comments], [Coordinator], [Created], [CreatedBy], [FirstName], [FullName], [LastName], [ManagerId], [Modified], [ModifiedBy], [NationalChair], [PreferencesAndSkills], [Residence], [SeniorCoordinator], [State], [Volunteer], [RadzenDataGridPageSizePref]) VALUES (N'2a2e8830-a356-45c9-a360-5fce7dd38cbc', N'000004', N'000004', N'test4@gmail.com', N'TEST4@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEKb3wp3OKR5CAfBXVrI7SXazC3Ly/Be2m2n0RmXe18+yIamMDZd3jrmFMwxa3hI+tA==', N'NKHSHWNU76Z2ZGQLQQ43TMFSVEDIISTG', N'cd2dddc2-bb40-480a-a13d-6d1a4ff0b458', N'555-555-5555', 0, 0, NULL, 1, 0, 1, 1, 6, N'Los Angeles Army', N'Works in the CIA', 1, CAST(N'2024-02-12T06:19:15.1787350' AS DateTime2), N'System', N'Al', N'Dillon, Al', N'Dillon', NULL, CAST(N'2024-02-12T06:19:15.1787360' AS DateTime2), N'System', 0, N'Colonel', N'Los Angeles, CA', 1, N'CA', 1, 15)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Active], [AppAngel], [ApplicationUserId], [Chapter], [Comments], [Coordinator], [Created], [CreatedBy], [FirstName], [FullName], [LastName], [ManagerId], [Modified], [ModifiedBy], [NationalChair], [PreferencesAndSkills], [Residence], [SeniorCoordinator], [State], [Volunteer], [RadzenDataGridPageSizePref]) VALUES (N'5826ae0c-7653-4e89-bfd5-8cc4c40cf685', N'000002', N'000002', N'test2@gmail.com', N'TEST2@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAECDoRRNOqPrq/Wg6dQVtyr+YMxbVVkl5xtHSywfZDBWmvF86asBkCzYxoIPpj9kKMw==', N'AFZ43TBUSIFVM34HIGULIZ25JHG5CYUX', N'dc2aa282-9d4a-4e36-8fde-a933c719cf1a', N'555-333-6789', 0, 0, NULL, 1, 0, 1, 1, 4, N'Kansas Corner', N'Makes plays', 1, CAST(N'2024-02-12T06:11:31.4848678' AS DateTime2), N'System', N'Travis', N'Kelce, Travis', N'Kelce', N'6ba3d3c2-9f3b-40a9-956e-2f218de234f7', CAST(N'2024-02-12T06:11:31.4848691' AS DateTime2), N'System', 0, N'Tight-End', N'Kansas City, KS', 0, N'KS', 1, 15)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Active], [AppAngel], [ApplicationUserId], [Chapter], [Comments], [Coordinator], [Created], [CreatedBy], [FirstName], [FullName], [LastName], [ManagerId], [Modified], [ModifiedBy], [NationalChair], [PreferencesAndSkills], [Residence], [SeniorCoordinator], [State], [Volunteer], [RadzenDataGridPageSizePref]) VALUES (N'6ba3d3c2-9f3b-40a9-956e-2f218de234f7', N'000003', N'000003', N'test3@gmail.com', N'TEST3@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEP8MOfd9ruo44KITCL73vKi4FygJdvYZqB50beslutpd0f909e1sdc+ttYbjx2A9lA==', N'NCZZORFNJXPYOHL7555QZBCAADB3S6D6', N'36927940-18b1-4de7-947a-007ffd93b401', N'555-234-1234', 0, 0, NULL, 1, 0, 1, 1, 5, N'Kansas Corner', N'Calls plays', 1, CAST(N'2024-02-12T06:13:07.9596097' AS DateTime2), N'System', N'Andy', N'Reid, Andy', N'Reid', N'', CAST(N'2024-02-12T06:13:07.9596112' AS DateTime2), N'System', 0, N'Coach', N'Kansas City, KS', 0, N'KS', 1, 15)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Active], [AppAngel], [ApplicationUserId], [Chapter], [Comments], [Coordinator], [Created], [CreatedBy], [FirstName], [FullName], [LastName], [ManagerId], [Modified], [ModifiedBy], [NationalChair], [PreferencesAndSkills], [Residence], [SeniorCoordinator], [State], [Volunteer], [RadzenDataGridPageSizePref]) VALUES (N'7d0b2b4b-e930-42ea-ae90-704aaa202812', N'000005', N'000005', N'test5@gmail.com', N'TEST5@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEKFtE25pZDMmp7z48k0q7rFl6fuusOtyiOicnBTa1p0qF1U8M9w36FJKD/xCwB7T/g==', N'B75PYQ2CTDPVXVZGBLSYZFVSF27URR2K', N'd51ec874-b477-42b7-8d4a-10a153ccea9f', N'555-432-1111', 0, 0, NULL, 1, 0, 1, 1, 7, N'Los Angeles Army', N'Private Military', 1, CAST(N'2024-02-12T06:21:45.2045215' AS DateTime2), N'System', N'Dutch', N'Schaefer, Dutch', N'Schaefer', N'2a2e8830-a356-45c9-a360-5fce7dd38cbc', CAST(N'2024-02-12T06:21:45.2045224' AS DateTime2), N'System', 0, N'Major', N'Los Angeles, CA', 0, N'CA', 1, 15)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Active], [AppAngel], [ApplicationUserId], [Chapter], [Comments], [Coordinator], [Created], [CreatedBy], [FirstName], [FullName], [LastName], [ManagerId], [Modified], [ModifiedBy], [NationalChair], [PreferencesAndSkills], [Residence], [SeniorCoordinator], [State], [Volunteer], [RadzenDataGridPageSizePref]) VALUES (N'85396555-79b1-44d2-91c9-6c77596a8908', N'000006', N'000006', N'test6@gmail.com', N'TEST6@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEGkeYMuGPsUWbO2ytSe3TdsJDnkfzDb4nbCHO5TTyIEJXE+S9yQOIzmK4UmbHyPHiQ==', N'HU6MY4USYYRB72I4NJUSWUN5INZCM67F', N'2c9bb321-902e-4972-87fa-cb894fa23dfe', N'555-334-5678', 0, 0, NULL, 1, 0, 1, 1, 8, N'Los Angeles Army', N'Private Military', 1, CAST(N'2024-02-12T06:23:54.3091810' AS DateTime2), N'System', N'Mac', N'Eliot, Mac', N'Eliot', N'7d0b2b4b-e930-42ea-ae90-704aaa202812', CAST(N'2024-02-12T06:23:54.3091820' AS DateTime2), N'System', 0, N'Sergeant', N'Los Angeles, CA', 0, N'CA', 1, 15)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Active], [AppAngel], [ApplicationUserId], [Chapter], [Comments], [Coordinator], [Created], [CreatedBy], [FirstName], [FullName], [LastName], [ManagerId], [Modified], [ModifiedBy], [NationalChair], [PreferencesAndSkills], [Residence], [SeniorCoordinator], [State], [Volunteer], [RadzenDataGridPageSizePref]) VALUES (N'cb72809a-cc5a-42b0-9ce9-0d578c0b2d4e', N'000001', N'000001', N'test1@gmail.com', N'TEST1@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEJA63olkj9+pluIxYsWoKfpuYWy9FEeB70EOBs+rgERD2+ivGR6WeZW3u8QweMSL0Q==', N'PVEV3KELFHA3YYB5LGMAOH2RHGD2JOHU', N'b74db5a0-36b2-49b5-84b8-17de94e8f8cd', N'555-555-1234', 0, 0, NULL, 1, 0, 1, 1, 3, N'Hollywood Hills', N'Sells Tickets', 1, CAST(N'2024-02-11T23:15:50.4327970' AS DateTime2), N'System', N'Rocky', N'Balboa, Rocky', N'Balboa', NULL, CAST(N'2024-02-11T23:15:50.4327977' AS DateTime2), N'System', 0, N'Boxer', N'Hollywood, CA', 0, N'CA', 1, 15)
GO
SET IDENTITY_INSERT [dbo].[AspNetUsers] OFF
GO
SET IDENTITY_INSERT [dbo].[Assignments] ON 
GO
INSERT [dbo].[Assignments] ([Id], [ApplicantFullName], [ApplicantFName], [ApplicantLName], [ApplicantState], [ApplicantChapter], [ApplicationType], [ApplicationStatus], [ApplicationDateAssigned], [ChapterContact], [Registrar], [ChapterContactEmail], [VerifyingGenie], [FirstReview], [DateOfLastAIRLetter], [ResponseDate], [DateComplete], [NCUpdateRequested], [HelpRequest], [ReassignmentRequest], [AAARequest], [ARTRequest], [SeniorCoordinatorRequest], [CoordinatorRequest], [ReturnRequest], [DocReceived], [PermissionLetter], [SelectedCoordinator], [StateProblem], [Notes], [LastContactWithChapterDate], [MemberInitials], [VolunteerContactChapter], [SpecialTeamRequest], [PatriotNumber], [PatriotName], [NewChildOfPatriot], [NewPatriot], [Correction], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (29, N'Rock, The', N'The', N'Rock', N'IL', N'Rock''s Place', N'AIR', N'verified', CAST(N'2024-02-07T00:00:00.0000000' AS DateTime2), N'Chapter Contact 1', NULL, N'test@gmail.com', N'Erik Cheatham', NULL, CAST(N'2024-02-06T00:00:00.0000000' AS DateTime2), CAST(N'2024-02-05T00:00:00.0000000' AS DateTime2), CAST(N'2024-02-04T00:00:00.0000000' AS DateTime2), 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, N'Test', N'Testing Notes Testing', CAST(N'2024-02-08T00:00:00.0000000' AS DateTime2), N'EIC', NULL, NULL, NULL, NULL, NULL, 1, NULL, CAST(N'2024-02-11T13:48:02.0850222' AS DateTime2), N'Cheatham, Erik', CAST(N'2024-02-11T13:45:58.5038169' AS DateTime2), N'System')
GO
INSERT [dbo].[Assignments] ([Id], [ApplicantFullName], [ApplicantFName], [ApplicantLName], [ApplicantState], [ApplicantChapter], [ApplicationType], [ApplicationStatus], [ApplicationDateAssigned], [ChapterContact], [Registrar], [ChapterContactEmail], [VerifyingGenie], [FirstReview], [DateOfLastAIRLetter], [ResponseDate], [DateComplete], [NCUpdateRequested], [HelpRequest], [ReassignmentRequest], [AAARequest], [ARTRequest], [SeniorCoordinatorRequest], [CoordinatorRequest], [ReturnRequest], [DocReceived], [PermissionLetter], [SelectedCoordinator], [StateProblem], [Notes], [LastContactWithChapterDate], [MemberInitials], [VolunteerContactChapter], [SpecialTeamRequest], [PatriotNumber], [PatriotName], [NewChildOfPatriot], [NewPatriot], [Correction], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (30, N'Diesel, Vin', N'Vin', N'Diesel', N'IL', N'Diesel''s Bluff', N'AIR Letter', N'removed', CAST(N'2024-02-01T00:00:00.0000000' AS DateTime2), N'Chapter Contact 2', NULL, N'test@gmail.com', N'Erik Cheatham', CAST(N'2024-01-31T00:00:00.0000000' AS DateTime2), CAST(N'2024-02-02T00:00:00.0000000' AS DateTime2), CAST(N'2024-02-03T00:00:00.0000000' AS DateTime2), CAST(N'2024-02-04T00:00:00.0000000' AS DateTime2), NULL, 1, 1, NULL, NULL, NULL, NULL, 1, 1, NULL, NULL, N'Testing Notes', N'Coordinator Reassign Application', CAST(N'2024-02-10T00:00:00.0000000' AS DateTime2), N'EIC', NULL, 1, N'000001', N'Grandpa Diesel', NULL, 1, NULL, CAST(N'2024-02-11T13:50:28.6280736' AS DateTime2), N'Cheatham, Erik', CAST(N'2024-02-11T13:48:07.8427727' AS DateTime2), N'System')
GO
INSERT [dbo].[Assignments] ([Id], [ApplicantFullName], [ApplicantFName], [ApplicantLName], [ApplicantState], [ApplicantChapter], [ApplicationType], [ApplicationStatus], [ApplicationDateAssigned], [ChapterContact], [Registrar], [ChapterContactEmail], [VerifyingGenie], [FirstReview], [DateOfLastAIRLetter], [ResponseDate], [DateComplete], [NCUpdateRequested], [HelpRequest], [ReassignmentRequest], [AAARequest], [ARTRequest], [SeniorCoordinatorRequest], [CoordinatorRequest], [ReturnRequest], [DocReceived], [PermissionLetter], [SelectedCoordinator], [StateProblem], [Notes], [LastContactWithChapterDate], [MemberInitials], [VolunteerContactChapter], [SpecialTeamRequest], [PatriotNumber], [PatriotName], [NewChildOfPatriot], [NewPatriot], [Correction], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (31, N'Cooper, Blain', N'Blain', N'Cooper', N'CA', N'Los Angeles Army', N'6 MO', N'pending', CAST(N'2024-02-06T00:00:00.0000000' AS DateTime2), N'Mac Eliot', NULL, N'test6@gmail.com', N'Dutch Schaefer', CAST(N'2024-02-05T00:00:00.0000000' AS DateTime2), CAST(N'2024-01-08T00:00:00.0000000' AS DateTime2), CAST(N'2024-02-09T00:00:00.0000000' AS DateTime2), CAST(N'2024-02-12T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, 1, 1, NULL, NULL, NULL, 1, NULL, NULL, N'Application sent awaiting confirmation', N'His patriot is confirmed documents attached to application', CAST(N'2024-02-12T00:00:00.0000000' AS DateTime2), N'ME', NULL, 1, N'000001', N'Mark Cooper', NULL, 1, NULL, CAST(N'2024-02-12T06:28:50.9483415' AS DateTime2), N'Eliot, Mac', CAST(N'2024-02-12T06:24:18.9123013' AS DateTime2), N'System')
GO
INSERT [dbo].[Assignments] ([Id], [ApplicantFullName], [ApplicantFName], [ApplicantLName], [ApplicantState], [ApplicantChapter], [ApplicationType], [ApplicationStatus], [ApplicationDateAssigned], [ChapterContact], [Registrar], [ChapterContactEmail], [VerifyingGenie], [FirstReview], [DateOfLastAIRLetter], [ResponseDate], [DateComplete], [NCUpdateRequested], [HelpRequest], [ReassignmentRequest], [AAARequest], [ARTRequest], [SeniorCoordinatorRequest], [CoordinatorRequest], [ReturnRequest], [DocReceived], [PermissionLetter], [SelectedCoordinator], [StateProblem], [Notes], [LastContactWithChapterDate], [MemberInitials], [VolunteerContactChapter], [SpecialTeamRequest], [PatriotNumber], [PatriotName], [NewChildOfPatriot], [NewPatriot], [Correction], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (32, N'Billy, Sole', N'Sole', N'Billy', N'CA', N'Los Angeles Army', N'AIR Letter', N'pending', CAST(N'2024-01-30T00:00:00.0000000' AS DateTime2), N'Dutch Schaefer', NULL, N'test5@gmail.com', N'Al Dillon', CAST(N'2024-01-29T00:00:00.0000000' AS DateTime2), CAST(N'2024-02-02T00:00:00.0000000' AS DateTime2), CAST(N'2024-02-07T00:00:00.0000000' AS DateTime2), CAST(N'2024-02-12T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, N'Application enroute', N'Patriot verified and documents attached', CAST(N'2024-02-09T00:00:00.0000000' AS DateTime2), N'DS', NULL, 1, N'000002', N'George Sole', 1, NULL, NULL, CAST(N'2024-02-12T06:32:10.3670918' AS DateTime2), N'Schaefer, Dutch', CAST(N'2024-02-12T06:32:42.1411531' AS DateTime2), N'Schaefer, Dutch')
GO
INSERT [dbo].[Assignments] ([Id], [ApplicantFullName], [ApplicantFName], [ApplicantLName], [ApplicantState], [ApplicantChapter], [ApplicationType], [ApplicationStatus], [ApplicationDateAssigned], [ChapterContact], [Registrar], [ChapterContactEmail], [VerifyingGenie], [FirstReview], [DateOfLastAIRLetter], [ResponseDate], [DateComplete], [NCUpdateRequested], [HelpRequest], [ReassignmentRequest], [AAARequest], [ARTRequest], [SeniorCoordinatorRequest], [CoordinatorRequest], [ReturnRequest], [DocReceived], [PermissionLetter], [SelectedCoordinator], [StateProblem], [Notes], [LastContactWithChapterDate], [MemberInitials], [VolunteerContactChapter], [SpecialTeamRequest], [PatriotNumber], [PatriotName], [NewChildOfPatriot], [NewPatriot], [Correction], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (33, N'Kelly, Rizzo', N'Rizzo', N'Kelly', N'IL', N'Founders Crossing', N'AIR', N'pending', CAST(N'2024-01-30T00:00:00.0000000' AS DateTime2), N'Erik Cheatham', 1, N'erikcheatham@gmail.com', N'Erik Cheatham', CAST(N'2024-01-29T00:00:00.0000000' AS DateTime2), CAST(N'2024-02-05T00:00:00.0000000' AS DateTime2), CAST(N'2024-02-07T00:00:00.0000000' AS DateTime2), CAST(N'2024-02-12T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, N'Application enroute', N'Documents Attached', CAST(N'2024-02-09T00:00:00.0000000' AS DateTime2), N'EIC', NULL, NULL, N'000003', N'Eugene Rizzo', NULL, 1, NULL, CAST(N'2024-02-12T06:54:49.1438831' AS DateTime2), N'Cheatham, Erik', CAST(N'2024-02-12T06:50:36.0413043' AS DateTime2), N'System')
GO
INSERT [dbo].[Assignments] ([Id], [ApplicantFullName], [ApplicantFName], [ApplicantLName], [ApplicantState], [ApplicantChapter], [ApplicationType], [ApplicationStatus], [ApplicationDateAssigned], [ChapterContact], [Registrar], [ChapterContactEmail], [VerifyingGenie], [FirstReview], [DateOfLastAIRLetter], [ResponseDate], [DateComplete], [NCUpdateRequested], [HelpRequest], [ReassignmentRequest], [AAARequest], [ARTRequest], [SeniorCoordinatorRequest], [CoordinatorRequest], [ReturnRequest], [DocReceived], [PermissionLetter], [SelectedCoordinator], [StateProblem], [Notes], [LastContactWithChapterDate], [MemberInitials], [VolunteerContactChapter], [SpecialTeamRequest], [PatriotNumber], [PatriotName], [NewChildOfPatriot], [NewPatriot], [Correction], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (34, N'Mahomes, Patrick', N'Patrick', N'Mahomes', N'KS', N'Kansas Corner', N'AIR Letter', N'pending', CAST(N'2023-12-01T00:00:00.0000000' AS DateTime2), N'Travis Kelce', NULL, N'test2@gmail.com', N'Andy Reid', CAST(N'2023-11-27T00:00:00.0000000' AS DateTime2), CAST(N'2023-12-18T00:00:00.0000000' AS DateTime2), CAST(N'2024-01-03T00:00:00.0000000' AS DateTime2), CAST(N'2024-01-05T00:00:00.0000000' AS DateTime2), 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, NULL, N'Application enroute', N'Documents verified and attached', CAST(N'2024-01-29T00:00:00.0000000' AS DateTime2), N'AR', 1, NULL, N'000004', N'Donovan Mahomes', 1, NULL, NULL, CAST(N'2024-02-12T06:58:27.8515173' AS DateTime2), N'Reid, Andy', CAST(N'2024-02-12T06:55:19.7900230' AS DateTime2), N'System')
GO
INSERT [dbo].[Assignments] ([Id], [ApplicantFullName], [ApplicantFName], [ApplicantLName], [ApplicantState], [ApplicantChapter], [ApplicationType], [ApplicationStatus], [ApplicationDateAssigned], [ChapterContact], [Registrar], [ChapterContactEmail], [VerifyingGenie], [FirstReview], [DateOfLastAIRLetter], [ResponseDate], [DateComplete], [NCUpdateRequested], [HelpRequest], [ReassignmentRequest], [AAARequest], [ARTRequest], [SeniorCoordinatorRequest], [CoordinatorRequest], [ReturnRequest], [DocReceived], [PermissionLetter], [SelectedCoordinator], [StateProblem], [Notes], [LastContactWithChapterDate], [MemberInitials], [VolunteerContactChapter], [SpecialTeamRequest], [PatriotNumber], [PatriotName], [NewChildOfPatriot], [NewPatriot], [Correction], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (35, N'Pacheco, Isiah', N'Isiah', N'Pacheco', N'KS', N'Kansas Corner', N'6 MO', N'verified', CAST(N'2024-01-04T00:00:00.0000000' AS DateTime2), N'Travis Kelce', 1, N'test2@gmail.com', N'Andy Reid', CAST(N'2024-01-08T00:00:00.0000000' AS DateTime2), CAST(N'2024-01-10T00:00:00.0000000' AS DateTime2), CAST(N'2024-01-15T00:00:00.0000000' AS DateTime2), CAST(N'2024-01-17T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Application correction required, note to Registrar', N'Correction required on attached documents, be sure they are returned also', CAST(N'2024-01-29T00:00:00.0000000' AS DateTime2), N'TK', NULL, 1, N'000005', N'Bertrand Pacheco', NULL, 1, 1, CAST(N'2024-02-12T07:02:19.8384933' AS DateTime2), N'Kelce, Travis', CAST(N'2024-02-12T06:58:57.7244540' AS DateTime2), N'System')
GO
SET IDENTITY_INSERT [dbo].[Assignments] OFF
GO
SET IDENTITY_INSERT [dbo].[Attachments] ON 
GO
INSERT [dbo].[Attachments] ([Id], [AssignmentID], [Name], [Type], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (65, 29, N'Hello this is a test file.docx', N'application/vnd.openxmlformats-officedocument.wordprocessingml.document', CAST(N'2024-02-11T13:48:02.0814005' AS DateTime2), N'Cheatham, Erik', CAST(N'2024-02-11T13:48:02.0814012' AS DateTime2), N'Cheatham, Erik')
GO
INSERT [dbo].[Attachments] ([Id], [AssignmentID], [Name], [Type], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (66, 30, N'tests-example.xls', N'application/vnd.ms-excel', CAST(N'2024-02-11T13:50:28.6280371' AS DateTime2), N'Cheatham, Erik', CAST(N'2024-02-11T13:50:28.6280380' AS DateTime2), N'Cheatham, Erik')
GO
INSERT [dbo].[Attachments] ([Id], [AssignmentID], [Name], [Type], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (67, 31, N'file_example_XLS_5000.xls', N'application/vnd.ms-excel', CAST(N'2024-02-12T06:28:50.8251166' AS DateTime2), N'Eliot, Mac', CAST(N'2024-02-12T06:28:50.8251178' AS DateTime2), N'Eliot, Mac')
GO
INSERT [dbo].[Attachments] ([Id], [AssignmentID], [Name], [Type], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (68, 31, N'Hello this is a test file.docx', N'application/vnd.openxmlformats-officedocument.wordprocessingml.document', CAST(N'2024-02-12T06:28:50.9446063' AS DateTime2), N'Eliot, Mac', CAST(N'2024-02-12T06:28:50.9446070' AS DateTime2), N'Eliot, Mac')
GO
INSERT [dbo].[Attachments] ([Id], [AssignmentID], [Name], [Type], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (69, 32, N'TestPDF.pdf', N'application/pdf', CAST(N'2024-02-12T06:32:10.3670523' AS DateTime2), N'Schaefer, Dutch', CAST(N'2024-02-12T06:32:10.3670528' AS DateTime2), N'Schaefer, Dutch')
GO
INSERT [dbo].[Attachments] ([Id], [AssignmentID], [Name], [Type], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (70, 33, N'Test1.txt', N'text/plain', CAST(N'2024-02-12T06:54:49.0052421' AS DateTime2), N'Cheatham, Erik', CAST(N'2024-02-12T06:54:49.0052427' AS DateTime2), N'Cheatham, Erik')
GO
INSERT [dbo].[Attachments] ([Id], [AssignmentID], [Name], [Type], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (71, 33, N'tests-example.xls', N'application/vnd.ms-excel', CAST(N'2024-02-12T06:54:49.1438479' AS DateTime2), N'Cheatham, Erik', CAST(N'2024-02-12T06:54:49.1438487' AS DateTime2), N'Cheatham, Erik')
GO
INSERT [dbo].[Attachments] ([Id], [AssignmentID], [Name], [Type], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (72, 34, N'file_example_XLS_5000.xls', N'application/vnd.ms-excel', CAST(N'2024-02-12T06:58:27.8514852' AS DateTime2), N'Reid, Andy', CAST(N'2024-02-12T06:58:27.8514860' AS DateTime2), N'Reid, Andy')
GO
INSERT [dbo].[Attachments] ([Id], [AssignmentID], [Name], [Type], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (73, 35, N'TestPDF.pdf', N'application/pdf', CAST(N'2024-02-12T07:02:19.8384581' AS DateTime2), N'Kelce, Travis', CAST(N'2024-02-12T07:02:19.8384587' AS DateTime2), N'Kelce, Travis')
GO
SET IDENTITY_INSERT [dbo].[Attachments] OFF
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'AK', N'Alaska', CAST(N'2023-12-31T19:29:32.1266667' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.1266667' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'AL', N'Alabama', CAST(N'2023-12-31T19:29:32.1500000' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.1500000' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'AR', N'Arkansas', CAST(N'2023-12-31T19:29:32.1600000' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.1600000' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'AZ', N'Arizona', CAST(N'2023-12-31T19:29:32.1633333' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.1633333' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'CA', N'California', CAST(N'2023-12-31T19:29:32.1733333' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.1733333' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'CO', N'Colorado', CAST(N'2023-12-31T19:29:32.1766667' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.1766667' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'CT', N'Connecticut', CAST(N'2023-12-31T19:29:32.1766667' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.1766667' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'DC', N'District Of Columbia', CAST(N'2023-12-31T19:29:32.1800000' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.1800000' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'DE', N'Delaware', CAST(N'2023-12-31T19:29:32.1800000' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.1800000' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'FL', N'Florida', CAST(N'2023-12-31T19:29:32.1800000' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.1800000' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'GA', N'Georgia', CAST(N'2023-12-31T19:29:32.1833333' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.1833333' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'GU', N'Guam', CAST(N'2023-12-31T19:29:32.1833333' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.1833333' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'HI', N'Hawaii', CAST(N'2023-12-31T19:29:32.1866667' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.1866667' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'IA', N'Iowa', CAST(N'2023-12-31T19:29:32.1866667' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.1866667' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'ID', N'Idaho', CAST(N'2023-12-31T19:29:32.1900000' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.1900000' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'IL', N'Illinois', CAST(N'2023-12-31T19:29:32.1900000' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.1900000' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'IN', N'Indiana', CAST(N'2023-12-31T19:29:32.1933333' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.1933333' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'KS', N'Kansas', CAST(N'2023-12-31T19:29:32.1933333' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.1933333' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'KY', N'Kentucky', CAST(N'2023-12-31T19:29:32.1966667' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.1966667' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'LA', N'Louisiana', CAST(N'2023-12-31T19:29:32.1966667' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.1966667' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'MA', N'Massachusetts', CAST(N'2023-12-31T19:29:32.2000000' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2000000' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'MD', N'Maryland', CAST(N'2023-12-31T19:29:32.2033333' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2033333' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'ME', N'Maine', CAST(N'2023-12-31T19:29:32.2066667' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2066667' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'MI', N'Michigan', CAST(N'2023-12-31T19:29:32.2100000' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2100000' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'MN', N'Minnesota', CAST(N'2023-12-31T19:29:32.2100000' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2100000' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'MO', N'Missouri', CAST(N'2023-12-31T19:29:32.2100000' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2100000' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'MS', N'Mississippi', CAST(N'2023-12-31T19:29:32.2133333' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2133333' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'MT', N'Montana', CAST(N'2023-12-31T19:29:32.2166667' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2166667' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'NC', N'North Carolina', CAST(N'2023-12-31T19:29:32.2166667' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2166667' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'ND', N'North Dakota', CAST(N'2023-12-31T19:29:32.2200000' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2200000' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'NE', N'Nebraska', CAST(N'2023-12-31T19:29:32.2200000' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2200000' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'NH', N'New Hampshire', CAST(N'2023-12-31T19:29:32.2200000' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2200000' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'NJ', N'New Jersey', CAST(N'2023-12-31T19:29:32.2233333' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2233333' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'NM', N'New Mexico', CAST(N'2023-12-31T19:29:32.2233333' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2233333' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'NV', N'Nevada', CAST(N'2023-12-31T19:29:32.2266667' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2266667' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'NY', N'New York', CAST(N'2023-12-31T19:29:32.2266667' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2266667' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'OH', N'Ohio', CAST(N'2023-12-31T19:29:32.2300000' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2300000' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'OK', N'Oklahoma', CAST(N'2023-12-31T19:29:32.2300000' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2300000' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'OR', N'Oregon', CAST(N'2023-12-31T19:29:32.2333333' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2333333' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'PA', N'Pennsylvania', CAST(N'2023-12-31T19:29:32.2333333' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2333333' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'PR', N'Puerto Rico', CAST(N'2023-12-31T19:29:32.2366667' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2366667' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'RI', N'Rhode Island', CAST(N'2023-12-31T19:29:32.2366667' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2366667' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'SC', N'South Carolina', CAST(N'2023-12-31T19:29:32.2400000' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2400000' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'SD', N'South Dakota', CAST(N'2023-12-31T19:29:32.2400000' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2400000' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'TN', N'Tennessee', CAST(N'2023-12-31T19:29:32.2400000' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2400000' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'TX', N'Texas', CAST(N'2023-12-31T19:29:32.2433333' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2433333' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'UT', N'Utah', CAST(N'2023-12-31T19:29:32.2433333' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2433333' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'VA', N'Virginia', CAST(N'2023-12-31T19:29:32.2466667' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2466667' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'VI', N'Virginia Islands', CAST(N'2023-12-31T19:29:32.2466667' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2466667' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'VT', N'Vermont', CAST(N'2023-12-31T19:29:32.2500000' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2500000' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'WA', N'Washington', CAST(N'2023-12-31T19:29:32.2500000' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2500000' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'WI', N'Wisconsin', CAST(N'2023-12-31T19:29:32.2500000' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2500000' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'WV', N'West Virginia', CAST(N'2023-12-31T19:29:32.2533333' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2533333' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'WY', N'Wyoming', CAST(N'2023-12-31T19:29:32.2533333' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2533333' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'XA', N'Austrailia', CAST(N'2023-12-31T19:29:32.2566667' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2566667' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'XB', N'Bahamas', CAST(N'2023-12-31T19:29:32.2566667' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2566667' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'XC', N'Canada', CAST(N'2023-12-31T19:29:32.2600000' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2600000' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'XD', N'Guam', CAST(N'2023-12-31T19:29:32.2600000' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2600000' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'XE', N'United Kingdom', CAST(N'2023-12-31T19:29:32.2600000' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2600000' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'XF', N'France', CAST(N'2023-12-31T19:29:32.2633333' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2633333' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'XG', N'Germany', CAST(N'2023-12-31T19:29:32.2633333' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2633333' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'XI', N'Italy', CAST(N'2023-12-31T19:29:32.2666667' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2666667' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'XJ', N'Japan', CAST(N'2023-12-31T19:29:32.2666667' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2666667' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'XM', N'Mexico', CAST(N'2023-12-31T19:29:32.2700000' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2700000' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'XS', N'Spain', CAST(N'2023-12-31T19:29:32.2700000' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2700000' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'XV', N'Austria', CAST(N'2023-12-31T19:29:32.2733333' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2733333' AS DateTime2), N'System')
GO
INSERT [dbo].[State] ([StateAb], [Name], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (N'XX', N'Overseas', CAST(N'2023-12-31T19:29:32.2733333' AS DateTime2), N'System', CAST(N'2023-12-31T19:29:32.2733333' AS DateTime2), N'System')
GO
SET IDENTITY_INSERT [dbo].[Volunteers] ON 
GO
INSERT [dbo].[Volunteers] ([Id], [AppUserId], [AssignmentId], [DateAssigned], [LeadVolunteer], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (33, 1, 29, CAST(N'2024-02-11T13:47:26.1844740' AS DateTime2), 1, CAST(N'2024-02-11T13:47:26.1844167' AS DateTime2), N'Cheatham, Erik', CAST(N'2024-02-11T13:47:26.1844173' AS DateTime2), N'Cheatham, Erik')
GO
INSERT [dbo].[Volunteers] ([Id], [AppUserId], [AssignmentId], [DateAssigned], [LeadVolunteer], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (34, 1, 30, CAST(N'2024-02-11T13:49:51.5041137' AS DateTime2), 0, CAST(N'2024-02-11T13:49:51.5041122' AS DateTime2), N'Cheatham, Erik', CAST(N'2024-02-11T13:49:51.5041131' AS DateTime2), N'Cheatham, Erik')
GO
INSERT [dbo].[Volunteers] ([Id], [AppUserId], [AssignmentId], [DateAssigned], [LeadVolunteer], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (35, 7, 31, CAST(N'2024-02-08T00:00:00.0000000' AS DateTime2), 1, CAST(N'2024-02-12T06:27:05.5564150' AS DateTime2), N'Eliot, Mac', CAST(N'2024-02-12T06:27:05.5564160' AS DateTime2), N'Eliot, Mac')
GO
INSERT [dbo].[Volunteers] ([Id], [AppUserId], [AssignmentId], [DateAssigned], [LeadVolunteer], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (36, 8, 31, CAST(N'2024-02-12T06:27:14.4251891' AS DateTime2), 0, CAST(N'2024-02-12T06:27:14.4251876' AS DateTime2), N'Eliot, Mac', CAST(N'2024-02-12T06:27:14.4251886' AS DateTime2), N'Eliot, Mac')
GO
INSERT [dbo].[Volunteers] ([Id], [AppUserId], [AssignmentId], [DateAssigned], [LeadVolunteer], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (37, 7, 32, CAST(N'2024-02-12T06:31:31.4052191' AS DateTime2), 1, CAST(N'2024-02-12T06:31:31.4052177' AS DateTime2), N'Schaefer, Dutch', CAST(N'2024-02-12T06:31:31.4052188' AS DateTime2), N'Schaefer, Dutch')
GO
INSERT [dbo].[Volunteers] ([Id], [AppUserId], [AssignmentId], [DateAssigned], [LeadVolunteer], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (38, 1, 33, CAST(N'2024-02-12T06:54:02.6176746' AS DateTime2), 1, CAST(N'2024-02-12T06:54:02.6176733' AS DateTime2), N'Cheatham, Erik', CAST(N'2024-02-12T06:54:02.6176742' AS DateTime2), N'Cheatham, Erik')
GO
INSERT [dbo].[Volunteers] ([Id], [AppUserId], [AssignmentId], [DateAssigned], [LeadVolunteer], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (39, 4, 34, CAST(N'2024-02-12T06:57:42.0856037' AS DateTime2), 1, CAST(N'2024-02-12T06:57:42.0856025' AS DateTime2), N'Reid, Andy', CAST(N'2024-02-12T06:57:42.0856034' AS DateTime2), N'Reid, Andy')
GO
INSERT [dbo].[Volunteers] ([Id], [AppUserId], [AssignmentId], [DateAssigned], [LeadVolunteer], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (40, 4, 35, CAST(N'2024-02-12T07:00:50.9343335' AS DateTime2), 0, CAST(N'2024-02-12T07:00:50.9343323' AS DateTime2), N'Kelce, Travis', CAST(N'2024-02-12T07:00:50.9343333' AS DateTime2), N'Kelce, Travis')
GO
INSERT [dbo].[Volunteers] ([Id], [AppUserId], [AssignmentId], [DateAssigned], [LeadVolunteer], [Created], [CreatedBy], [Modified], [ModifiedBy]) VALUES (41, 5, 35, CAST(N'2024-02-12T07:00:57.1504482' AS DateTime2), 1, CAST(N'2024-02-12T07:00:57.1504469' AS DateTime2), N'Kelce, Travis', CAST(N'2024-02-12T07:00:57.1504479' AS DateTime2), N'Kelce, Travis')
GO
SET IDENTITY_INSERT [dbo].[Volunteers] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 2/12/2024 1:40:48 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 2/12/2024 1:40:48 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 2/12/2024 1:40:48 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 2/12/2024 1:40:48 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 2/12/2024 1:40:48 AM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [AK_AspNetUsers_ApplicationUserId]    Script Date: 2/12/2024 1:40:48 AM ******/
ALTER TABLE [dbo].[AspNetUsers] ADD  CONSTRAINT [AK_AspNetUsers_ApplicationUserId] UNIQUE NONCLUSTERED 
(
	[ApplicationUserId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 2/12/2024 1:40:48 AM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 2/12/2024 1:40:48 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Attachments_AssignmentID]    Script Date: 2/12/2024 1:40:48 AM ******/
CREATE NONCLUSTERED INDEX [IX_Attachments_AssignmentID] ON [dbo].[Attachments]
(
	[AssignmentID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [idx_AppUserId]    Script Date: 2/12/2024 1:40:48 AM ******/
CREATE NONCLUSTERED INDEX [idx_AppUserId] ON [dbo].[Volunteers]
(
	[AppUserId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [idx_AssignmentId]    Script Date: 2/12/2024 1:40:48 AM ******/
CREATE NONCLUSTERED INDEX [idx_AssignmentId] ON [dbo].[Volunteers]
(
	[AssignmentId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [idx_LeadVolunteer]    Script Date: 2/12/2024 1:40:48 AM ******/
CREATE NONCLUSTERED INDEX [idx_LeadVolunteer] ON [dbo].[Volunteers]
(
	[LeadVolunteer] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT (CONVERT([bit],(0))) FOR [Active]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT (CONVERT([bit],(0))) FOR [AppAngel]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT (CONVERT([bit],(0))) FOR [Coordinator]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [Created]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT (N'') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [Modified]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT (N'') FOR [ModifiedBy]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT (CONVERT([bit],(0))) FOR [NationalChair]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT (CONVERT([bit],(0))) FOR [SeniorCoordinator]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT (CONVERT([bit],(0))) FOR [Volunteer]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT ((15)) FOR [RadzenDataGridPageSizePref]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Attachments]  WITH CHECK ADD  CONSTRAINT [FK_Attachments_To_Assignments] FOREIGN KEY([AssignmentID])
REFERENCES [dbo].[Assignments] ([Id])
GO
ALTER TABLE [dbo].[Attachments] CHECK CONSTRAINT [FK_Attachments_To_Assignments]
GO
ALTER TABLE [dbo].[Volunteers]  WITH CHECK ADD  CONSTRAINT [FK_Volunteers_AppUser] FOREIGN KEY([AppUserId])
REFERENCES [dbo].[AspNetUsers] ([ApplicationUserId])
GO
ALTER TABLE [dbo].[Volunteers] CHECK CONSTRAINT [FK_Volunteers_AppUser]
GO
ALTER TABLE [dbo].[Volunteers]  WITH CHECK ADD  CONSTRAINT [FK_Volunteers_Assignments] FOREIGN KEY([AssignmentId])
REFERENCES [dbo].[Assignments] ([Id])
GO
ALTER TABLE [dbo].[Volunteers] CHECK CONSTRAINT [FK_Volunteers_Assignments]
GO
--ALTER DATABASE [Moms250Blazor] SET  READ_WRITE 
--GO
