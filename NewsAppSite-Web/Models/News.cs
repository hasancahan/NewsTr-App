namespace NewsAppSite_Web.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public string Content { get; set; }
        public DateTime PublishedAt { get; set; }

        //public int CategoryId { get; set; }
        //public virtual Category Category { get; set; }

        //public virtual ICollection<Comments> Comments { get; set; }
    }
}
