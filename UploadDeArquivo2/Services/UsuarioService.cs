using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UploadDeArquivo2.Interface;
using UploadDeArquivo2.Models;
using UploadDeArquivo2.ViewModel;

namespace UploadDeArquivo2.Services
{
    public class UsuarioService : IUsuarioService
    {
        readonly IUsuarioRepository _usuarioRepository;
        readonly IWebHostEnvironment _webHostEnviroment;
        public UsuarioService(IUsuarioRepository usuarioRepository, IWebHostEnvironment webHostEnvironment)
        {
            _usuarioRepository = usuarioRepository;
            _webHostEnviroment = webHostEnvironment;
        }

        public bool Salvar(UsuarioModel u)
        {
            
            Usuario usuario = new Usuario()
            {
                Nome = u.Nome,
                NomeFotoDePerfil = u.Foto.FileName
            };

            if(u != null)
            {
                this.ArmanezarFoto(u.Foto);
                _usuarioRepository.Salvar(usuario);
                return true;
            }
            return false;
        }

        public async void ArmanezarFoto(IFormFile foto)
        {
            long size = foto.Length;
            string caminho = _webHostEnviroment.WebRootPath;
            caminho += "\\imagens";



            if (foto.Length > 0)
            {
                //var filePath = Path.GetTempFileName();
                var filePath = foto.FileName;

                using (var stream = System.IO.File.Create(filePath))
                {
                    await foto.CopyToAsync(stream);
                }
            }

            if (foto.Length > 0)
            {
                var filePath = Path.Combine(caminho,
                    foto.FileName);

                using (var stream = System.IO.File.Create(filePath))
                {
                    await foto.CopyToAsync(stream);
                }
            }

        }

        public List<Usuario> PegarTodosUsuarios()
        {
            return _usuarioRepository.PegarTodosUsuarios();
        }
    }
}
