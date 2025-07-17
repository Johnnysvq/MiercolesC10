-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE EditarVehiculo
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
		UPDATE [dbo].[Vehiculos]
		   SET [IdModelo] = @IdModelo
			  ,[Placa] = @Placa
			  ,[Color] = @Color
			  ,[Anio] = @Anio
			  ,[Precio] = @Precio
			  ,[CorreoPropietario] = @CorreoPropietario
			  ,[TelefonoPropietario] = @TelefonoPropietario
		 WHERE Id = @id
		 SELECT @Id
	COMMIT TRANSACTION
END