USE [SIS]
GO
SET IDENTITY_INSERT [Training].[MarkType] ON 

INSERT [Training].[MarkType] ([Id], [Name]) VALUES (1, N'WrittenTest')
INSERT [Training].[MarkType] ([Id], [Name]) VALUES (2, N'OralTest')
INSERT [Training].[MarkType] ([Id], [Name]) VALUES (3, N'Presentation')
INSERT [Training].[MarkType] ([Id], [Name]) VALUES (4, N'Project')
INSERT [Training].[MarkType] ([Id], [Name]) VALUES (5, N'Assignment')
SET IDENTITY_INSERT [Training].[MarkType] OFF
SET IDENTITY_INSERT [Training].[Course] ON 

INSERT [Training].[Course] ([Id], [CourseCode], [PackageId], [Name]) VALUES (4, N'DIE', NULL, N'Diploma In Entreuponoship')
INSERT [Training].[Course] ([Id], [CourseCode], [PackageId], [Name]) VALUES (2, N'DIP', NULL, N'Diploma In IT Support')
INSERT [Training].[Course] ([Id], [CourseCode], [PackageId], [Name]) VALUES (1, N'DSE', NULL, N'Diploma In Software Engineering')
INSERT [Training].[Course] ([Id], [CourseCode], [PackageId], [Name]) VALUES (3, N'DSM', NULL, N'Diploma In Sales and Marketing')
SET IDENTITY_INSERT [Training].[Course] OFF
SET IDENTITY_INSERT [Training].[Module] ON 

INSERT [Training].[Module] ([Id], [ModuleCode], [Name]) VALUES (1, N'DA101', N'Database')
INSERT [Training].[Module] ([Id], [ModuleCode], [Name]) VALUES (2, N'HD101', N'Hardware and Deskstop')
INSERT [Training].[Module] ([Id], [ModuleCode], [Name]) VALUES (4, N'SM101', N'Introduction of Sales')
INSERT [Training].[Module] ([Id], [ModuleCode], [Name]) VALUES (3, N'SW101', N'Software Windows')
SET IDENTITY_INSERT [Training].[Module] OFF
SET IDENTITY_INSERT [Training].[Trainer] ON 

INSERT [Training].[Trainer] ([Id], [IC], [Name], [FirstName], [LastName], [Email], [PhoneNum], [Address1], [Address2], [Postcode], [City], [State], [Country], [Gender], [Race], [DateOfBirth], [FileName]) VALUES (1, N'800120-10-6393', NULL, N'Joshua', N'Chang', N'joshua@gmail.com', N'017-202 1277', N'18A, Jalan 20/16A,', N'Taman Paramount,', N'46300', N'Petaling Jaya,', N'Selangor', N'Malaysia', N'Male', N'Chinese', CAST(N'2000-08-20' AS Date), NULL)
SET IDENTITY_INSERT [Training].[Trainer] OFF
SET IDENTITY_INSERT [Training].[Course_Module] ON 

INSERT [Training].[Course_Module] ([Id], [CourseId], [ModuleId], [TrainerId]) VALUES (2, N'DSE', N'DA101', 1)
INSERT [Training].[Course_Module] ([Id], [CourseId], [ModuleId], [TrainerId]) VALUES (3, N'DIP', N'HD101', 1)
INSERT [Training].[Course_Module] ([Id], [CourseId], [ModuleId], [TrainerId]) VALUES (4, N'DIP', N'SW101', 1)
SET IDENTITY_INSERT [Training].[Course_Module] OFF
SET IDENTITY_INSERT [Training].[ModuleStandard] ON 

