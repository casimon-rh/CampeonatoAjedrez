using Data;
using Data.Interfaz;
using Data.Linq.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CampeonatoAjedrezWPF.Routine.Catalogos
{
    public class RutinasTelefonosDeHotel : IRutinasCatalogos<Telefono>, INotifyPropertyChanged
    {
        public override event Delete Deleted;
        public override event onError OnError;
        public override event onPregunta OnPregunta;
        public override event onSuccess OnSuccess;
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        Window.Catalogos.TelefonosDeHotel window;

        public int id_hotel { get; set; }

        public Telefono Current
        {
            get { return current; }
            set { current = value; NotifyPropertyChanged("Current"); }
        }
        public IList<Telefono> Catalogos
        {
            get { return catalogos; }
            set { catalogos = value; NotifyPropertyChanged("Catalogos"); }
        }
        public void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                window = sender as Window.Catalogos.TelefonosDeHotel;
                this.daoCatalogo = Service.getdaoDiccionario().daos["CatalogoTelefonosDeHotel"] as ICatalogos<Telefono>;
                Current = new Telefono() { id_hotel=this.id_hotel};
                Catalogos = daoCatalogo.getAll().Where(x=>x.id_hotel==this.id_hotel).Select(x=> x).ToList();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error muy grave D: " + ex.Message, "Campeonato Ajedres", MessageBoxButton.OK, MessageBoxImage.Error);
                window.Close();
            }
        }
        public void onClick(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (this.evento)
                {
                    case EVENTO.ALTA:
                        daoCatalogo.refresh();
                        daoCatalogo.inserta(Current);
                        onCancela(sender, e);
                        break;
                    case EVENTO.BAJA:
                        this.OnPregunta("¿Desea borrar el siguiente registro?", evento);
                        break;
                    case EVENTO.UPDATE:
                        this.OnPregunta("¿Desea editar el siguiente registro?", evento);
                        break;
                }
                Catalogos = daoCatalogo.getAll().Where(x => x.id_hotel == this.id_hotel).Select(x => x).ToList();
            }
            catch (Exception ex)
            {
                OnError(ex);
            }
        }

        public void onCancela(object sender, RoutedEventArgs e)
        {
            try
            {
                Current = new Telefono() { id_hotel = this.id_hotel };
                daoCatalogo.refresh();
                Catalogos = daoCatalogo.getAll().Where(x => x.id_hotel == this.id_hotel).Select(x => x).ToList();
            }
            catch (Exception ex)
            {
                OnError(ex);
            }
        }

        public void OnDelete()
        {
            try
            {
                daoCatalogo.borrar(Current);
            }
            catch (Exception ex)
            {
                OnError(ex);
            }
        }

        public void Update()
        {

            try
            {
                daoCatalogo.update();
            }
            catch (Exception ex)
            {
                OnError(ex);
            }

        }
    }

}
