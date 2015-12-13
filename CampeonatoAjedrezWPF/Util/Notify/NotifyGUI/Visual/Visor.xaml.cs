using CrystalDecisions.CrystalReports.Engine;
using Data.Interfaz.Reporte;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Notify.NotifyGUI.CrystalReports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Notify.NotifyGUI.Visual
{
    /// <summary>
    /// Interaction logic for Visor.xaml
    /// </summary>
    public partial class Visor : MetroWindow
    {
        private ReportDocument _reporte;
        private Boolean isClose;
        private static Visor visor;
        public delegate void Delegado();
        public delegate IDictionary<String, T> DelegadoR<T>(IDictionary<string, IDictionary<string, string>> parametros = null);
        public delegate void OtroDelegado(IDictionary<string, IDictionary<string, string>> parametros = null);
        private static ProgressDialogController pdc;
        private static Dispatcher Manager;
        private SAPBusinessObjects.WPF.Viewer.CrystalReportsViewer visorReporte;
        static BackgroundWorker worker = new BackgroundWorker();


        private void setReporte(ReportDocument reporte, IDictionary<string, string> parametros)
        {

            foreach (var aux in parametros)
            {
                try
                {
                    reporte.SetParameterValue(aux.Key, aux.Value);
                }
                catch (Exception)
                {
                    this.ShowExceptionAsync("Reportes", new Exception("El parametro especificado no existe"));
                }
            }
            this.reporte = reporte;
        }
        public ReportDocument reporte
        {
            set
            {
                this._reporte = value;
                if (this.visorReporte != null)
                {
                    this.visorReporte.Owner = Window.GetWindow(this);
                    this.visorReporte.ViewerCore.ReportSource = value;
                }
                else
                {
                    Main.Children.Clear();
                    this.visorReporte = new SAPBusinessObjects.WPF.Viewer.CrystalReportsViewer();
                    //visorReporte.Loaded += visorReporte_Loaded;
                    Main.Children.Add(visorReporte);
                    this.visorReporte.Owner = Window.GetWindow(this);
                    this.visorReporte.ViewerCore.ReportSource = value;
                }
            }
        }

        private Visor()
        {
            InitializeComponent();
            isClose = false;
            //this.Loaded += Visor_Loaded;
            Manager = this.Dispatcher;
        }

        public static Visor getVisor(ReportDocument rpt, IDictionary<string, string> parametros)
        {
            if (visor == null || visor.isClose)
                visor = new Visor();
            visor.setReporte(rpt, parametros);
            return visor;
        }

        private delegate void Accion();

        private static async void MuestraMensaje(string msg)
        {
            await visor.ShowMessageAsync("Reportes", msg);
        }
        private static async Task<Object> MuestraExcepcion(Exception ex)
        {
            await visor.ShowExceptionAsync("Reportes", ex);
            return null;
        }
        private static Exception _ex;

        private static Exception Ex
        {
            get { return _ex; }
            set { _ex = value; }
        }
        public static async void NotificaAsyncro<T, U>(DelegadoR<U> SetSource, Delegado SetRpt,
           INotificaGUI Handler, IReporting<T> DAO, IDictionary<String, U> RSources, string connections = "",
           IDictionary<string, IDictionary<string, string>> parametros = null, Delegado Controller = null)
        {
            Ex = null;
            worker = new BackgroundWorker();
            if (visor == null || visor.isClose)
            {
                visor = new Visor();
                visor.Show();
            }
            pdc = await visor.ShowProgressAsync("Reportes", "Cargando...");
            pdc.SetCancelable(false);
            pdc.SetIndeterminate();
            NotificaGUICrystal HandlerCrystal = null;
            worker.DoWork += delegate (object s, DoWorkEventArgs e)
            {
                try
                {
                    if (Controller != null)
                        Controller();

                    if (!(Handler is NotificaGUICrystal))
                        throw new Exception("Tecnologia incorrecta, No se está usando Crystal Reports adecuadamente", new NotImplementedException());

                    HandlerCrystal = Handler as NotificaGUICrystal;
                    if (connections == "")
                    {
                        HandlerCrystal.SetReportSources(SetSource(parametros) as IDictionary<String, DataTable>);
                        HandlerCrystal.Process();
                    }
                    else
                    {
                        if (HandlerCrystal.SinDAO)
                        {
                            HandlerCrystal.ProcessSinDao();
                            if (HandlerCrystal.SinDAO)
                                if (HandlerCrystal.RptDoc.DataSourceConnections.Count != 0)
                                    foreach (CrystalDecisions.CrystalReports.Engine.InternalConnectionInfo con in HandlerCrystal.RptDoc.DataSourceConnections)
                                        con.SetConnection(connections.Split(';')[0].Split('=')[1], connections.Split(';')[1].Split('=')[1], connections.Split(';')[3].Split('=')[1], connections.Split(';')[4].Split('=')[1]);
                        }
                    }


                }
                catch (Exception exx)
                {
                    Ex = exx;
                }
            };
            worker.RunWorkerAsync();
            worker.RunWorkerCompleted += async delegate (object s, RunWorkerCompletedEventArgs e)
            {
                await pdc.CloseAsync();
                if (Ex != null)
                    if (Ex.Message == "No existen datos")
                        await visor.ShowMessageAsync("Reportes", Ex.Message);
                    else
                        await MuestraExcepcion(Ex);
                else
                    visor.setReporte(HandlerCrystal.RptDoc, HandlerCrystal.parametros ?? new Dictionary<string, string>());

            };
        }
        public static Visor getVisor(ReportDocument rpt)
        {
            if (visor == null || visor.isClose)
                visor = new Visor();
            visor.reporte = rpt;
            return visor;
        }
        public static Visor enviaVisorVacio()
        {
            if (visor == null || visor.isClose)
                visor = new Visor();
            visor.Show();
            visor.ShowMessageAsync("Reporte", "El reporte está vacío", MessageDialogStyle.Affirmative);
            return visor;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            visor.isClose = true;
        }
    }
}
