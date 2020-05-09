using System;
using System.Collections.Generic;
using System.Text;

namespace DM2BD.RacingGraph
{
    public class RacingGraphObject<ItemType>
    {
        public int NumberOfBarsDisplayed { get; set; }
     
        public ItemType Item { get; set; }
        
        public Func<ItemType, List<double>> ScoreListSelector { get; set; }
        
        public Func<ItemType, string> ImageURLSelector { get; set; }
        public int DateIndex { get; set; }
        public int MaxValue { get; set; }
        public Func<ItemType, byte[]> ImageByteArraySelector { get; set; }
        
        public Func<ItemType, string> NameSelector { get; set; }
        private int _index;
        
        public int Index
        {
            get => _index;
            set
            {
                if (value != _index)
                {
                    if (value < NumberOfBarsDisplayed || _index < NumberOfBarsDisplayed)
                        AnimateChange(value, _index);
                }
                _index = value;
            }
        }

        public string DisplayCSS
        {
            get => Index < NumberOfBarsDisplayed ? "" : "display: none;";
        }
        public bool Animating { get; set; }

        private int _top;
        public int Top 
        {
            get
            {
                if (!Animating) return Index * 87;
                return _top;
            }
            set
            {
                _top = value;
            }
        }
        protected void AnimateChange(int newIndex, int oldIndex)
        {
        }
    }
}
