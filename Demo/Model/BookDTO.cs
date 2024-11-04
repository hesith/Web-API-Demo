namespace Demo.Model
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Author { get; set; }
        public int Year { get; set; }

        public string? BookCode {
            get
            {
                return string.Concat(Id.ToString(), Year.ToString());
            }         
        }
    }
}
