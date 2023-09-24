namespace MovieLibrary.Models.Models
{
    public class Actor : IEntityBase
    {
        public int Id { get; set; }
        public string FullName { get; set; } = "";
        public string Bio { get; set; } = "";

        public int ImageId { get; set; }

        public IEnumerable<ActorMovie> ActorsMovies { get; set; } = new List<ActorMovie>();
        public Image Image { get; set; } = Image.DefaultImageFactory();
    }
}
