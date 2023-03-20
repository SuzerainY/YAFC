namespace FinancialCalculator;

static class Program
{
    //  The main entry point for the application.
    [STAThread]
    static void Main()
    {
        // To customize application configuration, see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new CalculatorWindow());
    }    
}