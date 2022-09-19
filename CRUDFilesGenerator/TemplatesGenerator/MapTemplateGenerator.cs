public static class MapTemplateGenerator
{
    public static string WriteModelClass(string projectName, string featureName, string moduleName, string nameSpace, string usingLocation)
    {
        var stringFile = @"using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using " + usingLocation + @";

" + nameSpace + @"
{";

        //stringFile = stringFile + "\r\n\t[Table(\"" + FileData.TableName + "\")]";
        stringFile = stringFile + "\r\n\tpublic class " + moduleName + "Map  : IEntityTypeConfiguration<" + moduleName + "> \r\n\t{\r\n";

        stringFile = stringFile + "\t\tpublic void Configure(EntityTypeBuilder<" + moduleName + @"> builder)
        {

        }";

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

