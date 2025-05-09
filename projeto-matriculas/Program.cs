namespace projeto_matriculas.DB
{
    internal static class Program
    {
        public static Form1 MainForm { get; private set; }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Db.CriarTabelas();
            ApplicationConfiguration.Initialize();
            MainForm = new Form1();
            Application.Run(MainForm);
        }
    }
}