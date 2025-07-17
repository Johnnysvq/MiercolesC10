
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ObtenerVehiculos]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT        Vehiculos.TelefonoPropietario, Vehiculos.CorreoPropietario, Vehiculos.Precio, Vehiculos.Anio, Vehiculos.Color, Vehiculos.Placa, Vehiculos.IdModelo, Vehiculos.id, Modelos.Nombre AS Modelo, Marcas.Nombre AS Marca
FROM            Vehiculos INNER JOIN
                         Modelos ON Vehiculos.IdModelo = Modelos.Id INNER JOIN
                         Marcas ON Modelos.IdMarca = Marcas.Id
END