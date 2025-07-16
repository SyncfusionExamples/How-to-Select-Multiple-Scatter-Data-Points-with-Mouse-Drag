# How to Select Multiple Scatter Data Points with Mouse Drag

The [WPF Chart](https://www.syncfusion.com/wpf-controls/charts) allows you to select multiple scatter data points using the canvas and mouse drag.

Here are the steps to follow:

**Step 1:** Create a scatter chart within a grid layout using this documentation

**Step 2:** Initialize the canvas with mouse interaction events.

**Step 3:** Implement the mouse interaction events to select the desired data points using the mouse drag.

**C#**

```csharp
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
                // Update the size of the rectangle as the mouse is dragged.
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

            // Create a new rectangle.
            currentRectangle = new Rectangle
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Fill = Brushes.Transparent
            };

            // Add the rectangle to the canvas.
            drawingCanvas.Children.Add(currentRectangle);

            // Set the initial position of the rectangle.
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
```

The following demo visualizes how to select multiple scatter data points using mouse drag, which shows the respective values in a list view.
![Demo](https://github.com/SyncfusionExamples/How-to-Select-Multiple-Scatter-Data-Points-with-Mouse-Drag/assets/103025761/971fd74f-f660-45e3-813f-aeaf41fda735)

## Troubleshooting
### Path too long exception
If you are facing a path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.

For more details, refer to the KB on [how to select multiple scatter data points using the mouse drag](https://support.syncfusion.com/kb/article/14773/how-to-select-multiple-scatter-data-points-with-mouse-drag).
