public static class RepositoryTemplateGenerator
{
    public static string WriteModelClass(string projectName, string featureName, string moduleName, string nameSpace, string _entityLocationUsing, string nameSpaceInt)
    {
        var stringFile = @"using SMARAPD.Common.Infrastructure.Persistence.EntityFramework;
using SMARAPD.SS_API.Infrastructure.Persistence.Model;
using " + nameSpaceInt + @";
using " + _entityLocationUsing + @";

" + nameSpace + @"
{";

        stringFile = stringFile + "\r\n\tpublic class " + moduleName + "Repository  : GenericRepository<" + moduleName + ", SsModel>, I" + moduleName + "Repository \r\n\t{\r\n";

        stringFile = stringFile + "\t\tpublic " + moduleName + @"Repository(SsModel context) : base(context)
        {
        }";

        stringFile = stringFile + "\r\n\t} \r\n}";

        return stringFile;
    }

    public static string WriteInterfaceModelClass(string projectName, string featureName, string moduleName, string nameSpace, string _entityLocationUsing)
    {
        var stringFile = @"using SMARAPD.Common.Infrastructure.Persistence.EntityFramework;
using " + _entityLocationUsing + @";

namespace " + nameSpace + @"
{";

        stringFile = stringFile + "\r\n\tpublic interface I" + moduleName + "Repository  : IRepository<" + moduleName + "> \r\n\t{\r\n";

        stringFile = stringFile + "\r\n\t} \r\n}";

        return stringFile;
    }
}

