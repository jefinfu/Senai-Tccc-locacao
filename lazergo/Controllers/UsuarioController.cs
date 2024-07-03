using lazergo.Dto;
using lazergo.Models;
using lazergo.Services.Usuario;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace lazergo.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioInterface _usuarioService;

        public UsuarioController(IUsuarioInterface usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(UsuarioCriacaoDto usuarioCriacaoDto)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _usuarioService.Cadastrar(usuarioCriacaoDto);
                if (usuario != null)
                {
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                    return RedirectToAction("Editar", new { id = usuario.Id }); // Redireciona para a página de edição com o ID do usuário
                }
                else
                {
                    TempData["MensagemErro"] = "Ocorreu um erro no momento do cadastro";
                    return View(usuarioCriacaoDto);
                }
            }
            return View(usuarioCriacaoDto);
        }


        public async Task<IActionResult> Editar(int id)
        {
            var usuario = await _usuarioService.ObterPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }

            var usuarioCriacaoDto = new UsuarioCriacaoDto
            {
                Usuario = usuario.Usuario,
                Email = usuario.Email,
                Nome = usuario.Nome,
                CPF = usuario.CPF,
                Sexo = usuario.Sexo,
                DtNascimento = usuario.DtNascimento,
                Celular = usuario.Celular,
                Endereco = usuario.Endereco,
                Numero = usuario.Numero,
                Bairro = usuario.Bairro,
                Cidade = usuario.Cidade,
                CEP = usuario.CEP,
                UF = usuario.UF,
                Observacao = usuario.Observacao,
                TipoPessoa = usuario.TipoPessoa,
                TipoUsuario = usuario.TipoUsuario
            };

            return View(usuarioCriacaoDto);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(int id, UsuarioCriacaoDto usuarioCriacaoDto)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _usuarioService.Editar(id, usuarioCriacaoDto);
                if (usuario != null)
                {
                    TempData["MensagemSucesso"] = "Usuário editado com sucesso!";
                    return RedirectToAction("Index", "Home"); // Redireciona para a página Home após edição
                }
                else
                {
                    TempData["MensagemErro"] = "Ocorreu um erro ao editar o usuário";
                    return View(usuarioCriacaoDto);
                }
            }
            return View(usuarioCriacaoDto);
        }


    }
}
