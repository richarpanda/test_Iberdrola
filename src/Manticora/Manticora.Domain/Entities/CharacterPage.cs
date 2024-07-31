using Manticora.Domain.ViewModels;

namespace Manticora.Domain.Entities
{
    public class CharacterPage
    {
        public List<CharacterViewModel> Characters { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
    }
}
