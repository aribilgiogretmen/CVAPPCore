namespace CVAPP.Models
{
    public class Experience
    {
        public int Id { get; set; }
        public int CvId { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Cv Cv { get; set; }
    }
}
