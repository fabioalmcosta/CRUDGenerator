public static class DtoTemplateGenerator
{
    public static string WriteModelClass(string projectName, string featureName, string moduleName, string extension)
    {
        var stringFile = @"namespace " + projectName + @"Crosscutting.DTO." + featureName + @"." + moduleName + @"Ctx" + @"
{
    public class " + moduleName + extension + @"
    {
    }
}";

        return stringFile;
    }
}


