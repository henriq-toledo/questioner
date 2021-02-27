namespace Questioner.WebApi.UnitTest.Framework.Defaults
{
    public static class ThemePassRateDefault
    {
        public static byte LessThanMin => 59;

        public static byte MoreThanMax => 101;

        public static byte MinValid => 60;

        public static byte MaxValid => 100;

        public static byte Default => 85;
    }
}
