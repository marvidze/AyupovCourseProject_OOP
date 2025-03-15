namespace AyupovCourseProject1
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new WelcomeForm());
            MainForm mainForm = new MainForm();
            Application.Run(mainForm);
        }
    }
}