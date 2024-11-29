using System.Security.Cryptography;
using System.Text;

namespace DA_NH.Utilities
{
    public class Function
    {

        public static int _UserId = 0;
        public static string _UserName = String.Empty;
        public static string _Email = String.Empty;
        public static string _Message = String.Empty;
        public static string _MessageEmail = String.Empty;
        public static string TitleSlugGenerationAlias(string title)
        {
            return SlugGenerator.SlugGenerator.GenerateSlug(title);
        }
        public static bool IsLogin()
        {
            if (string.IsNullOrEmpty(Function._UserName) || string.IsNullOrEmpty(Function._Email) || (Function._UserId <= 0))
                return false;
            return true;
        }
    }
}
