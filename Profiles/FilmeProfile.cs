using apiRest.Data.Dtos;
using apiRest.Models;
using AutoMapper;

namespace apiRest.Profiles
{
    public class FilmeProfile:Profile
    {
        public FilmeProfile(){
            CreateMap<CreateFilmeDto,Filme>();
            CreateMap<Filme,ReadFilmeDto>();
            CreateMap<UpdateFilmeDto,Filme>();
        }
    }
}