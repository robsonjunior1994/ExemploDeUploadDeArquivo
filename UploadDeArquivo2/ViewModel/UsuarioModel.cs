using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UploadDeArquivo2.ViewModel
{
    public class UsuarioModel
    {
        public string Nome { get; set; }
        public IFormFile Foto { get; set; }
    }
}
