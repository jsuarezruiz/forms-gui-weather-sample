using HelloGuiForms.ViewModels;
using Xamarin.Forms;

namespace HelloGuiForms.Views
{
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();

            BindingContext = new MainViewModel();
        }
    }
}