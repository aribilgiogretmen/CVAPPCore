namespace CVAPP.Models
{
    public class Education
    {
        public int Id { get; set; }
        public int CvId { get; set; }
        public string EducationName { get; set; }
        public string Dagree { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Cv Cv { get; set; }
    }
}
