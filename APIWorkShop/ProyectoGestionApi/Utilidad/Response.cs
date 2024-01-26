namespace ProyectoGestionAPI.Utilidad
{
    public class Response<T>
    {
        public bool status { get; set; }
        public T value { get; set; }
        public string mensage { get; set; }
    }

}
