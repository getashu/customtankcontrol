using TankControl;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace tank_test
{
    public class TestVM : INotifyPropertyChanged
    {
        public ObservableCollection<RangeValues> RangeValuesForTank { get; set; }
        public ObservableCollection<RangeValues> RangeValuesForSlider { get; set; }
        public ObservableCollection<RangeValues> RangeValuesForKnob { get; set; }
        public ObservableCollection<RangeValues> RangeValuesForGauge { get; set; }

        public TestVM()
        {
            CurrentValue = 0;
            CurrentValue = 50;
            RangeValuesForTank = new ObservableCollection<RangeValues>();
            RangeValuesForSlider = new ObservableCollection<RangeValues>();
            RangeValuesForKnob = new ObservableCollection<RangeValues>();
            RangeValuesForGauge = new ObservableCollection<RangeValues>();
            RangeValues value = new RangeValues();
            value.MinValue = 20;
            value.MaxValue = 30;
            value.Color = new SolidColorBrush(Colors.Green);
            RangeValuesForSlider.Add(value);

            value = new RangeValues();
            value.MinValue = 30;
            value.MaxValue = 60;
            value.Color = new SolidColorBrush(Colors.Orange);
            RangeValuesForSlider.Add(value);



            value = new RangeValues();
            value.MinValue = 60;
            value.MaxValue = 100;
            value.Color = new SolidColorBrush(Colors.Red);
            RangeValuesForSlider.Add(value);

            RangeValues r1 = new RangeValues();
            r1.MinValue = 20;
            r1.MaxValue = 46;
            r1.Color = new SolidColorBrush(Colors.Green);
            RangeValuesForTank.Add(r1);

            RangeValues r2 = new RangeValues();
            r2.MinValue = 46;
            r2.MaxValue = 60;
            r2.Color = new SolidColorBrush(Colors.Orange);
            RangeValuesForTank.Add(r2);

            RangeValues r3 = new RangeValues();
            r3.MinValue = 60;
            r3.MaxValue = 100;
            r3.Color = new SolidColorBrush(Colors.Red);
            RangeValuesForTank.Add(r3);


            RangeValuesForKnob.Add(new RangeValues() { Color = new SolidColorBrush(Colors.Red), MaxValue = 35, MinValue = 0 });
            RangeValuesForKnob.Add(new RangeValues() { Color = new SolidColorBrush(Colors.Orange), MaxValue = 70, MinValue = 35 });
            RangeValuesForKnob.Add(new RangeValues() { Color = new SolidColorBrush(Colors.Black), MaxValue = 200, MinValue = 70 });
            RangeValuesForGauge.Add(new RangeValues() { Color = new SolidColorBrush(Colors.Yellow), MaxValue = 35, MinValue = 19 });
            RangeValuesForGauge.Add(new RangeValues() { Color = new SolidColorBrush(Colors.Green), MaxValue = 57, MinValue = 35 });
            RangeValuesForGauge.Add(new RangeValues() { Color = new SolidColorBrush(Colors.Red), MaxValue = 100, MinValue = 57 });
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string currentvalue)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(currentvalue));
        }
        private double currValue;
        // Declare the event

        public double CurrentValue
        {
            get { return currValue; }
            set
            {
                currValue = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("CurrentValue");
            }
        }


        private bool currValueSwitch;
        // Declare the event

        public bool CurrentValueSwitch
        {
            get { return currValueSwitch; }
            set
            {
                currValueSwitch = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("CurrentValueSwitch");
            }
        }


        private bool currValueForIndicator;
        // Declare the event

        public bool CurrentValueForIndicator
        {
            get { return currValueForIndicator; }
            set
            {
                currValueForIndicator = value;
                OnPropertyChanged("CurrentValueForIndicator");
            }
        }
    }
}
