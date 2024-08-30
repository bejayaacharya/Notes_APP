namespace myNottes.Models
{
    public class Note
    {
        public int Id { get; set; }

        public string ?Title { get; set; }

        public string ?Description { get; set; }

        public  string ?Color{ get; set; }

        public DateTime Created_Date { get; set; }
    }
}
