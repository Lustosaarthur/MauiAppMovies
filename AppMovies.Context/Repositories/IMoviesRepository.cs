
using MauiAppMovies.Models;

namespace AppMovies.Context.Repositories
{
    public interface IMoviesRepository
    {
        IList<FilmeViewModel> GetAll();
        FilmeViewModel GetById(int id);
        void Add(FilmeViewModel movie);
        void Update(FilmeViewModel movie);
        void Update(List<FilmeViewModel> movie);
        void Delete(FilmeViewModel movie);
    }
}
