namespace CRUDFilesGenerator.MigrationTemplatesGenerators
{
    public class ClassInclusaoTemplateGenerator
    {

        public static string WriteSqlModel(string path, string migName, string title, string year, string month, string id)
        {
            var stringFile = @"using FluentMigrator;
using System;

namespace SmaraPD.Migration.accesscontrol.Migrations." + id + @"._" + year + @"._" + month + @"
{
    [Migration(" + migName + ")] " + @"
    public class Mig_" + migName + @"_" + title + @" : FluentMigrator.Migration
    {
        public override void Up()
        {
            Execute.Script(""" + path + "\" + GetType().Name + \"_UP.sql\");" + @"
        }

        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}";

            return stringFile;
        }

    }
}

