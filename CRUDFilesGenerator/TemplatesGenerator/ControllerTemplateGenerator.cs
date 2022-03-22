public static class ControllerTemplateGenerator
{
    public static string WriteModelClass(string projectName, string featureName, string moduleName)
    {
        var stringFile = @"using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SMARAPD.Common.DTO;
using SMARAPD.Common.Infrastructure.Persistence.FilterExtension;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using " + projectName + @"Service.Modules." + featureName + @"." + moduleName + @"Ctx.Interfaces;" + @"
using " + projectName + @"Crosscutting.DTO." + featureName + @"." + moduleName + @"Ctx;" + @"


namespace " + projectName + @"Interface.Controllers." + featureName + @"." + moduleName + @"Ctx" + @"
{";

        stringFile = stringFile + "\r\n\t" + @"/// <summary>
    /// Controller de " + moduleName + @".
    /// </summary>
    [ApiController]";

        stringFile = stringFile + "\r\n\t[Route(\"[controller]\")]";
    
        stringFile = stringFile + "\r\n\tpublic class " + moduleName + "Controller  : ControllerBase \r\n\t{\r\n";

        stringFile = stringFile + "\t\tprivate readonly I" + moduleName + "ApplicationService _appService;\r\n\t\t";

        stringFile = stringFile + @" /// <summary>
        /// Construtor da classe.
        /// </summary>
        public " + moduleName + "Controller(I" + moduleName + "ApplicationService appService) => _appService = appService;";

        stringFile = stringFile + "\r\n\t} \r\n}";

        return stringFile;
    }
}

