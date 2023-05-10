namespace CDSiteUsers.Models
{
    public class CDModel
    {
        public Guid Id { get; set; }
        public string SellerUsername { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public long Tracks { get; set; }
        public string Duration { get; set; }    
    }
}
