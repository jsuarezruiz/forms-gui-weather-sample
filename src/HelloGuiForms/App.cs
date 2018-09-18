using HelloGuiForms.Views;

namespace HelloGuiForms
{
    public class App : Xamarin.Forms.Application
    {
        public App()
        {
            MainPage = new MainView();
        }
    }
}