public static class ValidatorTemplateGenerator
{
    public static string WriteModelClass(string projectName, string featureName, string moduleName)
    {
        var stringFile = @"using FluentValidation;
using " + projectName + @"Domain.Entities." + featureName + @"." + moduleName + @"Ctx;" + @"
using " + projectName + @"Service.Validations.Base;

namespace " + projectName + @"Service.Validations.Modules." + featureName + @"." + moduleName + @"Ctx" + @"
{";

        stringFile = stringFile + "\r\n\tpublic class " + moduleName + "Validator : BaseValidator<" + moduleName + "> \r\n\t{\r\n\t\t";

        stringFile = stringFile + @"public " + moduleName + @"Validator()
        {
        }";

        stringFile = stringFile + "\r\n\t} \r\n}";

        return stringFile;
    }
}


