using AppMovies.Context.Repositories;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAppMovies.Messages;
using MauiAppMovies.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppMovies.ViewModels.Details
{
    [QueryProperty(nameof(Filme), "filme")]
    public partial class DetailFilmPageViewModel : ObservableObject
    {
        private FilmeViewModel movie;
        private IMoviesRepository _repository;

        private FilmeViewModel _filme;
        public FilmeViewModel Filme
        {
            get { return _filme; }
            set
            {
                if (_filme != value)
                {
                    _filme = value;
                    OnPropertyChanged(); // Certifique-se de chamar o evento OnPropertyChanged ou algo similar.

                    if (_filme != null)
                    {
                        Task.Run(() => LoadPlot(_filme.ImdbID));
                    }
                }
            }
        }

        [ObservableProperty]
        private List<FilmeViewModel> filmData;

        [ObservableProperty]
        private string plot;

        private readonly HttpClient client;
        [RelayCommand]
        private void GoBack()
        {
            Shell.Current.GoToAsync("..");
        }
        public DetailFilmPageViewModel()
        {
            client = new HttpClient();
            Filme = new FilmeViewModel();
            movie = new FilmeViewModel();
            _repository = new MoviesRepository();
        }
        [RelayCommand]
        private void SaveInDb()
        {
            movie.Titulo = Filme.Titulo;
            movie.Ano = Filme.Ano;
            movie.ImdbID = Filme.ImdbID;
            movie.Poster = Filme.Poster;
            movie.Tipo = Filme.Tipo;

            FilmeViewModel filmeEncontrado = FilmData.FirstOrDefault(f => f.ImdbID == Filme.ImdbID);
            if (filmeEncontrado != null)
            {
                movie.Sinopse = filmeEncontrado.Sinopse;
                movie.Director = filmeEncontrado.Director;
                movie.Actors = filmeEncontrado.Actors;
                movie.Genre = filmeEncontrado.Genre;
            }
            _repository.Add(movie);
            MessengerHelper.SendReloadDataMessage();
            Shell.Current.GoToAsync("..");
        }
        private async Task LoadPlot(string imdbId)
        {
            //await CarregarDetalhesFilme(imdbId);
            await LoadDetails(imdbId);
        }

        public async Task CarregarDetalhesFilme(string imdbId)
        {
            string apiUrl = $"https://www.omdbapi.com/?apikey=73bb9ec7&i={imdbId}&plot=full";

            var response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                var detalhesFilme = JsonConvert.DeserializeObject<FilmeViewModel>(jsonContent);

                Plot = detalhesFilme?.Sinopse;
            }
            else
            {
                // Lide com a situação em que os detalhes do filme não puderam ser carregados.
            }
        }
        private async Task LoadDetails(string imdbId)
        {
            string apiUrl = $"https://www.omdbapi.com/?apikey=73bb9ec7&i={imdbId}&plot=full";

            var response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                var details = JsonConvert.DeserializeObject<FilmeViewModel>(jsonContent);

                if (details != null)
                {
                    FilmData = new List<FilmeViewModel> { details };
                }
            }
            else
            {
                // Lide com a situação em que os detalhes do filme não puderam ser carregados.
            }
        }
    }
}
