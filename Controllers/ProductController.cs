using Microsoft.AspNetCore.Mvc;
using DeleteWebapi.Model;
using DeleteWebapi.Data;
namespace DeleteWebapi.Controllers{
[ApiController]
public class DeleteProductController : ControllerBase
{
    private readonly AppDbContext _context;
    public DeleteProductController(AppDbContext context)
    {
        _context = context;
    }
    [Route("api/DeleteProduct/{id}")]
    [HttpDelete]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        if (id < 1)
            return BadRequest();
        var Vehicle = await _context.VehicleDetails.FindAsync(id);
        if (Vehicle == null)
            return NotFound();
        _context.VehicleDetails.Remove(Vehicle);
        await _context.SaveChangesAsync();
        return Ok();
    }

}
}