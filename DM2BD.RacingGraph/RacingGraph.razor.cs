﻿using Microsoft.AspNetCore.Components;
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
        public Func<ItemType, List<double>> ScoreListSelector { get; set; }
        [Parameter]
        public Func<ItemType, string> ImageURLSelector { get; set; }
        [Parameter]
        public Func<ItemType, byte[]> ImageByteArraySelector { get; set; }
        [Parameter]
        public Func<ItemType, string> NameSelector { get; set; }
        [Parameter]
        public List<DateTime> Dates { get; set; }
        // must specify unit with value Ex: 10px, 10vh, 10vw...
        [Parameter]
        public string Height { get; set; }
        public int DateIndex { get; set; } = 0;
        public List<RacingGraphObject<ItemType>> TopFour { get; set; } = new List<RacingGraphObject<ItemType>>();
        public double MaxValue { get; set; }
        public List<RacingGraphObject<ItemType>> RacingGraphObjects { get; set; } = new List<RacingGraphObject<ItemType>>();
        public List<RacingGraphObject<ItemType>> RacingGraphObjectsOrdered { get; set; } = new List<RacingGraphObject<ItemType>>();

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
            foreach(ItemType item in Items)
            {
                RacingGraphObjects.Add(new RacingGraphObject<ItemType> { Index = i, Item = item });
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
                StartAnimation = true;

                if (DateIndex != 0)
                {
                    RacingGraphObjectsOrdered = RacingGraphObjectsOrdered
                        .OrderByDescending(x => (ScoreListSelector(x.Item))
                        .ElementAt(DateIndex))
                        .Select((x, i) => new RacingGraphObject<ItemType> { PreviousIndex = x.Index, Index = i, Item = x.Item, StartAnimation = true })
                        .ToList();
                }
                else
                {
                    RacingGraphObjectsOrdered = RacingGraphObjects
                    .OrderByDescending(x => (ScoreListSelector(x.Item))
                    .ElementAt(DateIndex))
                    .Select((x, i) => new RacingGraphObject<ItemType> { PreviousIndex = x.Index, Index = i, Item = x.Item, StartAnimation = true })
                    .ToList();
                }

                List<RacingGraphObject<ItemType>> previousTopFour = TopFour;

                TopFour = RacingGraphObjectsOrdered.Take(4).ToList();

                MaxValue = TopFour.Max(x => (ScoreListSelector(x.Item)).ElementAt(DateIndex));

                await InvokeAsync(StateHasChanged);

                foreach(RacingGraphObject<ItemType> racingGraphObject in previousTopFour)
                {
                    Animate(racingGraphObject);
                }
                foreach(RacingGraphObject<ItemType> racingGraphObject in TopFour)
                {
                    Animate(racingGraphObject);
                }

                StartAnimation = false;
                await Task.Delay(2000);
                DateIndex++;
            }
        }

        public async void Animate(RacingGraphObject<ItemType> racingGraphObject) 
        {
            if(racingGraphObject.PreviousIndex < 3)
            {
                racingGraphObject.Top = 200;
                await InvokeAsync(StateHasChanged);
                await Task.Delay(80);
                racingGraphObject.Top = 190;
                await InvokeAsync(StateHasChanged);
                await Task.Delay(80);
                racingGraphObject.Top = 180;
                await InvokeAsync(StateHasChanged);
                await Task.Delay(80);
                racingGraphObject.Top = 170;
                await InvokeAsync(StateHasChanged);
                await Task.Delay(80);
                racingGraphObject.Top = 160;
                await InvokeAsync(StateHasChanged);
                await Task.Delay(80);
                racingGraphObject.Top = 150;
                await InvokeAsync(StateHasChanged);
                await Task.Delay(80);
                racingGraphObject.Top = 140;
                await InvokeAsync(StateHasChanged);
                await Task.Delay(80);
                racingGraphObject.Top = 130;
                await InvokeAsync(StateHasChanged);
                await Task.Delay(80);
                racingGraphObject.Top = 120;
                await InvokeAsync(StateHasChanged);
                await Task.Delay(80);
                racingGraphObject.Top = 110;
                await InvokeAsync(StateHasChanged);
                await Task.Delay(80);
                racingGraphObject.Top = 100;
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
            else if(racingGraphObject.PreviousIndex == 0)
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
                    racingGraphObject.Top = -37 * 3;
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
                // Animate 2nd object going where ever
            }
            else if (racingGraphObject.PreviousIndex == 2)
            {
                // Animate third object going where ever
            }
            else if (racingGraphObject.PreviousIndex == 3)
            {
                // Animate fourth object going where ever
            }
        }

        public async void GetTop()
        {
            await Task.Delay(50);
            Top = 100;
            await InvokeAsync(StateHasChanged);
            await Task.Delay(80);
            Top = 95;
            await InvokeAsync(StateHasChanged);
            await Task.Delay(80);
            Top = 90;
            await InvokeAsync(StateHasChanged);
            await Task.Delay(80);
            Top = 85;
            await InvokeAsync(StateHasChanged);
            await Task.Delay(80);
            Top = 80;
            await InvokeAsync(StateHasChanged);
            await Task.Delay(80);
            Top = 75;
            await InvokeAsync(StateHasChanged);
            await Task.Delay(80);
            Top = 70;
            await InvokeAsync(StateHasChanged);
            await Task.Delay(80);
            Top = 65;
            await InvokeAsync(StateHasChanged);
            await Task.Delay(80);
            Top = 60;
            await InvokeAsync(StateHasChanged);
            await Task.Delay(80);
            Top = 55;
            await InvokeAsync(StateHasChanged);
            await Task.Delay(80);
            Top = 50;
            await InvokeAsync(StateHasChanged);
            await Task.Delay(80);
            Top = 45;
            await InvokeAsync(StateHasChanged);
            await Task.Delay(80);
            Top = 40;
            await InvokeAsync(StateHasChanged);
            await Task.Delay(80);
            Top = 35;
            await InvokeAsync(StateHasChanged);
            await Task.Delay(80);
            Top = 30;
            await InvokeAsync(StateHasChanged);
            await Task.Delay(80);
            Top = 25;
            await InvokeAsync(StateHasChanged);
            await Task.Delay(80);
            Top = 20;
            await InvokeAsync(StateHasChanged);
            await Task.Delay(80);
            Top = 15;
            await InvokeAsync(StateHasChanged);
            await Task.Delay(80);
            Top = 10;
            await InvokeAsync(StateHasChanged);
            await Task.Delay(80);
            Top = 5;
            await InvokeAsync(StateHasChanged);
            await Task.Delay(80);
            Top = 0;
            await InvokeAsync(StateHasChanged);
        }
    }
}
