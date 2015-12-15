using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace PanoramaControl
{
    /// <summary>
    /// Represents a groupig of tiles
    /// </summary>
    public class PanoramaGroup
    {
        public PanoramaGroup(string header, ICollectionView tiles)
        {
            this.Header = header;
            this.Tiles = tiles;
        }

        public PanoramaGroup()
        {
        }


        public string Header { get;  set; }
        public ICollectionView Tiles { get;  set; }
    }
}
