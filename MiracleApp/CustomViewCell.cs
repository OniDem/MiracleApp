namespace MiracleApp
{
    public class CustomViewCell : ViewCell
    {

        public static readonly BindableProperty SelectedBackgroundColorProperty = BindableProperty.Create(
            nameof(SelectedBackgroundColor), typeof(Color), typeof(CustomViewCell), Colors.White
        );

        public Color SelectedBackgroundColor
        {
            get { return (Color)GetValue(SelectedBackgroundColorProperty); }
            set { SetValue(SelectedBackgroundColorProperty, value); }
        }

        public CustomViewCell()
        {

        }
    }
}
