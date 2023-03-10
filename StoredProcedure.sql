USE [EmployeeDB]
GO
/****** Object:  StoredProcedure [dbo].[GetEmployee]    Script Date: 3/9/2023 4:24:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jelena
-- Create date: 20230309
-- Description:	Procedura za unijeti datum i poziciju vraca sve radnike zaposlene na toj poziciji na taj datum
-- =============================================
CREATE PROCEDURE [dbo].[GetEmployee] 
	@InputDate datetime,
	@InputPositionId int
AS
BEGIN
	SET NOCOUNT ON;

SELECT e.PositionId, e.FirstName, e.LastName, e.HireDate
FROM 
	dbo.Employees e
	JOIN dbo.Positions p ON e.Id = p.Id
	WHERE
	e.HireDate = @InputDate 
	AND e.PositionId = @InputPositionId
END
GO
