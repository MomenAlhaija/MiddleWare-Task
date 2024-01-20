using System.Text.RegularExpressions;

namespace coee2.CustomeContarinet
{
    public class MonthsCustomContarinet : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext,
            IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
          if(!values.ContainsKey(routeKey))
            {
                return false;
            }
            Regex regex = new Regex("^(apr|jul|oct|jan)$");
            string? monthValue = Convert.ToString(values[routeKey]);
            if (regex.IsMatch(monthValue)) return true;
            else return false;   
        }
    }
}
