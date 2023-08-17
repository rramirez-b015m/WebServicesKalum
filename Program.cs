using Microsoft.AspNetCore;
using WebServicesEnrollment;
using WebServicesEnrollment.model;
using Serilog;
using System.Text;
using WebServicesEnrollment.Utils;
public class Program
{

    private static AppLog AppLog = new AppLog();

    public static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Debug()
        .WriteTo
        .File("./Logs/WebServicesEnrollment.out", Serilog.Events.LogEventLevel.Debug, "{Message:lj}{NewLine}", encoding: Encoding.UTF8)
        .CreateLogger();

        AppLog logApp = new AppLog();
        logApp.ResponseTime = Convert.ToInt16(DateTime.Now.ToString("fff"));
        Utilerias.ImprimirLog(logApp, 0, "Iniciando servicio SOAP WebServicesEnrollment", "DEBUG");
        //Log.Debug("Iniciando WEBSERVICESENROLLMENT SOAP");
        CreateWebHostBuilder(args).Build().Run();
    }
    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
    WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();


}




