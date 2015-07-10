USE [Experimento2]
GO

/****** Object:  StoredProcedure [dbo].[sp_consulta_episodios_por_paciente]    Script Date: 09/07/2015 7:44:26 p. m. ******/
DROP PROCEDURE [dbo].[sp_consulta_episodios_por_paciente]
GO

/****** Object:  StoredProcedure [dbo].[sp_consulta_episodios_por_paciente]    Script Date: 09/07/2015 7:44:26 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_consulta_episodios_por_paciente]
	-- Add the parameters for the stored procedure here
	 @PageSize as int,
     @PageNumber as int,
	 @idpaciente as int
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
            ROW_NUMBER() OVER (ORDER BY [id_paciente]) AS RowNumber 
     FROM [Experimento2].[dbo].[tbl_episodios] AS E
     LEFT JOIN [Experimento2].[dbo].[tbl_intensidad] AS INTENSIDAD ON  INTENSIDAD.id_intensidad = E.intensidad
     where id_paciente = @idpaciente

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

