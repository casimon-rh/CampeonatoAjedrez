using Notify;
using Notify.NotifyGUI;
using PanoramaControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CampeonatoAjedrezWPF.Routine
{
    public class MainRoutine : INPCBase
    {
        private IDictionary<string, PanoramaGroup> SubMenus = new Dictionary<string, PanoramaGroup>();
        public IAccion LaAccion { get; set; }
        List<PanoramaTileModel> Data = new List<PanoramaTileModel>();
        List<PanoramaTileModel> DataSub = new List<PanoramaTileModel>();
        private IEnumerable<PanoramaGroup> panoramaItemsSub;
        private IEnumerable<PanoramaGroup> panoramaItems;

        #region Publics
        public IEnumerable<PanoramaGroup> PanoramaItems
        {
            get { return this.panoramaItems; }
            set
            {
                if (value != this.panoramaItems)
                {
                    this.panoramaItems = value;
                    NotifyPropertyChanged("PanoramaItems");
                }
            }
        }
        public IEnumerable<PanoramaGroup> PanoramaItemsSub
        {
            get { return this.panoramaItemsSub; }
            set
            {
                if (value != this.panoramaItemsSub)
                {
                    this.panoramaItemsSub = value;
                    NotifyPropertyChanged("PanoramaItemsSub");
                }
            }
        }
        #endregion

        Dictionary<string, PanoramaGroup> _SubMenus;


        public MainRoutine(){}

        public void llenaPanorama()
        {
            List<PanoramaGroup> _panoramaItems;
            Data.Add(new PanoramaTileModel(LaAccion, "Catalogos", "Catalogos"));

            _panoramaItems = new List<PanoramaGroup>();
            _panoramaItems.Add(new PanoramaGroup("Menu", CollectionViewSource.GetDefaultView(Data)));

            var lista = new List<PanoramaTileModel>(){
                { new PanoramaTileModel(LaAccion, "Campeonato Previo","Campeonato Previo") },
                { new PanoramaTileModel(LaAccion, "Hoteles", "Hoteles") },
                { new PanoramaTileModel(LaAccion, "Localidades", "Localidades") },
                { new PanoramaTileModel(LaAccion, "Participantes", "Participantes") },
                { new PanoramaTileModel(LaAccion, "Partidas", "Partidas") }
            };
            _SubMenus = new Dictionary<string, PanoramaGroup>();
            _SubMenus.Add("Catalogos", new PanoramaGroup("Catalogos", CollectionViewSource.GetDefaultView(lista)));

            PanoramaItems = _panoramaItems;
        }
        public bool llenaPanoramaSubMenu(string menu)
        {
            if (_SubMenus.ContainsKey(menu))
            {
                var panorama = new List<PanoramaGroup>();
                panorama.Add((_SubMenus[menu]));
                panoramaItemsSub = (panorama);
                return true;
            }
            else return false;

        }
    }
}
