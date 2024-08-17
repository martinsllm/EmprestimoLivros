using AutoMapper;
using EmprestimoLivrosAPI.DTOs;
using EmprestimoLivrosAPI.Models;

namespace EmprestimoLivrosAPI.Services {

    public class MappingDTO : Profile {

        public MappingDTO() {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Livro, LivroDTO>().ReverseMap();
        }
        
    }
}