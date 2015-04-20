using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FlowUploadFilter
{
        public class FlowUploadAttribute : ActionFilterAttribute
        {
            public FlowUploadAttribute(params string[] extensions)
            {
                Extensions = extensions;
                Size = 5000000;
            }
            public int Size { get; set; }
            public string[] Extensions { get; set; }
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                var flowJs = new FlowJsRepo();
                var request = filterContext.HttpContext.Request;
                var validationRules = new FlowValidationRules();
                validationRules.AcceptedExtensions.AddRange(Extensions);
                validationRules.MaxFileSize = Size;
                var status = flowJs.PostChunk(request, Path.GetTempPath(),validationRules);

                if (status.Status == PostChunkStatus.Done)
                {
                    var filepath = Path.Combine(Path.GetTempPath(), status.FileName);
                    var p = filterContext.ActionDescriptor.GetParameters()
                        .FirstOrDefault(x => x.ParameterType == typeof (FlowFile));

                    if (filepath != null)
                    {
                        filterContext.ActionParameters[p.ParameterName] = new FlowFile
                        {
                            flowFilename = status.FileName,
                            path = filepath
                        };
                        return;
                    }
                }

                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Accepted);

                base.OnActionExecuting(filterContext);
            }
        }
}