INSERT [Training].[ModuleStandard] ([Id], [Course_ModuleId], [MarkTypeId], [LabName], [Marks]) VALUES (10, 3, 1, NULL, 25)
INSERT [Training].[ModuleStandard] ([Id], [Course_ModuleId], [MarkTypeId], [LabName], [Marks]) VALUES (11, 3, 3, NULL, 30)
INSERT [Training].[ModuleStandard] ([Id], [Course_ModuleId], [MarkTypeId], [LabName], [Marks]) VALUES (12, 3, 5, N'Lab 1', 15)
INSERT [Training].[ModuleStandard] ([Id], [Course_ModuleId], [MarkTypeId], [LabName], [Marks]) VALUES (13, 3, 5, N'Lab 2', 30)
INSERT [Training].[ModuleStandard] ([Id], [Course_ModuleId], [MarkTypeId], [LabName], [Marks]) VALUES (14, 2, 1, NULL, 25)
INSERT [Training].[ModuleStandard] ([Id], [Course_ModuleId], [MarkTypeId], [LabName], [Marks]) VALUES (15, 2, 3, NULL, 10)
INSERT [Training].[ModuleStandard] ([Id], [Course_ModuleId], [MarkTypeId], [LabName], [Marks]) VALUES (16, 2, 5, N'Lab 3', 35)
INSERT [Training].[ModuleStandard] ([Id], [Course_ModuleId], [MarkTypeId], [LabName], [Marks]) VALUES (17, 2, 5, N'Lab 4', 30)
SET IDENTITY_INSERT [Training].[ModuleStandard] OFF
SET IDENTITY_INSERT [Training].[Year] ON 

INSERT [Training].[Year] ([Id], [Year]) VALUES (1, N'2015')
INSERT [Training].[Year] ([Id], [Year]) VALUES (2, N'2016')
SET IDENTITY_INSERT [Training].[Year] OFF
SET IDENTITY_INSERT [Training].[Month] ON 

INSERT [Training].[Month] ([Id], [Month]) VALUES (1, N'01')
INSERT [Training].[Month] ([Id], [Month]) VALUES (2, N'02')
INSERT [Training].[Month] ([Id], [Month]) VALUES (3, N'03')
INSERT [Training].[Month] ([Id], [Month]) VALUES (4, N'04')
INSERT [Training].[Month] ([Id], [Month]) VALUES (5, N'05')
INSERT [Training].[Month] ([Id], [Month]) VALUES (6, N'06')
INSERT [Training].[Month] ([Id], [Month]) VALUES (7, N'07')
INSERT [Training].[Month] ([Id], [Month]) VALUES (8, N'08')
INSERT [Training].[Month] ([Id], [Month]) VALUES (9, N'09')
INSERT [Training].[Month] ([Id], [Month]) VALUES (10, N'10')
INSERT [Training].[Month] ([Id], [Month]) VALUES (11, N'11')
INSERT [Training].[Month] ([Id], [Month]) VALUES (12, N'12')
SET IDENTITY_INSERT [Training].[Month] OFF
SET IDENTITY_INSERT [Training].[Intake] ON 

INSERT [Training].[Intake] ([Id], [YearId], [MonthId], [CourseCode]) VALUES (1, 2, 12, N'DSE')
INSERT [Training].[Intake] ([Id], [YearId], [MonthId], [CourseCode]) VALUES (2, 2, 7, N'DIP')
SET IDENTITY_INSERT [Training].[Intake] OFF
SET IDENTITY_INSERT [Training].[Nationality] ON 

INSERT [Training].[Nationality] ([Id], [Name]) VALUES (1, N'Malaysian')
INSERT [Training].[Nationality] ([Id], [Name]) VALUES (2, N'Singaporian')
INSERT [Training].[Nationality] ([Id], [Name]) VALUES (3, N'Australian')
SET IDENTITY_INSERT [Training].[Nationality] OFF
SET IDENTITY_INSERT [Training].[Student] ON 

