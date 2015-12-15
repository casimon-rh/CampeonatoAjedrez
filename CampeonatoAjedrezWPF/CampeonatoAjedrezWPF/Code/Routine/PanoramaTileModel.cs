using Notify;
using Notify.NotifyGUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CampeonatoAjedrezWPF.Routine
{
    public class PanoramaTileModel : INPCBase
    {
        private IAccion accion;
        private string text;
        private object obj;
        private string imageUrl;
        private ICommand tileClickedCommand;

        #region Publics
        public string Text { get { return text; } private set { if (value != null) text = value; NotifyPropertyChanged("Text"); } }
        public string ImageUrl { get { return imageUrl; } private set { if (value != null) imageUrl = value; NotifyPropertyChanged("ImageUrl"); } }
        public ICommand TileClickedCommand { get { return tileClickedCommand; } private set { if (value != null) tileClickedCommand = value; NotifyPropertyChanged("TileClickedCommand"); } }
        public object Obj { get { return obj; } set { obj = value; } }
        #endregion

        public PanoramaTileModel(IAccion ac, string text, object referencia, string imageUrl = null)
        {
            this.accion = ac;
            this.Text = text;
            this.Obj = referencia;
            var resources = GetResourceNames();
            if (resources.Contains(@"resources/" + text.ToLower().Replace(" ", "%20") + ".png"))
                this.ImageUrl = imageUrl ?? @"/CampeonatoAjedrezWPF;component/resources/" + text.ToLower().Replace(" ", "%20") + ".png";
            else
                this.ImageUrl = imageUrl ?? @"/CampeonatoAjedrezWPF;component/resources/N.png";
            this.TileClickedCommand = new SimpleCommand<object, object>(ExecuteTileClickedCommand);
        }
        public void ExecuteTileClickedCommand(object referencia)
        {
            accion.realiza(Obj);
        }

        public static List<string> GetResourceNames()
        {
            var assembly = Assembly.GetExecutingAssembly();
            string resName = assembly.GetName().Name + ".g.resources";
            using (var stream = assembly.GetManifestResourceStream(resName))
            {
                using (var reader = new System.Resources.ResourceReader(stream))
                {
                    return reader.Cast<DictionaryEntry>().Select(entry => (string)entry.Key).ToList();
                }
            }
        }
    }

}
