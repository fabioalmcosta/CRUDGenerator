public static class MapperTemplateGenerator
{
    public static string WriteModelClass(string projectName, string featureName, string moduleName, string nameSpace, string dtoNameSpace, string _entityLocationUsing)
    {
        var stringFile = @"using " + _entityLocationUsing + @";
using " + dtoNameSpace + @";

" + nameSpace + @"
{";

        stringFile = stringFile + "\r\n\tpublic class " + moduleName + "Mapper \r\n\t{\r\n\t\t";

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

