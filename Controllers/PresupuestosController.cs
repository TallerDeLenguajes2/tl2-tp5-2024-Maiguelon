using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Models;
using Repositories;

[ApiController]
[Route("[controller]")]

public class PresupuestosController : ControllerBase
{
   private PresupuestosRepository presupuestosRepository;

   public PresupuestosController()
   {
      presupuestosRepository = new PresupuestosRepository();
   }

   // Endo Pointos

   [HttpPost("AgregarPresupuesto")]
   public ActionResult AgregarPresupuesto([FromBody] Presupuestos nuevoPresupuesto)
   {
      presupuestosRepository.CreatePresupuesto(nuevoPresupuesto);
      return Created();
   }

   [HttpPost("AgregarDetalle/{idBuscado}/ProductoDetalle")]
   public ActionResult AgregarDetalle(int idBuscado, int idProducto, int cantidad)
   {
      presupuestosRepository.DetallarPresupuesto(idBuscado, idProducto, cantidad);
      return Ok();
   }

   [HttpGet("ListarPresupuestos")]
   public ActionResult<List<Presupuestos>> ListarPresupuestos()
   {
      var presupuestos = presupuestosRepository.ListarPresupuestos();
      return Ok(presupuestos);
   }

   [HttpGet("BuscarPresupuesto/{idBuscado}")]
   public ActionResult<Presupuestos> ObtenerPresupuesto(int idBuscado)
   {
      var presupuesto = presupuestosRepository.BuscarPresupuesto(idBuscado);
      return Ok(presupuesto);
   }

   [HttpDelete("EliminarPresupuesto/{idBuscado}")]
   public ActionResult BorrarPresupuesto(int idBuscado)
   {
      presupuestosRepository.DeletearPresupuesto(idBuscado);
      return Ok();
   }
}
