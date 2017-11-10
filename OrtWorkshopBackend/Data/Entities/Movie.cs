namespace OrtWorkshopBackend.Data.Entities
{
    public class Movie
    {
        public int MovieId { get; set; }

        public string Title  { get; set; }

        //TODO Workshop
        //public string Summary  { get; set; }

        public int Year { get; set; }

        public string Director { get; set; }
        
        public string Genre  { get; set; }
    }
}