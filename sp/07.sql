USE [Experimento2]
GO

/****** Object:  StoredProcedure [dbo].[sp_consultar_pacientes]    Script Date: 09/07/2015 7:44:50 p. m. ******/
DROP PROCEDURE [dbo].[sp_consultar_pacientes]
GO

/****** Object:  StoredProcedure [dbo].[sp_consultar_pacientes]    Script Date: 09/07/2015 7:44:50 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_consultar_pacientes]
	-- Add the parameters for the stored procedure here
	 @PageSize as int,
     @PageNumber as int
AS
BEGIN
	
	 WITH YourCTE AS 
(
           SELECT [id_paciente]
      ,[nombres_paciente]
      ,[apellidos_paciente]
      ,[ident_paciente]
      ,[tipo_id]
      ,[genero_paciente]
      ,[fecha_nacimiento]
      ,[direccion_paciente]
      ,[telefono_paciente]
      ,[movil_paciente],mail_paciente
      ,[fecha_registro], 
            ROW_NUMBER() OVER (ORDER BY [id_paciente]) AS RowNumber 
            FROM [Experimento2].[dbo].[tbl_pacientes] 
	
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

