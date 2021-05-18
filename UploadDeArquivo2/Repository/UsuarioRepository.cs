using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UploadDeArquivo2.Interface;
using UploadDeArquivo2.Models;

namespace UploadDeArquivo2.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        readonly AppContext _appContext;
        public UsuarioRepository(AppContext appContext)
        {
            _appContext = appContext;
        }

        public List<Usuario> PegarTodosUsuarios()
        {
            return _appContext.Usuarios.ToList();
        }

        public void Salvar(Usuario u)
        {
            _appContext.Usuarios.Add(u);
            _appContext.SaveChanges();
        }
    }
}
