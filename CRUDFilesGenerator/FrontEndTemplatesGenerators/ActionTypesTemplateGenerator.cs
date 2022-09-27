using System.Text.RegularExpressions;

public static class ActionTypesTemplateGenerator
{
    public static string WriteActionsTypesClass(string featureName, string moduleName)
    {

        string[] split = Regex.Split(moduleName, @"(?<!^)(?=[A-Z])");
        var typeModuleName = "";
        foreach (var item in split)
        {
            if (typeModuleName.Length == 0)
            {
                typeModuleName = item.ToUpper();
            }
            else
            {
                typeModuleName = typeModuleName + "_" + item.ToUpper();
            }
        }

        var stringFile = @"export const " + typeModuleName + "_GET = " + @"
               '" + featureName + "." + moduleName + "." + typeModuleName + @"_GET';
export const " + typeModuleName + "_SET = " + @"
               '" + featureName + "." + moduleName + "." + typeModuleName + @"_SET';
export const " + typeModuleName + "_POST = '" + @"
               '" + featureName + "." + moduleName + "." + typeModuleName + @"_POST';
export const " + typeModuleName + "_PUT = '" + @"
               '" + featureName + "." + moduleName + "." + typeModuleName + @"_PUT';
export const " + typeModuleName + "_DELETE = '" + @"
               '" + featureName + "." + moduleName + "." + typeModuleName + @"_DELETE';
export const " + typeModuleName + "_RESET = '" + @"
               '" + featureName + "." + moduleName + "." + typeModuleName + @"_RESET';";

        return stringFile;


    }
}