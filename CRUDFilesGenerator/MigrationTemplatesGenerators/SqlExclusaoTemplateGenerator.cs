namespace CRUDFilesGenerator.MigrationTemplatesGenerators
{
    public static class SqlExclusaoTemplateGenerator
    {
        public static string WriteSqlModel(string projectName, string featureName, string moduleName, string extension, string id)
        {
            var stringFile = @"DECLARE @IdSistema INT,
@NomeDominio VARCHAR(150),
@NomeFuncionalidadeTela NVARCHAR(MAX),
@UrlFuncionalidadeTela NVARCHAR(MAX);

SET @IdSistema = " + id + @";
SET @NomeDominio = '" + $"{moduleName} - {featureName}" + @"'
-- Exclusão de " + featureName + @"
SET @NomeFuncionalidadeTela = 'Exclusão de " + featureName + @"'
SET @UrlFuncionalidadeTela = '/" + moduleName.ToLower() + "/" + featureName.ToLower() + "/delete/:id'" + @"
EXEC dbo.CriarPermissaoTela @IdSistema, @NomeDominio, @NomeFuncionalidadeTela, @UrlFuncionalidadeTela, 'DELETE', '/" + featureName.ToLower() + @"/{id}'";

            return stringFile;
        }
    }



}
