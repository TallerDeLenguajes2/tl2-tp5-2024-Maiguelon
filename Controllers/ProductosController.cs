using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Models;
using Repositories;

[ApiController]
[Route("[controller]")]

public class ProductoController : ControllerBase
{
    // private Productos producto;
    private ProductoRepository productosRep;

    public ProductoController()
    {
        productosRep = new ProductoRepository();
    }

    [HttpPost("AgregarProducto")]
    public ActionResult AgregarProducto([FromBody] Productos productoNuevo)
    {
        productosRep.CreateProducto(productoNuevo);

        return Created();
    }

    [HttpGet("GetProductos")]
    public ActionResult<List<Productos>> GetProductos()
    {
        return Ok(productosRep.GetAllProductos());
    }

    [HttpGet("DetalleProducto/{idBuscado}")]
    public ActionResult<Productos> DetalleProducto(int idBuscado)
    {
        return Ok(productosRep.GetDetalleDeProducto(idBuscado));
    }

    [HttpPut("ModificarNombreProducto/{idBuscado}")]
    public ActionResult ModificarNombreProducto(int idBuscado, [FromBody] Productos producto)
    {
        productosRep.UpdateProducto(idBuscado, producto);
        return Ok();
    }

    [HttpDelete("DeleteProducto/{idBuscado}")]
    public ActionResult DeleteProducto(int idBuscado)
    {
        productosRep.DeleteProducto(idBuscado);
        return Ok();
    }
}