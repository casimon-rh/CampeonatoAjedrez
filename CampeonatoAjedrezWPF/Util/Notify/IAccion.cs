using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notify
{
    public interface IAccion
    {
        void realiza();
        void realiza(string referencia);
        void realiza(object referencia);

    }
}
