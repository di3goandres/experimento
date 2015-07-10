USE [Experimento2]
GO

/****** Object:  StoredProcedure [dbo].[sp_obtener_catalizadores]    Script Date: 09/07/2015 7:45:01 p. m. ******/
DROP PROCEDURE [dbo].[sp_obtener_catalizadores]
GO

/****** Object:  StoredProcedure [dbo].[sp_obtener_catalizadores]    Script Date: 09/07/2015 7:45:01 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_obtener_catalizadores] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  SELECT  [id_catalizador]
   
      ,[nombre_catalizador]
    
  FROM [Experimento2].[dbo].[tbl_catalizadores]
  order by [nombre_catalizador]
END

GO

