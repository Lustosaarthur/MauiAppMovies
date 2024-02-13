using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAppMovies.Models;
using MauiAppMovies.Services;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Text.Json;


namespace MauiAppMovies.ViewModels
{
    public partial class StartPageViewModel : ObservableObject
    {
        
        public string _apiKey = "73bb9ec7";

        [ObservableProperty]
        private string categoryName;
        FilmeService service;
        CategoriesService categoriesService;
        [ObservableProperty]
        private List<CategorieModel> categories;
        [ObservableProperty]
        private List<FilmeViewModel> _filmes;
        [ObservableProperty]
        private List<FilmeViewModel> _filmesHorror;
        [ObservableProperty]
        private List<FilmeViewModel> _filmesComedy;

        public StartPageViewModel()
        {

            categoriesService = new CategoriesService();

            Filmes = new List<FilmeViewModel>();
            service = new FilmeService();
            Categories = categoriesService.GetCategories();

            InitializeAsync( _apiKey);
        }
        [RelayCommand]
        private void GoToSearch()
        {
            Shell.Current.GoToAsync("search");
        }
        [RelayCommand]
        private void GoToDetail(FilmeViewModel filme)
        {
            var parameter = new Dictionary<string, object>()
            {
                {"filme" , filme}
            };
            Shell.Current.GoToAsync("detail", parameter);
        }
        [RelayCommand]
        private void UpdateCollection(CategorieModel categorie)
        {
            var search = categorie.name;
            GetDataByName(search);
        }
        public async Task GetDataByName(string search)
        {
            var apiKey = _apiKey;
            Filmes = await service.LoadData(search, apiKey);
        }
        public async Task InitializeAsync(string apiKey)
        {
            Filmes = await service.LoadData("Action", apiKey);
            FilmesHorror = await service.LoadData("Horror", apiKey);
            FilmesComedy = await service.LoadData("Comedy", apiKey);
        }
        //private async Task LoadData()
        //{
        //    string apiUrl = $"https://www.omdbapi.com/?apikey={_apiKey}&s={System.Uri.EscapeDataString(categoria)}";

        //    var response = await client.GetAsync(apiUrl);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var jsonContent = await response.Content.ReadAsStringAsync();
        //        System.Diagnostics.Debug.WriteLine($"JSON Response: {jsonContent}");

        //        try
        //        {
        //            var filmeApiResponse = JsonConvert.DeserializeObject<FilmeApiResponse>(jsonContent);

        //            if (filmeApiResponse != null)
        //            {
        //                System.Diagnostics.Debug.WriteLine($"TotalResults: {filmeApiResponse.TotalResults}");
        //                System.Diagnostics.Debug.WriteLine($"Response: {filmeApiResponse.Response}");

        //                if (filmeApiResponse.Filmes != null)
        //                {
        //                    System.Diagnostics.Debug.WriteLine($"Número de Filmes: {filmeApiResponse.Filmes.Count}");
        //                    Filmes = new List<FilmeViewModel>(filmeApiResponse.Filmes);
        //                }
        //                else
        //                {
        //                    System.Diagnostics.Debug.WriteLine("A lista de filmes é nula");
        //                }
        //            }
        //            else
        //            {
        //                System.Diagnostics.Debug.WriteLine("A resposta não pôde ser desserializada para FilmeApiResponse");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            System.Diagnostics.Debug.WriteLine($"Erro ao desserializar JSON: {ex.Message}");
        //        }
        //    }
        //    else
        //    {
        //        System.Diagnostics.Debug.WriteLine($"Erro na solicitação: {response.StatusCode} - {response.ReasonPhrase}");
        //    }
        //}
        //private async Task LoadHorror()
        //{
        //    string apiUrl = $"https://www.omdbapi.com/?apikey={_apiKey}&s={System.Uri.EscapeDataString(categoria1)}";

        //    var response = await client.GetAsync(apiUrl);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var jsonContent = await response.Content.ReadAsStringAsync();
        //        System.Diagnostics.Debug.WriteLine($"JSON Response: {jsonContent}");

        //        try
        //        {
        //            var filmeApiResponse = JsonConvert.DeserializeObject<FilmeApiResponse>(jsonContent);

        //            if (filmeApiResponse != null)
        //            {
        //                System.Diagnostics.Debug.WriteLine($"TotalResults: {filmeApiResponse.TotalResults}");
        //                System.Diagnostics.Debug.WriteLine($"Response: {filmeApiResponse.Response}");

        //                if (filmeApiResponse.Filmes != null)
        //                {
        //                    System.Diagnostics.Debug.WriteLine($"Número de Filmes: {filmeApiResponse.Filmes.Count}");
        //                    FilmesHorror = new List<FilmeViewModel>(filmeApiResponse.Filmes);
        //                }
        //                else
        //                {
        //                    System.Diagnostics.Debug.WriteLine("A lista de filmes é nula");
        //                }
        //            }
        //            else
        //            {
        //                System.Diagnostics.Debug.WriteLine("A resposta não pôde ser desserializada para FilmeApiResponse");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            System.Diagnostics.Debug.WriteLine($"Erro ao desserializar JSON: {ex.Message}");
        //        }
        //    }
        //    else
        //    {
        //        System.Diagnostics.Debug.WriteLine($"Erro na solicitação: {response.StatusCode} - {response.ReasonPhrase}");
        //    }
        //}


    }
}
