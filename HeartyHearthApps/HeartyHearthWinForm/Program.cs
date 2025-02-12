
namespace HeartyHearthWinForm
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            DBManager.SetConnectionString("Server=tcp:dev-rochelsusholz.database.windows.net,1433; Initial Catalog=HeartyHearthDB;Persist Security Info=False;User ID=rsadmin;Password=Rochel@9225; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30");
            Application.Run(new frmMain());
        }
    }
}