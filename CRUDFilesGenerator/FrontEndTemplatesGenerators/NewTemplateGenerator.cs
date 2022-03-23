public static class NewTemplateGenerator
{
    public static string WriteNewClass(string moduleName)
    {
        var nomeDaClasse = char.ToUpper(moduleName[0]) + moduleName.Substring(1);

        var stringFile = @"import React, { FC } from 'react';
import { connect } from '@common/components/base.component';
import FloatingButton from '@/components/floatingButton/FloatingButton';
import " + moduleName + "Actions from '../store/" + moduleName + @".actions';
import " + moduleName + "Selectors from '../store/" + moduleName + @".selectors';
import " + nomeDaClasse + "Form from '../components/" + moduleName + @".form';

const " + nomeDaClasse + @"New: FC = (props: any) => {

    const onSubmit = (values: any) => {
        props." + moduleName + @"Actions.save(values);
    }

    return (
        <>
            <FloatingButton />
            <" + nomeDaClasse + @"Form onSubmit={onSubmit} prefix='I' />
        </>
    );
};

export default connect({
    actions: { " + moduleName + @"Actions },
    selectors: { " + moduleName + @"Selectors },
})(" + nomeDaClasse + "New); ";

        return stringFile;

    }
}
