USE [Experimento2]
GO

/****** Object:  StoredProcedure [dbo].[sp_consulta_episodios_por_paciente_userid]    Script Date: 09/07/2015 7:44:33 p. m. ******/
DROP PROCEDURE [dbo].[sp_consulta_episodios_por_paciente_userid]
GO

/****** Object:  StoredProcedure [dbo].[sp_consulta_episodios_por_paciente_userid]    Script Date: 09/07/2015 7:44:33 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_consulta_episodios_por_paciente_userid]
	-- Add the parameters for the stored procedure here
	 @PageSize as int,
     @PageNumber as int,
	 @idpaciente as varchar(max)
AS
BEGIN
WITH YourCTE AS 
(
SELECT  E.[id_episodio]
      ,E.[id_paciente]
      ,E.[intensidad],
	  INTENSIDAD.Nombre as nombre_intensidad
      ,E.[fecha_episodio]
      ,E.[duracion],
            ROW_NUMBER() OVER (ORDER BY E.[id_paciente]) AS RowNumber 
     FROM [Experimento2].[dbo].[tbl_episodios] AS E
     LEFT JOIN [Experimento2].[dbo].[tbl_intensidad] AS INTENSIDAD ON  INTENSIDAD.id_intensidad = E.intensidad
	 left join [dbo].[tbl_pacientes] as pa on E.id_paciente =   pa.id_paciente
     where userId = @idpaciente

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

