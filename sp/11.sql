USE [Experimento2]
GO

/****** Object:  StoredProcedure [dbo].[sp_obtener_tipos_identificacion]    Script Date: 09/07/2015 7:45:13 p. m. ******/
DROP PROCEDURE [dbo].[sp_obtener_tipos_identificacion]
GO

/****** Object:  StoredProcedure [dbo].[sp_obtener_tipos_identificacion]    Script Date: 09/07/2015 7:45:13 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_obtener_tipos_identificacion]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
SELECT [id_tipoId]
      ,[nombre_tipoId]
    
  FROM [Experimento2].[dbo].[tbl_tipoId]
END

GO

