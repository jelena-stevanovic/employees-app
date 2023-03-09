USE [EmployeeDB]
GO
SET IDENTITY_INSERT [dbo].[Positions] ON 

INSERT [dbo].[Positions] ([Id], [Title], [IsManager]) VALUES (1, N'Back-end developer', 0)
INSERT [dbo].[Positions] ([Id], [Title], [IsManager]) VALUES (2, N'Front-end developer', 0)
INSERT [dbo].[Positions] ([Id], [Title], [IsManager]) VALUES (3, N'Full-stack developer', 0)
INSERT [dbo].[Positions] ([Id], [Title], [IsManager]) VALUES (4, N'UI designer', 0)
INSERT [dbo].[Positions] ([Id], [Title], [IsManager]) VALUES (5, N'Software development manager', 1)
INSERT [dbo].[Positions] ([Id], [Title], [IsManager]) VALUES (6, N'Software test engineer', 0)
INSERT [dbo].[Positions] ([Id], [Title], [IsManager]) VALUES (7, N'Lead developer', 1)
SET IDENTITY_INSERT [dbo].[Positions] OFF
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [PositionId], [Salary], [VacationDays], [ManagerId]) VALUES (1, N'Shannon', N'Smith', 1, CAST(1141.00 AS Decimal(18, 2)), 10, 2)
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [PositionId], [Salary], [VacationDays], [ManagerId]) VALUES (2, N'Harry', N'Williams', 5, CAST(1141.00 AS Decimal(18, 2)), 13, NULL)
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [PositionId], [Salary], [VacationDays], [ManagerId]) VALUES (3, N'Charles', N'King', 2, CAST(1235.00 AS Decimal(18, 2)), 20, 2)
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [PositionId], [Salary], [VacationDays], [ManagerId]) VALUES (4, N'Simone', N'Harper', 7, CAST(1362.00 AS Decimal(18, 2)), 16, NULL)
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [PositionId], [Salary], [VacationDays], [ManagerId]) VALUES (5, N'Emma', N'Taylor', 6, CAST(1141.00 AS Decimal(18, 2)), 13, 4)
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
SET IDENTITY_INSERT [dbo].[SalaryHistories] ON 

INSERT [dbo].[SalaryHistories] ([Id], [Salary], [EmployeeId], [PositionId], [Date]) VALUES (1, CAST(2350.00 AS Decimal(18, 2)), 1, 1, CAST(N'2015-03-29T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[SalaryHistories] ([Id], [Salary], [EmployeeId], [PositionId], [Date]) VALUES (2, CAST(2450.00 AS Decimal(18, 2)), 3, 2, CAST(N'2018-04-30T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[SalaryHistories] OFF
GO
SET IDENTITY_INSERT [dbo].[Bonuses] ON 

INSERT [dbo].[Bonuses] ([Id], [BonusType], [EmployeeId]) VALUES (1, 0, 1)
INSERT [dbo].[Bonuses] ([Id], [BonusType], [EmployeeId]) VALUES (2, 2, 2)
INSERT [dbo].[Bonuses] ([Id], [BonusType], [EmployeeId]) VALUES (3, 3, 3)
INSERT [dbo].[Bonuses] ([Id], [BonusType], [EmployeeId]) VALUES (4, 2, 4)
INSERT [dbo].[Bonuses] ([Id], [BonusType], [EmployeeId]) VALUES (5, 1, 5)
SET IDENTITY_INSERT [dbo].[Bonuses] OFF
GO
SET IDENTITY_INSERT [dbo].[Deductions] ON 

INSERT [dbo].[Deductions] ([Id], [DeductionType], [EmployeeId]) VALUES (1, 0, 1)
INSERT [dbo].[Deductions] ([Id], [DeductionType], [EmployeeId]) VALUES (2, 1, 2)
INSERT [dbo].[Deductions] ([Id], [DeductionType], [EmployeeId]) VALUES (3, 1, 3)
INSERT [dbo].[Deductions] ([Id], [DeductionType], [EmployeeId]) VALUES (4, 1, 4)
INSERT [dbo].[Deductions] ([Id], [DeductionType], [EmployeeId]) VALUES (5, 2, 5)
SET IDENTITY_INSERT [dbo].[Deductions] OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230308223349_InitialMigration', N'6.0.9')
GO
