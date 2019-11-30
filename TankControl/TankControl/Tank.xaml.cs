using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TankControl
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class Tank : UserControl
    {
        public Tank()
        {
            InitializeComponent();
            
        }
        #region DependencyProperties

        /// <summary>
        /// Minor Steps of Tank ruler
        /// </summary>
        public static readonly DependencyProperty MinorStepsProperty =
          DependencyProperty.Register("MinorSteps", typeof(double), typeof(Tank));

        /// <summary>
        /// Major Steps of Tank ruler
        /// </summary>
        public static readonly DependencyProperty MajorStepsProperty =
          DependencyProperty.Register("MajorSteps", typeof(double), typeof(Tank));

        /// <summary>
        /// Max value of Tank ruler
        /// </summary>
        public static readonly DependencyProperty MaxValueProperty =
          DependencyProperty.Register("MaxValue", typeof(double), typeof(Tank));

        /// <summary>
        /// Min value of Tank ruler
        /// </summary>
        public static readonly DependencyProperty MinValueProperty =
          DependencyProperty.Register("MinValue", typeof(double), typeof(Tank));

        /// <summary>
        /// Orientation  of Tank 
        /// </summary>
        public static readonly DependencyProperty IsHorizontalProperty =
          DependencyProperty.Register("IsHorizontal", typeof(bool), typeof(Tank));

        // <summary>
        /// Current value of Tank ruler
        /// </summary>
        public static readonly DependencyProperty CurrentValueProperty =
           DependencyProperty.Register("CurrentValue", typeof(double), typeof(Tank), new FrameworkPropertyMetadata(
           0.0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault , new PropertyChangedCallback(OnCurrentValueChanged), CoerceValue));

        // <summary>
        /// Value Text Offset of Tank ruler
        /// </summary>
        public static readonly DependencyProperty ValueTextOffsetProperty =
          DependencyProperty.Register("ValueTextVerticalOffset", typeof(double), typeof(Tank));

        // <summary>
        /// Value Text Horizontal Offset of Tank ruler
        /// </summary>
        public static readonly DependencyProperty ValueTextHorizontalOffsetProperty =
          DependencyProperty.Register("ValueTextHorizontalOffset", typeof(double), typeof(Tank));

        // <summary>
        /// Minor stpes length of Tank ruler
        /// </summary>
        public static readonly DependencyProperty MinorStepsLengthProperty =
          DependencyProperty.Register("MinorStepsLength", typeof(double), typeof(Tank));

        // <summary>
        /// Major stpes length of Tank ruler
        /// </summary>
        public static readonly DependencyProperty MajorStepsLengthProperty =
          DependencyProperty.Register("MajorStepsLength", typeof(double), typeof(Tank));

        // <summary>
        /// Animation Time Of rectangle
        /// </summary>
        public static readonly DependencyProperty AnimationTimeProperty =
          DependencyProperty.Register("AnimationTime", typeof(double), typeof(Tank));

        // <summary>
        /// Precision Of Scale
        /// </summary>
        public static readonly DependencyProperty PrecisionProperty =
          DependencyProperty.Register("Precision", typeof(int), typeof(Tank));

        /// <summary>
        /// Flip scale
        /// </summary>
        /// 
        public static readonly DependencyProperty FlipScaleProperty =
       DependencyProperty.Register("FlipScale", typeof(bool), typeof(Tank));

        /// <summary>
        /// Default tank Color
        /// </summary>
        public static readonly DependencyProperty DefaultColorProperty =
            DependencyProperty.Register("DefaultTankColor", typeof(Color), typeof(Tank));
        
        /// <summary>
        /// Property for ranges
        /// </summary>
        public static readonly DependencyProperty RangesProperty =
           DependencyProperty.Register("Ranges", typeof(ObservableCollection<RangeValues>), typeof(Tank),
               new PropertyMetadata(new ObservableCollection<RangeValues>()));

        #endregion DependencyProperties 

        #region Scale Text  Dependency properties

        public static readonly DependencyProperty ScaleTextFamilyProperty =
            DependencyProperty.Register("ScaleTextFontFamily", typeof(FontFamily), typeof(Tank), new FrameworkPropertyMetadata(new FontFamily("Verdana")));

        public static readonly DependencyProperty ScaleTextFontSizeProperty =
            DependencyProperty.Register("ScaleTextFontSize", typeof(double), typeof(Tank), new PropertyMetadata(10.0));

        public static readonly DependencyProperty ScaleTextFontStretchProperty =
            DependencyProperty.Register("ScaleTextFontStretch", typeof(FontStretch), typeof(Tank), new PropertyMetadata(new FontStretch()));

        public static readonly DependencyProperty ScaleTextFontStyleProperty =
            DependencyProperty.Register("ScaleTextFontStyle", typeof(FontStyle), typeof(Tank), new PropertyMetadata(new FontStyle()));

        public static readonly DependencyProperty ScaleTextFontWeightProperty =
           DependencyProperty.Register("ScaleTextFontWeight", typeof(FontWeight), typeof(Tank), new PropertyMetadata(new FontWeight()));

        public static readonly DependencyProperty ScaleTextColorProperty =
          DependencyProperty.Register("ScaleTextColor", typeof(Color), typeof(Tank), new PropertyMetadata(Colors.Black));

        public static readonly DependencyProperty ScaleTextHorizontalOffsetProperty =
            DependencyProperty.Register("ScaleTextHorizontalOffset", typeof(double), typeof(Tank), new PropertyMetadata(0.0));

        public static readonly DependencyProperty ScaleTextVerticalOffsetProperty =
       DependencyProperty.Register("ScaleTextVerticalOffset", typeof(double), typeof(Tank), new PropertyMetadata(0.0));

        /// <summary>
        /// This property displays text for Unit of measurement
        /// </summary>
        public static readonly DependencyProperty UnitTextProperty =
         DependencyProperty.Register("UnitText", typeof(String), typeof(Tank));
  

        // Using a DependencyProperty for Unit type Property ( Speed , pressure etc)
        public static readonly DependencyProperty UnitTypeProperty =
            DependencyProperty.Register("UnitType", typeof(string), typeof(Tank), null);

        #endregion

        #region Properties

        // Describes type of Unit
        public string UnitType
        {
            get { return (string)GetValue(UnitTypeProperty); }
            set { SetValue(UnitTypeProperty, value); }
        }
        public double MinorSteps
        {
            get { return (double)GetValue(MinorStepsProperty); }
            set { SetValue(MinorStepsProperty, value); }
        }

        public double MajorSteps
        {
            get { return (double)GetValue(MajorStepsProperty); }
            set { SetValue(MajorStepsProperty, value); }
        }

        public double MaxValue
        {
            get { return (double)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value);
            }
        }

        public double MinValue
        {
            get { return (double)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); }
        }

        public bool IsHorizontal
        {
            get { return (bool)GetValue(IsHorizontalProperty); }
            set { SetValue(IsHorizontalProperty, value); }
        }

        public double AnimationTime
        {
            get { return (double)GetValue(AnimationTimeProperty); }
            set { SetValue(AnimationTimeProperty, value); }
        }

        public int Presicion
        {
            get { return (int)GetValue(PrecisionProperty); }
            set { SetValue(PrecisionProperty, value); }
        }
        public double CurrentValue
        {
            get { return (double)GetValue(CurrentValueProperty); }
            set {SetValue(CurrentValueProperty, value); }
        }
        public double ValueTextVerticalOffset
        {
            get { return (double)GetValue(ValueTextOffsetProperty); }
            set { SetValue(ValueTextOffsetProperty, value); }
        }

        public double ValueTextHorizontalOffset
        {
            get { return (double)GetValue(ValueTextHorizontalOffsetProperty); }
            set { SetValue(ValueTextHorizontalOffsetProperty, value); }
        }

        public double MinorStepsLength
        {
            get { return (double)GetValue(MinorStepsLengthProperty); }
            set { SetValue(MinorStepsLengthProperty, value); }
        }
        public double MajorStepsLength
        {
            get { return (double)GetValue(MajorStepsLengthProperty); }
            set { SetValue(MajorStepsLengthProperty, value); }
        }
        public bool FlipScale
        {
            get { return (bool)GetValue(FlipScaleProperty); }
            set { SetValue(FlipScaleProperty, value); }
        }
        public Color DefaultTankColor
        {
            get { return (Color)GetValue(DefaultColorProperty); }
            set { SetValue(DefaultColorProperty, value); }
        }

        public ObservableCollection<RangeValues> Ranges
        {
            get
            {
                return (ObservableCollection<RangeValues>)GetValue(RangesProperty);
            }
            set
            {
                SetValue(RangesProperty, value);
            }
        }
        #region Scale Text properties
        public FontFamily ScaleTextFontFamily
        {
            get { return (FontFamily)GetValue(ScaleTextFamilyProperty); }
            set { SetValue(ScaleTextFamilyProperty, value); }
        }

        public double ScaleTextFontSize
        {
            get { return (double)GetValue(ScaleTextFontSizeProperty); }
            set { SetValue(ScaleTextFontSizeProperty, value); }
        }

        public FontStretch ScaleTextFontStretch
        {
            get { return (FontStretch)GetValue(ScaleTextFontStretchProperty); }
            set { SetValue(ScaleTextFontStretchProperty, value); }
        }

        public FontStyle ScaleTextFontStyle
        {
            get { return (FontStyle)GetValue(ScaleTextFontStyleProperty); }
            set { SetValue(ScaleTextFontStyleProperty, value); }
        }

        public FontWeight ScaleTextFontWeight
        {
            get { return (FontWeight)GetValue(ScaleTextFontWeightProperty); }
            set { SetValue(ScaleTextFontWeightProperty, value); }
        }

        public Color ScaleTextColor
        {
            get { return (Color)GetValue(ScaleTextColorProperty); }
            set { SetValue(ScaleTextColorProperty, value); }
        }

        public string UnitText
        {
            get { return (string)GetValue(UnitTextProperty); }
            set { SetValue(UnitTextProperty, value); }
        }

        /// <summary>
        /// Gets/Sets Scale Text Offset
        /// </summary>
        public double ScaleTextVerticalOffset
        {
            get { return (double)GetValue(ScaleTextVerticalOffsetProperty);}
            set { SetValue(ScaleTextVerticalOffsetProperty, value); }
        }

        /// <summary>
        /// Gets/Sets Scale Text Offset
        /// </summary>
        public double ScaleTextHorizontalOffset
        {
            get { return (double)GetValue(ScaleTextHorizontalOffsetProperty); }
            set { SetValue(ScaleTextHorizontalOffsetProperty, value); }
        }
        #endregion Properties
        #endregion

        #region Local Variables 
        int count = 0;
        double originX = 0;
        double originY = 0;
        double availableHeight = 0;
        double availableWidth = 0;
        Point originAnimation = new Point();
        Color? lastFillColor = new Color();
        double lastHeight = 0;
        double lastWidth = 0;
        double xAxisCurrentText = 0;
        double yAxisCurrentText = 0;
        bool isParentContainerLoaded = false;
        Rectangle temp = null;
        double currentValueOnDrawing = 0;
        #endregion

        /// <summary>
        /// This method converts length and pixel values
        /// </summary>
        /// <param name="parameter">value to be converted</param>
        /// <param name="length">length</param>
        /// <returns></returns>
        private double ConvertValueInPixel(double parameter, double length)
        {
            double scalingFactor = length / (MaxValue - MinValue);
            double valueOnDrawing = ((parameter - MinValue)) * scalingFactor;
            return valueOnDrawing;
        }

        /// <summary>
        /// This method gets color values based on range values
        /// </summary>
        /// <param name="CurrentValue">Double parameter takes current value</param>
        /// <returns></returns>
        public SolidColorBrush GetColorBasedOnRanges(double CurrentValue)
        {
            SolidColorBrush tempSolidColor = null;
            foreach (RangeValues item in Ranges)
            {
                if (CurrentValue <= item.MaxValue && CurrentValue >= item.MinValue)
                {
                    tempSolidColor = item.Color;
                    break;
                }
            }
            if (tempSolidColor == null)
            {
                tempSolidColor = new SolidColorBrush(DefaultTankColor);
            }
            return tempSolidColor;

        }

        /// <summary>
        /// This method is animating Horizontal fill value
        /// </summary>
        /// <param name="CurrentValue">Current Value on Scale</param>
        /// <param name="height">height of rectangle</param>
        /// <param name="width">Width of rectangle</param>
        /// <param name="origin">origin point where to draw rectangle</param>
        private void AnimateHorizontalCurrentValueFill(double CurrentValue, double height, double width, Point origin)
        {
            lastHeight = height;
            lastWidth = width;
            originAnimation.X = origin.X;
            originAnimation.Y = origin.Y;
            SolidColorBrush baseBrush;
            ColorAnimation animation;
            double TimeToAnimate =  Math.Round( ((CurrentValue-MinValue)*AnimationTime)/(MaxValue - MinValue));
            if (TimeToAnimate <= 0)
            {
                TimeToAnimate = 1;
            }
            double scalingFactor = width / (MaxValue - MinValue);
            currentValueOnDrawing = ((CurrentValue - MinValue)) * scalingFactor;
            DoubleAnimation da = new DoubleAnimation();
            da.From = ConvertValueInPixel(MinValue, width);
            da.To = ConvertValueInPixel(CurrentValue, width);
            da.Duration = new Duration(TimeSpan.FromSeconds(TimeToAnimate));
            baseBrush = new SolidColorBrush();
            animation = new ColorAnimation();
            animation.From = GetColorBasedOnRanges(MinValue).Color;
            animation.To = GetColorBasedOnRanges(CurrentValue).Color;
            lastFillColor = animation.To;
            animation.Duration = new Duration(TimeSpan.FromSeconds(TimeToAnimate));
            baseBrush.BeginAnimation(SolidColorBrush.ColorProperty, animation);
            Rectangle obj = new Rectangle();
            obj.Name = "AnimatedRectangle";
            obj.Height = height;
            obj.Width = (ConvertValueInPixel(CurrentValue, width) < 0) ? 1 : ConvertValueInPixel(CurrentValue, width);
            Canvas.SetZIndex(obj, -1);
            Canvas.SetLeft(obj, origin.X);
            Canvas.SetTop(obj, origin.Y);
            obj.Fill = baseBrush;
            obj.BeginAnimation(Rectangle.WidthProperty, da);
            DrawingCanvas.Children.Add(obj);
        }
        /// <summary>
        /// This method is animating Vertical fill value
        /// </summary>
        /// <param name="CurrentValue">Current Value on Scale</param>
        /// <param name="height">height of rectangle</param>
        /// <param name="width">Width of rectangle</param>
        /// <param name="origin">origin point where to draw rectangle</param>
        private void AnimateVerticalCurrentValueFill(double CurrentValue, double height, double width, Point origin)
        {
                lastHeight = height;
                lastWidth = width;
                originAnimation.X = origin.X;
                originAnimation.Y = origin.Y;
                SolidColorBrush baseBrush;
                ColorAnimation animation;
                double scalingFactor = height / (MaxValue - MinValue);
                currentValueOnDrawing = ((CurrentValue - MinValue)) * scalingFactor;
                double TimeToAnimate = Math.Round(((CurrentValue - MinValue) * AnimationTime) / (MaxValue - MinValue));
                if (TimeToAnimate <=0)
                {
                    TimeToAnimate = 1;
                }
                DoubleAnimation da = new DoubleAnimation();
                da.From = ConvertValueInPixel(MinValue, height);
                da.To = ConvertValueInPixel(CurrentValue, height);
                da.Duration = new Duration(TimeSpan.FromSeconds(TimeToAnimate));
                baseBrush = new SolidColorBrush();
                animation = new ColorAnimation();
                animation.From = GetColorBasedOnRanges(MinValue).Color;
                animation.To = GetColorBasedOnRanges(CurrentValue).Color;
                lastFillColor = animation.To;
                animation.Duration = new Duration(TimeSpan.FromSeconds(TimeToAnimate));
                baseBrush.BeginAnimation(SolidColorBrush.ColorProperty, animation);
                Rectangle obj = new Rectangle();
                obj.Height = (ConvertValueInPixel(CurrentValue, height) < 0) ? 1 : ConvertValueInPixel(CurrentValue, height);
                obj.Width = width;
                Canvas.SetLeft(obj, origin.X);
                Canvas.SetTop(obj, origin.Y);
                Canvas.SetZIndex(obj, -1);
                obj.Fill = baseBrush;
                ScaleTransform tempTr = new ScaleTransform();
                tempTr.ScaleY = -1;
                obj.RenderTransform = tempTr;
                obj.BeginAnimation(Rectangle.HeightProperty, da);
                DrawingCanvas.Children.Add(obj);
           
        }

        /// <summary>
        /// This method writes text of current scale
        /// </summary>
        /// <param name="x">X cordinate</param>
        /// <param name="y">Y cordinate</param>
        /// <param name="text">String of text</param>
        /// <param name="color">Color of the text</param>
        private void Text(double x, double y, string text, Color color)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = text;
            textBlock.Foreground = new SolidColorBrush(ScaleTextColor);
            textBlock.FontFamily = ScaleTextFontFamily;
            textBlock.FontSize = ScaleTextFontSize;
            textBlock.FontStretch = ScaleTextFontStretch;
            textBlock.FontStyle = ScaleTextFontStyle;
            textBlock.FontWeight = ScaleTextFontWeight;
            Canvas.SetLeft(textBlock, x);
            Canvas.SetTop(textBlock, y);
            DrawingCanvas.Children.Add(textBlock);
        }


        private void WriteCurrentValText(double x, double y, string text)
        {
            TextBlock temp;
            foreach (UIElement child in DrawingCanvas.Children)
            {
                if (child is TextBlock)
                {
                    temp = (TextBlock)child;
                    if (temp.Name == "CurrentValueText")
                    {
                        DrawingCanvas.Children.Remove(temp);
                        break;
                    }
                }
            }
            TextBlock textBlock = new TextBlock();
            textBlock.Name = "CurrentValueText";
            textBlock.Text =  text;
            textBlock.Foreground = new SolidColorBrush(ScaleTextColor);
            textBlock.FontFamily = ScaleTextFontFamily;
            textBlock.FontSize = ScaleTextFontSize;
            textBlock.FontStretch = ScaleTextFontStretch;
            textBlock.FontStyle = ScaleTextFontStyle;
            textBlock.FontWeight = ScaleTextFontWeight;
            Canvas.SetLeft(textBlock, x);
            Canvas.SetTop(textBlock, y);
            Canvas.SetZIndex(textBlock, 10000);
            if (text==MinValue.ToString())
            {
                return;
            }
            DrawingCanvas.Children.Add(textBlock);

               }
        /// <summary>
        /// This method rounds value as per integer parameter 
        /// </summary>
        /// <param name="number">Number of Presicion digits </param>
        /// <returns></returns>
        private string RoundDouble(double number)
        {
            double m = Math.Round(number, Presicion);
            string tempStr = "N" + Presicion.ToString();
            return m.ToString(tempStr);
        }


        /// <summary>
        /// This method draws horizontal scale
        /// </summary>
        /// <param name="MinValue">Min value on scale</param>
        /// <param name="MaxValue">Max Value on scale</param>
        /// <param name="length">length of horizontal value</param>
        /// <param name="p1">initial point of scale</param>
        /// <param name="p2">final point of scale</param>
        /// <param name="flipDirection">boolean value to flip scale</param>
        private void DrawHorizontalScale(double MinValue, double MaxValue, double length, Point p1, Point p2, bool flipDirection)
        {
            if (flipDirection)
            {
                ValueTextVerticalOffset = -ValueTextVerticalOffset;
            }
            double templength = p1.X;
            double totalLogicalValue = MaxValue - MinValue;
            double scalingFactor = length / totalLogicalValue;
            double conversionFactor = length / ((MajorSteps) * (MinorSteps));
            double valueAtMajorSteps = MinValue;
            Line minTick = new Line();
            minTick.Visibility = Visibility.Visible;
            minTick.StrokeThickness = 1;
            minTick.Stroke = Brushes.Black;
            minTick.Y1 = p1.Y - (MajorStepsLength);
            minTick.X1 = templength;
            Text(minTick.X1 - ValueTextHorizontalOffset, minTick.Y1 + ValueTextVerticalOffset, RoundDouble(MinValue), Colors.Red);
            minTick.Y2 = p1.Y + MajorStepsLength;
            minTick.X2 = templength;
            DrawingCanvas.Children.Add(minTick);
            for (double i = 0; i < length; i = i + conversionFactor)
            {
                count++;
                if (count == MinorSteps)
                {
                    valueAtMajorSteps = valueAtMajorSteps + ((MaxValue - MinValue) / MajorSteps);
                    string text = RoundDouble(valueAtMajorSteps);
                    Line majorTick = new Line();
                    majorTick.Visibility = Visibility.Visible;
                    majorTick.StrokeThickness = 1;
                    majorTick.Stroke = Brushes.Black;
                    majorTick.Y1 = p1.Y - (MajorStepsLength);
                    majorTick.X1 = templength + conversionFactor;
                    Text(majorTick.X1 - ValueTextHorizontalOffset, majorTick.Y1 + ValueTextVerticalOffset, text, Colors.Red);
                    majorTick.X2 = majorTick.X1;
                    majorTick.Y2 = p1.Y + MajorStepsLength;
                    DrawingCanvas.Children.Add(majorTick);
                    count = 0;

                }
                else
                {
                    if (valueAtMajorSteps >= MaxValue)
                    {
                        break;
                    }
                    Line line = new Line();
                    line.Visibility = Visibility.Visible;
                    line.StrokeThickness = 1;
                    line.Stroke = Brushes.Black;
                    line.Y1 = p1.Y - MinorStepsLength;
                    line.X1 = templength + conversionFactor;
                    line.Y2 = p1.Y + MinorStepsLength;
                    line.X2 = line.X1;
                    DrawingCanvas.Children.Add(line);
                }
                if (valueAtMajorSteps >= MaxValue)
                {
                    break;
                }

                templength += conversionFactor;
            }
        }

        /// <summary>
        /// This method draws vertical scale
        /// </summary>
        /// <param name="MinValue">Min value on scale</param>
        /// <param name="MaxValue">Max Value on scale</param>
        /// <param name="length">length of horizontal value</param>
        /// <param name="p1">initial point of scale</param>
        /// <param name="p2">final point of scale</param>
        /// <param name="flipDirection">boolean value to flip scale</param>
        private void DrawVerticalScale(double MinValue, double MaxValue, double length, Point p1, Point p2, bool flipDirection)
        {
            if (flipDirection)
            {
                ValueTextVerticalOffset = -ValueTextVerticalOffset;
            }
            double templength = p2.Y;
            double totalLogicalValue = MaxValue - MinValue;
            double scalingFactor = length / totalLogicalValue;
            double conversionFactor = length / ((MajorSteps) * (MinorSteps));
            double valueAtMajorSteps = MinValue;
            Line minTick = new Line();
            minTick.Visibility = Visibility.Visible;
            minTick.StrokeThickness = 1;
            minTick.Stroke = Brushes.Black;
            minTick.X1 = p1.X - (MajorStepsLength);
            minTick.Y1 = templength;
            Text(p1.X + ValueTextVerticalOffset, minTick.Y1 - 8, RoundDouble(MinValue), Colors.Red);
            minTick.X2 = p1.X + MajorStepsLength;
            minTick.Y2 = minTick.Y1;
            DrawingCanvas.Children.Add(minTick);
            for (double i = 0; i < length; i = i + conversionFactor)
            {
                count++;
                if (count == MinorSteps)
                {
                    valueAtMajorSteps = valueAtMajorSteps + ((MaxValue - MinValue) / MajorSteps);
                    string text = RoundDouble(valueAtMajorSteps);
                    Line majorTick = new Line();
                    majorTick.Visibility = Visibility.Visible;
                    majorTick.StrokeThickness = 1;
                    majorTick.Stroke = Brushes.Black;
                    majorTick.X1 = p1.X - (MajorStepsLength);
                    majorTick.Y1 = templength - conversionFactor;
                    Text(p1.X + ValueTextVerticalOffset, majorTick.Y1 - 8, text, Colors.Red);
                    majorTick.X2 = p1.X + MajorStepsLength;
                    majorTick.Y2 = majorTick.Y1;
                    DrawingCanvas.Children.Add(majorTick);
                    count = 0;
                    if (valueAtMajorSteps >= MaxValue)
                    {
                        break;
                    }
                }
                else
                {
                    Line line = new Line();
                    line.Visibility = Visibility.Visible;
                    line.StrokeThickness = 1;
                    line.Stroke = Brushes.Black;
                    line.X1 = p1.X - MinorStepsLength;
                    line.Y1 = templength - conversionFactor;
                    line.X2 = p1.X + MinorStepsLength;
                    line.Y2 = line.Y1;
                    DrawingCanvas.Children.Add(line);
                    if (valueAtMajorSteps >= MaxValue)
                    {
                        break;
                    }
                }
                templength -= conversionFactor;
            }
        }
        
        /// <summary>
        /// This method draws entire tank on canvas
        /// </summary>
        /// <param name="origin">origin point</param>
        /// <param name="height">height of tank</param>
        /// <param name="width">width of tank</param>
        /// <param name="minValueParam">minimum value of tank scale</param>
        /// <param name="maxValueParam">maximum value of tank scale</param>
        /// <param name="FlipScale">boolean parameter to flip scale direction</param>
        /// <param name="IsHorizontal">Boolean parameter to represent alignment</param>
        private void DrawNewRectangle(Point origin, double height, double width, double minValueParam, double maxValueParam, bool FlipScale, bool IsHorizontal)
        {
            if (IsHorizontal)
            {
                //line1
                line1.X1 = origin.X;
                line1.Y1 = origin.Y;
                line1.X2 = origin.X + width;
                line1.Y2 = origin.Y;

                //Base Line line2
                line2.X1 = origin.X;
                line2.Y1 = origin.Y;
                line2.X2 = origin.X;
                line2.Y2 = origin.Y + height;


                TextBlock textBlock = new TextBlock();
                textBlock.Name = "UnitType";
                textBlock.Text = UnitType;
                textBlock.Foreground = new SolidColorBrush(ScaleTextColor);
                textBlock.FontFamily = ScaleTextFontFamily;
                textBlock.FontSize = ScaleTextFontSize;
                textBlock.FontStretch = ScaleTextFontStretch;
                textBlock.FontStyle = ScaleTextFontStyle;
                textBlock.FontWeight = ScaleTextFontWeight;
                Canvas.SetTop(textBlock, (line2.Y1 + line2.Y2) / 2- ValueTextVerticalOffset );
                Canvas.SetLeft(textBlock, line2.X1-35);

                //Canvas.SetBottom(textBlock, origin.X + height);
                DrawingCanvas.Children.Add(textBlock);

                xAxisCurrentText = origin.X + (width / 2);
                yAxisCurrentText = origin.Y + (height / 2);
                //line3
                line3.X1 = origin.X;
                line3.Y1 = origin.Y + height;
                line3.X2 = origin.X + width;
                line3.Y2 = origin.Y + height;
                if (FlipScale)
                {
                    DrawHorizontalScale(MinValue, MaxValue, width, new Point(line1.X1, line1.Y1), new Point(line1.X2, line1.Y2), true);
                    isParentContainerLoaded = true;
                    AnimateHorizontalCurrentValueFill(CurrentValue, height, width, new Point(line2.X2, line2.Y1));
                    WriteCurrentValText(origin.X + currentValueOnDrawing, yAxisCurrentText, " " + RoundDouble( CurrentValue) + " " + UnitText);
                }
                else
                {
                    DrawHorizontalScale(MinValue, MaxValue, width, new Point(line3.X1, line3.Y1), new Point(line3.X2, line3.Y2), false);
                    isParentContainerLoaded = true;
                    AnimateHorizontalCurrentValueFill(CurrentValue, height, width, new Point(line2.X2, line2.Y1));
                    WriteCurrentValText(origin.X + currentValueOnDrawing, yAxisCurrentText, " " + RoundDouble(CurrentValue) + " " + UnitText);
                }
            }
            else
            {
                //Left line1
                line1.X1 = origin.X;
                line1.Y1 = origin.Y;
                line1.X2 = origin.X;
                line1.Y2 = origin.Y + height;

                //Base line2
                line2.X1 = origin.X;
                line2.Y1 = origin.Y + height;
                line2.X2 = origin.X + width;
                line2.Y2 = origin.Y + height;

                TextBlock textBlock = new TextBlock();
                textBlock.Name = "UnitType";
                textBlock.Text = UnitType;
                textBlock.Foreground = new SolidColorBrush(ScaleTextColor);
                textBlock.FontFamily = ScaleTextFontFamily;
                textBlock.FontSize = ScaleTextFontSize;
                textBlock.FontStretch = ScaleTextFontStretch;
                textBlock.FontStyle = ScaleTextFontStyle;
                textBlock.FontWeight = ScaleTextFontWeight;
                Canvas.SetLeft(textBlock, (line2.X1+line2.X2)/2-ValueTextHorizontalOffset);
                Canvas.SetTop(textBlock, origin.Y + height);
                DrawingCanvas.Children.Add(textBlock);

                xAxisCurrentText = origin.X + (width/ 2);
                yAxisCurrentText = origin.Y + (height);

                //Right line3
                line3.X1 = origin.X + width;
                line3.Y1 = origin.Y + height;
                line3.X2 = origin.X + width;
                line3.Y2 = origin.Y;
                if (FlipScale)
                {
                    DrawVerticalScale(MinValue, MaxValue, height, new Point(line1.X1, line1.Y1), new Point(line1.X2, line1.Y2), true);
                    isParentContainerLoaded = true;
                    AnimateVerticalCurrentValueFill(CurrentValue, height, width, new Point(line1.X2, line2.Y1));
                    WriteCurrentValText(xAxisCurrentText-originX, yAxisCurrentText- (currentValueOnDrawing + originY), " " + RoundDouble(CurrentValue) + " " + UnitText);

                }
                else
                {
                    DrawVerticalScale(MinValue, MaxValue, height, new Point(line3.X2, line3.Y2), new Point(line3.X1, line3.Y1), false);
                    isParentContainerLoaded = true;
                    AnimateVerticalCurrentValueFill(CurrentValue, height, width, new Point(line1.X2, line2.Y1));
                    WriteCurrentValText(xAxisCurrentText-originX, yAxisCurrentText-(currentValueOnDrawing + originY), " " + RoundDouble(CurrentValue) + " " + UnitText);

                }
            }
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                DrawingCanvas.Height = Height;
                DrawingCanvas.Width = Width;
                availableHeight = DrawingCanvas.Height * .8;
                availableWidth = DrawingCanvas.Width * .8;
                originX = (DrawingCanvas.Width - availableWidth) / 2;
                originY = (DrawingCanvas.Height - availableHeight) / 2;
                Point origin = new Point(originX, originY);
                if (CurrentValue < MinValue)
                {
                    CurrentValue = MinValue;
                }
                DrawNewRectangle(origin, availableHeight, availableWidth, MinValue, MaxValue, FlipScale, IsHorizontal);
            }
            catch (Exception ex)
            {
                //todo log exception messages here ex.ToString()
            }

        }

        /// <summary>
        /// this will get called when value is changed 
        /// </summary>
        /// <param name="d">sender dependency object</param>
        /// <param name="e">event arguments</param>
        private static  void OnCurrentValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Tank tankObj = d as Tank;
            if (tankObj != null)
            {
                tankObj.OnCurrentValueChanged(Convert.ToDouble(e.OldValue), Convert.ToDouble(e.NewValue));
            }

        }

        static object CoerceValue(DependencyObject d, object value)
        {
            double maxVal = (double)d.GetValue(MaxValueProperty);
            double minVal = (double)d.GetValue(MinValueProperty);
            if ((double)value > maxVal)
                return maxVal;

            if ((double)value < minVal)
                return minVal;

            return value;
        }

        /// <summary>
        /// method to animate old value to new value
        /// </summary>
        /// <param name="oldVal">Old value of scale</param>
        /// <param name="newVal">New value of scale</param>
        protected virtual void OnCurrentValueChanged(double oldVal,double newVal)
        {
            try
            {
                if (!isParentContainerLoaded || newVal < MinValue || newVal > MaxValue)
                {
                    if (CurrentValue < MinValue)
                    {
                        CurrentValue = oldVal;

                    }
                    return;
                }
                TextBlock tempTxt;
                foreach (UIElement child in DrawingCanvas.Children)
                {
                    if (child is TextBlock)
                    {
                        tempTxt = (TextBlock)child;
                        if (tempTxt.Name == "CurrentValueText")
                        {
                            DrawingCanvas.Children.Remove(tempTxt);
                            break;
                        }
                    }
                }
                foreach (UIElement child in DrawingCanvas.Children)
                {
                    if (child is Rectangle)
                    {
                        temp = (Rectangle)child;
                        if (temp.Name == "AnimatedRectangle")
                        {
                            break;
                        }
                    }
                }
                double TimeToAnimate = Math.Round(((Math.Abs(oldVal - newVal)) * AnimationTime) / (MaxValue - MinValue));
                if (TimeToAnimate <= 0)
                {
                    TimeToAnimate = 1;
                }
                if (IsHorizontal)
                {
                    SolidColorBrush baseBrush;
                    ColorAnimation animation;
                    double scalingFactor = lastWidth / (MaxValue - MinValue);
                    currentValueOnDrawing = ((newVal - MinValue)) * scalingFactor;
                    DoubleAnimation da = new DoubleAnimation();
                    da.From = ConvertValueInPixel(oldVal, lastWidth);
                    da.To = ConvertValueInPixel(newVal, lastWidth);
                    da.Duration = new Duration(TimeSpan.FromSeconds(TimeToAnimate));
                    baseBrush = new SolidColorBrush();
                    animation = new ColorAnimation();
                    animation.From = GetColorBasedOnRanges(oldVal).Color; ;
                    animation.To = GetColorBasedOnRanges(newVal).Color;
                    animation.Completed += Animation_Completed_Horizontal;
                    animation.Duration = new Duration(TimeSpan.FromSeconds(TimeToAnimate));
                    temp.Height = lastHeight;
                    temp.Width = ConvertValueInPixel(CurrentValue, lastWidth);
                    temp.Fill = baseBrush;

                    temp.BeginAnimation(Rectangle.WidthProperty, da);

                    baseBrush.BeginAnimation(SolidColorBrush.ColorProperty, animation);
                }
                else
                {
                    SolidColorBrush baseBrush;
                    ColorAnimation animation;
                    double scalingFactor = lastHeight / (MaxValue - MinValue);
                    currentValueOnDrawing = ((newVal - MinValue)) * scalingFactor;
                    DoubleAnimation da = new DoubleAnimation();
                    da.From = ConvertValueInPixel(oldVal, lastHeight);
                    da.To = ConvertValueInPixel(newVal, lastHeight);
                    da.Duration = new Duration(TimeSpan.FromSeconds(TimeToAnimate));
                    baseBrush = new SolidColorBrush();
                    animation = new ColorAnimation();
                    animation.From = GetColorBasedOnRanges(oldVal).Color;
                    animation.To = GetColorBasedOnRanges(newVal).Color;
                    animation.Completed += Animation_Completed_Vertical;
                    animation.Duration = new Duration(TimeSpan.FromSeconds(TimeToAnimate));
                    baseBrush.BeginAnimation(SolidColorBrush.ColorProperty, animation);
                    temp.Height = (ConvertValueInPixel(newVal, lastHeight) <= 0) ? 1 : ConvertValueInPixel(newVal, lastHeight);
                    temp.Width = lastWidth;
                    temp.Fill = baseBrush;
                    ScaleTransform tempTr = new ScaleTransform();
                    tempTr.ScaleY = -1;
                    temp.RenderTransform = tempTr;
                    temp.BeginAnimation(Rectangle.HeightProperty, da);
                }
            }
            catch (Exception ex)
            {
                //todo log exception messages here ex.ToString()
            }
            
            
        }

        /// <summary>
        /// This method is called when horizontal animation is completed
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event arguments</param>
        private void Animation_Completed_Horizontal(object sender, EventArgs e)
        {
            try
            {
                WriteCurrentValText(Canvas.GetLeft(temp) + currentValueOnDrawing, Canvas.GetTop(temp) + (lastHeight / 2), " " + RoundDouble(CurrentValue) + " " + UnitText);
            }
            catch (Exception)
            {
                //todo log exception messages here ex.ToString()
            }
            
        }

        /// <summary>
        /// this method is called when vertical animation is completed
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event argumetns</param>
        private void Animation_Completed_Vertical(object sender, EventArgs e)
        {
            try
            {
                WriteCurrentValText(Canvas.GetLeft(temp) + (lastWidth / 2) - (originX), Canvas.GetTop(temp) - (currentValueOnDrawing + originY), " " + RoundDouble(CurrentValue) + " " + UnitText);
            }
            catch (Exception)
            {
                //todo log exception messages here ex.ToString()
            }
            
        }

    }
}
