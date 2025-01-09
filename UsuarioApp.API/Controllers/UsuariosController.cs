using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsuariosApp.API.Dtos.Requests;
using UsuariosApp.API.Dtos.Responses;
using UsuariosApp.API.Services;

namespace UsuariosApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class UsuariosController : ControllerBase
    {
        private string teste = "123";
        private readonly UsuarioService _usuarioService;

        public UsuariosController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        /// <summary>
        /// Cria um novo usuário no sistema
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("criar")]
        [ProducesResponseType(typeof(CriarUsuarioResponseDto), 201)]
        public async Task<IActionResult> Criar([FromBody] CriarUsuarioRequestDto dto)
        {
            try
            {
                return StatusCode(201, await _usuarioService.CriarAsync(dto));
            }
            catch (ApplicationException e)
            {
                return StatusCode(400, new { e.Message });
            }
        }
        /// <summary>
        /// Realiza a autenticação do usuário 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("autenticar")]
        [ProducesResponseType(typeof(AutenticarUsuarioResponseDto), 200)]
        public async Task<IActionResult> Autenticar([FromBody] AutenticarUsuarioRequestDto dto)
        {
            try
            {
                return StatusCode(200, await _usuarioService.AutenticarAsync(dto));
            }
            catch (ApplicationException e)
            {
                return StatusCode(401, new { e.Message });
            }
        }

        /// <summary>
        /// Gera um novo token de acesso e um novo refresh token com base no refresh token de 
        /// atualização informado.
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        [HttpPost("refresh-token")]
        [ProducesResponseType(typeof(AutenticarUsuarioResponseDto), 200)]
        public async Task<IActionResult> RefreshToken([FromBody] string refreshToken)
        {
            try
            {
                var response = await _usuarioService.RefreshTokenAsync(refreshToken);
                return Ok(response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(400, new { e.Message });
            }
        }
    }
}



