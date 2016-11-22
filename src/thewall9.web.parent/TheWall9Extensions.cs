using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thewall9.web.parent.Models;

namespace thewall9.web.parent
{
    public class TheWall9Extensions
    {
        public static HtmlString FindValue(ContentBindingList Model, string Value, bool AllowNull)
        {
            try
            {
                var _Item = Model.Items.Where(m => m.ContentPropertyAlias.Equals(Value)).SingleOrDefault();
                return new HtmlString(_Item.ContentCultures.ToList()[0].ContentPropertyValue);
            }
            catch (ArgumentNullException e)
            {
                if (AllowNull) return new HtmlString(string.Empty);
                throw new ArgumentNullException("Value=" + Value + " in " + Model.ContentPropertyAlias + " is NULL", e.InnerException);
            }
            catch (NullReferenceException e)
            {
                if (AllowNull) return new HtmlString(string.Empty);
                throw new NullReferenceException("Value=" + Value + " in " + Model.ContentPropertyAlias + " is NULL", e.InnerException);
            }
            catch (ArgumentOutOfRangeException e)
            {
                if (AllowNull) return new HtmlString(string.Empty);
                throw new ArgumentOutOfRangeException("Value=" + Value + " in " + Model.ContentPropertyAlias + " is NULL", e.InnerException);
            }
        }
    }
}
