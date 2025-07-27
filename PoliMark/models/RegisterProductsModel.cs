namespace PoliMark.Api.models
{
    public class RegisterProductsModel
    {
        public int tax_id { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public string company { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
    }
}
