namespace CRUD_DEMO.Models
{
    public class AddProductDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Detalles { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }
}
