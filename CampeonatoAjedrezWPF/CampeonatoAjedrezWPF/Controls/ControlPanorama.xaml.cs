using PanoramaControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

namespace CampeonatoAjedrezWPF.Controls
{
    /// <summary>
    /// Interaction logic for ControlPanorama.xaml
    /// </summary>
    public partial class ControlPanorama : UserControl, INotifyPropertyChanged
    {
        private IEnumerable<PanoramaGroup> panoramaItems;
        private double imgSize;
        private double itemBox;
        private double groupHeight;

        public ControlPanorama()
        {
            InitializeComponent();
            (this as FrameworkElement).DataContext = this;
        }

        public static readonly DependencyProperty PanoramaItemsProperty = DependencyProperty.Register("PanoramaItems", typeof(IEnumerable<PanoramaGroup>), typeof(ControlPanorama), null);
        public static readonly DependencyProperty GroupHeightProperty = DependencyProperty.Register("GroupHeight", typeof(double), typeof(ControlPanorama), null);
        public static readonly DependencyProperty ItemBoxProperty = DependencyProperty.Register("ItemBox", typeof(double), typeof(ControlPanorama), null);
        public static readonly DependencyProperty SizeProperty = DependencyProperty.Register("Size", typeof(double), typeof(ControlPanorama), null);

        public double GroupHeight { get { return (double)GetValue(GroupHeightProperty); } set { SetValueDp(GroupHeightProperty, value); } }
        public double ItemBox { get { return (double)GetValue(ItemBoxProperty); } set { SetValueDp(ItemBoxProperty, value); } }
        public double Size { get { return (double)GetValue(SizeProperty); } set { SetValueDp(SizeProperty, value); } }
        public IEnumerable<PanoramaGroup> PanoramaItems { get { return (IEnumerable<PanoramaGroup>)GetValue(PanoramaItemsProperty); } set { SetValueDp(PanoramaItemsProperty, value); } }

        private void SetValueDp(DependencyProperty pro, object value, String p = null)
        {
            SetValue(pro, value);
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }

}
