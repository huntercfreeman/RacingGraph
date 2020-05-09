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
        public int NumberOfBarsDisplayed { get; set; } = 4;
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
                RacingGraphObjects.Add(new RacingGraphObject<ItemType> 
                { 
                    Index = i, 
                    Item = item, 
                    DateIndex = 0, 
                    ImageByteArraySelector = this.ImageByteArraySelector, 
                    NumberOfBarsDisplayed = this.NumberOfBarsDisplayed, 
                    ScoreListSelector = this.ScoreListSelector, 
                    ImageURLSelector = this.ImageURLSelector, 
                    MaxValue = 40, 
                    NameSelector = this.NameSelector 
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
                    RacingGraphObjects = RacingGraphObjects
                            .OrderByDescending(x => (ScoreListSelector(x.Item))
                            .ElementAt(DateIndex))
                            .Select((x, i) => { x.Index = i; return x; })
                            .ToList();
                }
                await InvokeAsync(StateHasChanged);
                await Task.Delay(1900);
                DateIndex++;
            }
        }

        /*
        public async void Animate(RacingGraphObject<ItemType> racingGraphObject) 
        {
            if (racingGraphObject.Index > 3)
            {
                if (racingGraphObject.PreviousIndex == 0)
                {
                    racingGraphObject.Top = 0;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 10;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 20;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 30;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 40;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 50;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 60;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 70;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 80;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 90;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 200;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 210;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 220;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 230;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 240;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 250;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 260;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 270;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 280;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 290;
                    await InvokeAsync(StateHasChanged);
                }
                else if (racingGraphObject.PreviousIndex == 1)
                {
                    racingGraphObject.Top = 87;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 97;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 107;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 117;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 127;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 137;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 147;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 157;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 167;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 177;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 200;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 210;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 220;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 230;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 240;
                    await InvokeAsync(StateHasChanged);


                    await Task.Delay(80);
                    racingGraphObject.Top = 250;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 260;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 270;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 280;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 290;
                    await InvokeAsync(StateHasChanged);
                }
                else if (racingGraphObject.PreviousIndex == 2)
                {
                    racingGraphObject.Top = 87 * 2;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 97 * 2;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 107 * 2;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 117 * 2;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 127 * 2;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 137 * 2;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 147 * 2;
                    await InvokeAsync(StateHasChanged);
                }
                else if (racingGraphObject.PreviousIndex == 3)
                {
                    racingGraphObject.Top = 87 * 3;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 97 * 3;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 107 * 3;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 117 * 3;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 127 * 3;
                    await InvokeAsync(StateHasChanged);
                }

                await Task.Delay(80);
                racingGraphObject.IsDisplayed = false;
                await InvokeAsync(StateHasChanged);
            }
            else if (racingGraphObject.PreviousIndex > 3)
            {
                racingGraphObject.Top = 300;
                await InvokeAsync(StateHasChanged);

                await Task.Delay(80);
                racingGraphObject.Top = 290;
                await InvokeAsync(StateHasChanged);

                await Task.Delay(80);
                racingGraphObject.Top = 280;
                await InvokeAsync(StateHasChanged);

                await Task.Delay(80);
                racingGraphObject.Top = 270;
                await InvokeAsync(StateHasChanged);

                await Task.Delay(80);
                racingGraphObject.Top = 260;
                await InvokeAsync(StateHasChanged);

                await Task.Delay(80);
                racingGraphObject.Top = 250;
                await InvokeAsync(StateHasChanged);

                await Task.Delay(80);
                racingGraphObject.Top = 240;
                await InvokeAsync(StateHasChanged);

                await Task.Delay(80);
                racingGraphObject.Top = 230;
                await InvokeAsync(StateHasChanged);

                await Task.Delay(80);
                racingGraphObject.Top = 220;
                await InvokeAsync(StateHasChanged);

                await Task.Delay(80);
                racingGraphObject.Top = 210;
                await InvokeAsync(StateHasChanged);

                await Task.Delay(80);
                racingGraphObject.Top = 200;
                await InvokeAsync(StateHasChanged);

                await Task.Delay(80);
                racingGraphObject.Top = 90;
                await InvokeAsync(StateHasChanged);

                await Task.Delay(80);
                racingGraphObject.Top = 80;
                await InvokeAsync(StateHasChanged);

                await Task.Delay(80);
                racingGraphObject.Top = 70;
                await InvokeAsync(StateHasChanged);

                await Task.Delay(80);
                racingGraphObject.Top = 60;
                await InvokeAsync(StateHasChanged);

                await Task.Delay(80);
                racingGraphObject.Top = 50;
                await InvokeAsync(StateHasChanged);

                await Task.Delay(80);
                racingGraphObject.Top = 40;
                await InvokeAsync(StateHasChanged);

                await Task.Delay(80);
                racingGraphObject.Top = 30;
                await InvokeAsync(StateHasChanged);

                await Task.Delay(80);
                racingGraphObject.Top = 20;
                await InvokeAsync(StateHasChanged);

                await Task.Delay(80);
                racingGraphObject.Top = 10;
                await InvokeAsync(StateHasChanged);

                await Task.Delay(80);
                racingGraphObject.Top = 0;
                await InvokeAsync(StateHasChanged);

            }
            else if (racingGraphObject.PreviousIndex == 0)
            {
                if (racingGraphObject.Index == 1)
                {
                    racingGraphObject.Top = -87;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = -77;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = -67;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = -57;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = -47;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = -37;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = -27;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = -17;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = -7;
                    await InvokeAsync(StateHasChanged);

                    racingGraphObject.Top = 0;
                    await InvokeAsync(StateHasChanged);
                }
                else if (racingGraphObject.Index == 2)
                {
                    racingGraphObject.Top = -87 * 2;
                    await Task.Delay(80);
                    await InvokeAsync(StateHasChanged);

                    racingGraphObject.Top = -77 * 2;
                    await Task.Delay(80);
                    await InvokeAsync(StateHasChanged);

                    racingGraphObject.Top = -67 * 2;
                    await Task.Delay(80);
                    await InvokeAsync(StateHasChanged);

                    racingGraphObject.Top = -57 * 2;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = -47 * 2;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = -37 * 2;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = -27 * 2;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = -17 * 2;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = -7 * 2;
                    await InvokeAsync(StateHasChanged);

                    racingGraphObject.Top = 0;
                    await InvokeAsync(StateHasChanged);

                }
                else if (racingGraphObject.Index == 3)
                {
                    racingGraphObject.Top = -87 * 3;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = -77 * 3;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = -67 * 3;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = -57 * 3;
                    await InvokeAsync(StateHasChanged);


                    await Task.Delay(80);
                    racingGraphObject.Top = -47 * 3;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = -37 * 3;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = -27 * 3;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = -17 * 3;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = -7 * 3;
                    await InvokeAsync(StateHasChanged);

                    racingGraphObject.Top = 0;
                    await InvokeAsync(StateHasChanged);
                }
            }
            else if (racingGraphObject.PreviousIndex == 1)
            {
                if (racingGraphObject.Index == 0)
                {
                    racingGraphObject.Top = 87;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 77;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 67;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 57;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 47;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 37;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 27;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 17;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 7;
                    await InvokeAsync(StateHasChanged);

                    racingGraphObject.Top = 0;
                    await InvokeAsync(StateHasChanged);

                }
                else if (racingGraphObject.Index == 2)
                {
                    racingGraphObject.Top = -87;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = -77;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = -67;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = -57;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = -47;
                    await InvokeAsync(StateHasChanged);
                    
                    await Task.Delay(80);
                    racingGraphObject.Top = -37;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = -27;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = -17;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = -7;
                    await InvokeAsync(StateHasChanged);

                    racingGraphObject.Top = 0;
                    await InvokeAsync(StateHasChanged);

                }
                else if (racingGraphObject.Index == 3)
                {
                    racingGraphObject.Top = -87 * 2;
                    await InvokeAsync(StateHasChanged);


                    await Task.Delay(80);
                    racingGraphObject.Top = -77 * 2;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = -67 * 2;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = -57 * 2;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = -47 * 2;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = -37 * 2;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = -27 * 2;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = -17 * 2;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = -7 * 2;
                    await InvokeAsync(StateHasChanged);

                    racingGraphObject.Top = 0;
                    await InvokeAsync(StateHasChanged);

                }
            }
            else if (racingGraphObject.PreviousIndex == 2)
            {
                if (racingGraphObject.Index == 0)
                {
                    racingGraphObject.Top = 87 * 2;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 77 * 2;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 67 * 2;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 57 * 2;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 47 * 2;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 37 * 2;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 27 * 2;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 17 * 2;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 7 * 2;
                    await InvokeAsync(StateHasChanged);

                    racingGraphObject.Top = 0;
                    await InvokeAsync(StateHasChanged);

                }
                else if (racingGraphObject.Index == 1)
                {
                    racingGraphObject.Top = 87;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 77;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 67;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 57;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 47;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 37;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 27;
                    await InvokeAsync(StateHasChanged);


                    await Task.Delay(80);
                    racingGraphObject.Top = 17;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 7;
                    await InvokeAsync(StateHasChanged);

                    racingGraphObject.Top = 0;
                    await InvokeAsync(StateHasChanged);
                }
                else if (racingGraphObject.Index == 3)
                {
                    racingGraphObject.Top = -87;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = -77;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = -67;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = -57;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = -47;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = -37;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = -27;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = -17;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = -7;
                    await InvokeAsync(StateHasChanged);

                    racingGraphObject.Top = 0;
                    await InvokeAsync(StateHasChanged);

                }
            }
            else if (racingGraphObject.PreviousIndex == 3)
            {
                if (racingGraphObject.Index == 0)
                {
                    racingGraphObject.Top = 87 * 3;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 77 * 3;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 67 * 3;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 57 * 3;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 47 * 3;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 37 * 3;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 27 * 3;
                    await InvokeAsync(StateHasChanged);


                    await Task.Delay(80);
                    racingGraphObject.Top = 17 * 3;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 7 * 3;
                    await InvokeAsync(StateHasChanged);

                    racingGraphObject.Top = 0;
                    await InvokeAsync(StateHasChanged);

                }
                else if (racingGraphObject.Index == 1)
                {
                    racingGraphObject.Top = 87 * 2;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 77 * 2;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 67 * 2;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 57 * 2;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 47 * 2;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 27 * 2;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 27 * 2;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 17 * 2;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 7 * 2;
                    await InvokeAsync(StateHasChanged);

                    racingGraphObject.Top = 0;
                    await InvokeAsync(StateHasChanged);

                }
                else if (racingGraphObject.Index == 2)
                {
                    racingGraphObject.Top = 87;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 77;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 67;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 57;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 47;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 27;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 27;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 17;
                    await InvokeAsync(StateHasChanged);

                    await Task.Delay(80);
                    racingGraphObject.Top = 7;
                    await InvokeAsync(StateHasChanged);

                    racingGraphObject.Top = 0;
                    await InvokeAsync(StateHasChanged);

                }
            }
        }
        */
    }
}
