using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using WebServicesEnrollment.model;

namespace WebServicesEnrollment.DB
{
    public class Conexion
    {
        private static Conexion instancia;

        private SqlConnection connection;
        private IConfiguration Configuration;

        public Conexion(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
            this.connection = new SqlConnection(Configuration.GetConnectionString("defaultConnection"));

        }

        public static Conexion GetInstancia(IConfiguration Configuration)
        {
            if (instancia == null)
            {

                instancia = new Conexion(Configuration);
            }

            return instancia;


        }

        public AspiranteResponse ExecuteQueryAspirante(AspiranteRequest request)
        {
            AspiranteResponse response = null;
            SqlCommand cmd = new SqlCommand(Configuration.GetValue<string>("Profiles:SpCandidateCreate"), connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@apellidos", request.Apellidos));
            cmd.Parameters.Add(new SqlParameter("@nombres", request.Nombres));
            cmd.Parameters.Add(new SqlParameter("@direccion", request.Direccion));
            cmd.Parameters.Add(new SqlParameter("@telefono", request.Telefono));
            cmd.Parameters.Add(new SqlParameter("@email", request.Email));
            cmd.Parameters.Add(new SqlParameter("@examenId", request.ExamenId));
            cmd.Parameters.Add(new SqlParameter("@carreraId", request.CarreraId));
            cmd.Parameters.Add(new SqlParameter("@jornadaId", request.JornadaId));
            SqlDataReader reader = null;
            try
            {
                this.connection.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    response = new AspiranteResponse()
                    {

                        Message = reader.GetValue(0).ToString(),
                        NoExpediente = reader.GetValue(1).ToString()

                    };

                    if (reader.GetValue(0).ToString().Equals("TRANSACTION SUCCESS"))
                    {

                        response.StatusCode = 201;
                    }

                    else if (reader.GetValue(0).ToString().Equals("TRANSACTION ERROR"))
                    {

                        response.StatusCode = 503;
                    }

                    else
                    {
                        response.StatusCode = 500;
                    }

                }

                reader.Close();
                this.connection.Close();

            }
            catch (Exception e)
            {
                response = new AspiranteResponse()
                {
                    StatusCode = 500,
                    Message = "Error al momento de ejecutar el proceso de creacion de un aspirante en la base de datos",
                    NoExpediente = "0"
                };
            }

            finally
            {
                this.connection.Close();
            }

            return response;
        }

        public EnrollmentResponse ExecuteQuery(EnrollmentRequest request)
        {

            EnrollmentResponse response = new EnrollmentResponse();
            SqlCommand cmd = new SqlCommand(this.Configuration.GetValue<string>("Profiles:SpEnrollmentProcess"), connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@noExpediente", request.NoExpediente));
            cmd.Parameters.Add(new SqlParameter("@ciclo", request.Ciclo));
            cmd.Parameters.Add(new SqlParameter("@mesInicioPago", request.MesInicioPago));
            cmd.Parameters.Add(new SqlParameter("@carreraid", request.CarreraId));
            cmd.Parameters.Add(new SqlParameter("@inscripcionCargoId", request.InscripcionCargoId));
            cmd.Parameters.Add(new SqlParameter("@carneCargoId", request.CarneCargoId));
            cmd.Parameters.Add(new SqlParameter("@cargoMensualId", request.CargoMensualId));
            cmd.Parameters.Add(new SqlParameter("@diaPago", request.DiaPago));

            SqlDataReader reader = null;

            try
            {
                this.connection.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    response = new EnrollmentResponse()
                    {
                        Message = reader.GetValue(0).ToString(),
                        Carne = reader.GetValue(1).ToString()

                    };

                    if (reader.GetValue(0).ToString().Equals("TRANSACTION SUCCESS"))
                    {

                        response.StatusCode = 201;
                    }

                    else if (reader.GetValue(0).ToString().Equals("TRANSACTION ERROR"))
                    {

                        response.StatusCode = 500;
                    }

                }

                reader.Close();
                this.connection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                response.StatusCode = 503;
                response.Message = "Error al momento de ejecutar el proceso de inscripcion en la base de datos";

            }

            finally
            {
                this.connection.Close();
            }

            return response;

        }


        public List<EnrollmentResponseDeudaAlumno> ExecuteQuery(EnrollmentRequestDeudaAlumno request)
        {

            EnrollmentResponseDeudaAlumno response = new EnrollmentResponseDeudaAlumno();
            List<EnrollmentResponseDeudaAlumno> listaresponse = new List<EnrollmentResponseDeudaAlumno>();

            SqlCommand cmd = new SqlCommand("sp_EnrollmentConsulta", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@carnealumno", request.carnealumno));


            SqlDataReader reader = null;

            try
            {
                this.connection.Open();
                reader = cmd.ExecuteReader();


                while (reader.Read())

                {

                    response = new EnrollmentResponseDeudaAlumno()
                    {


                        //Message = reader.GetValue(0).ToString(),
                        correlativo = reader.GetValue(0).ToString(),
                        anio = reader.GetValue(1).ToString(),
                        descripcion = reader.GetValue(2).ToString(),
                        fechacargo = reader.GetValue(3).ToString(),
                        fechaaplica = reader.GetValue(4).ToString(),
                        monto = reader.GetValue(5).ToString()

                    };





                    if (reader.GetValue(0).ToString().Equals("TRANSACTION SUCCESS"))
                    {

                        response.StatusCode = 201;
                    }

                    else if (reader.GetValue(0).ToString().Equals("TRANSACTION ERROR"))
                    {

                        response.StatusCode = 500;
                    }

                    listaresponse.Add(response);

                }



                reader.Close();
                this.connection.Close();

            }


            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                response.StatusCode = 503;
                response.Message = "ERROR AL CONSULTAR";

            }

            finally
            {
                this.connection.Close();
            }

            return listaresponse;

        }



    }



}
