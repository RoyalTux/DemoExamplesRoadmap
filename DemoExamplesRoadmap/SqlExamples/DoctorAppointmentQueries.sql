-- CREATE DATABASE DoctorAppointment
USE DoctorAppointment

CREATE TABLE [dbo].[User] (
    [Id]		   INT            IDENTITY (1, 1) NOT NULL,
    [Login]        NVARCHAR (20)  NOT NULL,
    [Password]     NVARCHAR (50)  NOT NULL,
    [Access]	   INT            NOT NULL,
	[ActiveState]  BIT			  NOT NULL,
	[Name]         NVARCHAR (20)  NULL,
    [Surname]      NVARCHAR (40)  NULL,
    [DateOfBirth]  DATE           NULL,
    [PhoneNumber]  NVARCHAR (50)  NULL,
    [Image]        NVARCHAR(MAX),
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Patient] (
    [Id]			  INT IDENTITY (1, 1) NOT NULL,
	[UserId]          INT			 NULL,
	[Address]         NVARCHAR (50)  NULL,
	[Height]          INT            NULL,
    [Weight]          INT            NULL,
    [ChronicDisease]  NVARCHAR (MAX) NULL,
    [TestResults]     NVARCHAR (MAX) NULL,
    [Diagnosis]       NVARCHAR (MAX) NULL,
    [Treatment]       NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
	FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

CREATE  TABLE [dbo].[Specialty] (
    [Id]			INT            IDENTITY (1, 1) NOT NULL,
    [Name]			NVARCHAR (20)  NULL,
    [Description]	NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Doctor] (
    [Id]				INT        IDENTITY (1, 1) NOT NULL,
	[UserId]			INT        NULL,
	[LicenceNumber]		INT        NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
	FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

CREATE  TABLE [dbo].[DoctorSpecialty] (
    [Id]			INT     IDENTITY (1, 1) NOT NULL,
	[Doctorid]		INT		NULL,
	[SpecialtyId]	INT		NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
	FOREIGN KEY ([DoctorId]) REFERENCES [dbo].[Doctor] ([Id]),
	FOREIGN KEY ([SpecialtyId]) REFERENCES [dbo].[Specialty] ([Id])
);

CREATE  TABLE [dbo].[DoctorReview] (
    [Id]			INT            IDENTITY (1, 1) NOT NULL,
	[Doctorid]		INT			   NULL,
	[PatientId]		INT			   NULL,
    [Message]		NVARCHAR (20)  NULL,
    [Rating]		INT			   NULL,
	[DateTimeStamp]	DATETIME	   NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
	FOREIGN KEY ([Doctorid])  REFERENCES [dbo].[Doctor] ([Id]),
	FOREIGN KEY ([PatientId])  REFERENCES [dbo].[Patient] ([Id])
);

CREATE TABLE [dbo].[Appointment] (
   [Id]				INT	IDENTITY(1, 1)  NOT NULL,
   [Patientid]		INT					NULL,
   [Doctorid]		INT					NULL,
   [StartDate]		DATETIME			NULL,
   [EndDate]		DATETIME			NULL,
   [Description]	NVARCHAR(MAX)		NULL,
   PRIMARY KEY CLUSTERED ([Id] ASC),
   FOREIGN KEY ([Patientid]) REFERENCES [dbo].[Patient] ([Id]),
   FOREIGN KEY ([Doctorid])  REFERENCES [dbo].[Doctor] ([Id])
);



