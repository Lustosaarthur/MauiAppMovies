using MauiAppMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppMovies.Services
{
    public class CategoriesService
    {
        public List<CategorieModel> GetCategories()
        {
            return MockCategoriesService.GetCategories();
        }

    }
    public class MockCategoriesService
    {
        public static List<CategorieModel> GetCategories()
        {
            return new List<CategorieModel>
            {
                new CategorieModel{ name = "Action", },
                new CategorieModel{ name = "Horror", },
                new CategorieModel{ name = "Comedy", },
                new CategorieModel{ name = "Fantasy", },
            };
        }

    }
}
