using QuickTrivia.Enums;

namespace QuickTrivia.Models
{
    public static class TriviaCategoryHelper
    {
        public static readonly Dictionary<TriviaCategory, string> ReadableNames = new()
        {
            { TriviaCategory.GeneralKnowledge, "General Knowledge" },
            { TriviaCategory.EntertainmentBooks, "Entertainment: Books" },
            { TriviaCategory.EntertainmentFilm, "Entertainment: Film" },
            { TriviaCategory.EntertainmentMusic, "Entertainment: Music" },
            { TriviaCategory.EntertainmentMusicalsAndTheatres, "Entertainment: Musicals & Theatres" },
            { TriviaCategory.EntertainmentTelevision, "Entertainment: Television" },
            { TriviaCategory.EntertainmentVideoGames, "Entertainment: Video Games" },
            { TriviaCategory.EntertainmentBoardGames, "Entertainment: Board Games" },
            { TriviaCategory.ScienceAndNature, "Science & Nature" },
            { TriviaCategory.ScienceComputers, "Science: Computers" },
            { TriviaCategory.ScienceMathematics, "Science: Mathematics" },
            { TriviaCategory.Mythology, "Mythology" },
            { TriviaCategory.Sports, "Sports" },
            { TriviaCategory.Geography, "Geography" },
            { TriviaCategory.History, "History" },
            { TriviaCategory.Politics, "Politics" },
            { TriviaCategory.Art, "Art" },
            { TriviaCategory.Celebrities, "Celebrities" },
            { TriviaCategory.Animals, "Animals" },
            { TriviaCategory.Vehicles, "Vehicles" },
            { TriviaCategory.EntertainmentComics, "Entertainment: Comics" },
            { TriviaCategory.ScienceGadgets, "Science: Gadgets" },
            { TriviaCategory.EntertainmentJapaneseAnimeAndManga, "Entertainment: Japanese Anime & Manga" },
            { TriviaCategory.EntertainmentCartoonAndAnimations, "Entertainment: Cartoon & Animations" }
        };

        public static string GetReadableName(TriviaCategory category)
        {
            if (ReadableNames.TryGetValue(category, out var readableName))
            {
                return readableName;
            }
            return "Unknown";
        }
    }
}
