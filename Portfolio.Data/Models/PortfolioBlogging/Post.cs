using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Data.Models.PortfolioBlogging;

public class Post
{
    public int PostID { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    public bool IsDeleted { get; set; }
    public int BlogID { get; set; }

    [ForeignKey(nameof(BlogID))]
    public Blog Blog { get; set; }

    public PostView ConvertToPostView()
    {
        return new()
        {
            PostId = PostID,
            Title = Title,
            Content = Content,
            BlogId = BlogID
        };
    }
}

public class PostView
{
    public int PostId { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    public int BlogId { get; set; }

    public Post ConvertToPost()
    {
        return new()
        {
            PostID = PostId,
            Title = Title,
            Content = Content,
            BlogID = BlogId
        };
    }
}
