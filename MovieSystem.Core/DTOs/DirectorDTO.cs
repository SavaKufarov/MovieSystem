namespace MovieSystem.Core.DTOs
{
    public class DirectorDto
    {
        public int DirectorId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }
    }

    public class CreateDirectorDto
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }
    }
}