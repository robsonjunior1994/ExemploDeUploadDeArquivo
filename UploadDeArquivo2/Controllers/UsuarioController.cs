using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UploadDeArquivo2.Interface;
using UploadDeArquivo2.Models;
using UploadDeArquivo2.ViewModel;

namespace UploadDeArquivo2.Controllers
{
    public class UsuarioController : Controller
    {
        readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Post(UsuarioModel u)
        {
            if (_usuarioService.Salvar(u))
            {
                return View("Sucesso");
            }

            return View("Fracasso");
        }

        public IActionResult GetAll()
        {
            List<Usuario> usuarios = _usuarioService.PegarTodosUsuarios();

            ViewBag.Usuarios = usuarios;

            return View();
        }




    }
}
