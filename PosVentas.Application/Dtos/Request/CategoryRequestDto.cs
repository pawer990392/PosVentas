namespace PosVentas.Application.Dtos.Request
{
    public class CategoryRequestDto
    {
        //delcarar lps atributos que se necesita enviar o cliente enviar para que ecista una categoria
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int State { get; set; }
    }
}


//solicitud o |||  peticion