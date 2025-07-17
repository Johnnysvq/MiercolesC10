﻿using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Reglas;
using Abstracciones.Modelos;

namespace Flujo
{
    public class VehiculoFlujo : IVehiculoFlujo
    {
        private IVehiculoDA _vehiculoDA;
        private readonly IRegistroReglas _registroReglas;
        private readonly IRevisionReglas _revisionReglas;

        public VehiculoFlujo(IVehiculoDA vehiculoDA, IRegistroReglas registroReglas, IRevisionReglas revisionReglas)
        {
            _vehiculoDA = vehiculoDA;
            _registroReglas = registroReglas;
            _revisionReglas = revisionReglas;
        }

        public async Task<Guid> Agregar(VehiculoRequest vehiculo)
        {
            return await _vehiculoDA.Agregar(vehiculo);
        }

        public async Task<Guid> Editar(Guid Id, VehiculoRequest vehiculo)
        {
            return await _vehiculoDA.Editar(Id, vehiculo);
        }

        public async Task<Guid> Eliminar(Guid id)
        {
            return await _vehiculoDA.Eliminar(id);
        }

        public async Task<IEnumerable<VehiculoResponse>> Obtener()
        {
            return await _vehiculoDA.Obtener();
        }

        public async Task<VehiculoDetalle> Obtener(Guid id)
        {
            var vehiculo = await _vehiculoDA.Obtener(id);
            vehiculo.RegistroValido = await _registroReglas.VehiculoEstaRegistrado(vehiculo.Placa, vehiculo.CorreoPropietario);
            vehiculo.RevisionValida = await _revisionReglas.RevisionEsValida(vehiculo.Placa);
            return vehiculo;
        }
    }
}
