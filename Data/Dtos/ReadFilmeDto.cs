using System;
using System.ComponentModel.DataAnnotations;
using apiRest.Models;
using apiRest.Utils;

namespace apiRest.Data.Dtos
{
    public class ReadFilmeDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = MensagensErros.MensagemCampoObrigatorio)]
        public string Titulo { get; set; }
        [Required(ErrorMessage = MensagensErros.MensagemCampoObrigatorio)]
        public string Diretor { get; set; }
        [StringLength(30, ErrorMessage = "O gênero não pode passar de 30 caracteres.")]
        public string Genero { get; set; }
        [Required]
        [Range(1, 600, ErrorMessage = "A duração do filme deve ter no mínimo 1 e no máximo 600 minutos")]
        public int Duracao { get; set; }

        public DateTime HoraDaConsulta {get;set;}

        public Filme ToFilme()
        {
            return new Filme
            {
                Titulo = this.Titulo,
                Diretor = this.Diretor,
                Duracao = this.Duracao,
                Genero = this.Genero,
                Id = this.Id
            };
        }
    }

}