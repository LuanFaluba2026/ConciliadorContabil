namespace Conciliacao_Plamev
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ConverterRazao conv = new ConverterRazao();
            SheetLayout sheetL = new SheetLayout();

            sheetL.CreateSheet(conv.Conversao());
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}