using lazergo.Dto;
using lazergo.Models;
using System.Threading.Tasks;

namespace lazergo.Services.Usuario
{
    public interface IUsuarioInterface
    {
        Task<UsuarioModel> Cadastrar(UsuarioCriacaoDto usuarioCriacaoDto);
        Task<UsuarioModel> Login(LoginDto loginDto);
        Task<UsuarioModel> Editar(int id, UsuarioCriacaoDto usuarioCriacaoDto);
        Task<UsuarioModel> ObterPorId(int id);
    }
}
