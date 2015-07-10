USE [Experimento2]
GO

/****** Object:  StoredProcedure [dbo].[sp_obtener_sintomas]    Script Date: 09/07/2015 7:45:07 p. m. ******/
DROP PROCEDURE [dbo].[sp_obtener_sintomas]
GO

/****** Object:  StoredProcedure [dbo].[sp_obtener_sintomas]    Script Date: 09/07/2015 7:45:07 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_obtener_sintomas] 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [id_sintoma]
      ,[nombre_sintoma]
      ,[descripcion_sintoma]
  FROM [Experimento2].[dbo].[tbl_sintomas]
  order by nombre_sintoma
END

GO

