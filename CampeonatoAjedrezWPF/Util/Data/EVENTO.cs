using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// Describe los eventos de iteracción que se realizan sobre el catálogo
    /// </summary>
    public enum EVENTO
    {
        /// <summary>
        /// Inserta en la tabla o equivalente
        /// </summary>
        ALTA,
        /// <summary>
        /// Borra en la tabla o equivalente
        /// </summary>
        BAJA,
        /// <summary>
        /// Actualiza al estado actual la tabla o equivalente
        /// </summary>
        UPDATE
    }
}
