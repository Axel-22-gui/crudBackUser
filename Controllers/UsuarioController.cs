using CRUDUser.Dao;
using CRUDUser.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDUser.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        UsuarioCAD usuarioCAD = new UsuarioCAD();

        [HttpGet("list/all")]
        public ActionResult<List<Usuario>> listarUsuarios() {
            var lista = usuarioCAD.listarUsuarios();
            if (lista.Count > 0)
            {
                return Ok(lista);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("list/param/{id}")]
        public ActionResult<Usuario> encontrarUsuario(Int64 id) {
            var encontrado = usuarioCAD.encontrarUsuario(id);
            if (encontrado.Id > 0)
            {
                return Ok(encontrado);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("add")]
        public ActionResult<Int64> agregarUsuario(Usuario usuario) {
            var nuevoUsuario = usuarioCAD.agregarUsuario(usuario);
            if (nuevoUsuario > 0)
            {
                return Ok(nuevoUsuario);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("edit")]
        public ActionResult<Int64> editarUsuario(Int64 id, Usuario usuario) {
            var nuevoUsuario = usuarioCAD.editarUsuario(id,usuario);
            if (nuevoUsuario > 0)
            {
                return Ok(nuevoUsuario);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete")]
        public ActionResult<Boolean> eliminarUsuario(Int64 id) {
            var eliminado = usuarioCAD.eliminarUsuario(id);
            if (eliminado)
            {
                return Ok(id);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
