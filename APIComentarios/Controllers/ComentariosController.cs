using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using APIComentarios.Data;
using APIComentarios.Models;

namespace APIComentarios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComentariosController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Comentario>), (int)HttpStatusCode.OK)]
        public IEnumerable<Comentario> Get(
            [FromServices]ApplicationDbContext context)
        {
            return context.Comentarios.ToArray();
        }

        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public IActionResult Post(
            Comentario comentario,
            [FromServices]ApplicationDbContext context)
        {
            comentario.Id = Guid.NewGuid();
            comentario.Data = DateTime.Now;
            context.Comentarios.Add(comentario);
            context.SaveChanges();

            return Ok();
        }
    }
}