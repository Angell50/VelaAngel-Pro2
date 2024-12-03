using VelaAngel_Pro2.Pages;

namespace VelaAngel_Pro2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
