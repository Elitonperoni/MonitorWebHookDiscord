using APIProducao.Context;
using APIProducao.Models;
using APIProducao.Repository.Interfaces;
using APIProducao.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIProducao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;
        public UsuarioController(IUnitOfWork context, IConfiguration configuration, ITokenService tokenService) 
        {
            _uof = context;
            _configuration = configuration;
            _tokenService = tokenService;
        }

        [HttpPost("autorizacao")]
        [AllowAnonymous]
        public async Task<IActionResult> ObterToken(Usuario user)
        {
            var usuario = await _uof.UsuarioRepository.GetFilter(p => p.nome.Equals(user.nome) && p.senha.Equals(user.senha));

            if (usuario is not null) 
            {
                var tokenString = _tokenService.GerarToken(_configuration["Jwt:Key"],
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    user);

                return Ok(new { Token = tokenString.ToString() });
            }
            return Unauthorized("Usuário ou senha incorretos");
        }
    }
}
