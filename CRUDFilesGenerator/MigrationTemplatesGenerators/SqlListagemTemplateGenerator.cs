namespace CRUDFilesGenerator.MigrationTemplatesGenerators
{
    public static class SqlListagemTemplateGenerator
    {
        public static string WriteSqlModel(string projectName, string featureName, string moduleName, string extension, string id)
        {
            var stringFile = @"DECLARE @IdSistema INT,
@NomeDominio VARCHAR(150),
@NomeFuncionalidadeTela NVARCHAR(MAX),
@UrlFuncionalidadeTela NVARCHAR(MAX);

SET @IdSistema = " + id + @";
SET @NomeDominio = '" + $"{moduleName} - {featureName}" + @"'
-- Listagem de " + featureName + @"
SET @NomeFuncionalidadeTela = 'Busca de " + featureName + @"'
SET @UrlFuncionalidadeTela = '/" + moduleName.ToLower() + "/" + featureName.ToLower() + "'" + @"
EXEC dbo.CriarPermissaoTela @IdSistema, @NomeDominio, @NomeFuncionalidadeTela, @UrlFuncionalidadeTela, 'POST', '/" + featureName.ToLower() + @"/filter'";

            return stringFile;
        }
    }



}
