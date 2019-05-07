namespace DellChallenge.B
{
    public enum Gender : byte
    {
        Male = 1,
        Female = 2,
        Hermaphrodite = 3
    }

    public static class GenderExtensions
    {
        public static string GetText(this Gender g)
        {
            switch (g)
            {
                case Gender.Male: return "Gender is male.";
                case Gender.Female: return "Gender is female.";
                case Gender.Hermaphrodite: return "Gender is hermaphrodite";

                default: return "Unknown gender.";
            }
        }
    }
}
