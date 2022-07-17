using PRAPristupBazi.Models;

namespace Knjižara.Models
{

    class HomeViewModel
    {
        public static IList<string> BookQuotes = new List<String>()
        {
            "So many books, so little time.",
            "A room without books is like a body without a soul.",
            "Good friends, good books, and a sleepy conscience: this is the ideal life."
        };
        public IList<Knjiga> preporuceneKnjige =new List<Knjiga>();

        public static string getRandomQuote()
        {
            Random random = new Random();
            int value = random.Next(0, HomeViewModel.BookQuotes.Count);
            return HomeViewModel.BookQuotes[value];
        }
    }
}
