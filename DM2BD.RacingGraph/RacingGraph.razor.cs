using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DM2BD.RacingGraph
{
    public partial class RacingGraph<ItemType> : ComponentBase
    {
        [Parameter]
        public List<ItemType> Items { get; set; }
        [Parameter]
        public int NumberOfBarsDisplayed { get; set; } = 9;
        [Parameter]
        public Func<ItemType, List<double>> ScoreListSelector { get; set; }
        [Parameter]
        public Func<ItemType, string> ImageURLSelector { get; set; }
        [Parameter]
        public Func<ItemType, byte[]> ImageByteArraySelector { get; set; }
        [Parameter]
        public Func<ItemType, string> NameSelector { get; set; }
        [Parameter]
        public Func<ItemType, ItemType, bool> Comparer { get; set; }
        [Parameter]
        public List<DateTime> Dates { get; set; }
        [Parameter]
        public int AnimationDelayBetweenDates { get; set; } = 2000;
        [Parameter]
        public int AnimationFrames { get; set; } = 10;
        // must specify unit with value Ex: 10px, 10vh, 10vw...
        [Parameter]
        public string Height { get; set; }
        public int DateIndex { get; set; } = 0;
        public double MaxValue { get; set; }
        public List<RacingGraphObject<ItemType>> RacingGraphObjects { get; set; } = new List<RacingGraphObject<ItemType>>();

        bool StartAnimation { get; set; }
        private double _top;
        public double Top 
        {
            get
            {
                return _top;
            }
            set => _top = value;
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            int i = 0;
            foreach(ItemType item in Items.OrderByDescending(x => (ScoreListSelector(x)).ElementAt(0)))
            {
                if (i == 0) MaxValue = ScoreListSelector(item).ElementAt(0);
                RacingGraphObjects.Add(new RacingGraphObject<ItemType>
                {
                    Index = i++,
                    Item = item,
                    DateIndex = 0,
                    ImageByteArraySelector = this.ImageByteArraySelector,
                    NumberOfBarsDisplayed = this.NumberOfBarsDisplayed,
                    ScoreListSelector = this.ScoreListSelector,
                    ImageURLSelector = this.ImageURLSelector,
                    MaxValue = (int)MaxValue,
                    NameSelector = this.NameSelector,
                    AnimationDelayBetweenDates = AnimationDelayBetweenDates,
                    AnimationFrames = AnimationFrames,
                    Width = (ScoreListSelector(item).ElementAt(DateIndex) / MaxValue * 60)
                });
            }
        }

        protected async override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if(firstRender)
                await GetTopFour();
        }

        private async Task GetTopFour()
        {
            while(DateIndex != Dates.Count)
            {
                if (DateIndex != 0)
                {
                    var racingGraphObjectsSorted = RacingGraphObjects
                            .OrderByDescending(x => (ScoreListSelector(x.Item)).ElementAt(DateIndex));

                    RacingGraphObjects = racingGraphObjectsSorted
                            .Select((x, i) => { x.DateIndex = DateIndex; x.Index = i; x.MaxValue = racingGraphObjectsSorted.ElementAt(0).MaxValue; AnimationDelayBetweenDates = AnimationDelayBetweenDates; return x; })
                            .ToList();
                }
                await InvokeAsync(StateHasChanged);
                await Task.Delay(AnimationDelayBetweenDates);
                DateIndex++;
            }
        }
    }
}
