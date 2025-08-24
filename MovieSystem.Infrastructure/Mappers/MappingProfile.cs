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
            
            CreateMap<Movie, MovieDto>()
                .ForMember(dest => dest.DirectorName, opt => opt.MapFrom(src => src.Director.Name))
                .ReverseMap()
                .ForMember(dest => dest.Director, opt => opt.Ignore()); 

            CreateMap<User, UserDto>()
                .ForMember(dest => dest.RatedMovieIds, opt => opt.MapFrom(src => src.Ratings.Select(r => r.MovieId)))
                .ReverseMap()
                .ForMember(dest => dest.Ratings, opt => opt.Ignore());

            CreateMap<Rating, RatingDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName))
                .ForMember(dest => dest.MovieTitle, opt => opt.MapFrom(src => src.Movie.Title))
                .ReverseMap()
                .ForMember(dest => dest.User, opt => opt.Ignore())
                .ForMember(dest => dest.Movie, opt => opt.Ignore());
        }
    }
}
