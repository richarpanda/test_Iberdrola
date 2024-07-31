namespace Manticora.Domain.ViewModels
{
    public class CharacterViewModel
    {
        public int DefenderId { get; set; }
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Species { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }
        public string Origin { get; set; }
        public string Location { get; set; }
        public string Image { get; set; }
        public List<string> Episode { get; set; }
        public string Url { get; set; }
        public DateTime Created { get; set; }
        public int Gold { get; set; }
    }
}