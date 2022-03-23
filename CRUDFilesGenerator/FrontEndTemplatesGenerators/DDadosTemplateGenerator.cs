using System.Text.RegularExpressions;

public static class DDadosTemplateGenerator
{
    public static string WriteDDadosClass(string moduleName)
    {

        var nomeDaClasse = char.ToUpper(moduleName[0]) + moduleName.Substring(1);

        string[] split = Regex.Split(nomeDaClasse, @"(?<!^)(?=[A-Z])");
        var LabelsModuleName = "";
        foreach (var item in split)
        {
            if (LabelsModuleName.Length == 0)
            {
                LabelsModuleName = item;
            }
            else
            {
                LabelsModuleName = LabelsModuleName + " " + item;
            }
        }

        var stringFile = @"import { DDadosType } from '@/common/types/ddados.types';

const DDados: DDadosType = {
    Titulo: '"+ LabelsModuleName + @"',
    Campos: {
        Id: {
            Tipo: 'number',
            Label: '" + LabelsModuleName + @"',
            Tooltip: '" + LabelsModuleName + @"',
            Placeholder: '" + LabelsModuleName + @"',
            Tamanho: 4,
            Desabilitado: true,
        }
    },
};

export default DDados;";

        return stringFile;

    }
}
