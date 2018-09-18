using Terminal.Gui.Forms;
using Xamarin.Forms;

namespace HelloGuiForms
{
    public class Program
    {
        public static void Main()
        {
            Terminal.Gui.Application.Init();
            Forms.Init();
            var app = new App();
            var window = new FormsWindow("WeatherApp");
            window.LoadApplication(app);
            Terminal.Gui.Application.Run();
        }
    }
}