using System;
using System.Collections.Generic;
using System.Text;

namespace DM2BD.RacingGraph
{
    public class RacingGraphObject<ItemType>
    {
        public int Index { get; set; }
        public int PreviousIndex { get; set; }
        public ItemType Item { get; set; }
        public bool StartAnimation { get; set; }
        public double Top { get; set; }
        public bool IsDisplayed { get; set; } = true;
        public string DisplayCSS 
        { 
            get
            {
                return IsDisplayed ? "" : "display: none;";
            }
        }
    }
}
