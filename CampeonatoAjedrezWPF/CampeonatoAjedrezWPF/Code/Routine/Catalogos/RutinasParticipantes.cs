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
    public class RutinasParticipantes : IRutinasCatalogos<Participante>, INotifyPropertyChanged
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

        Window.Catalogos.Participantes window;
        private Localidad _CurrentLocalidad;
        private IList<Localidad> _CatalogoLocalidad;
        private ICatalogos<Localidad> _daoLocalidad;

        #region Publics
        public Participante Current
        {
            get { return current; }
            set { current = value; NotifyPropertyChanged("Current"); }
        }
        public IList<Participante> Catalogos
        {
            get { return catalogos; }
            set { catalogos = value; NotifyPropertyChanged("Catalogos"); }
        }

        public Localidad CurrentLocalidad
        {
            get
            {
                return _CurrentLocalidad;
            }

            set
            {
                _CurrentLocalidad = value;
                NotifyPropertyChanged("CurrentLocalidad");
            }
        }

        public IList<Localidad> CatalogoLocalidad
        {
            get
            {
                return _CatalogoLocalidad;
            }

            set
            {
                _CatalogoLocalidad = value;
                NotifyPropertyChanged("CatalogoLocalidad");
            }
        }

        public ICatalogos<Localidad> DaoLocalidad
        {
            get
            {
                return _daoLocalidad;
            }

            set
            {
                _daoLocalidad = value;
            }
        }

        #endregion
        public void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                window = sender as Window.Catalogos.Participantes;
                this.daoCatalogo = Service.getdaoDiccionario().daos["CatalogoParticipantes"] as ICatalogos<Participante>;
                DaoLocalidad = Service.getdaoDiccionario().daos["CatalogoLocalidad"] as ICatalogos<Localidad>;
                Current = new Participante();
                CurrentLocalidad = new Localidad();
                Catalogos = daoCatalogo.getAll();
                CatalogoLocalidad = DaoLocalidad.getAll();

                (sender as Window.Catalogos.Participantes).Flip.HideControlButtons();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error muy grave D: " + ex.Message, "Campeonato Ajedrez", MessageBoxButton.OK, MessageBoxImage.Error);
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
                        current.idlocalidad = CurrentLocalidad.idlocalidad;
                        onCancela(sender, e);
                        break;
                    case EVENTO.BAJA:
                        this.OnPregunta("¿Desea borrar el siguiente registro?", evento);
                        break;
                    case EVENTO.UPDATE:
                        this.OnPregunta("¿Desea editar el siguiente registro?", evento);
                        break;
                }
                Catalogos = daoCatalogo.getAll();
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
                Current = new Participante();
                daoCatalogo.refresh();
                Catalogos = daoCatalogo.getAll();
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
                current.idlocalidad = CurrentLocalidad.idlocalidad;
                daoCatalogo.update();
            }
            catch (Exception ex)
            {
                OnError(ex);
            }

        }
    }
}
