using AppMovies.Context.Repositories;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAppMovies.Messages;
using MauiAppMovies.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppMovies.ViewModels.Favorites
{
    [QueryProperty(nameof(Filme), "filme")]
    public partial class FavoritesDetailPageViewModel : ObservableObject
    {
        HttpClient client;
        [ObservableProperty]
        private FilmeViewModel filme;
        [ObservableProperty]
        private List<FilmeViewModel> filmData;
        IMoviesRepository _repository;

        public FavoritesDetailPageViewModel()
        {
            client = new HttpClient();
            _repository = new MoviesRepository();
        }
        [RelayCommand]
        private void GoBack()
        {
            Shell.Current.GoToAsync("..");
        }
        [RelayCommand]
        private void DeleteMovie()
        {
            _repository.Delete(Filme);
            MessengerHelper.SendReloadDataMessage();
            Shell.Current.GoToAsync("..");
        }
    }
}
