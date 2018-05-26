namespace VCI.Utils
{
    public class Verification
    {
        public static bool StringLength(int Min, int Max, string text)
        {
            if(text.Length < Min || text.Length > Max)
            {
                return false;
            }
            return true;
        }
    }
}
