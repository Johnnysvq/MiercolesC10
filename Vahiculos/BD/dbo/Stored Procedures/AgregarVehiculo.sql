-- =============================================
-- Author:		<Author,,Johnny>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE AgregarVehiculo
	-- Add the parameters for the stored procedure here
	@id AS uniqueidentifier
	,@IdModelo AS uniqueidentifier
	,@Placa AS VARCHAR(MAX)
	,@Color AS VARCHAR(MAX)
	,@Anio AS INT
	,@Precio AS DECIMAL(18,0)
	,@CorreoPropietario AS VARCHAR(MAX)
	,@TelefonoPropietario AS VARCHAR(MAX)	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	BEGIN TRANSACTION
		INSERT INTO [dbo].[Vehiculos]
				   ([id]
				   ,[IdModelo]
				   ,[Placa]
				   ,[Color]
				   ,[Anio]
				   ,[Precio]
				   ,[CorreoPropietario]
				   ,[TelefonoPropietario])
			 VALUES
				   (@id
					,@IdModelo
					,@Placa
					,@Color
					,@Anio
					,@Precio
					,@CorreoPropietario
					,@TelefonoPropietario)
				SELECT @Id
	COMMIT TRANSACTION
END