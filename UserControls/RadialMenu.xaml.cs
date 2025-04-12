using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ScreenCanvas.UserControls
{
    /// <summary>
    /// Interaction logic for RadialMenu.xaml
    /// </summary>
    public partial class RadialMenu : UserControl
    {
        private ObservableCollection<Button> _Buttons = [];
        public ObservableCollection<Button> Buttons { get => _Buttons; set => _Buttons = value; }
        
        private Canvas _MainCanvas = new();
        public Canvas MainCanvas { get => _MainCanvas; set => _MainCanvas = value; }

        public RadialMenu()
        {
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            MainGrid.Children.Add(MainCanvas);

            Buttons.Add(new Button
            {
                Content = "Save"
            });
            Buttons.Add(new Button
            {
                Content = "Clear"
            });
            Buttons.Add(new Button
            {
                Content = "Text"
            });
            Buttons.Add(new Button
            {
                Content = "Rectangle"
            });

            foreach (Button button in Buttons)
            {
                Canvas.SetLeft(button, 200);
                Canvas.SetTop (button, 200);

                _ = MainCanvas.Children.Add(button);
            }
            OrderButtons();
        }

        public void OrderButtons()
        {
            int i = 0;

            foreach (Button button in Buttons)
            {
                double AngleDivision = 360 / Buttons.Count;
                double newAngle = AngleDivision * (i + 1);
                double radius = 100;

                double currentX = Canvas.GetLeft(button);
                double currentY = Canvas.GetTop(button);

                double deltaX = radius / Math.Sin(90) * Math.Sin(90-newAngle);
                double deltaY = radius / Math.Sin(90) * Math.Sin(newAngle);

                Canvas.SetLeft(button, currentX + deltaX);
                Canvas.SetTop(button, currentY + deltaY);

                i++;
            }
        }
    }
}
