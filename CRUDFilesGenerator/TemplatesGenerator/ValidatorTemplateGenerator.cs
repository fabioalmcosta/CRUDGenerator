public static class ValidatorTemplateGenerator
{
    public static string WriteModelClass(string projectName, string featureName, string moduleName, string _entityLocationUsing, string nameSpace)
    {
        var stringFile = @"using FluentValidation;
using " + _entityLocationUsing + @";
using " + projectName + @"Service.Validations.Base;

" + nameSpace + @"
{";

        stringFile = stringFile + "\r\n\tpublic class " + moduleName + "Validator : BaseValidator<" + moduleName + "> \r\n\t{\r\n\t\t";

        stringFile = stringFile + @"public " + moduleName + @"Validator()
        {
        }";

        stringFile = stringFile + "\r\n\t} \r\n}";

        return stringFile;
    }
}


