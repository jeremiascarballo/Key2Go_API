using Application.Service;
using Contract.User.Request;
using Contract.User.Response;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserResponse>>> GetAll()
        {
            var response = await _userService.GetAll();

            if (!response.Any())
            {
                return NotFound("no hay usuarios disponibles");
            }
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> GetById([FromRoute] int id)
        {
            var response = await _userService.GetById(id);

            if (response == null)
            {
                return NotFound("usuario no encontrado");
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _userService.Create(request);

            if (result == null)
                return BadRequest("Email en uso");

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.Delete(id);
            if (!result)
                return NotFound("Usuario no encontrado");

            return NoContent();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _userService.Update(id, request);

            if (updated is null)
                // Diferenciar error entre not found o email duplicado.
                return NotFound("Usuario no encontrado o email ya está en uso.");

            return Ok(updated);
        }
    }
}
