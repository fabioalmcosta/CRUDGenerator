using System.Text.RegularExpressions;

public static class RoutesTemplateGenerator
{
    public static string WriteRoutesClass(string featureName, string moduleName, string _pathImport, string _pathActions)
    {

        var nomeClasseBradCamp = char.ToUpper(moduleName[0]) + moduleName.Substring(1);
        var nomeFeatureBradCamp = char.ToUpper(featureName[0]) + featureName.Substring(1);

        string[] splitNomeFeatureBradCamp = Regex.Split(nomeFeatureBradCamp, @"(?<!^)(?=[A-Z])");
        nomeFeatureBradCamp = "";
        foreach (var item in splitNomeFeatureBradCamp)
        {
            if (nomeFeatureBradCamp.Length == 0)
            {
                nomeFeatureBradCamp = item;
            }
            else
            {
                nomeFeatureBradCamp = nomeFeatureBradCamp + " " + item;
            }
        }

        string[] splitNomeClasseBradCamp = Regex.Split(nomeClasseBradCamp, @"(?<!^)(?=[A-Z])");
        nomeClasseBradCamp = "";
        foreach (var item in splitNomeClasseBradCamp)
        {
            if (nomeClasseBradCamp.Length == 0)
            {
                nomeClasseBradCamp = item;
            }
            else
            {
                nomeClasseBradCamp = nomeClasseBradCamp + " " + item;
            }
        }

        var stringFile = @"import RouteType from '@/common/types/routes.types';
import Grid from './container/" + moduleName + @".search';
import View from './container/" + moduleName + @".view';
import New from './container/" + moduleName + @".new';
import Edit from './container/" + moduleName + @".edit';

const routes: Array<RouteType> = [
    {
        name: '" + _pathImport + @"',
        path: '/" + _pathActions + @"',
        accessControl: true,
        component: Grid,
        breadCrumb: [{ text: '" + nomeFeatureBradCamp + "' }, { text: '" + nomeClasseBradCamp + @"' }],
    },
    {
        name: '" + _pathImport + @".new',
        path: '/" + _pathActions + @"/new',
        accessControl: true,
        component: New,
        breadCrumb: [
            { text: '" + nomeFeatureBradCamp + @"' },
            { text: '" + nomeClasseBradCamp + "', link: '" + featureName + "." + moduleName + @"' },
            { text: 'Inclusão' },
        ],
    },
    {
        name: '" + _pathImport + @".view',
        path: '/" + _pathActions + @"/view/:id',
        accessControl: true,
        component: View,
        breadCrumb: [
            { text: '" + nomeFeatureBradCamp + @"' },
            { text: '" + nomeClasseBradCamp + "', link: '" + featureName + "." + moduleName + @"' },
            { text: 'Visualização' },
        ],
    },
    {
        name: '" + _pathImport + @".edit',
        path: '/" + _pathActions + @"/edit/:id',
        accessControl: true,
        component: Edit,
        breadCrumb: [
            { text: '" + nomeFeatureBradCamp + @"' },
            { text: '" + nomeClasseBradCamp + "', link: '" + featureName + "." + moduleName + @"' },
            { text: 'Edição' },
        ],
    },
];

export default routes;";

        return stringFile;

    }
}
