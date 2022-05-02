public static class GridTemplateGenerator
{
    public static string WriteGridClass(string featureName, string moduleName)
    {
        var nomeDaClasse = char.ToUpper(moduleName[0]) + moduleName.Substring(1);
        var moduleRouteName = char.ToLower(moduleName[0]) + moduleName.Substring(1);
        var featureRouteName = char.ToLower(featureName[0]) + featureName.Substring(1);
        var featureWebStoreName = char.ToUpper(featureName[0]) + featureName.Substring(1);

        var stringFile = @"import React, { FC, useRef } from 'react';
import DataGrid from '@common/components/grid/dataGrid.component';
import { connect } from '@common/components/base.component';
import Grid"+nomeDaClasse+ @" from '../"+moduleName+ @".grid.ddados';
import api from '../service/" + moduleName + @".service';
import " + moduleName + "Actions from '../store/" + moduleName + @".actions';
import DDados from '../" + moduleName + @".ddados';
import * as messages from '@/modules/common/app/helpers/common.messages';

const " + nomeDaClasse + @"Grid: FC = (props: any) => {
    const gridRef = useRef<unknown>(null);
    const rm = props.routerManager;
    const columns = Grid"+ nomeDaClasse + @".Columns;
    const order = Grid" + nomeDaClasse + @".Order;

    const actions = [
        {
            title: 'Visualizar',
            icon: 'far fa-eye',
            onClick: (dataItem: { Id: any; }) => rm.redirect(
                { name: '" + featureRouteName + "." + moduleRouteName + @".view', parameters: { id: dataItem.Id } },
            ),
            url: '/"+featureRouteName+"/"+ moduleRouteName + @"/view/:id',
        },
        {
            type: 'edit',
            onClick: (dataItem: any) => rm.redirect(
                { name: '" + featureRouteName + "." + moduleRouteName + @".edit', parameters: { id: dataItem.Id } }),
            url: '/" + featureRouteName + "/" + moduleRouteName + @"/edit/:id',
        },
        {
            type: 'delete',
            onClick: async (dataItem: { Id: any; })=> {
                const result = await _alert.confirm(messages.CONFIRMA_DELETE, 'Remover Registro Selecionado');
                if (result) props."+ moduleName + @"Actions.remove(dataItem.Id);
            },
            url: '/" + featureRouteName + "/" + moduleRouteName + @"/delete/:id',
        },
    ];

    const options = {
        recurso: DDados.Titulo,
        service: api.filter,
        filterVersion: 1,
        webStorage: '"+ featureWebStoreName +"."+ nomeDaClasse + @"',
        applySearchOnLoad: false,
    };

    const toolbar = {
        title: DDados.Titulo,
        new: {
            onClick: () => rm.redirect({ name: '" + featureRouteName + "." + moduleRouteName + @".new' }),
            route: '" + featureRouteName + "." + moduleRouteName + @".new',
        },
        massDelete: { service: api.massDelete,
          url: '/" + featureRouteName + "/" + moduleRouteName + @"/massdelete'
        },
    };

    const config = {
        columns,
        order,
        actions,
        options,
        toolbar,
    };

    return <DataGrid ref={gridRef} {...config} />;
 };

export default connect({
    actions: { " + moduleName + @"Actions },
})(" + nomeDaClasse + "Grid); ";

        return stringFile;

    }
}
