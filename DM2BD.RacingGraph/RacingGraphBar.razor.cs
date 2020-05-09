using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DM2BD.RacingGraph
{
    public partial class RacingGraphBar<ItemType> : ComponentBase 
    {
        [Parameter]
        public RacingGraphObject<ItemType> RacingGraphObject { get; set; }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            int animationTime = RacingGraphObject.AnimationDelayBetweenDates / RacingGraphObject.AnimationFrames;

            while (RacingGraphObject.AnimationDelayBetweenDates > 0)
            {
                await InvokeAsync(StateHasChanged);
                await Task.Delay(animationTime);
            }

            return;
        }
    }
}
