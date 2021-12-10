using AutoMapper;
using LibraryApp.Business.Abstract.Dtos;
using LibraryApp.Entities;

namespace LibraryApp.WebAPI.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Author, AuthorDto>(); // Converting from author to AuthorDto
            CreateMap<AuthorDto, Author>(); // Converting from AuthorDto to Author
            CreateMap<Author, AuthorWithBookDto>();
            CreateMap<AuthorWithBookDto, Author>();
            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();
            CreateMap<Book, BookWithAuthorDto>();
            CreateMap<BookWithAuthorDto, Book>();
           CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}