using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notify.NotifyGUI
{
    public interface INotificaGUI
    {
        void notificar();
        void notificaVacio();
        void Process();
        void ProcessSinDao();
    }

    public abstract class INotificaGUIGeneric<T> : INotificaGUI
    {
        public IList<T> lista { get; set; }
        public abstract void notificar();
        public abstract void notificaVacio();
        public abstract void Process();
        public abstract void ProcessSinDao();
    }
}
