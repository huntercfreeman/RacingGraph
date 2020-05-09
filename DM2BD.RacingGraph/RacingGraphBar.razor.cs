using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace DM2BD.RacingGraph
{
    public partial class RacingGraphBar<ItemType> : ComponentBase 
    {
        [Parameter]
        public RacingGraphObject<ItemType> RacingGraphObject { get; set; }
    }
}
