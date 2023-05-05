namespace Schneider.MinesweeperHybrid.Utilities.Helpers
{
    public static class ConvertHelper
    {
        public static string ConvertRowToLetter(int row)
        {
            const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var convertedLetter = string.Empty;

            convertedLetter += letters[row - 1];

            return convertedLetter;
        }
    }
}
