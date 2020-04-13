using Xamarin.Forms;

namespace HomeworkCode9
{
    public partial class Drive : ContentPage
    {
        public Drive()
        {
            InitializeComponent();
        }

        void Calc_Button_Clicked(System.Object sender, System.EventArgs e)
        {
            var ageText = age.Text;
            if (int.TryParse(ageText, out int numAge))
            {
                int ageLegal = numAge-16;
                output.Text = $"You could have been legally driving in Wisconsin for {ageLegal} years!";

            }
            else
            {
                output.Text = "Please enter a number "+ageText;
            }
        }
    }
}
