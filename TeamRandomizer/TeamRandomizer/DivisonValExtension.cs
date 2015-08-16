using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Markup;
using TeamRandomizer.Models;

namespace TeamRandomizer
{
    public class DivisonValExtension : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return SummonerDivisions.Values;
        }
    }
}
