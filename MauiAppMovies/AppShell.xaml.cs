namespace MauiAppMovies
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("search/detail", typeof(Views.Details.DetailFilmPage));
            Routing.RegisterRoute("homepage/search", typeof (Views.SearchPage));
            Routing.RegisterRoute("homepage/detail", typeof (Views.Details.DetailFilmPage));
            Routing.RegisterRoute("favorities/detail", typeof(Views.Favorites.FavoritesDetailPage));
        }
    }
}