INSERT [Training].[Student] ([Id], [StudentId], [IntakeId], [SPMResultId], [Insurence], [Name], [Age], [DOB], [IC], [NationalityId], [Gender], [Status], [PhoneNum], [OtherPhoneNum], [EmailAddress], [Religion], [SingleParent], [MomName], [MomEdu], [MomWorkStatus], [MomJob], [MomFeildWork], [MomSectorJob], [MomSalary], [FatherName], [FatherEdu], [FatherWorkStatus], [FatherJob], [FatherFeildWork], [FatherSectorJob], [FatherSalary], [NumSibling], [BirthOrd]) VALUES (1, N'P16120001', 1, NULL, 1, N'Eddie Lok', 19, CAST(N'1998-01-20' AS Date), 961219106057, 1, N'Male', N'Active', N'017-368 9328', NULL, N'eddie@gmail.com', N'Buddhism ', N'No', N'Ho Yuan Lih', N'Master', N'No', N'HouseWife', NULL, NULL, NULL, N'Lok Kah Chong', N'Master', N'Yes', N'Boss', NULL, NULL, 5000.0000, 5, 4)
INSERT [Training].[Student] ([Id], [StudentId], [IntakeId], [SPMResultId], [Insurence], [Name], [Age], [DOB], [IC], [NationalityId], [Gender], [Status], [PhoneNum], [OtherPhoneNum], [EmailAddress], [Religion], [SingleParent], [MomName], [MomEdu], [MomWorkStatus], [MomJob], [MomFeildWork], [MomSectorJob], [MomSalary], [FatherName], [FatherEdu], [FatherWorkStatus], [FatherJob], [FatherFeildWork], [FatherSectorJob], [FatherSalary], [NumSibling], [BirthOrd]) VALUES (3, N'P16070003', 2, NULL, 1, N'Lim Jian Yang', 19, CAST(N'1997-11-10' AS Date), 971011106049, 1, N'Male', N'Active', N'017-368 9328', N'0173689328', N'limjianyang30@gmail.com', N'Buddhism ', N'No', N'Lim Hiong', N'Form 6', N'No', N'HouseWife', NULL, NULL, NULL, N'Lim Ben', N'Form 6', N'Yes', NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [Training].[Student] OFF
SET IDENTITY_INSERT [Training].[Package_Course] ON 

INSERT [Training].[Package_Course] ([Id], [CourseId], [StudentId], [TotalPrice], [FirstPay], [MonthlyInterest], [TotalMonthlyP], [AfterPlnPay], [InterestRate], [MonthlyPayment], [TotalLeft]) VALUES (1, N'DSE', 1, CAST(26888.00 AS Decimal(18, 2)), CAST(1000.00 AS Decimal(18, 2)), 12, CAST(1688.80 AS Decimal(18, 2)), CAST(24199.20 AS Decimal(18, 2)), 10, CAST(140.73 AS Decimal(18, 2)), CAST(25388.00 AS Decimal(18, 2)))
INSERT [Training].[Package_Course] ([Id], [CourseId], [StudentId], [TotalPrice], [FirstPay], [MonthlyInterest], [TotalMonthlyP], [AfterPlnPay], [InterestRate], [MonthlyPayment], [TotalLeft]) VALUES (2, N'DIE', 3, CAST(50000.00 AS Decimal(18, 2)), CAST(1000.00 AS Decimal(18, 2)), 10, CAST(24000.00 AS Decimal(18, 2)), CAST(25000.00 AS Decimal(18, 2)), 50, CAST(2400.00 AS Decimal(18, 2)), CAST(47500.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [Training].[Package_Course] OFF
SET IDENTITY_INSERT [Training].[ClassStudent] ON 

INSERT [Training].[ClassStudent] ([Id], [Course_ModuleId], [StudentId], [Day], [Exam_Day], [Trial_Day], [Project_Day], [Status], [CreateDate]) VALUES (1, 2, 1, 10, 1, 1, 1, 0, CAST(N'2017-01-03' AS Date))
INSERT [Training].[ClassStudent] ([Id], [Course_ModuleId], [StudentId], [Day], [Exam_Day], [Trial_Day], [Project_Day], [Status], [CreateDate]) VALUES (2, 3, 1, 15, 1, 1, 1, 1, CAST(N'2017-01-03' AS Date))
INSERT [Training].[ClassStudent] ([Id], [Course_ModuleId], [StudentId], [Day], [Exam_Day], [Trial_Day], [Project_Day], [Status], [CreateDate]) VALUES (3, 3, 3, 15, 1, 1, 1, 1, CAST(N'2017-01-03' AS Date))
SET IDENTITY_INSERT [Training].[ClassStudent] OFF
SET IDENTITY_INSERT [Training].[TestType] ON 

INSERT [Training].[TestType] ([Id], [Name]) VALUES (1, N'FirstTest')
INSERT [Training].[TestType] ([Id], [Name]) VALUES (2, N'FirstResit')
INSERT [Training].[TestType] ([Id], [Name]) VALUES (3, N'SecondResit')
SET IDENTITY_INSERT [Training].[TestType] OFF
SET IDENTITY_INSERT [Training].[CourseWork] ON 

INSERT [Training].[CourseWork] ([Id], [ClassStudentId], [Course_ModuleId], [TestTypeId], [ModuleStandardId], [Marks], [Status], [Total1], [Total2], [Total3], [Total4]) VALUES (40, 2, 3, 1, 10, 25, N'Pass', 25, NULL, NULL, NULL)
INSERT [Training].[CourseWork] ([Id], [ClassStudentId], [Course_ModuleId], [TestTypeId], [ModuleStandardId], [Marks], [Status], [Total1], [Total2], [Total3], [Total4]) VALUES (41, 2, 3, 1, 11, 30, N'Pass', 55, NULL, NULL, NULL)
INSERT [Training].[CourseWork] ([Id], [ClassStudentId], [Course_ModuleId], [TestTypeId], [ModuleStandardId], [Marks], [Status], [Total1], [Total2], [Total3], [Total4]) VALUES (42, 2, 3, 1, 12, 15, N'Pass', 70, NULL, NULL, NULL)
INSERT [Training].[CourseWork] ([Id], [ClassStudentId], [Course_ModuleId], [TestTypeId], [ModuleStandardId], [Marks], [Status], [Total1], [Total2], [Total3], [Total4]) VALUES (43, 2, 3, 1, 13, 30, N'Pass', 100, NULL, NULL, NULL)
INSERT [Training].[CourseWork] ([Id], [ClassStudentId], [Course_ModuleId], [TestTypeId], [ModuleStandardId], [Marks], [Status], [Total1], [Total2], [Total3], [Total4]) VALUES (44, 2, 3, 2, 10, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Training].[CourseWork] ([Id], [ClassStudentId], [Course_ModuleId], [TestTypeId], [ModuleStandardId], [Marks], [Status], [Total1], [Total2], [Total3], [Total4]) VALUES (45, 2, 3, 2, 11, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Training].[CourseWork] ([Id], [ClassStudentId], [Course_ModuleId], [TestTypeId], [ModuleStandardId], [Marks], [Status], [Total1], [Total2], [Total3], [Total4]) VALUES (46, 2, 3, 2, 12, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Training].[CourseWork] ([Id], [ClassStudentId], [Course_ModuleId], [TestTypeId], [ModuleStandardId], [Marks], [Status], [Total1], [Total2], [Total3], [Total4]) VALUES (47, 2, 3, 2, 13, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Training].[CourseWork] ([Id], [ClassStudentId], [Course_ModuleId], [TestTypeId], [ModuleStandardId], [Marks], [Status], [Total1], [Total2], [Total3], [Total4]) VALUES (48, 2, 3, 3, 10, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Training].[CourseWork] ([Id], [ClassStudentId], [Course_ModuleId], [TestTypeId], [ModuleStandardId], [Marks], [Status], [Total1], [Total2], [Total3], [Total4]) VALUES (49, 2, 3, 3, 11, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Training].[CourseWork] ([Id], [ClassStudentId], [Course_ModuleId], [TestTypeId], [ModuleStandardId], [Marks], [Status], [Total1], [Total2], [Total3], [Total4]) VALUES (50, 2, 3, 3, 12, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Training].[CourseWork] ([Id], [ClassStudentId], [Course_ModuleId], [TestTypeId], [ModuleStandardId], [Marks], [Status], [Total1], [Total2], [Total3], [Total4]) VALUES (51, 2, 3, 3, 13, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Training].[CourseWork] ([Id], [ClassStudentId], [Course_ModuleId], [TestTypeId], [ModuleStandardId], [Marks], [Status], [Total1], [Total2], [Total3], [Total4]) VALUES (52, 1, 2, 1, 14, 25, N'Pass', 25, NULL, NULL, NULL)
INSERT [Training].[CourseWork] ([Id], [ClassStudentId], [Course_ModuleId], [TestTypeId], [ModuleStandardId], [Marks], [Status], [Total1], [Total2], [Total3], [Total4]) VALUES (53, 1, 2, 1, 15, 10, N'Fail', 35, NULL, NULL, NULL)
INSERT [Training].[CourseWork] ([Id], [ClassStudentId], [Course_ModuleId], [TestTypeId], [ModuleStandardId], [Marks], [Status], [Total1], [Total2], [Total3], [Total4]) VALUES (54, 1, 2, 1, 16, 30, N'Pass', 65, NULL, NULL, NULL)
INSERT [Training].[CourseWork] ([Id], [ClassStudentId], [Course_ModuleId], [TestTypeId], [ModuleStandardId], [Marks], [Status], [Total1], [Total2], [Total3], [Total4]) VALUES (55, 1, 2, 1, 17, 30, N'Pass', 95, NULL, NULL, NULL)
INSERT [Training].[CourseWork] ([Id], [ClassStudentId], [Course_ModuleId], [TestTypeId], [ModuleStandardId], [Marks], [Status], [Total1], [Total2], [Total3], [Total4]) VALUES (56, 1, 2, 2, 14, 25, N'Pass', NULL, NULL, NULL, NULL)
INSERT [Training].[CourseWork] ([Id], [ClassStudentId], [Course_ModuleId], [TestTypeId], [ModuleStandardId], [Marks], [Status], [Total1], [Total2], [Total3], [Total4]) VALUES (57, 1, 2, 2, 15, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Training].[CourseWork] ([Id], [ClassStudentId], [Course_ModuleId], [TestTypeId], [ModuleStandardId], [Marks], [Status], [Total1], [Total2], [Total3], [Total4]) VALUES (58, 1, 2, 2, 16, 30, N'Pass', NULL, NULL, NULL, NULL)
INSERT [Training].[CourseWork] ([Id], [ClassStudentId], [Course_ModuleId], [TestTypeId], [ModuleStandardId], [Marks], [Status], [Total1], [Total2], [Total3], [Total4]) VALUES (59, 1, 2, 2, 17, 30, N'Pass', NULL, NULL, NULL, NULL)
INSERT [Training].[CourseWork] ([Id], [ClassStudentId], [Course_ModuleId], [TestTypeId], [ModuleStandardId], [Marks], [Status], [Total1], [Total2], [Total3], [Total4]) VALUES (60, 1, 2, 3, 14, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Training].[CourseWork] ([Id], [ClassStudentId], [Course_ModuleId], [TestTypeId], [ModuleStandardId], [Marks], [Status], [Total1], [Total2], [Total3], [Total4]) VALUES (61, 1, 2, 3, 15, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Training].[CourseWork] ([Id], [ClassStudentId], [Course_ModuleId], [TestTypeId], [ModuleStandardId], [Marks], [Status], [Total1], [Total2], [Total3], [Total4]) VALUES (62, 1, 2, 3, 16, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Training].[CourseWork] ([Id], [ClassStudentId], [Course_ModuleId], [TestTypeId], [ModuleStandardId], [Marks], [Status], [Total1], [Total2], [Total3], [Total4]) VALUES (63, 1, 2, 3, 17, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Training].[CourseWork] ([Id], [ClassStudentId], [Course_ModuleId], [TestTypeId], [ModuleStandardId], [Marks], [Status], [Total1], [Total2], [Total3], [Total4]) VALUES (64, 3, 3, 1, 10, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Training].[CourseWork] ([Id], [ClassStudentId], [Course_ModuleId], [TestTypeId], [ModuleStandardId], [Marks], [Status], [Total1], [Total2], [Total3], [Total4]) VALUES (65, 3, 3, 1, 11, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Training].[CourseWork] ([Id], [ClassStudentId], [Course_ModuleId], [TestTypeId], [ModuleStandardId], [Marks], [Status], [Total1], [Total2], [Total3], [Total4]) VALUES (66, 3, 3, 1, 12, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Training].[CourseWork] ([Id], [ClassStudentId], [Course_ModuleId], [TestTypeId], [ModuleStandardId], [Marks], [Status], [Total1], [Total2], [Total3], [Total4]) VALUES (67, 3, 3, 1, 13, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Training].[CourseWork] ([Id], [ClassStudentId], [Course_ModuleId], [TestTypeId], [ModuleStandardId], [Marks], [Status], [Total1], [Total2], [Total3], [Total4]) VALUES (68, 3, 3, 2, 10, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Training].[CourseWork] ([Id], [ClassStudentId], [Course_ModuleId], [TestTypeId], [ModuleStandardId], [Marks], [Status], [Total1], [Total2], [Total3], [Total4]) VALUES (69, 3, 3, 2, 11, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Training].[CourseWork] ([Id], [ClassStudentId], [Course_ModuleId], [TestTypeId], [ModuleStandardId], [Marks], [Status], [Total1], [Total2], [Total3], [Total4]) VALUES (70, 3, 3, 2, 12, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Training].[CourseWork] ([Id], [ClassStudentId], [Course_ModuleId], [TestTypeId], [ModuleStandardId], [Marks], [Status], [Total1], [Total2], [Total3], [Total4]) VALUES (71, 3, 3, 2, 13, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Training].[CourseWork] ([Id], [ClassStudentId], [Course_ModuleId], [TestTypeId], [ModuleStandardId], [Marks], [Status], [Total1], [Total2], [Total3], [Total4]) VALUES (72, 3, 3, 3, 10, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Training].[CourseWork] ([Id], [ClassStudentId], [Course_ModuleId], [TestTypeId], [ModuleStandardId], [Marks], [Status], [Total1], [Total2], [Total3], [Total4]) VALUES (73, 3, 3, 3, 11, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Training].[CourseWork] ([Id], [ClassStudentId], [Course_ModuleId], [TestTypeId], [ModuleStandardId], [Marks], [Status], [Total1], [Total2], [Total3], [Total4]) VALUES (74, 3, 3, 3, 12, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [Training].[CourseWork] ([Id], [ClassStudentId], [Course_ModuleId], [TestTypeId], [ModuleStandardId], [Marks], [Status], [Total1], [Total2], [Total3], [Total4]) VALUES (75, 3, 3, 3, 13, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [Training].[CourseWork] OFF
SET IDENTITY_INSERT [Training].[SPMResult] ON 

INSERT [Training].[SPMResult] ([Id], [StudentId], [SubjectName], [Grade]) VALUES (1, 1, N'BM', N'A+        ')
INSERT [Training].[SPMResult] ([Id], [StudentId], [SubjectName], [Grade]) VALUES (2, 1, N'BI', N'A+        ')
INSERT [Training].[SPMResult] ([Id], [StudentId], [SubjectName], [Grade]) VALUES (4, 3, N'BM', N'A         ')
INSERT [Training].[SPMResult] ([Id], [StudentId], [SubjectName], [Grade]) VALUES (5, 3, N'BI', N'C+        ')
SET IDENTITY_INSERT [Training].[SPMResult] OFF
SET IDENTITY_INSERT [Training].[Sibling] ON 

INSERT [Training].[Sibling] ([Id], [StudentId], [Name], [Age], [Gender], [HomePosition], [Occupation]) VALUES (1, 1, N'Lok Hui Wen', 13, N'Female', 2, N'Student')
INSERT [Training].[Sibling] ([Id], [StudentId], [Name], [Age], [Gender], [HomePosition], [Occupation]) VALUES (3, 3, N'Lim Xuan', 12, N'Female', 2, N'Student')
INSERT [Training].[Sibling] ([Id], [StudentId], [Name], [Age], [Gender], [HomePosition], [Occupation]) VALUES (4, 3, N'Lim Yuan', 10, N'Male', 3, N'student')
SET IDENTITY_INSERT [Training].[Sibling] OFF
SET IDENTITY_INSERT [Training].[Address] ON 

INSERT [Training].[Address] ([Id], [StudentId], [StreetLine1], [StreetLine2], [PostCode], [City], [State], [Country]) VALUES (1, 1, N'1,Jalan 20/9', N'Taman Paramount', N'46300', N'PetalingJaya', N'Selangor', N'Malaysia')
INSERT [Training].[Address] ([Id], [StudentId], [StreetLine1], [StreetLine2], [PostCode], [City], [State], [Country]) VALUES (2, 1, N'2,Jalan 20/9', N'Taman Paramount', N'46300', N'PetalingJaya', N'Selangor', N'Malaysia')
INSERT [Training].[Address] ([Id], [StudentId], [StreetLine1], [StreetLine2], [PostCode], [City], [State], [Country]) VALUES (4, 3, N'1,jalan 20', N'taman jaya', N'46300', N'PetalingJaya', N'Selangor', N'Malaysia')
INSERT [Training].[Address] ([Id], [StudentId], [StreetLine1], [StreetLine2], [PostCode], [City], [State], [Country]) VALUES (5, 3, N'2,jalan 20/1', N'taman bahagia', N'46300', N'PetalingJaya', N'Selangor', N'Malaysia')
SET IDENTITY_INSERT [Training].[Address] OFF
SET IDENTITY_INSERT [Training].[Invoice] ON 

INSERT [Training].[Invoice] ([Id], [StudentId], [Ref], [Date], [Description], [Description2], [Description3], [Amount], [Amount2], [Amount3], [GST], [GST2], [GST3], [GSTAmt], [Total], [FinalTotal], [Color]) VALUES (1, 1, N'Cash', CAST(N'2017-01-03' AS Date), N'1st payment', NULL, NULL, CAST(500.00 AS Decimal(18, 2)), NULL, NULL, CAST(28.30 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(28.30 AS Decimal(18, 2)), CAST(471.69 AS Decimal(18, 2)), CAST(500.00 AS Decimal(18, 2)), N'#00ff00')
INSERT [Training].[Invoice] ([Id], [StudentId], [Ref], [Date], [Description], [Description2], [Description3], [Amount], [Amount2], [Amount3], [GST], [GST2], [GST3], [GSTAmt], [Total], [FinalTotal], [Color]) VALUES (3, 3, N'Cash', CAST(N'2017-01-03' AS Date), N'First Payment', N'Tool Box', N'Insurance', CAST(500.00 AS Decimal(18, 2)), CAST(300.00 AS Decimal(18, 2)), CAST(86.00 AS Decimal(18, 2)), CAST(28.30 AS Decimal(18, 2)), CAST(16.98 AS Decimal(18, 2)), CAST(4.86 AS Decimal(18, 2)), CAST(50.15 AS Decimal(18, 2)), CAST(835.84 AS Decimal(18, 2)), CAST(886.00 AS Decimal(18, 2)), N'#00ff00')
INSERT [Training].[Invoice] ([Id], [StudentId], [Ref], [Date], [Description], [Description2], [Description3], [Amount], [Amount2], [Amount3], [GST], [GST2], [GST3], [GSTAmt], [Total], [FinalTotal], [Color]) VALUES (4, 3, N'Cash', CAST(N'2017-01-04' AS Date), N'Second Payment', NULL, NULL, CAST(1000.00 AS Decimal(18, 2)), NULL, NULL, CAST(56.60 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(56.60 AS Decimal(18, 2)), CAST(943.39 AS Decimal(18, 2)), CAST(1000.00 AS Decimal(18, 2)), N'#000000')
SET IDENTITY_INSERT [Training].[Invoice] OFF
SET IDENTITY_INSERT [Training].[Attendance] ON 

INSERT [Training].[Attendance] ([Id], [ClassStudentId], [MorningIn], [MorningOut], [AfternoonIn], [AfternoonOut], [TodayDate], [MStatus], [AStatus], [Status], [EditBy], [EditDate]) VALUES (1, 2, CAST(N'10:30:00' AS Time), CAST(N'12:15:00' AS Time), CAST(N'13:15:00' AS Time), CAST(N'16:00:00' AS Time), CAST(N'2017-01-03' AS Date), N'Late', N'Ontime', 1, N'admin@test.com', CAST(N'2017-01-03 13:12:32.783' AS DateTime))
INSERT [Training].[Attendance] ([Id], [ClassStudentId], [MorningIn], [MorningOut], [AfternoonIn], [AfternoonOut], [TodayDate], [MStatus], [AStatus], [Status], [EditBy], [EditDate]) VALUES (2, 3, CAST(N'09:30:00' AS Time), CAST(N'11:15:00' AS Time), CAST(N'14:15:00' AS Time), CAST(N'16:00:00' AS Time), CAST(N'2017-01-03' AS Date), N'Ontime', N'Late', 1, N'admin@test.com', CAST(N'2017-01-03 13:12:32.787' AS DateTime))
SET IDENTITY_INSERT [Training].[Attendance] OFF
