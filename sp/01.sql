USE [Experimento2]
GO

/****** Object:  StoredProcedure [dbo].[AsociarPacienteDoctor]    Script Date: 09/07/2015 7:44:06 p. m. ******/
DROP PROCEDURE [dbo].[AsociarPacienteDoctor]
GO

/****** Object:  StoredProcedure [dbo].[AsociarPacienteDoctor]    Script Date: 09/07/2015 7:44:06 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AsociarPacienteDoctor]
	-- Add the parameters for the stored procedure here
	 @paciente as int,
     @doctor as int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	

    -- Insert statements for procedure here
	 insert into [dbo].[tbl_doctor_paciente] (id_doctor, id_paciente)values (@doctor, @paciente)
END

GO

