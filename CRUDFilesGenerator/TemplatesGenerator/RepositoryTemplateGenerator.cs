public static class RepositoryTemplateGenerator
{
    public static string WriteModelClass(string projectName, string featureName, string moduleName)
    {
        var stringFile = @"using SMARAPD.Common.Infrastructure.Persistence.EntityFramework;
using SMARAPD.SS_API.Infrastructure.Persistence.Model;
using SMARAPD.SS_API.Infrastructure.Persistence.Repository." + featureName + @"." + moduleName + @"Ctx.Interfaces;" + @"
using " + projectName + @"Domain.Entities." + featureName + @"." + moduleName + @"Ctx;" + @"

namespace " + projectName + @"Infrastructure.Persistence.Repository." + featureName + @"." + moduleName + @"Ctx" + @"
{";

        stringFile = stringFile + "\r\n\tpublic class " + moduleName + "Repository  : GenericRepository<" + moduleName + ", SsModel>, I" + moduleName + "Repository \r\n\t{\r\n";

        stringFile = stringFile + "\t\tpublic " + moduleName + @"Repository(SsModel context) : base(context)
        {
        }";

        stringFile = stringFile + "\r\n\t} \r\n}";

        return stringFile;
    }

    public static string WriteInterfaceModelClass(string projectName, string featureName, string moduleName)
    {
        var stringFile = @"using SMARAPD.Common.Infrastructure.Persistence.EntityFramework;
using " + projectName + @"Domain.Entities." + featureName + @"." + moduleName + @"Ctx;" + @"

namespace " + projectName + @"Infrastructure.Persistence.Repository." + featureName + @"." + moduleName + @"Ctx.Interfaces" + @"
{";

        stringFile = stringFile + "\r\n\tpublic interface I" + moduleName + "Repository  : IRepository<" + moduleName + "> \r\n\t{\r\n";

        stringFile = stringFile + "\r\n\t} \r\n}";

        return stringFile;
    }
}

