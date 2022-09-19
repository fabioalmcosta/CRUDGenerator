using System.Text.RegularExpressions;

public static class ActionTypesTemplateGenerator
{
    public static string WriteActionsTypesClass(string featureName, string moduleName, string _actionsTypes, string _pathImport)
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

        var stringFile = @"export const " + _actionsTypes + "_GET = '" + _pathImport + "." + _actionsTypes + @"_GET';
export const " + _actionsTypes + "_SET = '" + _pathImport + "." + _actionsTypes + @"_SET';
export const " + _actionsTypes + "_POST = '" + _pathImport + "." + _actionsTypes + @"_POST';
export const " + _actionsTypes + "_PUT = '" + _pathImport + "." + _actionsTypes + @"_PUT';
export const " + _actionsTypes + "_DELETE = '" + _pathImport + "." + _actionsTypes + @"_DELETE';
export const " + _actionsTypes + "_RESET = '" + _pathImport + "." + _actionsTypes + @"_RESET';";

        return stringFile;

    }
}

