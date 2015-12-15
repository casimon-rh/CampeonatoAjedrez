using CampeonatoAjedrezWPF.Routine;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Notify;
using Notify.NotifyGUI;
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
using System.Windows.Threading;

namespace CampeonatoAjedrezWPF.Window
{
    /// <summary>
    /// Interaction logic for MainPanorama.xaml
    /// </summary>
    public partial class MainPanorama : MetroWindow, IAccion
    {
        private MainRoutine rutina;
        Dispatcher ds;
        delegate void deleg(MessageDialogResult mdr, Delegate eventoPositivo, Delegate eventoNegativo);
        List<string> subMenuRef;
        private bool check = false;
        public void realiza() { }
        public void realiza(string referencia) { }

        public MainPanorama()
        {
            InitializeComponent();
            ds = this.Dispatcher;
            this.Loaded += MainPanorama_Loaded;
            subMenuRef = new List<string>();
            Flip.SelectionChanged += Flip_SelectionChanged;
        }

        private void Flip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Flip.SelectedIndex == 0)
            {
                subMenuRef.Clear();
                if (!check)
                {
                    check = true;
                    MainPanorama_Loaded(null, null);
                }
            }
            else
                check = false;
        }

        private void MainPanorama_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!check)
                    rutina = Resources["Rutina"] as MainRoutine;
                rutina.LaAccion = this;
                Flip.HideControlButtons();
                Flip.IsBannerEnabled = false;
                if (!check)
                    rutina.llenaPanorama();
            }
            catch (Exception ex)
            {
                ExcepcionAsyncro(ex);
            }
        }
        private string generateType(string s)
        {
            return (subMenuRef.Any() ? subMenuRef.Aggregate((i, j) => i + "." + j) : "") + "." + s.Replace(" ", string.Empty);
        }
        public void realiza(object referencia)
        {
            try
            {
                if (!rutina.llenaPanoramaSubMenu(referencia as string))
                {
                    try
                    {
                        string tipo = generateType(referencia as string);
                        MetroWindow mw = (Activator.CreateInstance(Type.GetType("CampeonatoAjedrezWPF.Window." + tipo,true))) as MetroWindow;
                        mw.ShowDialog();
                    }
                    catch (Exception ex) { if (ex is TypeLoadException) MensajeAsyncro("No se encontro la Funcionalidad"); else ExcepcionAsyncro(ex); }
                }
                else
                {
                    string sss = (referencia as string).Replace(" ", string.Empty);
                    if (!subMenuRef.Contains(sss))
                        subMenuRef.Add(sss);
                    Flip.SelectedIndex = 1;
                    Flip.ShowControlButtons();
                    Pan2.PanoramaItems = rutina.PanoramaItemsSub;
                }
            }
            catch (Exception ex)
            {
                ExcepcionAsyncro(ex);
            }
        }
        #region Messages
        delegate void t();
        void tt() { }
        async void MensajeNoAsyncro(string mensaje)
        {
            var aux = await Dialogs.showQuestionMessage(mensaje, "Campeonato Ajedrez", MessageDialogStyle.Affirmative, this);
            deleg auxLogin = new deleg(delegada);
            try
            {
                ds.BeginInvoke(auxLogin, aux, new t(tt), new t(tt));
            }
            catch (Exception ex)
            {
                Dialogs.showException(ex, "Campeonato Ajedrez", this);
            }
        }
        async void MensajeNoAsyncro(string mensaje, Delegate eventoPositivo, Delegate eventoNegativo)
        {
            var aux = await Dialogs.showQuestionMessage(mensaje, "Campeonato Ajedrez", MessageDialogStyle.Affirmative, this);
            deleg auxLogin = new deleg(delegada);
            try
            {
                ds.BeginInvoke(auxLogin, aux, eventoPositivo, eventoNegativo);
            }
            catch (Exception ex)
            {
                Dialogs.showException(ex, "Campeonato Ajedrez", this);
            }
        }
        void delegada(MessageDialogResult mdr, Delegate eventoPositivo, Delegate eventoNegativo)
        {
            if (mdr == MessageDialogResult.Affirmative) eventoPositivo.Method.Invoke(this, null);
            else if (mdr == MessageDialogResult.Negative) eventoNegativo.Method.Invoke(this, null);

        }
        void MensajeAsyncro(string mensaje)
        {
            Dialogs.showMessage(mensaje, "Campeonato Ajedrez", this);
        }
        async void ExcepcionAsyncro(Exception ex)
        {
            await this.ShowExceptionAsync("Campeonato Ajedrez", ex);
        }

        #endregion
    }
}
