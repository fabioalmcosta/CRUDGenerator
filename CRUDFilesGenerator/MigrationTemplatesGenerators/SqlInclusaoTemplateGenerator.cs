namespace CRUDFilesGenerator.MigrationTemplatesGenerators
{
    public static class SqlInclusaoTemplateGenerator
    {
        public static string WriteSqlModel(string projectName, string featureName, string moduleName, string extension, string id)
        {
            var stringFile = @"DECLARE @IdSistema INT,
@NomeDominio VARCHAR(150),
@NomeFuncionalidadeTela NVARCHAR(MAX),
@UrlFuncionalidadeTela NVARCHAR(MAX);

SET @IdSistema = " + id + @";
SET @NomeDominio = '" + $"{moduleName} - {featureName}" + @"'
-- Inclusão de " + featureName + @"
SET @NomeFuncionalidadeTela = 'Inclusão de " + featureName + @"'
SET @UrlFuncionalidadeTela = '/" + moduleName.ToLower() + "/" + featureName.ToLower() + "/new'" + @"
EXEC dbo.CriarPermissaoTela @IdSistema, @NomeDominio, @NomeFuncionalidadeTela, @UrlFuncionalidadeTela, 'POST', '/" + featureName.ToLower() + @"'
";

            return stringFile;
        }
    }



}
