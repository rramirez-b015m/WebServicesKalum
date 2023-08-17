using WebServicesEnrollment.model;
using WebServicesEnrollment.DB;
using WebServicesEnrollment.Utils;

namespace WebServicesEnrollment.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private IConfiguration _Configuration;

        public EnrollmentService(IConfiguration Configuration)
        {

            this._Configuration = Configuration;

        }

        public AspiranteResponse CandidateRecordProcess(AspiranteRequest request)
        {
            AppLog AppLog = new AppLog();
            //AppLog.ResponseTime = Convert.ToInt16(DateTime.Now.ToString("fff"));
            AppLog.ResponseTime = Convert.ToInt16(DateTime.Now.ToString(this._Configuration.GetValue<string>("Profiles:formatDate")));
            AspiranteResponse response = Conexion.GetInstancia(this._Configuration).ExecuteQueryAspirante(request);
            if (response.StatusCode == 201)
            {
                Utilerias.ImprimirLog(AppLog, response.StatusCode, response.Message, "INFORMATION");
            }
            else
            {
                Utilerias.ImprimirLog(AppLog, response.StatusCode, response.Message, "ERROR");
            }
            return response;
        }
        public EnrollmentResponse EnrollmentProcess(EnrollmentRequest request)
        {
            AppLog AppLog = new AppLog();
            //AppLog.ResponseTime = Convert.ToInt16(DateTime.Now.ToString("fff"));
            AppLog.ResponseTime = Convert.ToInt16(DateTime.Now.ToString(this._Configuration.GetValue<string>("Profiles:formatDate")));

            EnrollmentResponse response = Conexion.GetInstancia(this._Configuration).ExecuteQuery(request);
            if (response.StatusCode == 201)
            {
                Utilerias.ImprimirLog(AppLog, response.StatusCode, response.Message, "INFORMATION");
            }
            else
            {
                Utilerias.ImprimirLog(AppLog, response.StatusCode, response.Message, "ERROR");

            }
            return response;
        }

        public string test(string message)
        {
            string servicio = "Servicio enrollment up";
            return servicio;
        }

        public List<EnrollmentResponseDeudaAlumno> EnrollmentProcess1(EnrollmentRequestDeudaAlumno request)
        {

            List<EnrollmentResponseDeudaAlumno> listaresponse = Conexion.GetInstancia(this._Configuration).ExecuteQuery(request);
            return listaresponse;

        }
    }
}