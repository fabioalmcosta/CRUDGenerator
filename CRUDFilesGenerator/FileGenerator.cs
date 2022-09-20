public class FileGenerator
{
    private string _featureName;
    private string _internContextPath;
    private string _projectName;
    private string _dir;
    private string _baseNameSpace;
    private string _internNameSpacePath;
    private string _moduleName;
    private string _entityLocationUsing;
    private string _repositoryIntUsing;
    private string _repositoryUsing;
    private string _unitOfWorkInter;
    public FileGenerator(string projectName, string featureName, string internContext, string dir, string baseNameSpace, string internNameSpacePath, string moduleName)
    {
        _projectName = projectName;
        _featureName = featureName;
        _internContextPath = internContext;
        _dir = dir;
        _baseNameSpace = baseNameSpace;
        _internNameSpacePath = internNameSpacePath;
        _moduleName = moduleName;
    }

    public void Generate()
    {
        if (char.IsUpper(_featureName[0]) == false)
        {
            _featureName = char.ToUpper(_featureName[0]) + _featureName.Substring(1);
        }

        if (char.IsUpper(_internContextPath[0]) == false)
        {
            _internContextPath = char.ToUpper(_internContextPath[0]) + _internContextPath.Substring(1);
        }

        GenerateEntity();
        GenerateMap();
        GenerateRepository();
        GenerateUnitOfWork();
        GenerateController();
        GenerateService();
        GenerateMappers();
        GenerateValidations();
        GenerateDtos();
        //GenerateTestsMocks();
        //GenerateTestsModules();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
        Console.WriteLine("■■■■■■■■■ Arquivos do backend gerados com sucesso! ■■■■■■■■■■■■■");
        Console.WriteLine("■■■■■■■■■           Aperte para continuar!         ■■■■■■■■■■■■■");
        Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadLine();
        Console.Clear();
    }
    private async void GenerateEntity()
    {

        string dir = _dir + _projectName + @"Domain\Entities\" + _featureName + @"/" + _internContextPath + "/";
        _entityLocationUsing = _baseNameSpace + @"Domain.Entities." + _featureName + (!string.IsNullOrEmpty(_internNameSpacePath) ? @"." + _internNameSpacePath : "");

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }


        var fileDir = dir + _moduleName + ".cs";
        await File.WriteAllTextAsync(fileDir, EntityTemplateGenerator.WriteModelClass(_baseNameSpace, _featureName, _moduleName, _entityLocationUsing));
    }
    private async void GenerateMap()
    {

        string dir = _dir + _projectName + @"Infrastructure\Persistence\Map\" + _featureName + @"/" + _internContextPath + "/";
        string nameSpace = "namespace " + _baseNameSpace + @"Infrastructure.Persistence.Map." + _featureName + (!string.IsNullOrEmpty(_internNameSpacePath) ? @"." + _internNameSpacePath : "");


        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        var fileDir = dir + _moduleName + "Map.cs";
        await File.WriteAllTextAsync(fileDir, MapTemplateGenerator.WriteModelClass(_baseNameSpace, _featureName, _moduleName, nameSpace, _entityLocationUsing));
    }
    private async void GenerateRepository()
    {
        string dir = _dir + _projectName + @"Infrastructure\Persistence\Repository\" + _featureName + @"/" + _internContextPath + "/";
        string interfaceDir = dir + @"\Interfaces\";
        _repositoryUsing = "namespace " + _baseNameSpace + @"Infrastructure.Persistence.Repository." + _featureName + (!string.IsNullOrEmpty(_internNameSpacePath) ? @"." + _internNameSpacePath : "");
        _repositoryIntUsing = _baseNameSpace + @"Infrastructure.Persistence.Repository." + _featureName + (!string.IsNullOrEmpty(_internNameSpacePath) ? @"." + _internNameSpacePath : "") + @".Interfaces" + @"";


        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        if (!Directory.Exists(interfaceDir))
        {
            Directory.CreateDirectory(interfaceDir);
        }


        var fileDir = dir + _moduleName + "Repository.cs";
        var iFileDir = interfaceDir + "I" + _moduleName + "Repository.cs";

        await File.WriteAllTextAsync(fileDir, RepositoryTemplateGenerator.WriteModelClass(_baseNameSpace, _featureName, _moduleName, _repositoryUsing, _entityLocationUsing, _repositoryIntUsing));
        await File.WriteAllTextAsync(iFileDir, RepositoryTemplateGenerator.WriteInterfaceModelClass(_baseNameSpace, _featureName, _moduleName, _repositoryIntUsing, _entityLocationUsing));
    }
    private async void GenerateUnitOfWork()
    {
        string dir = _dir + _projectName + @"Infrastructure\Persistence\UnitOfWork\" + _featureName + @"/" + _internContextPath + "/";
        string interfaceDir = dir + @"\Interfaces\";
        string nameSpace = "namespace " + _baseNameSpace + @"Infrastructure.Persistence.UnitOfWork." + _featureName + (!string.IsNullOrEmpty(_internNameSpacePath) ? @"." + _internNameSpacePath : "");
        _unitOfWorkInter = _baseNameSpace + @"Infrastructure.Persistence.UnitOfWork." + _featureName + (!string.IsNullOrEmpty(_internNameSpacePath) ? @"." + _internNameSpacePath : "") + @".Interfaces" + @"";

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        if (!Directory.Exists(interfaceDir))
        {
            Directory.CreateDirectory(interfaceDir);
        }

        var fileDir = dir + _moduleName + "UnitOfWork.cs";
        var iFileDir = interfaceDir + "I" + _moduleName + "UnitOfWork.cs";

        await File.WriteAllTextAsync(fileDir, UnitOfWorkTemplateGenerator.WriteModelClass(_baseNameSpace, _featureName, _moduleName, _entityLocationUsing, nameSpace, _unitOfWorkInter, _repositoryIntUsing));
        await File.WriteAllTextAsync(iFileDir, UnitOfWorkTemplateGenerator.WriteInterfaceModelClass(_baseNameSpace, _featureName, _moduleName, _entityLocationUsing, _unitOfWorkInter, _repositoryIntUsing));

    }
    private async void GenerateController()
    {
        string dir = _dir + _projectName + @"Interface\Controllers\" + _featureName + @"/" + _internContextPath + "/";
        string nameSpace = "namespace " + _baseNameSpace + @"Interface.Controllers." + _featureName + (!string.IsNullOrEmpty(_internNameSpacePath) ? @"." + _internNameSpacePath : "");

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        var fileDir = dir + _moduleName + "Controller.cs";

        await File.WriteAllTextAsync(fileDir, ControllerTemplateGenerator.WriteModelClass(_baseNameSpace, _featureName, _moduleName, !string.IsNullOrEmpty(_internNameSpacePath) ? _internNameSpacePath : _moduleName, nameSpace));

    }
    private async void GenerateService()
    {
        string dir = _dir + _projectName + @"Service\Modules\" + _featureName + @"/" + _internContextPath + "/";
        string interfaceDir = dir + @"\Interfaces\";
        string nameSpace = "namespace " + _baseNameSpace + @"Service.Modules." + _featureName + (!string.IsNullOrEmpty(_internNameSpacePath) ? @"." + _internNameSpacePath : "");
        string dtoNameSpace = _baseNameSpace + @"Crosscutting.DTO." + _featureName + (!string.IsNullOrEmpty(_internNameSpacePath) ? @"." + _internNameSpacePath : "");
        string mappersNameSpace = _baseNameSpace + @"Service.Mappers." + _featureName + (!string.IsNullOrEmpty(_internNameSpacePath) ? @"." + _internNameSpacePath : "");
        string modulesNameSpace = _baseNameSpace + @"Service.Modules." + _featureName + (!string.IsNullOrEmpty(_internNameSpacePath) ? @"." + _internNameSpacePath : "");
        string validationsNameSpace = _baseNameSpace + @"Service.Validations.Modules." + _featureName + (!string.IsNullOrEmpty(_internNameSpacePath) ? @"." + _internNameSpacePath : "");

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        if (!Directory.Exists(interfaceDir))
        {
            Directory.CreateDirectory(interfaceDir);
        }

        var fileDir = dir + _moduleName + "ApplicationService.cs";
        var iFileDir = interfaceDir + "I" + _moduleName + "ApplicationService.cs";



        await File.WriteAllTextAsync(fileDir,
            ApplicationServiceTemplateGenerator.WriteModelClass(
                _baseNameSpace,
                _featureName,
                _moduleName,
                nameSpace,
                _internNameSpacePath,
                dtoNameSpace,
                _entityLocationUsing,
                _repositoryIntUsing,
                _unitOfWorkInter,
                mappersNameSpace,
                modulesNameSpace,
                validationsNameSpace
            ));
        await File.WriteAllTextAsync(iFileDir, ApplicationServiceTemplateGenerator.WriteInterfaceModelClass(_baseNameSpace, _featureName, _moduleName, dtoNameSpace, _internNameSpacePath, dtoNameSpace, _entityLocationUsing));
    }
    private async void GenerateMappers()
    {
        string dir = _dir + _projectName + @"Service\Mappers\" + _featureName + @"/" + _internContextPath + "/";
        string nameSpace = "namespace " + _baseNameSpace + @"Service.Mappers." + _featureName + (!string.IsNullOrEmpty(_internNameSpacePath) ? @"." + _internNameSpacePath : "");
        string dtoNameSpace = _baseNameSpace + @"Crosscutting.DTO." + _featureName + (!string.IsNullOrEmpty(_internNameSpacePath) ? @"." + _internNameSpacePath : "");

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        var fileDir = dir + _moduleName + "Mapper.cs";

        await File.WriteAllTextAsync(fileDir, MapperTemplateGenerator.WriteModelClass(_baseNameSpace, _featureName, _moduleName, nameSpace, dtoNameSpace));

    }
    private async void GenerateValidations()
    {
        string dir = _dir + _projectName + @"Service\Validations\Modules\" + _featureName + @"/" + _internContextPath + "/";
        string nameSpace = "namespace " + _baseNameSpace + @"Service.Validations.Modules." + _featureName + (!string.IsNullOrEmpty(_internNameSpacePath) ? @"." + _internNameSpacePath : "");

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        var fileDir = dir + _moduleName + "Validator.cs";

        await File.WriteAllTextAsync(fileDir, ValidatorTemplateGenerator.WriteModelClass(_baseNameSpace, _featureName, _moduleName, _entityLocationUsing, nameSpace));

    }
    private async void GenerateDtos()
    {
        string dir = _dir + _projectName + @"Crosscutting\DTO\" + _featureName + @"/" + _internContextPath + "/";
        string nameSpace = "namespace " + _baseNameSpace + @"Crosscutting.DTO." + _featureName + (!string.IsNullOrEmpty(_internNameSpacePath) ? @"." + _internNameSpacePath : "");

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        var fileDir = dir + _moduleName;

        await File.WriteAllTextAsync(fileDir + @"GetDto.cs", DtoTemplateGenerator.WriteModelClass(_baseNameSpace, _featureName, _moduleName, "GetDto", nameSpace));
        await File.WriteAllTextAsync(fileDir + @"GridDto.cs", DtoTemplateGenerator.WriteModelClass(_baseNameSpace, _featureName, _moduleName, "GridDto", nameSpace));
        await File.WriteAllTextAsync(fileDir + @"PostDto.cs", DtoTemplateGenerator.WriteModelClass(_baseNameSpace, _featureName, _moduleName, "PostDto", nameSpace));
        await File.WriteAllTextAsync(fileDir + @"PutDto.cs", DtoTemplateGenerator.WriteModelClass(_baseNameSpace, _featureName, _moduleName, "PutDto", nameSpace));

    }
    //private async void GenerateTestsMocks()
    //{
    //    string dir = _dir + _projectName + @"Service.Tests\Mockups\" + _featureName + @"/" + _internContextPath + "/";

    //    if (!Directory.Exists(dir))
    //    {
    //        Directory.CreateDirectory(dir);
    //    }

    //    var fileDir = dir + _moduleName + "Mocks.cs";
    //    Console.WriteLine("------------------------------------------------------");
    //    Console.WriteLine();
    //    Console.WriteLine("Gerando arquivo de mocks!");

    //    await File.WriteAllTextAsync(fileDir, "");

    //    Console.WriteLine("Arquivo gerado com sucesso!");
    //    Console.WriteLine();
    //    Console.WriteLine("------------------------------------------------------");
    //}
    //    private async void GenerateTestsModules()
    //    {
    //        string dir = _dir + _projectName + @"Service.Tests\Modules\" + _featureName + @"\" + _internContext + @"Ctx\";

    //        if (!Directory.Exists(dir))
    //        {
    //            Directory.CreateDirectory(dir);
    //        }

    //        var fileDir = dir + _internContext + "ApplicationServiceTests.cs";
    //        Console.WriteLine("------------------------------------------------------");
    //        Console.WriteLine();
    //        Console.WriteLine("Gerando arquivo de modules!");

    //        await File.WriteAllTextAsync(fileDir, "");

    //        Console.WriteLine("Arquivo gerado com sucesso!");
    //        Console.WriteLine();
    //        Console.WriteLine("------------------------------------------------------");
    //    }


}
