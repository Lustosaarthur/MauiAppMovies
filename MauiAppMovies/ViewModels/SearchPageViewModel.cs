using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAppMovies.Models;
using MauiAppMovies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppMovies.ViewModels
{
    public partial class SearchPageViewModel : ObservableObject
    {
        private string apiKey = "73bb9ec7";
        private FilmeService service;

        [ObservableProperty]
        private string nameFilme;
 

        [ObservableProperty]
        private List<FilmeViewModel> allFilms;
        public SearchPageViewModel()
        {
            service = new FilmeService();
        }
        [RelayCommand]
        private void GoBack()
        {
            Shell.Current.GoToAsync("..");
        }
        [RelayCommand]
        private void OnTextSearch()
        {
             InitializeAsync(NameFilme, apiKey);
        }
        public async Task InitializeAsync(string Name,string apiKey)
        {
            AllFilms = await service.LoadData(Name, apiKey);
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
    }
}
