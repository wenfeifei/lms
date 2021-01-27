using System;
using System.Linq;
using System.Text.RegularExpressions;
using Lms.Core.Exceptions;

namespace Lms.Rpc.Routing.Template
{
    public static class TemplateSegmentHelper
    {
        private const string segmentValReg = @"\{(.*?)\}";
        

        private static bool IsVariable(string segmentLine)
        {
            return Regex.IsMatch(segmentLine, segmentValReg);
        }

        public static SegmentType GetSegmentType(string segemnetLine)
        {
            if (!IsVariable(segemnetLine))
            {
                return SegmentType.Literal;
            }

            var segemnetLineVal = Regex.Match(segemnetLine, segmentValReg);
            if (segemnetLineVal == null)
            {
                throw new LmsException("");
            }

            if (segemnetLineVal.Value.StartsWith("appservice",StringComparison.OrdinalIgnoreCase))
            {
                return SegmentType.AppService;
            }

            return SegmentType.Path;
        }
    }
}