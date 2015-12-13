﻿using Data;
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
    public class RutinasPartidas : IRutinasCatalogos<Partida>, INotifyPropertyChanged
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

        Window.Catalogos.Partidas window;

        private Arbitro _CurrentArbitro;
        private IList<Arbitro> _CatalogoArbitro;

        

        public Partida Current
        {
            get { return current; }
            set { current = value; NotifyPropertyChanged("Current"); }
        }
        public IList<Partida> Catalogos
        {
            get { return catalogos; }
            set { catalogos = value; NotifyPropertyChanged("Catalogos"); }
        }
        public void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                window = sender as Window.Catalogos.Partidas;
                this.daoCatalogo = Service.getdaoDiccionario().daos["CatalogoPartidas"] as ICatalogos<Partida>;
                Current = new Partida();
                Catalogos = daoCatalogo.getAll();


                (sender as Window.Catalogos.Partidas).Flip.HideControlButtons();
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
                Current = new Partida();
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
                daoCatalogo.update();
            }
            catch (Exception ex)
            {
                OnError(ex);
            }

        }
    }
}
