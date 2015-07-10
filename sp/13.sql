USE [Experimento2]
GO

/****** Object:  StoredProcedure [dbo].[sp_registrar_paciente]    Script Date: 09/07/2015 7:45:23 p. m. ******/
DROP PROCEDURE [dbo].[sp_registrar_paciente]
GO

/****** Object:  StoredProcedure [dbo].[sp_registrar_paciente]    Script Date: 09/07/2015 7:45:23 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_registrar_paciente]
	-- Add the parameters for the stored procedure here
		@nombres_paciente as varchar(45),
		@apellidos_paciente as varchar(45),
		@tipo_id as  int, 
		@ident_paciente varchar(50),
		@genero_paciente int,
	--	@fecha_nacimiento Date,
		@direccion_paciente varchar(45),
		@telefono_paciente varchar(45),
		@movil_paciente varchar(45),
		@mail_paciente varchar(max),
		@userId varchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	INSERT INTO  [dbo].[tbl_pacientes]
	 (
		nombres_paciente,
		apellidos_paciente,
		tipo_id,
		ident_paciente, 
		genero_paciente,
		[fecha_nacimiento],
		direccion_paciente,
		[telefono_paciente], 
		[movil_paciente],
		mail_paciente,userId,fecha_registro
	) 
	VALUES
    (
	@nombres_paciente,
	 @apellidos_paciente,
	 @tipo_id, 
	 @ident_paciente,
    @genero_paciente,
	 GETDATE(),
	 @direccion_paciente,
	  @telefono_paciente,
	  @movil_paciente,@mail_paciente,@userId,
    GETDATE());
END

GO

