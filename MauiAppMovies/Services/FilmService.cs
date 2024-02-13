using MauiAppMovies.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MauiAppMovies.Services
{
        public class FilmeService
        {
            HttpClient client;
            public FilmeService()
            {
                client = new HttpClient();

            }
        public async Task<List<FilmeViewModel>> LoadData(string categoria, string apiKey)
            {
                string apiUrl = $"https://www.omdbapi.com/?apikey={apiKey}&s={System.Uri.EscapeDataString(categoria)}";
                string apiUrl1 = $"https://www.omdbapi.com/?apikey={apiKey}&s={System.Uri.EscapeDataString(categoria)}&plot=full";



            var response = await client.GetAsync(apiUrl1);

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    System.Diagnostics.Debug.WriteLine($"JSON Response: {jsonContent}");

                    try
                    {
                        var filmeApiResponse = JsonConvert.DeserializeObject<FilmeApiResponse>(jsonContent);

                        if (filmeApiResponse != null)
                        {
                            System.Diagnostics.Debug.WriteLine($"TotalResults: {filmeApiResponse.TotalResults}");
                            System.Diagnostics.Debug.WriteLine($"Response: {filmeApiResponse.Response}");

                            if (filmeApiResponse.Filmes != null)
                            {
                                System.Diagnostics.Debug.WriteLine($"Número de Filmes: {filmeApiResponse.Filmes.Count}");
                                return new List<FilmeViewModel>(filmeApiResponse.Filmes);
                            }
                            else
                            {
                                System.Diagnostics.Debug.WriteLine("A lista de filmes é nula");
                            }
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("A resposta não pôde ser desserializada para FilmeApiResponse");
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Erro ao desserializar JSON: {ex.Message}");
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"Erro na solicitação: {response.StatusCode} - {response.ReasonPhrase}");
                }

                return null; // ou uma lista vazia, dependendo do comportamento desejado
            }
        public async Task<List<FilmeViewModel>> SearchFilmes(string searchTerm, string apiKey)
        {
            string apiUrl = $"https://www.omdbapi.com/?apikey={apiKey}&s={System.Uri.EscapeDataString(searchTerm)}";

            var response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();

                try
                {
                    var filmeApiResponse = JsonConvert.DeserializeObject<FilmeApiResponse>(jsonContent);

                    if (filmeApiResponse != null && filmeApiResponse.Filmes != null)
                    {
                        new List<FilmeViewModel>(filmeApiResponse.Filmes);
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Erro ao desserializar JSON: {ex.Message}");
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"Erro na solicitação: {response.StatusCode} - {response.ReasonPhrase}");
            }

            return null;
        }

    }

}

