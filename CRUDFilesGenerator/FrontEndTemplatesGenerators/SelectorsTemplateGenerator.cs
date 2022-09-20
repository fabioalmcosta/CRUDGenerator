public static class SelectorsTemplateGenerator
{
    public static string WriteSelectorsClass(string featureName, string moduleName, string _pathImport)
    {
        var stringFile = @"export default {
    " + moduleName + @": (state: any) => state." + _pathImport + @",
};";

        return stringFile;
    }
}
