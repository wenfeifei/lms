using Lms.Rpc.Routing.Template;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;

namespace Lms.Rpc.Routing
{
    public class Router : IRouter
    {
        private const string separator = "/";

        public Router(string template, HttpMethod httpMethod)
        {
            RouteTemplate = new RouteTemplate();
            ParseRouteTemplate(template);
            HttpMethod = httpMethod;
        }

        public RouteTemplate RouteTemplate { get; }

        public HttpMethod HttpMethod { get; }

        public string RoutePath { get; }

        public bool IsMatch(string api, HttpMethod httpMethod)
        {
            throw new System.NotImplementedException();
        }

        private void ParseRouteTemplate(string template)
        {
            var segemnetLines = template.Split(separator);

            foreach (var segemnetLine in segemnetLines)
            {
                var segmentType = TemplateSegmentHelper.GetSegmentType(segemnetLine);
                if (segmentType == SegmentType.Literal)
                {
                    RouteTemplate.Segments.Add(new TemplateSegment(SegmentType.Literal,segemnetLine));
                }
                else
                {
                    
                }
            }
        }

      
    }
}