namespace PoliMark.Api.models
{
    public class RequestSale
    {
        public int client_id { get; set; }
        public int seller_id { get; set; }
        public List<ProductSaleModel> listProducts { get; set; }
    }
}
