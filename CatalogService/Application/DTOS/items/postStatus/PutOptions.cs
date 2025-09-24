namespace Application.DTOS.items.postStatus
{
    public class PutOptions
    {
        public string OptionId { get; set; }
        public string parentOptionId { get; set; }
        public string Status { get; set; }
        public List<PutStatusByCatlogs> StatusByCatalog { get; set; }
    }
}