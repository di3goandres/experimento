USE [Experimento2]
GO

/****** Object:  StoredProcedure [dbo].[sp_consultar_doctores_identificacion]    Script Date: 09/07/2015 7:44:45 p. m. ******/
DROP PROCEDURE [dbo].[sp_consultar_doctores_identificacion]
GO

/****** Object:  StoredProcedure [dbo].[sp_consultar_doctores_identificacion]    Script Date: 09/07/2015 7:44:45 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_consultar_doctores_identificacion]
	-- Add the parameters for the stored procedure here
     @PageSize as int,
     @PageNumber as int,
	  @Identificacion as varchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	  WITH YourCTE AS 
(
       SELECT [id_doctor]
      ,[doctorId]
      ,[nombres_doctor]
      ,[apellidos_doctor]
      ,[ident_doctor]
      ,[tipo_id]
      ,[id_especialidad]
      ,[mail_doctor]
      ,
            ROW_NUMBER() OVER (ORDER BY [id_doctor]) AS RowNumber 
            FROM [Experimento2].[dbo].[tbl_doctores]
				where [ident_doctor] like '%'+  @Identificacion + '%'

	
)
SELECT 
    *,
    (SELECT MAX(RowNumber) FROM YourCTE) AS 'TotalRows' 
FROM 
    YourCTE
    WHERE RowNumber BETWEEN @PageSize * @PageNumber + 1 
                    AND @PageSize * (@PageNumber + 1)
END

GO

