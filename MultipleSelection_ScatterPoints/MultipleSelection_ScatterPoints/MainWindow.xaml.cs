using Syncfusion.UI.Xaml.Charts;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MultipleSelection_ScatterPoints
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Fields

        private Point startPoint;
        private Rectangle? currentRectangle;
        private Rect currentRect;

        #endregion

        #region Constructor

        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && currentRectangle != null)
            {
                // Update the size of the rectangle as the mouse is dragged
                double width = e.GetPosition(drawingCanvas).X - startPoint.X;
                double height = e.GetPosition(drawingCanvas).Y - startPoint.Y;
                if (width > 0 && height > 0)
                {
                    currentRect = new Rect(startPoint.X, startPoint.Y, width, height);
                    currentRectangle.Width = width;
                    currentRectangle.Height = height;
                }
            }
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(drawingCanvas);

            // Create a new rectangle
            currentRectangle = new Rectangle
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Fill = Brushes.Transparent
            };

            // Add the rectangle to the canvas
            drawingCanvas.Children.Add(currentRectangle);

            // Set the initial position of the rectangle
            Canvas.SetLeft(currentRectangle, startPoint.X);
            Canvas.SetTop(currentRectangle, startPoint.Y);
        }

        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            viewModel.SelectedDataPoints = series.GetDataPoints(currentRect);
            currentRectangle = null;
            currentRect = Rect.Empty;
            drawingCanvas.Children.Clear();
        } 

        #endregion
    }
}