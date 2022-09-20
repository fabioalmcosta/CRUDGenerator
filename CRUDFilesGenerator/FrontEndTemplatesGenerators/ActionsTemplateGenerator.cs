using System.Text.RegularExpressions;

public static class ActionsTemplateGenerator
{
    public static string WriteActionsClass(string moduleName, string _actionsName, string _actionsTypes)
    {
        var nomeDaClasse = char.ToUpper(moduleName[0]) + moduleName.Substring(1);

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

        var stringFile = @"import * as types from './" + moduleName + @".actionTypes';

export default {
  getById: (id: number) => ({
    type: types." + _actionsTypes + @"_GET,
    payload: { id }
  }),
  set" + nomeDaClasse + @": (data: unknown | null) => ({
    type: types." + _actionsTypes + @"_SET,
    payload: { data },
  }),
  save: (data: unknown | null) => ({
    type: types." + _actionsTypes + @"_POST,
    payload: { data },
  }),
  update: (id: number, data: unknown | null) => ({
    type: types." + _actionsTypes + @"_PUT,
    payload: { id, data },
  }),
  remove: (id: number) => ({
    type: types." + _actionsTypes + @"_DELETE,
    payload: { id },
  }),
};";

        return stringFile;

    }
}
