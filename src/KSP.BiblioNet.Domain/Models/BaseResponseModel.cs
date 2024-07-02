namespace KSP.BiblioNet.Domain.Models
{
    // Definimos el cuerpo de la respuesta 
    public class BaseResponseModel
    {
        public int StatusCode { get; set; }
        public bool Succes { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
    }
}
