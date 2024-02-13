using MauiAppMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMovies.Context.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        private AppMoviesContext _db;
        public MoviesRepository()
        {
            _db = new AppMoviesContext();
        }
        public void Add(FilmeViewModel movie)
        {
            
                _db.Filmes.Add(movie);
                _db.SaveChanges();
            
        }

        public void Delete(FilmeViewModel movie)
        {
            _db.Filmes.Remove(movie);
            _db.SaveChanges();
        }

        public IList<FilmeViewModel> GetAll()
        {
            return _db.Filmes.ToList();

        }

        public FilmeViewModel GetById(int id)
        {
            return _db.Filmes.FirstOrDefault(a => a.Id == id);
        }

        public void Update(FilmeViewModel movie)
        {
            _db.Filmes.Update(movie);
            _db.SaveChanges();
        }

        public void Update(List<FilmeViewModel> movie)
        {
            _db.Filmes.UpdateRange(movie);
            _db.SaveChanges();
        }
    }
}
