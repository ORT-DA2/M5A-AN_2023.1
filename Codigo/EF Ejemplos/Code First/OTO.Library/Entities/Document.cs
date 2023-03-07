namespace OTO.Library.Entities
{
    public class Document
    {
        public Document()
        {
            
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
