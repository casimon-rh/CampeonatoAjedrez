using CampeonatoAjedrezWPF.Routine.Catalogos;
using Data;
using Data.Linq.Mapping;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Notify.NotifyGUI;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Windows.Threading;


namespace CampeonatoAjedrezWPF.Window.Catalogos
{
    public partial class CampeonatoPrevio : MetroWindow
    {
        RutinasCampeonatoPrevio rutinas;
        Dispatcher dsDispatch;
        public delegate void Show(bool b, EVENTO evt);
        public CampeonatoPrevio()
        {
            try
            {
                InitializeComponent();
                rutinas = Resources["Rutina"] as RutinasCampeonatoPrevio;
                this.Loaded += rutinas.MetroWindow_Loaded;
                rutinas.OnError += rutinas_onFailure;
                rutinas.OnPregunta += rutinas_onUploadSuccess;
                dsDispatch = this.Dispatcher;
                Flip.HideControlButtons();
            }
            catch (Exception)
            {

                throw;
            }
        }
        void rutinas_onUploadSuccess()
        {
            Dialogs.showMessage("Los resultados son bla bla", "Campeonato Ajedrez", this);
        }
        void rutinas_onFailure(Exception ex)
        {
            Dialogs.showException(ex, "Error", this);

        }
        void rutinas_onLoadSuccess()
        {
            Dialogs.showMessage("asdasd", "Campeonato Ajedrez", this);
        }
        void success()
        {
            Dialogs.showMessage("Se insertó correctamente", "Campeonato Ajedrez", this);
        }

        async void rutinas_onUploadSuccess(string s, EVENTO evento)
        {

            MessageDialogResult res = await Dialogs.showQuestionMessage(s, "Campeonato Ajedrez", this).ConfigureAwait(false);
            Show ss = new Show(evalua);
            try
            {
                dsDispatch.BeginInvoke(ss, res == MahApps.Metro.Controls.Dialogs.MessageDialogResult.Affirmative, evento);
            }
            catch (Exception ex) { }

        }
        private void ElDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as DataGrid).SelectedIndex != -1)
            {
                rutinas.evento = EVENTO.UPDATE;
                Flip.SelectedIndex = 1;
                //clave.IsEnabled = false;
            }
        }

        private void Nuevo_Click(object sender, RoutedEventArgs e)
        {
            Nuevo.IsEnabled = false;
            rutinas.evento = EVENTO.ALTA;
            rutinas.Current = new Campeonato();
            Flip.SelectedIndex = 1;
            Borrar.IsEnabled = false;
            //clave.IsEnabled = true;
        }

        private void Flip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as FlipView).SelectedIndex == 0 && rutinas != null)
            {
                ElDataGrid.SelectedIndex = -1;
                Nuevo.IsEnabled = true;
                Aceptar.IsEnabled = false;
                rutinas.onCancela(sender, e);
            }
            else if (rutinas != null)
            {
                Nuevo.IsEnabled = false;
                Aceptar.IsEnabled = true;
                //if (rutinas.Current != null && rutinas.Current.id_hotel != 0)
                    Borrar.IsEnabled = true;
            }

        }
        void evalua(bool res, EVENTO evt)
        {
            if (res)
            {
                if (evt == EVENTO.UPDATE)
                    rutinas.Update();
                else
                    rutinas.OnDelete();
                Cancelar_Click(null, null);
                Flip.SelectedIndex = 0;
            }
            else
                rutinas.evento = EVENTO.UPDATE;
        }

        private void Borrar_Click(object sender, RoutedEventArgs e)
        {
            if (rutinas.Current != null)
            {
                rutinas.evento = EVENTO.BAJA;
                rutinas.onClick(sender, e);
            }
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            Flip.SelectedIndex = 0;
            Flip.HideControlButtons();
            rutinas.onCancela(sender, e);
        }

        private void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            //if (!string.IsNullOrEmpty(clave.Text))
            //{
            rutinas.onClick(sender, e);
            if (rutinas.evento == EVENTO.ALTA)
                Flip.SelectedIndex = 0;
            //}
            //else
            //    Dialogs.showMessage("Verifique que todos los campos requeridos hayan sido llenado", "Campeonato Ajedres", this);
        }
    }

}
