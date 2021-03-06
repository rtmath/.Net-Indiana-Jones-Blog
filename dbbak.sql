CREATE DATABASE [IndianaJonesBlog]
GO
USE [IndianaJonesBlog]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2/8/2017 4:46:58 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Experiences]    Script Date: 2/8/2017 4:46:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Experiences](
	[ExperienceId] [int] IDENTITY(1,1) NOT NULL,
	[LocationId] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Title] [nvarchar](max) NULL,
 CONSTRAINT [PK_Experiences] PRIMARY KEY CLUSTERED 
(
	[ExperienceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ExperiencesPersons]    Script Date: 2/8/2017 4:46:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExperiencesPersons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ExperienceId] [int] NOT NULL,
	[PersonId] [int] NOT NULL,
 CONSTRAINT [PK_ExperiencesPersons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Locations]    Script Date: 2/8/2017 4:46:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Locations](
	[LocationId] [int] IDENTITY(1,1) NOT NULL,
	[Country] [nvarchar](max) NULL,
	[Region] [nvarchar](max) NULL,
 CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED 
(
	[LocationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persons]    Script Date: 2/8/2017 4:46:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[Experiences]  WITH CHECK ADD  CONSTRAINT [FK_Experiences_Locations_LocationId] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Locations] ([LocationId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Experiences] CHECK CONSTRAINT [FK_Experiences_Locations_LocationId]
GO
ALTER TABLE [dbo].[ExperiencesPersons]  WITH CHECK ADD  CONSTRAINT [FK_ExperiencesPersons_Experiences_ExperienceId] FOREIGN KEY([ExperienceId])
REFERENCES [dbo].[Experiences] ([ExperienceId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ExperiencesPersons] CHECK CONSTRAINT [FK_ExperiencesPersons_Experiences_ExperienceId]
GO
ALTER TABLE [dbo].[ExperiencesPersons]  WITH CHECK ADD  CONSTRAINT [FK_ExperiencesPersons_Persons_PersonId] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Persons] ([PersonId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ExperiencesPersons] CHECK CONSTRAINT [FK_ExperiencesPersons_Persons_PersonId]
GO
