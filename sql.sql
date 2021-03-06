use master
go
create database StudentManagement
go
USE [StudentManagement]
GO
/****** Object:  Table [dbo].[AcademicTranscripts]    Script Date: 11/4/2021 2:50:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AcademicTranscripts](
	[transcriptID] [varchar](100) NOT NULL,
	[studentID] [varchar](100) NULL,
	[subjectID] [varchar](20) NULL,
	[test15Min] [float] NULL,
	[test45Min] [float] NULL,
	[finalTest] [float] NULL,
	[average] [float] NULL,
	[semester] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[transcriptID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 11/4/2021 2:50:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[userID] [varchar](30) NOT NULL,
	[role] [nvarchar](30) NULL,
	[name] [nvarchar](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[userID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Classes]    Script Date: 11/4/2021 2:50:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Classes](
	[classID] [varchar](10) NOT NULL,
	[studentID] [varchar](100) NULL,
	[className] [varchar](10) NULL,
	[userID] [varchar](30) NULL,
	[schoolYear] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[classID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SchoolYears]    Script Date: 11/4/2021 2:50:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SchoolYears](
	[schoolYearID] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[schoolYearID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 11/4/2021 2:50:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[studentID] [varchar](100) NOT NULL,
	[name] [nvarchar](150) NULL,
	[birth] [date] NULL,
	[address] [nvarchar](250) NULL,
	[proficiency] [nvarchar](20) NULL,
	[schoolYearID] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[studentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 11/4/2021 2:50:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subjects](
	[subjectID] [varchar](20) NOT NULL,
	[subjectName] [nvarchar](50) NULL,
 CONSTRAINT [subjectID] PRIMARY KEY CLUSTERED 
(
	[subjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AcademicTranscripts]  WITH CHECK ADD FOREIGN KEY([studentID])
REFERENCES [dbo].[Students] ([studentID])
GO
ALTER TABLE [dbo].[AcademicTranscripts]  WITH CHECK ADD FOREIGN KEY([subjectID])
REFERENCES [dbo].[Subjects] ([subjectID])
GO
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD FOREIGN KEY([studentID])
REFERENCES [dbo].[Students] ([studentID])
GO
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD FOREIGN KEY([schoolYear])
REFERENCES [dbo].[SchoolYears] ([schoolYearID])
GO
ALTER TABLE [dbo].[Classes]  WITH CHECK ADD FOREIGN KEY([userID])
REFERENCES [dbo].[Accounts] ([userID])
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [schoolYearID] FOREIGN KEY([schoolYearID])
REFERENCES [dbo].[SchoolYears] ([schoolYearID])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [schoolYearID]
GO

alter table [dbo].[Subjects]
add semester int
