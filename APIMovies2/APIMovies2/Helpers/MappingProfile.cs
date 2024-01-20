using APIMovies2.DTO;
using APIMovies2.Model;
using AutoMapper;

namespace APIMovies2.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieDtoDetailes>();
            CreateMap<MoviesDTO, Movie>().ForMember(src => src.Poster, opt => opt.Ignore());


        }
    }
}
