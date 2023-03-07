namespace OTO.Library.Entities
{
    public class User
    {
        public User()
        {
            
        }

        public int Id { get; set; }

        public string UserName { get; set; }

        public int DocumentId { get; set; }

        public Document Document { get; set; }
    }
}
