namespace Review_Site_Spectaculars.Models
{
    public class ProductModels
    {
        public int Id { get; set; }
        public string? Name { get; set; }  
        public string? Image { get; set; }
        public virtual List<ReviewModel>? Reviews { get; set; }
        public string? Description { get; set; }

    }
}
