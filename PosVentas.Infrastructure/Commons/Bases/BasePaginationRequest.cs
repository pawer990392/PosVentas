namespace PosVentas.Infrastructure.Commons.Bases
{
    //Estos en nuestra clase Base en cual nos va servir para nuestro listado de datos
    public class BasePaginationRequest
    {

        public int NumPage { get; set; } = 1;
        public int NumRecordsPage { get; set; } = 10;
        private readonly int NumMaxRecordsPage = 50;
        public string Order { get; set; } = "asc";
        public string? Sort { get; set; } = null;

        //registro que queiro mostrar 
        public int Records
        {
            get => NumRecordsPage;
            set
            {
                NumRecordsPage = (value > NumMaxRecordsPage) ? NumMaxRecordsPage : value;
            }
        }

    }
}
