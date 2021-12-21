using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using apiRest.Models;
using System.Linq;
using apiRest.Data;
using apiRest.Data.Dtos;
using AutoMapper;

namespace apiRest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;
        public FilmeController(FilmeContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        /*Ele já monta o filme automaticamente, fazendo as devidas conversões*/
        public IActionResult AdicionaFilme([FromBody]CreateFilmeDto filmeDto)
        {
            /*Convertendo de filmeDto para filme
            O generic é para que classe queremos converter e o objeto passado por parametro
            de qual lugar estamos convertendo
            */
            Filme filme = _mapper.Map<Filme>(filmeDto);

            _context.Filmes.Add(filme);
            _context.SaveChanges();
            /*Explicando os parametros:
                qual é a função que recupera o valor, qual é a "chave", e qual é o valor de fato
            */
            return CreatedAtAction(nameof(RecuperaFilmesPorId), new {Id = filme.Id},filme);
            
        }

        [HttpGet]
        public IEnumerable<Filme> RecuperarFilmes()
        {
            return _context.Filmes;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmesPorId(int id)
        {
            /*Retorna o primeiro filme que tiver id igual ao id passado por parametro*/
            Filme filme =  _context.Filmes.FirstOrDefault(filme => filme.Id == id); 
            if(filme == null){
                return NotFound();
            }
            ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);
            return Ok(filmeDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id,[FromBody]UpdateFilmeDto filmeDto)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme=>filme.Id == id);
            if(filme == null){
                return NotFound();
            }
            //pegando os dados de filmeDto e sobreescrevendo os dados de filme
            _mapper.Map(filmeDto,filme);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id){
            Filme filme = _context.Filmes.FirstOrDefault(filme=>filme.Id == id);
            if(filme == null){
                return NotFound();
            }
            _context.Filmes.Remove(filme);
            _context.SaveChanges();
            return NoContent();
        }

    }
}