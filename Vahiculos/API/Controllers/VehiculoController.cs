﻿using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase, IVehiculoController
    {
        private IVehiculoFlujo _vehiculoFlujo;
        private ILogger<VehiculoController> _logger;

        public VehiculoController(IVehiculoFlujo vehiculoFlujo, ILogger<VehiculoController> logger)
        {
            _vehiculoFlujo = vehiculoFlujo;
            _logger = logger;
        }
        #region Operaciones
        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] VehiculoRequest vehiculo)
        {
            var resultado = await _vehiculoFlujo.Agregar(vehiculo);
            return CreatedAtAction(nameof(Obtener), new { Id = resultado }, null);
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Editar([FromRoute] Guid Id, [FromBody] VehiculoRequest vehiculo)
        {
            if (!await VerificarVehiculoExiste(Id))
            {
                return NotFound("El vehiculo no existe");
            }
            var resultado = await _vehiculoFlujo.Editar(Id, vehiculo);
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] Guid id)
        {
            if (!await VerificarVehiculoExiste(id))
            {
                return NotFound("El vehiculo no existe");
            }
            var resultado = await _vehiculoFlujo.Eliminar(id);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var resultado = await _vehiculoFlujo.Obtener();
            if (!resultado.Any())
            {
                return NoContent();
            }
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Obtener([FromRoute] Guid id)
        {
            var resultado = await _vehiculoFlujo.Obtener(id);

            return Ok(resultado);
        }
        #endregion Operaciones

        #region Helpers
        private async Task<bool> VerificarVehiculoExiste(Guid Id)
        {
            var resultadoValidacion = false;
            var resultadoVehiculoExiste = await _vehiculoFlujo.Obtener(Id);
            if (resultadoVehiculoExiste != null)
            {
                resultadoValidacion = true;
            }
            return resultadoValidacion;
        }
        #endregion Helpers
    }
}
    