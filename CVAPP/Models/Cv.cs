namespace CVAPP.Models
{
    public class Cv
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }

        public User User { get; set; }
        public ICollection<Experience> Experience { get; set; }
        public ICollection<Education> Education { get; set; }

    }
}
