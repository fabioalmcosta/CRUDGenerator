public static class MapperTemplateGenerator
{
    public static string WriteModelClass(string projectName, string featureName, string moduleName)
    {
        var stringFile = @"using " + projectName + @"Domain.Entities." + featureName + @"." + moduleName + @"Ctx;" + @"
using " + projectName + @"Crosscutting.DTO." + featureName + @"." + moduleName + @"Ctx;" + @"

namespace " + projectName + @"Service.Mappers." + featureName + @"." + moduleName + @"Ctx" + @"
{";

        stringFile = stringFile + "\r\n\tpublic class " + moduleName + "Mapper \r\n\t{\r\n";

        stringFile = stringFile + @"public " + moduleName + " MapearEntidade(" + moduleName + @"PostDto dto)
        {
            return new " + moduleName + @"
            {
            };
        }

        public " + moduleName + " MapearEntidade(" + moduleName + " entidade, " + moduleName + @"PutDto dto)
        {

            return entidade;
        }

        public " + moduleName + "GetDto MapearEntidade(" + moduleName + @" entidade)
        {

            return new " + moduleName + @"GetDto 
            {

            };
        }";

        stringFile = stringFile + "\r\n\t} \r\n}";

        return stringFile;
    }
}

