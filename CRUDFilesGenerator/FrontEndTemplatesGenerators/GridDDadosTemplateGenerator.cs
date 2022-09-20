public static class GridDDadosTemplateGenerator
{
    public static string WriteGridDDadosClass(string moduleName)
    {

        var nomeDaClasse = char.ToUpper(moduleName[0]) + moduleName.Substring(1);

        var stringFile = @"import { GridDDados } from '@/common/types/ddados.types';
import DDados from './" + moduleName + @".ddados';
import * as typeArray from '@/modules/common/app/helpers/grid.typeArray';

const Grid" + nomeDaClasse + @"DDados: GridDDados = {
    Order: [
        {
            fieldName: DDados.Campos.Id.Label,
            dataName: 'Id',
            order: 'A',
        },
    ],
    Columns: [
        {
            fieldName: DDados.Campos.Id.Label,
            dataName: 'Id',
            show: true,
            type: 'number',
            width: 115,
        },
    ],
};

export default Grid" + nomeDaClasse + @"DDados;";

        return stringFile;

    }
}
