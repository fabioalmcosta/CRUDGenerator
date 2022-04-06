using CRUDFilesGenerator.MigrationTemplatesGenerators;

public class FileGeneratorMigration
{
    private string _featureName;
    private string _moduleName;
    private string _projectName;
    private string _dir;
    private string _baseSqlPath;
    private string _baseSql;
    private string _baseClassPath;
    private string _baseClass;
    private DateTime _date;
    private string _id;
    private string _prefixoEmpresa;
    public FileGeneratorMigration(string projectName, string featureName, string moduleName, string dir, string id, string prefixo)
    {
        _featureName = featureName;
        _moduleName = moduleName;
        _projectName = projectName;
        _dir = dir;
        _date = DateTime.Now;
        _id = id;
        _prefixoEmpresa = prefixo;

        string dia = String.Format("{0:D2}", _date.Day);
        string mes = String.Format("{0:D2}", _date.Month);
        string hora = String.Format("{0:D2}", _date.Hour);
        string minuto = String.Format("{0:D2}", _date.Minute);

        string baseDir = _dir + @"\Sqls\" + prefixo.ToUpper() + @"\" + _date.Year + @"\" + _date.Month + @"\";
        _baseSqlPath = baseDir;
        _baseSql = baseDir + "Mig_" + $"{_date.Year}{dia}{mes}{hora}{minuto}{id}";

        string baseClassDir = _dir + @"\" + prefixo.ToUpper() + @"\" + _date.Year + @"\" + _date.Month + @"\";
        _baseClassPath = baseClassDir;
        _baseClass = baseClassDir + "Mig_" + $"{_date.Year}{dia}{mes}{hora}{minuto}{id}";
    }

    public async void GenerateMigration()
    {
        if (char.IsUpper(_featureName[0]) == true)
        {
            _featureName = char.ToUpper(_featureName[0]) + _featureName.Substring(1);
        }

        if (char.IsUpper(_moduleName[0]) == true)
        {
            _moduleName = char.ToUpper(_moduleName[0]) + _moduleName.Substring(1);
        }

        GenerateSql();
        GenerateMigrationClass();

        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine("Arquivos gerados com sucesso!");
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||||||||||||||");
        Console.WriteLine("******************************************************");
    }

    private async void GenerateSql()
    {

        if (!Directory.Exists(_baseSqlPath))
        {
            Directory.CreateDirectory(_baseSqlPath);
        }

        var fileDirInclusao = _baseSql + $"_SMAR{_prefixoEmpresa.ToLower()}_Inclusao" + _moduleName + "_UP.sql";
        var fileDirEdicao = _baseSql + $"_SMAR{_prefixoEmpresa.ToLower()}_Edicao" + _moduleName + "_UP.sql";
        var fileDirVisualizacao = _baseSql + $"_SMAR{_prefixoEmpresa.ToLower()}_Visualizacao" + _moduleName + "_UP.sql";
        var fileDirExclusao = _baseSql + $"_SMAR{_prefixoEmpresa.ToLower()}_Exclusao" + _moduleName + "_UP.sql";
        var fileDirListagem = _baseSql + $"_SMAR{_prefixoEmpresa.ToLower()}_Listagem" + _moduleName + "_UP.sql";

        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine();
        Console.WriteLine("Gerando arquivos sql!");


        await File.WriteAllTextAsync(fileDirInclusao, SqlInclusaoTemplateGenerator.WriteSqlModel(_projectName, _moduleName, _featureName, "", _id));
        await File.WriteAllTextAsync(fileDirEdicao, SqlEdicaoTemplateGenerator.WriteSqlModel(_projectName, _moduleName, _featureName, "", _id));
        await File.WriteAllTextAsync(fileDirVisualizacao, SqlVisualizacaoTemplateGenerator.WriteSqlModel(_projectName, _moduleName, _featureName, "", _id));
        await File.WriteAllTextAsync(fileDirExclusao, SqlExclusaoTemplateGenerator.WriteSqlModel(_projectName, _moduleName, _featureName, "", _id));
        await File.WriteAllTextAsync(fileDirListagem, SqlListagemTemplateGenerator.WriteSqlModel(_projectName, _moduleName, _featureName, "", _id));

        Console.WriteLine("Arquivos gerados com sucesso!");
        Console.WriteLine();
        Console.WriteLine("------------------------------------------------------");
    }

    private async void GenerateMigrationClass()
    {
        if (!Directory.Exists(_baseClassPath))
        {
            Directory.CreateDirectory(_baseClassPath);
        }

        var fileDirInclusao = _baseClass + $"_SMAR{_prefixoEmpresa.ToLower()}_Inclusao" + _moduleName + ".cs";
        var fileDirEdicao = _baseClass + $"_SMAR{_prefixoEmpresa.ToLower()}_Edicao" + _moduleName + ".cs";
        var fileDirVisualizacao = _baseClass + $"_SMAR{_prefixoEmpresa.ToLower()}_Visualizacao" + _moduleName + ".cs";
        var fileDirExclusao = _baseClass + $"_SMAR{_prefixoEmpresa.ToLower()}_Exclusao" + _moduleName + ".cs";
        var fileDirListagem = _baseClass + $"_SMAR{_prefixoEmpresa.ToLower()}_Listagem" + _moduleName + ".cs";

        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine();
        Console.WriteLine("Gerando arquivos de classe!");

        string dia = String.Format("{0:D2}", _date.Day);
        string mes = String.Format("{0:D2}", _date.Month);
        string hora = String.Format("{0:D2}", _date.Hour);
        string minuto = String.Format("{0:D2}", _date.Minute);


        string path = $"Sqls/{_prefixoEmpresa.ToUpper()}/{_date.Year}/{mes}";
        string migName = $"{_date.Year}{dia}{mes}{hora}{minuto}{_id}";


        await File.WriteAllTextAsync(fileDirInclusao, ClassInclusaoTemplateGenerator.WriteSqlModel(path, migName, $"SMAR{_prefixoEmpresa.ToLower()}_Inclusao{_moduleName}", _date.Year.ToString(), mes, _id.ToUpper()));
        await File.WriteAllTextAsync(fileDirEdicao, ClassInclusaoTemplateGenerator.WriteSqlModel(path, migName, $"SMAR{_prefixoEmpresa.ToLower()}_Edicao{_moduleName}", _date.Year.ToString(), mes, _id.ToUpper()));
        await File.WriteAllTextAsync(fileDirExclusao, ClassInclusaoTemplateGenerator.WriteSqlModel(path, migName, $"SMAR{_prefixoEmpresa.ToLower()}_Exclusao{_moduleName}", _date.Year.ToString(), mes, _id.ToUpper()));
        await File.WriteAllTextAsync(fileDirVisualizacao, ClassInclusaoTemplateGenerator.WriteSqlModel(path, migName, $"SMAR{_prefixoEmpresa.ToLower()}_Visualizacao{_moduleName}", _date.Year.ToString(), mes, _id.ToUpper()));
        await File.WriteAllTextAsync(fileDirListagem, ClassInclusaoTemplateGenerator.WriteSqlModel(path, migName, $"SMAR{_prefixoEmpresa.ToLower()}_Listagem{_moduleName}", _date.Year.ToString(), mes, _id.ToUpper()));


        Console.WriteLine("Arquivos gerados com sucesso!");
        Console.WriteLine();
        Console.WriteLine("------------------------------------------------------");
    }

}

