using AutoMapper;
using LibApi.Entities;
using LibApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApi
{
    public class LibraryMappingProfile : Profile
    {
        public LibraryMappingProfile()
        {
            CreateMap<Book, BookDto>();

            CreateMap<Author, AuthorDto>();

            CreateMap<CreateBookDto, Book>();

            CreateMap<CreateAuthorDto, Author>();

            CreateMap<CreateBorrowDto, Borrow>();

            CreateMap<Borrow, BorrowDto>()
                .ForMember(m => m.Email, c => c.MapFrom(s => s.User.Email))
                .ForMember(m => m.Book, c => c.MapFrom(s => s.Book));






        }
    }
}
