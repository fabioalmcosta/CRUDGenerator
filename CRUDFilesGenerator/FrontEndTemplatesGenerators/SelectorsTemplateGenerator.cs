using System.Text.RegularExpressions;

public static class SelectorsTemplateGenerator
{
    public static string WriteSelectorsClass(string featureName, string moduleName)
    {
        var stringFile = @"export default {
    "+ moduleName + @": (state: any) => state."+ featureName + "."+ moduleName + @",
};";

        return stringFile;
    }
}
