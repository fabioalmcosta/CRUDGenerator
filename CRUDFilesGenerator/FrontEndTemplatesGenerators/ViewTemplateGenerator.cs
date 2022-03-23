public static class ViewTemplateGenerator
{
    public static string WriteViewClass(string moduleName)
    {
        var nomeDaClasse = char.ToUpper(moduleName[0]) + moduleName.Substring(1);

        var stringFile = @"import React, { FC, useEffect  } from 'react';
import { connect } from '@common/components/base.component';
import FloatingButton from '@/components/floatingButton/FloatingButton';
import " + moduleName + "Actions from '../store/" + moduleName + @".actions';
import " + moduleName + "Selectors from '../store/" + moduleName + @".selectors';
import " + nomeDaClasse + "Form from '../components/" + moduleName + @".form';

const " + nomeDaClasse + @"View: FC = (props: any) => {

    const { id } = props.routerManager.params;
    const isView = true

    useEffect(() => {
        props."+ moduleName + @"Actions.getById(id, isView);
    }, []);

    return (
        <>
            <FloatingButton />
            <" + nomeDaClasse + @"Form prefix='V' />
        </>
    );
};

export default connect({
    actions: { " + moduleName + @"Actions },
    selectors: { " + moduleName + @"Selectors },
})(" + nomeDaClasse + "View); ";

        return stringFile;

    }
}
