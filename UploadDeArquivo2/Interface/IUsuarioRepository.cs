using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UploadDeArquivo2.Models;

namespace UploadDeArquivo2.Interface
{
    public interface IUsuarioRepository
    {
        void Salvar(Usuario u);
        List<Usuario> PegarTodosUsuarios();
    }
}
