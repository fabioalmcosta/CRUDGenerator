namespace CRUDFilesGenerator.MigrationTemplatesGenerators
{
    public static class SqlVisualizacaoTemplateGenerator
    {
        public static string WriteSqlModel(string projectName, string featureName, string moduleName, string extension, string id)
        {
            var stringFile = @"DECLARE @IdSistema INT,
@NomeDominio VARCHAR(150),
@NomeFuncionalidadeTela NVARCHAR(MAX),
@UrlFuncionalidadeTela NVARCHAR(MAX);

SET @IdSistema = " + id + @";
SET @NomeDominio = '" + $"{moduleName} - {featureName}" + @"'
-- Visualização de " + featureName + @"
SET @NomeFuncionalidadeTela = 'Visualização de " + featureName + @"'
SET @UrlFuncionalidadeTela = '/" + moduleName.ToLower() + "/" + featureName.ToLower() + "/view/:id'" + @"
EXEC dbo.CriarPermissaoTela @IdSistema, @NomeDominio, @NomeFuncionalidadeTela, @UrlFuncionalidadeTela, 'GET', '/" + featureName.ToLower() + @"/{id}'";

            return stringFile;
        }
    }



}
