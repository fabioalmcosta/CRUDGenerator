public static class ApplicationServiceTemplateGenerator
{
    public static string WriteModelClass(string projectName, string featureName, string moduleName)
    {
        var stringFile = @"using System;
using Microsoft.Extensions.DependencyInjection;
using SMARAPD.Common.Domain.AuditoriaCtx;
using SMARAPD.Common.Infrastructure.Persistence.EntityFramework;
using SMARAPD.SS_API.Infrastructure.Persistence.Model;
using SMARAPD.SS_API.Infrastructure.Persistence.Repository." + featureName + @"." + moduleName + @"Ctx.Interfaces;" + @"
using SMARAPD.SS_API.Infrastructure.Persistence.UnitOfWork." + featureName + @"." + moduleName + @"Ctx.Interfaces;" + @"

namespace " + projectName + @"Infrastructure.Persistence.UnitOfWork." + featureName + @"." + moduleName + @"Ctx" + @"
{";

        stringFile = stringFile + "\r\n\tpublic class " + moduleName + "UnitOfWork  : GenericUnitOfWork, I" + moduleName + "UnitOfWork \r\n\t{\r\n";

        stringFile = stringFile + "\t\tpublic I" + moduleName + @"Repository " + moduleName + @"Repository =>
            _serviceProvider.GetService<I" + moduleName + @"Repository>();

        public " + moduleName + @"UnitOfWork(SsModel context,
            IServiceProvider serviceProvider,
            IAuditoriaEventServiceBus auditoriaEventServiceBus)
            : base(context, serviceProvider, auditoriaEventServiceBus)
        {
        }";

        stringFile = stringFile + "\r\n\t} \r\n}";

        return stringFile;
    }

    public static string WriteInterfaceModelClass(string projectName, string featureName, string moduleName)
    {
        var stringFile = @"using SMARAPD.Common.Infrastructure.Persistence;
using " + projectName + @"Infrastructure.Persistence.Repository." + featureName + @"." + moduleName + @"Ctx.Interfaces;" + @"

namespace " + projectName + @"Infrastructure.Persistence.UnitOfWork." + featureName + @"." + moduleName + @"Ctx.Interfaces" + @"
{";

        stringFile = stringFile + "\r\n\tpublic interface I" + moduleName + "UnitOfWork  : IGenericUnitOfWork \r\n\t{\r\n";

        stringFile = stringFile + "\t\tI" + moduleName + "Repository " + moduleName + "Repository { get; }";

        stringFile = stringFile + "\r\n\t} \r\n}";

        return stringFile;
    }
}

