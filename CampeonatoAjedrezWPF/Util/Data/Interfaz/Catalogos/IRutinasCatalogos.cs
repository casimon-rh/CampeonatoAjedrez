using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaz
{
    /// <summary>
    /// Funcionalidad de catalogo, pensada en funcionar con IDaoCrud<T> e ICatalogos<T>
    /// Clase Abstracta para Interfaz Gráfica de Usuario sobre el esquema MVVM sobre WPF
    /// Debe implementar INotifyPropertyChanged y ser correctamente Bindeado a la Vista
    /// </summary>
    /// <typeparam name="T">La tabla o equivalente</typeparam>
    public abstract class IRutinasCatalogos<T>
    {
        /// <summary>
        /// Delegado para el evento de Interfaz Gráfica de Usuario que notifica un error
        /// </summary>
        /// <param name="ex">La excepción cachada a notificar. De no ser una excepción, lanzar una</param>
        public delegate void onError(Exception ex);
        /// <summary>
        /// Delegado para el evento de Interfaz Gráfica de Usuario que notifica una pregunta
        /// </summary>
        /// <param name="men">El mensaje de pregunta</param>
        /// <param name="evento">El evento de interacción que se realizará en caso de una respuesta afirmativa</param>
        public delegate void onPregunta(String men, EVENTO evento);
        /// <summary>
        /// Delegado para el evento de Interfaz Gráfica de Usuario que notifica el exito
        /// </summary>
        /// <param name="men">El mensaje de exito</param>
        public delegate void onSuccess(String men);
        /// <summary>
        /// El delegado para el evento de Interfaz Gráfica de Usuario que solicita confirmación de borrado
        /// </summary>
        public delegate void Delete();


        /// <summary>
        /// Evento para notificar a la Interfaz Gráfica de Usuario un error
        /// </summary>
        public abstract event onError OnError;
        /// <summary>
        /// Evento para notificar una pregunta a la Interfaz Gráfica de Usuario 
        /// </summary>
        public abstract event onPregunta OnPregunta;
        /// <summary>
        /// Evento para notificar el exito en la operación a la Interfaz Gráfica de Usuario 
        /// </summary>
        public abstract event onSuccess OnSuccess;
        /// <summary>
        /// Evento para notificar una confirmación de borrado a la Interfaz Gráfica de Usuario 
        /// </summary>
        public abstract event Delete Deleted;
        /// <summary>
        /// El objeto seleccionado, el que se inserta, modifica o borra del catálogo
        /// </summary>
        protected T current;
        /// <summary>
        /// La lista de objetos que se obtiene de la tabla o equivalente.
        /// De ésta se selecciona el objeto current
        /// </summary>
        protected IList<T> catalogos;
        /// <summary>
        /// El dao de interacción con la base de datos o equivalente
        /// </summary>
        public ICatalogos<T> daoCatalogo;
        /// <summary>
        /// El evento de interacción en curso, la ejecución de los eventos de Interfaz Gráfica de Usuario , deben cambiar éste.
        /// </summary>
        public EVENTO evento;

    }
}
