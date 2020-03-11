USE [Schools]
GO

CREATE TABLE [dbo].[Schools](
	[SchoolId] [int] IDENTITY(1,1) NOT NULL,
	[SchoolName] [varchar](150) NOT NULL,
	[ServerName] [varchar](150) NULL,
	[DatabaseName] [varchar](150) NOT NULL,
 CONSTRAINT [PK_Schools] PRIMARY KEY CLUSTERED 
(
	[SchoolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE PROCEDURE [dbo].[sp_School_Select]
	@Email varchar(150)
AS
BEGIN
	--declare @Email varchar(100) = 'dan@weston.com';
	declare @School varchar(100);
	declare @start int = charindex('@', @Email);
	declare @end int = charindex('.', @Email);

	if (@start > -1 and @end > 1)
		set @School = substring(@Email, @start + 1, (@end-@start)-1);
	
	select SchoolName, DatabaseName, ServerName from Schools where SchoolName = @School;
END
GO

USE [Weston]
GO

CREATE TABLE [dbo].[Users](
	[OID] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[DisplayName] [nvarchar](50) NULL,
	[EMailAddress] [nvarchar](100) NULL,
	[Salt] [nchar](100) NULL,
	[LoginId] [nvarchar](50) NULL,
	[LoginPassword] [varbinary](max) NULL,
	[LoginChangePassword] [bit] NULL,
	[LoginDisabled] [bit] NULL,
	[IsAdministrator] [bit] NULL,
	[DefaultTeacher] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[ModifiedOn] [datetime] NULL,
	[OptimisticLockField] [int] NULL,
	[GCRecord] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[OID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Users]  WITH NOCHECK ADD  CONSTRAINT [FK_Users_DefaultTeacher] FOREIGN KEY([DefaultTeacher])
REFERENCES [dbo].[Teachers] ([OID])
NOT FOR REPLICATION 
GO

ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_DefaultTeacher]
GO

CREATE PROCEDURE [dbo].[sp_Class_Select]
	@year_group_id int,
	@subject_id int
AS
BEGIN
	declare @year_id int;

	if (datepart(month, getdate()) > 8)
		set @year_id = datepart(year, getdate());
	else
		set @year_id = datepart(year, getdate()) -1;

	SELECT [OID],*
	FROM [dbo].[Classes]
	WHERE AcademicYearStart = @year_id AND YearGroup = @year_group_id AND [Subject] = @subject_id AND GCRecord IS NULL
	ORDER BY TeacherInitials
END
GO

CREATE PROCEDURE [dbo].[sp_Levels_Select]
--	@early_years bit
AS
BEGIN
--	if @early_years = 1
		select id, shortcode, description from KpiLevels order by Description;
--	else
--		select id, shortcode, description from KpiLevelsEarlyYears order by Description;
END
GO

create PROCEDURE [dbo].[sp_Objectives_Select]

AS
BEGIN
	SELECT [Id], [ShortCode], [Description]
	FROM [dbo].[KpiLevelsEarlyYears]
	WHERE GCRecord IS NULL AND Visible = 1
	ORDER BY Id;
END
GO

create PROCEDURE [dbo].[sp_Subject_Select]
	@year_group_id int
AS
BEGIN
	declare @year_id int;

	if (datepart(month, getdate()) > 8)
		set @year_id = datepart(year, getdate());
	else
		set @year_id = datepart(year, getdate()) -1;

	SELECT YG.OID, YG.Code, SB.OID AS SubjectId, DisplayName, Category, AcademicYearStart
		FROM ((
		   SELECT [YearGroup], [Subject], AcademicYearStart
		   FROM [dbo].[Classes]
		   WHERE GCRecord IS NULL AND AcademicYearStart = @year_id AND YearGroup = @year_group_id
		   GROUP BY [YearGroup], [Subject],AcademicYearStart
		 ) BD LEFT JOIN [dbo].[Subjects] SB ON BD.[Subject] = SB.OID) LEFT JOIN [dbo].[YearGroups] YG ON BD.[YearGroup] = YG.OID 
		 ORDER BY AgeStart, DisplayName;
END
GO

create PROCEDURE [dbo].[sp_TrackerEarlyYearsPupil_Select]
	@class_id int
AS
BEGIN
	select PupilName, ft.Initials FormTeacher, py.StartDate, datediff(month, p.DateOfBirth, getdate()) MonthsOld, class 
		, ke.ShortCode + ' : ' + ke.Description EndOfLastYearStatus
		, ka.ShortCode + ' : ' + ka.Description AutumnStatus
		, kah.ShortCode + ' : ' + kah.Description AutumnHalfTermStatus
		, kp.ShortCode + ' : ' + kp.Description SpringStatus
		, kph.ShortCode + ' : ' + kph.Description SpringHalfTermStatus
		, ks.ShortCode + ' : ' + ks.Description SummerStatus
		, ksh.ShortCode + ' : ' + ksh.Description SummerHalfTermStatus
	from KpiTrackers t 
		join pupilyears py on py.OID = t.PupilYear
		join Pupils p on p.OID = py.Pupil
		join Teachers ft on ft.OID = py.FormTeacher
		left join KpiLevelsEarlyYears ke on ke.OID = t.EndOfLastYearStatus
		left join KpiLevelsEarlyYears ka on ka.OID = t.AutumnStatus
		left join KpiLevelsEarlyYears kah on kah.OID = t.AutumnHalfTermStatus
		left join KpiLevelsEarlyYears kp on kp.OID = t.SpringStatus
		left join KpiLevelsEarlyYears kph on kph.OID = t.SpringHalfTermStatus
		left join KpiLevelsEarlyYears ks on ks.OID = t.SummerStatus
		left join KpiLevelsEarlyYears ksh on ksh.OID = t.SummerHalfTermStatus
	where class = @class_id;
END
GO

CREATE PROCEDURE [dbo].[sp_TrackerPrimaryPupil_Select]
	@class_id int
AS
BEGIN
	select PupilName, ft.Initials FormTeacher, py.StartDate, datediff(month, p.DateOfBirth, getdate()) MonthsOld, class 
		, ke.ShortCode + ' : ' + ke.Description EndOfLastYearStatus
		, ka.ShortCode + ' : ' + ka.Description AutumnStatus
		, kah.ShortCode + ' : ' + kah.Description AutumnHalfTermStatus
		, kp.ShortCode + ' : ' + kp.Description SpringStatus
		, kph.ShortCode + ' : ' + kph.Description SpringHalfTermStatus
		, ks.ShortCode + ' : ' + ks.Description SummerStatus
		, ksh.ShortCode + ' : ' + ksh.Description SummerHalfTermStatus
	from KpiTrackers t 
		join pupilyears py on py.OID = t.PupilYear
		join Pupils p on p.OID = py.Pupil
		join Teachers ft on ft.OID = py.FormTeacher
		left join KpiLevels ke on ke.OID = t.EndOfLastYearStatus
		left join KpiLevels ka on ka.OID = t.AutumnStatus
		left join KpiLevels kah on kah.OID = t.AutumnHalfTermStatus
		left join KpiLevels kp on kp.OID = t.SpringStatus
		left join KpiLevels kph on kph.OID = t.SpringHalfTermStatus
		left join KpiLevels ks on ks.OID = t.SummerStatus
		left join KpiLevels ksh on ksh.OID = t.SummerHalfTermStatus
	where class = @class_id;
END
GO

create PROCEDURE [dbo].[sp_TrackerPupil_Select]
	@class_id int,
	@year_group_code varchar(2)
AS
BEGIN
	if (@year_group_code in ('E1', 'E2', 'N1', 'N2', 'R'))
		exec sp_TrackerEarlyYearsPupil_Select @class_id;
	else
		exec sp_TrackerPrimaryPupil_Select @class_id;
END
GO

CREATE PROCEDURE [dbo].[sp_User_Select]
	@Email varchar(150)
AS
BEGIN
	select * from WebUsers where Email = @Email;
END
GO

CREATE PROCEDURE [dbo].[sp_YearGroup_Select]

AS
BEGIN
SELECT [OID], [Code], [KeyStage], [Description], AssessTwicePerTerm
    FROM [dbo].[YearGroups]
    WHERE GCRecord IS NULL AND Active = 1
    ORDER BY AgeStart
END
GO


