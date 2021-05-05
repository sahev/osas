using System.Web;

namespace Sessions
{
    public static class StateClasses
    {
        public static int IsPage
        {
            get
            {
                object o = HttpContext.Current.Session["IsPage"];
                if (o == null)
                    return 0;
                else
                    return (int)o;
            }
            set
            {
                HttpContext.Current.Session["IsPage"] = value;
            }
        }
    }
}