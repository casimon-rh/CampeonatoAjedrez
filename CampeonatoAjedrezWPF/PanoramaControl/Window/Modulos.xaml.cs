using Data.Linq.Mapping.Seguridad;
using MahApps.Metro.Controls;
using SistemaAccesoWPF_CTP.Routines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Visualize.Actions;
using Visualize.Controles.Metro;

namespace SistemaAccesoWPF_CTP.Window
{
    /// <summary>
    /// Lógica de interacción para Modulos.xaml
    /// </summary>
    public partial class Modulos : MetroWindow, IAccion
    {
        public SistemasModel rutina { get; set; }
        private object referen;
        public Modulos(Sistema sis)
        {
            InitializeComponent();
            rutina = Resources["Rutina"] as SistemasModel;
            referen = sis;
        }

        public void realiza()
        {
            throw new NotImplementedException();
        }

        public void realiza(string referencia)
        {
            throw new NotImplementedException();
        }

        public void realiza(object referencia)
        {
            Dialogs.showMessage("Ejecuta el modulo " + (referencia as Modulo).nommod, "Factor100", this);
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            rutina.LaAccionMod = this;
            DataContext = rutina;
            rutina.llenaPanoramaMod(referen as Sistema);
        }
    }
}
