USE [Experimento2]
GO

/****** Object:  StoredProcedure [dbo].[sp_registrar_episodio_paciente]    Script Date: 09/07/2015 7:45:18 p. m. ******/
DROP PROCEDURE [dbo].[sp_registrar_episodio_paciente]
GO

/****** Object:  StoredProcedure [dbo].[sp_registrar_episodio_paciente]    Script Date: 09/07/2015 7:45:18 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_registrar_episodio_paciente]
	-- Add the parameters for the stored procedure here
	@idpaciente as varchar(max),
	@idintensidad as int, 
	@duracion as int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @idpacientedb as int  = (select  id_paciente from [dbo].[tbl_pacientes] where userId  = @idpaciente  )
    INSERT INTO  [Experimento2].[dbo].[tbl_episodios] (id_paciente, intensidad, fecha_episodio, duracion)
	VALUES(@idpacientedb, @idintensidad, GETDATE(), @duracion)
END

GO

