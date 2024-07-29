namespace Manticora.Domain.Entities
{
    public class CharacterPage
    {
        public List<Character> Characters { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
    }
}
