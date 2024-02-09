namespace Bookstore.Models.DTOS
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int Isbn { get; set; }
        public DateTime PublishDate { get; set; }
        public string UserName { get; set; }
    }
}
