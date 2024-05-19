using APIProducao.Context;
using APIProducao.Models;
using APIProducao.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIProducao.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext contexto) : base(contexto)
        {
                
        }       
    }
}
