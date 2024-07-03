using lazergo.Conexao;
using lazergo.Dto;
using lazergo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lazergo.Services.Usuario
{
    public class UsuarioService : IUsuarioInterface
    {
        private readonly AppDbContext _appDbContext;

        public UsuarioService(AppDbContext context)
        {
            _appDbContext = context;
        }

        public async Task<UsuarioModel> Cadastrar(UsuarioCriacaoDto usuarioCriacaoDto)
        {
            try
            {
                CriarSenhaHash(usuarioCriacaoDto.Senha, out byte[] senhaHash, out byte[] senhaSalt);

                usuarioCriacaoDto.Celular = Regex.Replace(usuarioCriacaoDto.Celular, @"\D", "");

                var usuario = new UsuarioModel
                {
                    Usuario = usuarioCriacaoDto.Usuario,
                    Email = usuarioCriacaoDto.Email,
                    SenhaHash = senhaHash,
                    SenhaSalt = senhaSalt,
                    Nome = usuarioCriacaoDto.Nome,
                    CPF = usuarioCriacaoDto.CPF,
                    Sexo = usuarioCriacaoDto.Sexo,
                    DtNascimento = usuarioCriacaoDto.DtNascimento,
                    Celular = usuarioCriacaoDto.Celular,
                    Endereco = usuarioCriacaoDto.Endereco,
                    Numero = usuarioCriacaoDto.Numero,
                    Bairro = usuarioCriacaoDto.Bairro,
                    Cidade = usuarioCriacaoDto.Cidade,
                    CEP = usuarioCriacaoDto.CEP,
                    UF = usuarioCriacaoDto.UF,
                    Observacao = usuarioCriacaoDto.Observacao,
                    TipoPessoa = usuarioCriacaoDto.TipoPessoa,
                    TipoUsuario = usuarioCriacaoDto.TipoUsuario
                };

                _appDbContext.Add(usuario);
                await _appDbContext.SaveChangesAsync();

                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UsuarioModel> Login(LoginDto loginDto)
        {
            try
            {
                var usuario = await _appDbContext.usuarios.FirstOrDefaultAsync(user => user.Email == loginDto.Email);

                if (usuario == null)
                {
                    return new UsuarioModel();
                }

                if (!VerificarSenha(loginDto.Senha, usuario.SenhaHash, usuario.SenhaSalt))
                {
                    return new UsuarioModel();
                }

                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UsuarioModel> Editar(int id, UsuarioCriacaoDto usuarioCriacaoDto)
        {
            try
            {
                var usuario = await _appDbContext.usuarios.FindAsync(id);
                if (usuario == null)
                {
                    throw new Exception("Usuário não encontrado");
                }

                usuario.Usuario = usuarioCriacaoDto.Usuario;
                usuario.Email = usuarioCriacaoDto.Email;
                usuario.Nome = usuarioCriacaoDto.Nome;
                usuario.CPF = usuarioCriacaoDto.CPF;
                usuario.Sexo = usuarioCriacaoDto.Sexo;
                usuario.DtNascimento = usuarioCriacaoDto.DtNascimento;
                usuario.Celular = Regex.Replace(usuarioCriacaoDto.Celular, @"\D", "");
                usuario.Endereco = usuarioCriacaoDto.Endereco;
                usuario.Numero = usuarioCriacaoDto.Numero;
                usuario.Bairro = usuarioCriacaoDto.Bairro;
                usuario.Cidade = usuarioCriacaoDto.Cidade;
                usuario.CEP = usuarioCriacaoDto.CEP;
                usuario.UF = usuarioCriacaoDto.UF;
                usuario.Observacao = usuarioCriacaoDto.Observacao;
                usuario.TipoPessoa = usuarioCriacaoDto.TipoPessoa;
                usuario.TipoUsuario = usuarioCriacaoDto.TipoUsuario;

                _appDbContext.usuarios.Update(usuario);
                await _appDbContext.SaveChangesAsync();

                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UsuarioModel> ObterPorId(int id)
        {
            try
            {
                return await _appDbContext.usuarios.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void CriarSenhaHash(string senha, out byte[] senhaHash, out byte[] senhaSalt)
        {
            using (HMACSHA512 hmac = new HMACSHA512())
            {
                senhaSalt = hmac.Key;
                senhaHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
            }
        }

        private bool VerificarSenha(string senha, byte[] senhaHash, byte[] senhaSalt)
        {
            using (HMACSHA512 hmac = new HMACSHA512(senhaSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
                return computedHash.SequenceEqual(senhaHash);
            }
        }
    }
}
