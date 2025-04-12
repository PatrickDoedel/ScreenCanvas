using System.Windows;

namespace ScreenCanvas
{
    /// <summary>
    /// Interaction logic for GetUserTextWindow.xaml
    /// </summary>
    public partial class GetUserTextWindow : Window
    {
        public GetUserTextWindow()
        {
            InitializeComponent();
            InputTextBox.Focus();
        }

        private void InputTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            switch (e.Key)
            {
                case System.Windows.Input.Key.Enter:
                    LogicController.UserTextInput = InputTextBox.Text;
                    Close();             
                    break;
                default:
                    break;
            }
        }
    }
}
