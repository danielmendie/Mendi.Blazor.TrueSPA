namespace TestSample.Models
{
    public class StoryBook
    {
        public string BookName { get; set; } = null!; // required property
        public string EditorName { get; set; } = null!; // required property
        public string? BestSellingBookTitle { get; set; } // optional property
        public int NumberOfPages { get; set; }
        public int BookId { get; set; }
        public string ImageUrl { get; set; } = null!;
        public string AgeRange { get; set; } = null!;
    }
}
