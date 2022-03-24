public static class EntityTemplateGenerator
{
    public static string WriteModelClass(string projectName, string featureName, string moduleName)
    {
        var stringFile = @"using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace " + projectName + @"Domain.Entities." + featureName + @"." + moduleName + @"Ctx" + @"
{";

        //stringFile = stringFile + "\r\n\t[Table(\"" + FileData.TableName + "\")]";
        stringFile = stringFile + "\r\n\tpublic class " + moduleName + " \r\n\t{\r\n";

        stringFile = stringFile + " \t\t[Key] \r\n\t\t[Column(\"Id\")] \r\n\t\tpublic int Id { get; set; }";

        //foreach (var field in Fields)
        //{
        //    stringFile = stringFile + " \r\n\t\t[Column(\"" + field.DbName + "\")] \r\n\t\tpublic " + field.Type + " " + field.PropName + " { get; set; };";
        //}

        stringFile = stringFile + "\r\n\t} \r\n}";

        return stringFile;

        //if (!Directory.Exists(Dir + @"\backend\model\"))
        //{
        //    Directory.CreateDirectory(Dir + @"\backend\model\");
        //}

        //await File.WriteAllTextAsync(Dir + @"\backend\model\" + FileData.ModelName + ".cs", stringFile);
    }
}
