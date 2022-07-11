namespace Portfolio.Data.Models.PortfolioBlogging
{
    public class Blog
    {
        public int BlogID { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Post> Posts { get; set; }

        public BlogView ConvertToBlogView()
        {
            return new()
            {
                BlogId = BlogID,
                Url = Url,
                Name = Name,
                Posts = Posts.Select(p => p.ConvertToPostView())
            };
        }
    }

    public class BlogView
    {
        public int? BlogId { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public IEnumerable<PostView> Posts { get; set; }

        public Blog ConvertToBlog()
        {
            return new()
            {
                BlogID = BlogId ?? 0,
                Url = Url,
                Name = Name,
                Posts = Posts?.Select(p => p.ConvertToPost())?.ToList()
            };
        }
    }
}
