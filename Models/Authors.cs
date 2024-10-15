namespace Stetco_Bianca_Lab2.Models
{
    public class Authors
    {
        public int AuthorsID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Navigation property to the books written by this author
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
