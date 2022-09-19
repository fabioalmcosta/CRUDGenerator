public static class DtoTemplateGenerator
{
    public static string WriteModelClass(string projectName, string featureName, string moduleName, string extension, string nameSpace)
    {
        var stringFile = nameSpace + @"
{
    public class " + moduleName + extension + @"
    {
    }
}";

        return stringFile;
    }
}


