using System.ServiceModel;
using WebServicesEnrollment.model;

namespace WebServicesEnrollment.Services
{
    [ServiceContract]
    public interface IEnrollmentService
    {

        [OperationContract]
        public string test(string message);
        [OperationContract]
        EnrollmentResponse EnrollmentProcess (EnrollmentRequest request);
        [OperationContract]
        List<EnrollmentResponseDeudaAlumno> EnrollmentProcess1(EnrollmentRequestDeudaAlumno request);
        [OperationContract]
        AspiranteResponse CandidateRecordProcess(AspiranteRequest request);
        
        

    }
}