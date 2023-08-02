namespace PosVentas.Application.Dtos.Response
{
    public class CategoryResponseDto
    {
        //Lo que qeuremos mostar finalmente nuestro endPoint
        //Es un endpoint resultante
        public int CategoryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime AuditCreateDate { get; set; }
        public int State { get; set; }
        //madera descriptiva
        public string? StateCategory { get; set; }
    }
}
