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
    public class PerfilController : Controller
    {
        PerfilCAD perfilCAD = new PerfilCAD();

        [HttpGet("list/all")]
        public ActionResult<List<Perfil>> listarPerfil()
        {
            var lista = perfilCAD.listarPerfil();
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
        public ActionResult<Perfil> encontrarPerfil(Int32 id)
        {
            var encontrado = perfilCAD.encontrarPerfil(id);
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
        public ActionResult<Int64> agregarPerfil(Perfil Perfil)
        {
            var nuevoPerfil = perfilCAD.agregarPerfil(Perfil);
            if (nuevoPerfil > 0)
            {
                return Ok(nuevoPerfil);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("edit")]
        public ActionResult<Int64> editarPerfil(Int32 id, Perfil Perfil)
        {
            var nuevoPerfil = perfilCAD.editarPerfil(id, Perfil);
            if (nuevoPerfil > 0)
            {
                return Ok(nuevoPerfil);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete")]
        public ActionResult<Boolean> eliminarPerfil(Int32 id)
        {
            var eliminado = perfilCAD.eliminarPerfil(id);
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
