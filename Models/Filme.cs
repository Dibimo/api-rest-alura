using System;
using System.ComponentModel.DataAnnotations;
using apiRest.Data.Dtos;
using apiRest.Utils;
using Microsoft.AspNetCore.Mvc;
namespace apiRest.Models
{
    public class Filme
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

        public ReadFilmeDto ToReadFilmeDto()
        {
            return new ReadFilmeDto
            {
                Titulo = this.Titulo,
                Diretor = this.Diretor,
                Duracao = this.Duracao,
                Genero = this.Genero,
                Id = this.Id,
                HoraDaConsulta = DateTime.Now
            };
        }

    }
}