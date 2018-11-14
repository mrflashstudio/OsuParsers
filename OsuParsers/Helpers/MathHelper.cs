namespace OsuParsers.Helpers
{
    internal class MathHelper
    {
        public static int CalculateCollumn(int posX, int collumnCount)
        {
            return (int)(posX / (512.0 / collumnCount));
        }
    }
}
