using Notify.NotifyGUI;
using Notify.NotifyGUI.Visual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaz.Reporte
{
    public interface IReporting<T>
    {
        INotificaGUI getHandler();
        void ToReport(IDictionary<string, IDictionary<string, string>> parametros = null, bool async = false, Visor.Delegado Controller = null);
        List<T> getSource();
        IDictionary<string, TT> getSourceAsync<TT>(IDictionary<string, IDictionary<string, string>> parametros = null);
        void setRSource<TT>(IDictionary<String, TT> s);
        void SetConnections(INotificaGUI handler);
    }
}
