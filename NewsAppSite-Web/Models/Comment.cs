namespace NewsAppSite_Web.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime PostedAt { get; set; }

        //public int UserId { get; set; }
        //public virtual Users User { get; set; }

        //public int NewsId { get; set; }
        //public virtual News News { get; set; }
    }
}
