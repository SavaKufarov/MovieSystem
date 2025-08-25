using AutoMapper;
using MovieSystem.Core.DTOs;
using MovieSystem.Core.DTOs.MovieSystem.Core.DTOs;
using MovieSystem.Core.Models;

namespace MovieSystem.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Director, DirectorDto>();
            CreateMap<CreateDirectorDto, Director>();

            CreateMap<Movie, MovieDto>();
            CreateMap<CreateMovieDto, Movie>();

            CreateMap<Rating, RatingDto>();
            CreateMap<CreateRatingDto, Rating>();

            CreateMap<User, UserDto>();
            CreateMap<CreateUserDto, User>();
        }
    }
}
