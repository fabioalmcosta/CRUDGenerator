public static class FormTemplateGenerator
{
    public static string WriteFormClass( string featureName, string moduleName)
    {
        var nomeDaClasse = char.ToUpper(moduleName[0]) + moduleName.Substring(1);
        var moduleRouteName = char.ToLower(moduleName[0]) + moduleName.Substring(1);
        var featureRouteName = char.ToLower(featureName[0]) + featureName.Substring(1);
        var stringFile = @"import React, { FC } from 'react';
import DDadosItem from '@common/components/ddados/ddados.item';
import { connect } from '@common/components/base.component';
import Form from '@common/components/validation/form.validation';
import Panel from '@common/components/panel/panel.component';
import { Row, Col } from 'react-bootstrap';
import DDados from '../" + moduleName + @".ddados';
import " + moduleName + "Actions from '../store/" + moduleName + @".actions';
import " + moduleName + "Selectors from '../store/" + moduleName + @".selectors';

const " + nomeDaClasse + @"Form: FC = (props: any) => {
    const { "+moduleName+ " } = props."+moduleName+ @"Selectors;
    const { onSubmit, prefix, routerManager } = props;
    const { Titulo, Campos } = DDados;
    const isView = prefix === 'V';

    const handleCancel = () => {
        routerManager.redirect({ name: '" + featureRouteName+ "." +moduleRouteName+ "'"+ @"});
    };

    return (
        <>
           <Form
                boxForm
                onSubmit={() => onSubmit("+moduleName+ @")}
                onCancel={() => handleCancel()}
                prefix={prefix}
                title={Titulo}
                formControl
                routerManager={routerManager}
           >
                {(form: any) => (
                    <Row>
                       <Col lg={12}>
                        //Adicione os campos do formulário
                       </Col>
                    </Row>
                )}
           </Form>
        </>
    );
 };

export default connect({
    actions: { " + moduleName + @"Actions },
    selectors: { " + moduleName + @"Selectors },
})(" + nomeDaClasse+ "Form); ";

    return stringFile;

    }
}
