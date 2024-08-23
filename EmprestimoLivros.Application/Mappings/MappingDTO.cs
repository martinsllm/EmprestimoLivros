using AutoMapper;
using EmprestimoLivros.Application.DTOs;
using EmprestimoLivros.Domain.Entities;

namespace EmprestimoLivros.Application.Mappings {

    public class MappingDTO : Profile {

        public MappingDTO() {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Livro, LivroDTO>().ReverseMap();
            CreateMap<Emprestimo, EmprestimoDTO>().ReverseMap();
            CreateMap<Emprestimo, EmprestimoPostDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
        }
        
    }
}