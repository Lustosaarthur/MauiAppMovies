using AppMovies.Context.Repositories;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAppMovies.Messages;
using MauiAppMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppMovies.ViewModels
{
    public partial class FavoritiesPageViewModel : ObservableObject
    {
        private IMoviesRepository _repository;
        [ObservableProperty]
        private List<FilmeViewModel> _filmes;
        private List<FilmeViewModel> filmeFiltred;
        [ObservableProperty]
        private string textSearch;
        public FavoritiesPageViewModel()
        {
            _repository = new MoviesRepository();
            filmeFiltred = (List<FilmeViewModel>)_repository.GetAll();

            MessengerHelper.ReloadDataRequested += OnReloadData;
            LoadData();
        }
        private void OnReloadData(ReloadDataMessage message)
        {
            LoadData();
        }
        private void LoadData()
        {
            Filmes = (List<FilmeViewModel>)_repository.GetAll();
        }

        [RelayCommand]
        private void FilmDetail(FilmeViewModel filme)
        {
            var parameter = new Dictionary<string, object>()
            {
                {"filme", filme }
            };
            Shell.Current.GoToAsync("detail", parameter);
        }
        [RelayCommand]
        private void  TitleSearch()
        {
            Filmes = filmeFiltred.Where(
                    a => a.Titulo.ToLower().Contains(TextSearch.ToLower())
                )
                .ToList();
        }
    }
}
