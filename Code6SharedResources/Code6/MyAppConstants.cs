using Xamarin.Forms;

namespace Code6
{
    static class MyAppConstants
    {
        public static readonly Font DifferentFont;
        public static readonly Color bgRed;

        static MyAppConstants()
        {
            DifferentFont = Font.SystemFontOfSize(40, FontAttributes.Italic);
            bgRed = Color.Red;
        }
    }
}
