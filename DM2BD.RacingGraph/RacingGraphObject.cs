using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DM2BD.RacingGraph
{
    public class RacingGraphObject<ItemType>
    {
        public int NumberOfBarsDisplayed { get; set; }
     
        public ItemType Item { get; set; }
        
        public Func<ItemType, List<double>> ScoreListSelector { get; set; }
        public int AnimationDelayBetweenDates { get; set; }
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
            get => Index < NumberOfBarsDisplayed ? "display: flex;" : "display: none;";
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
        protected async void AnimateChange(int newIndex, int oldIndex)
        {
            Animating = true;

            int oldTop = oldIndex * 87;
            int newTop = newIndex * 87;
            
            Top = oldTop;

            int animationChange = (newTop - oldTop) / 10;

            int animationTime = AnimationDelayBetweenDates / 10;
            int delay = AnimationDelayBetweenDates;
            while ((delay -= animationTime) > 0)
            {

                Top += animationChange;
                await Task.Delay(animationTime);
            }

            Animating = false;
        }
    }
}
