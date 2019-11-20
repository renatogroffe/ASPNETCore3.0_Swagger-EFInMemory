using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIComentarios.Models
{
    public class Comentario
    {
        public Guid? Id { get; set; }
        public DateTime? Data { get; set; }

        [Required]
        [MaxLength(60)]
        public string Nome { get; set; }

        [Required]
        public string Mensagem { get; set; }
    }
}