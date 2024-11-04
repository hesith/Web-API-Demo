namespace Demo.Model
{
    public static class Repository
    {
        public static List<Book> Books { get; set; } = new List<Book>()
        {
            new Book
            {
                Id = 1,
                Name = "The First Teacher",
                Author = "Chinghiz Aitmatov",
                Year = 1962
            },          
            new Book
            {
                Id = 2,
                Name = "King Solomon's Mines",
                Author = "Rider Haggard",
                Year = 1885
            },
            new Book
            {
                Id = 3,
                Name = "Tom Sawyer",
                Author = "Mark Twain",
                Year = 1876
            }
        };
    }
}
