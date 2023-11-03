namespace AustralianFall
{
    public partial class App : Application
    {
        public App()
        {

            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                Exception ex = (Exception)e.ExceptionObject;
                Console.WriteLine("Unhandled Exception: " + ex.Message);
                // Log or handle the exception as needed.
            };

            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}