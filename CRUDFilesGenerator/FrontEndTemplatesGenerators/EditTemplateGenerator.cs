public static class EditTemplateGenerator
{
    public static string WriteEditClass(string moduleName)
    {
        var nomeDaClasse = char.ToUpper(moduleName[0]) + moduleName.Substring(1);

        var stringFile = @"import React, { FC, useEffect  } from 'react';
import { connect } from '@common/components/base.component';
import FloatingButton from '@/components/floatingButton/FloatingButton';
import " + moduleName + "Actions from '../store/" + moduleName + @".actions';
import " + moduleName + "Selectors from '../store/" + moduleName + @".selectors';
import " + nomeDaClasse + "Form from '../components/" + moduleName + @".form';

const " + nomeDaClasse + @"Edit: FC = (props: any) => {

    const { id } = props.routerManager.params;
    const isView = true

    useEffect(() => {
        props." + moduleName + @"Actions.getById(id, isView);
    }, []);

    const onSubmit = (values: any) => {
        props." + moduleName + @"Actions.update(id, values);
    }

    return (
        <>
            <FloatingButton />
            <" + nomeDaClasse + @"Form onSubmit={onSubmit} prefix='E' />
        </>
    );
};

export default connect({
    actions: { " + moduleName + @"Actions },
    selectors: { " + moduleName + @"Selectors },
})(" + nomeDaClasse + "Edit); ";

        return stringFile;

    }
}
