using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ScreenCanvas
{

    public partial class MainWindow : Window
    {
        private bool isDrawingLine = false;
        private Point previousPoint;
        private SolidColorBrush colorSliderBrush = new SolidColorBrush { Color = Colors.Red };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void App_MouseDown(object sender, MouseButtonEventArgs e)
        {
            switch (e.ChangedButton)
            {
                case MouseButton.Left:
                    isDrawingLine = true;
                    previousPoint = e.GetPosition(PaintCanvas);
                    break;
                case MouseButton.Middle:
                    Text(e.GetPosition(PaintCanvas).X, e.GetPosition(PaintCanvas).Y, Colors.Red);
                    break;
                default:
                    break;
            }
        }

        private void App_MouseMove(object sender, MouseEventArgs e)
        {

            if (isDrawingLine)
            {
                Point currentPoint = e.GetPosition(PaintCanvas);

                Line line = new Line
                {
                    Stroke = colorSliderBrush,
                    StrokeThickness = 4,
                    X1 = previousPoint.X,
                    Y1 = previousPoint.Y,
                    X2 = currentPoint.X,
                    Y2 = currentPoint.Y
                };

                _ = PaintCanvas.Children.Add(line);

                previousPoint = currentPoint;
            }
        }

        private void App_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isDrawingLine = false;
        }

        private void App_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    Close();
                    break;
                default:
                    break;
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            PaintCanvas.Children.Clear();
        }

        private void RainbowSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sender is not Slider slider || rainbowBrush == null)
            {
                return;
            }

            double relativePosition = (slider.Value - slider.Minimum) / (slider.Maximum - slider.Minimum);

            GradientStop previousStop = rainbowBrush.GradientStops.OrderBy(gs => gs.Offset)
                                                                  .LastOrDefault(gs => gs.Offset <= relativePosition);

            GradientStop nextStop = rainbowBrush.GradientStops.OrderBy(gs => gs.Offset)
                                                              .FirstOrDefault(gs => gs.Offset >= relativePosition);

            Color currentColor = Colors.Black;

            if (previousStop != null && nextStop != null)
            {
                double blendFactor = (relativePosition - previousStop.Offset) / (nextStop.Offset - previousStop.Offset);
                currentColor = BlendColors(previousStop.Color, nextStop.Color, blendFactor);
            }
            else if (previousStop != null)
            {
                currentColor = previousStop.Color;
            }
            else if (nextStop != null)
            {
                currentColor = nextStop.Color;
            }

            colorSliderBrush = new SolidColorBrush(currentColor);
        }

        private Color BlendColors(Color color1, Color color2, double ratio)
        {
            double r = (color1.R * (1 - ratio)) + (color2.R * ratio);
            double g = (color1.G * (1 - ratio)) + (color2.G * ratio);
            double b = (color1.B * (1 - ratio)) + (color2.B * ratio);

            return Color.FromRgb((byte)r, (byte)g, (byte)b);
        }

        private void Text(double x, double y, Color color)
        {
            TextBlock newTextBlock = new TextBlock
            {
                Text = LogicController.UserTextInput,
                Foreground = colorSliderBrush
            };

            Canvas.SetLeft(newTextBlock, x);
            Canvas.SetTop(newTextBlock, y);

            _ = PaintCanvas.Children.Add(newTextBlock);
        }
    }
}
