using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinBasic.Source.Tuan3
{
    public class WeekThreeFlyoutPageFlyoutMenuItem
    {
        public WeekThreeFlyoutPageFlyoutMenuItem()
        {
            TargetType = typeof(WeekThreeFlyoutPageFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }

        public string Icon { get; set; }
    }
}