# FlowUploadFilter
.Net MVC 5 Flow JS Filter

This is a MVC 5 pre-action filter that will handle uploads from the [Flow.js](https://github.com/flowjs) library.  

## Install
` PM> Install-Package FlowUploadFilter `

## Usage
```csharp
using System.Net;
using System.Web.Mvc;
using FlowUploadFilter;
using WebGrease.Css.Extensions;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        [FlowUpload("pdf","txt")]
        [ActionName("Upload")]
        public ActionResult Upload(FlowFile file)
        {
            return Json(new {derp=file.flowFilename});
        }
    }
}
```

The filter works by recognizing that `FlowFile` type is a paramater of the Action. When a 'chunk' from flow.js 
come in it will check to see if that chunk completes the file, if it does not it will accept the chunk, save it then respond 
with an accepted http status and skip execution of the actual Action. When the final chunk is recieved it will hydrate the FlowFile parameter 
of the Action and let excution of the Action proceed. Paramater name is not important, only the Parameter type. The filter uses Temp storage.
