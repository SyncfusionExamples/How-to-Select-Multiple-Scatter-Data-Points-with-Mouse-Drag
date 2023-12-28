using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleSelection_ScatterPoints
{
    public class StockData: INotifyPropertyChanged
    {
        #region Fields

        DateTime date = new DateTime(2023, 1, 1);
        private List<object> selectedDataPoints;
        private ObservableCollection<StockModel> data;

        #endregion

        #region Properties

        public List<object> SelectedDataPoints
        {
            get { return selectedDataPoints; }
            set
            {
                selectedDataPoints = value;
                OnPropertyChanged(nameof(SelectedDataPoints));
            }
        }
        public ObservableCollection<StockModel> Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
                OnPropertyChanged(nameof(Data));
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        public StockData()
        {
            Data = new ObservableCollection<StockModel>()
            {
            new StockModel(date.AddMonths(0), 62, 6),
            new StockModel(date.AddMonths(1), 50, 12),
            new StockModel(date.AddMonths(2), 17, 2),
            new StockModel(date.AddMonths(3), 34, 7),
            new StockModel(date.AddMonths(4), 70, 15),
            new StockModel(date.AddMonths(5), 22, 8),
            new StockModel(date.AddMonths(6), 48, 3),
            new StockModel(date.AddMonths(7), 53, 10),
            new StockModel(date.AddMonths(8), 48, 14),
            new StockModel(date.AddMonths(9), 35, 12),
            new StockModel(date.AddMonths(10), 16, 6),
            new StockModel(date.AddMonths(11), 55, 7),
        };
        } 

        #endregion

        #region Event Handler

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        } 

        #endregion
    }
}
