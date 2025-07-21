using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Backend.DTO.Account;
using Backend.Interfaces;
using Microsoft.AspNetCore.Authorization;


namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {

        private readonly ITokenService _tokenService;

        public AccountController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }


        /*    REGISTO MANUAL!!!!

          [HttpPost("register")]
       public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
  {
      try
      {
          if (!ModelState.IsValid)
          {
              return BadRequest(ModelState);
          }

          if (!(registerDTO.Email.EndsWith("@utad.pt", StringComparison.OrdinalIgnoreCase) ||
                registerDTO.Email.EndsWith("@alunos.utad.pt", StringComparison.OrdinalIgnoreCase)))
          {
              return BadRequest(new { message = "O email tem de ser do domínio utad.pt ou alunos.utad.pt." });
          }

          var utilizador = new Utilizador
          {
              Email = registerDTO.Email,
              Nome = registerDTO.Nome,
              UserName = registerDTO.Nome
          };

          var utilizadorCriado = await _userManager.CreateAsync(utilizador, registerDTO.PalavraPasse);
          if (utilizadorCriado.Succeeded)
          {
              var token = await _userManager.GenerateEmailConfirmationTokenAsync(utilizador);
              var confirmationLink = Url.Action(
              nameof(ConfirmEmail),
              "Account",
              new { userId = utilizador.Id, token },
              Request.Scheme
              );

          await _emailService.SendEmailAsync(
          utilizador.Email,
          "Confirmação de Email - UTAD",
          $"<p>Bem-vindo à aplicação UTAD!</p><p>Por favor confirme o seu email clicando neste link: <a href='{confirmationLink}'>Confirmar Email</a></p>"
  );

  return Ok(new { message = "Utilizador registado com sucesso! Verifique o seu email para confirmar a conta." });

          }
          else
          {
              return BadRequest(utilizadorCriado.Errors);
          }
      }
      catch (Exception e)
  {
      return StatusCode(500, new 
      {
          error = "Ocorreu um erro interno.",
          detalhes = e.Message
      });
  }

  } 
      [HttpGet("confirmemail")]
      public async Task<IActionResult> ConfirmEmail(string userId, string token)
      {
      var user = await _userManager.FindByIdAsync(userId);
      if (user == null)
      {
          return BadRequest("Utilizador inválido.");
      }

      var result = await _userManager.ConfirmEmailAsync(user, token);
      if (result.Succeeded)
      {
          return Ok("Email confirmado com sucesso!");
      }
      else
      {
          return BadRequest("Erro na confirmação do email.");
      }
  }
  */
        [HttpPost("login-simulacao")]
        [AllowAnonymous]
        public IActionResult LoginSimulado([FromBody] LoginSimDTO dto)
        {
            Utilizador? utilizadorFalso = null;

            if (dto.Email == "aluno@utad.pt")
            {
                utilizadorFalso = new Utilizador
                {
                    UtilizadorId = 99,
                    Email = dto.Email,
                    Nome = "Aluno Teste",
                    GrupoUtilizadorId = 1 
                };
            }
            else if (dto.Email == "professor@utad.pt")
            {
                utilizadorFalso = new Utilizador
                {
                    UtilizadorId = 100,
                    Email = dto.Email,
                    Nome = "Professor Teste",
                    GrupoUtilizadorId = 2
                };
            }
            else if (dto.Email == "admin@utad.pt")
            {
                utilizadorFalso = new Utilizador
                {
                    UtilizadorId = 101,
                    Email = dto.Email,
                    Nome = "Admin Teste",
                    GrupoUtilizadorId = 3
                };
            }

            if (utilizadorFalso != null)
            {
                var token = _tokenService.CreateToken(utilizadorFalso);

                return Ok(new
                {
                    Success = true,
                    Token = token,
                    Nome = utilizadorFalso.Nome,
                    Email = utilizadorFalso.Email
                });
            }

            return Unauthorized(new { Success = false, Message = "Credenciais inválidas (simulação)" });
        }
    }
}