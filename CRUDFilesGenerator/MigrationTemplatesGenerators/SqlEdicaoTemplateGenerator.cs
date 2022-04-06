namespace CRUDFilesGenerator.MigrationTemplatesGenerators
{
    public static class SqlEdicaoTemplateGenerator
    {
        public static string WriteSqlModel(string projectName, string featureName, string moduleName, string extension, string id)
        {
            var stringFile = @"DECLARE @IdSistema INT,
@NomeDominio VARCHAR(150),
@NomeFuncionalidadeTela NVARCHAR(MAX),
@UrlFuncionalidadeTela NVARCHAR(MAX);

SET @IdSistema = " + id + @";
SET @NomeDominio = '" + $"{moduleName} - {featureName}" + @"'
-- Edição de " + featureName + @"
SET @NomeFuncionalidadeTela = 'Edição de " + featureName + @"'
SET @UrlFuncionalidadeTela = '/" + moduleName.ToLower() + "/" + featureName.ToLower() + "/edit/:id'" + @"
EXEC dbo.CriarPermissaoTela @IdSistema, @NomeDominio, @NomeFuncionalidadeTela, @UrlFuncionalidadeTela, 'PUT', '/" + featureName.ToLower() + @"'
";

            return stringFile;
        }
    }



}
