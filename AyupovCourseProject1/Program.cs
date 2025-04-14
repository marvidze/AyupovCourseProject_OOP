using QuestPDF.Infrastructure;

namespace AyupovCourseProject1
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            QuestPDF.Settings.License = LicenseType.Community;
            ApplicationConfiguration.Initialize();
            Application.Run(new WelcomeForm());
            MainForm mainForm = new MainForm();
            Application.Run(mainForm);
        }
    }
}