namespace Prog3Api.NET.Resultados
{
    //Crear objeto para controlar Resultados de peticiones HTTP
    public class ResultadoBase
    {
        public int StatusCode { get; set; } //Codigo de respuesta
        public bool Ok { get; set; } = false; //Estado Ok
        public string Error { get; set; } = ""; //Mensaje de error
        public string Message { get; set; } = ""; //Mensaje de error
        public void SetError(string error) //Asignar error en caso de haber uno
        {
            Ok = false;
            Error = error;
            StatusCode = 500;
        } 
    }
}
