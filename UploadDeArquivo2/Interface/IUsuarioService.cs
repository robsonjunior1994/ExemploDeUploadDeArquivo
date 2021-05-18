using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UploadDeArquivo2.Models;
using UploadDeArquivo2.ViewModel;

namespace UploadDeArquivo2.Interface
{
    public interface IUsuarioService
    {
        bool Salvar(UsuarioModel u);
        List<Usuario> PegarTodosUsuarios();
    }
}
