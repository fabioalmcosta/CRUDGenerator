public class FileGenerator
{
    private string _featureName;
    private string _internContext;
    private string _projectName;
    private string _dir;
    private string _nameSpace;
    private string _nameSpacePath;
    private string _subModuleName;
    private string _entityLocationUsing;
    private string _repositoryIntUsing;
    private string _repositoryUsing;
    private string _unitOfWorkInter;
    public FileGenerator(string projectName, string featureName, string internContext, string dir, string nameSpace, string nameSpacePath, string subModuleName)
    {
        _featureName = featureName;
        _internContext = internContext;
        _projectName = projectName;
        _dir = dir;
        _nameSpace = nameSpace;
        _nameSpacePath = nameSpacePath;
        _subModuleName = subModuleName;
    }

    public async void Generate()
    {
        if (char.IsUpper(_featureName[0]) == false)
        {
            _featureName = char.ToUpper(_featureName[0]) + _featureName.Substring(1);
        }

        if (char.IsUpper(_internContext[0]) == false)
        {
            _internContext = char.ToUpper(_internContext[0]) + _internContext.Substring(1);
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

        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine("Arquivos gerados com sucesso!");
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||||||||||||||");
        Console.WriteLine("******************************************************");
    }

    private async void GenerateEntity()
    {

        string dir = _dir + _projectName + @"Domain\Entities\" + _featureName + @"/" + _internContext + "/";
        _entityLocationUsing = _nameSpace + @"Domain.Entities." + _featureName + @"." + _nameSpacePath;

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }


        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine();
        Console.WriteLine("Gerando arquivo de entidade!");

        var fileDir = dir + _subModuleName + ".cs";
        await File.WriteAllTextAsync(fileDir, EntityTemplateGenerator.WriteModelClass(_nameSpace, _featureName, _subModuleName, _entityLocationUsing));

        Console.WriteLine("Arquivo gerado com sucesso!");
        Console.WriteLine();
        Console.WriteLine("------------------------------------------------------");
    }
    private async void GenerateMap()
    {

        string dir = _dir + _projectName + @"Infrastructure\Persistence\Map\" + _featureName + @"/" + _internContext + "/";
        string nameSpace = "namespace " + _nameSpace + @"Infrastructure.Persistence.Map." + _featureName + @"." + _nameSpacePath;


        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine();
        Console.WriteLine("Gerando arquivo de mapeamento!");

        var fileDir = dir + _subModuleName + "Map.cs";
        await File.WriteAllTextAsync(fileDir, MapTemplateGenerator.WriteModelClass(_nameSpace, _featureName, _subModuleName, nameSpace, _entityLocationUsing));


        Console.WriteLine("Arquivo gerado com sucesso!");
        Console.WriteLine();
        Console.WriteLine("------------------------------------------------------");
    }
    private async void GenerateRepository()
    {
        string dir = _dir + _projectName + @"Infrastructure\Persistence\Repository\" + _featureName + @"/" + _internContext + "/";
        string interfaceDir = dir + @"\Interfaces\";
        _repositoryUsing = "namespace " + _nameSpace + @"Infrastructure.Persistence.Repository." + _featureName + @"." + _nameSpacePath;
        _repositoryIntUsing = _nameSpace + @"Infrastructure.Persistence.Repository." + _featureName + @"." + _nameSpacePath + @".Interfaces" + @"";


        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        if (!Directory.Exists(interfaceDir))
        {
            Directory.CreateDirectory(interfaceDir);
        }


        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine();
        Console.WriteLine("Gerando arquivo de repository!");



        var fileDir = dir + _subModuleName + "Repository.cs";
        var iFileDir = interfaceDir + "I" + _subModuleName + "Repository.cs";

        await File.WriteAllTextAsync(fileDir, RepositoryTemplateGenerator.WriteModelClass(_nameSpace, _featureName, _subModuleName, _repositoryUsing, _entityLocationUsing, _repositoryIntUsing));
        await File.WriteAllTextAsync(iFileDir, RepositoryTemplateGenerator.WriteInterfaceModelClass(_nameSpace, _featureName, _subModuleName, _repositoryIntUsing, _entityLocationUsing));


        Console.WriteLine("Arquivo gerado com sucesso!");
        Console.WriteLine("Interface gerada com sucesso!");
        Console.WriteLine();
        Console.WriteLine("------------------------------------------------------");
    }
    private async void GenerateUnitOfWork()
    {
        string dir = _dir + _projectName + @"Infrastructure\Persistence\UnitOfWork\" + _featureName + @"/" + _internContext + "/";
        string interfaceDir = dir + @"\Interfaces\";
        string nameSpace = "namespace " + _nameSpace + @"Infrastructure.Persistence.UnitOfWork." + _featureName + @"." + _nameSpacePath;
        _unitOfWorkInter = _nameSpace + @"Infrastructure.Persistence.UnitOfWork." + _featureName + @"." + _nameSpacePath + @".Interfaces" + @"";

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        if (!Directory.Exists(interfaceDir))
        {
            Directory.CreateDirectory(interfaceDir);
        }

        var fileDir = dir + _subModuleName + "UnitOfWork.cs";
        var iFileDir = interfaceDir + "I" + _subModuleName + "UnitOfWork.cs";
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine();
        Console.WriteLine("Gerando arquivo de unit of work!");

        await File.WriteAllTextAsync(fileDir, UnitOfWorkTemplateGenerator.WriteModelClass(_nameSpace, _featureName, _subModuleName, _entityLocationUsing, nameSpace, _unitOfWorkInter, _repositoryIntUsing));
        await File.WriteAllTextAsync(iFileDir, UnitOfWorkTemplateGenerator.WriteInterfaceModelClass(_nameSpace, _featureName, _subModuleName, _entityLocationUsing, _unitOfWorkInter, _repositoryIntUsing));

        Console.WriteLine("Arquivo gerado com sucesso!");
        Console.WriteLine("Interface gerada com sucesso!");
        Console.WriteLine();
        Console.WriteLine("------------------------------------------------------");
    }
    private async void GenerateController()
    {
        string dir = _dir + _projectName + @"Interface\Controllers\" + _featureName + @"/" + _internContext + "/";
        string nameSpace = "namespace " + _nameSpace + @"Interface.Controllers." + _featureName + @"." + _nameSpacePath;

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        var fileDir = dir + _subModuleName + "Controller.cs";
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine();
        Console.WriteLine("Gerando arquivo de controller!");

        await File.WriteAllTextAsync(fileDir, ControllerTemplateGenerator.WriteModelClass(_nameSpace, _featureName, _subModuleName, _nameSpacePath, nameSpace));

        Console.WriteLine("Arquivo gerado com sucesso!");
        Console.WriteLine();
        Console.WriteLine("------------------------------------------------------");
    }
    private async void GenerateService()
    {
        string dir = _dir + _projectName + @"Service\Modules\" + _featureName + @"/" + _internContext + "/";
        string interfaceDir = dir + @"\Interfaces\";
        string nameSpace = "namespace " + _nameSpace + @"Service.Modules." + _featureName + @"." + _nameSpacePath;
        string dtoNameSpace = _nameSpace + @"Crosscutting.DTO." + _featureName + @"." + _nameSpacePath;
        string mappersNameSpace = _nameSpace + @"Service.Mappers." + _featureName + @"." + _nameSpacePath;
        string modulesNameSpace = _nameSpace + @"Service.Modules." + _featureName + @"." + _nameSpacePath;
        string validationsNameSpace = _nameSpace + @"Service.Validations.Modules." + _featureName + @"." + _nameSpacePath;

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        if (!Directory.Exists(interfaceDir))
        {
            Directory.CreateDirectory(interfaceDir);
        }

        var fileDir = dir + _subModuleName + "ApplicationService.cs";
        var iFileDir = interfaceDir + "I" + _subModuleName + "ApplicationService.cs";

        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine();
        Console.WriteLine("Gerando arquivo de application service!");

        await File.WriteAllTextAsync(fileDir, ApplicationServiceTemplateGenerator.WriteModelClass(
            _nameSpace,
            _featureName,
            _subModuleName,
            nameSpace,
            _nameSpacePath,
            dtoNameSpace,
            _entityLocationUsing,
            _repositoryIntUsing,
            _unitOfWorkInter,
            mappersNameSpace,
            modulesNameSpace,
            validationsNameSpace
            ));
        await File.WriteAllTextAsync(iFileDir, ApplicationServiceTemplateGenerator.WriteInterfaceModelClass(_nameSpace, _featureName, _subModuleName, dtoNameSpace, _nameSpacePath, dtoNameSpace, _entityLocationUsing));

        Console.WriteLine("Arquivo gerado com sucesso!");
        Console.WriteLine("Interface gerada com sucesso!");
        Console.WriteLine();
        Console.WriteLine("------------------------------------------------------");
    }
    private async void GenerateMappers()
    {
        string dir = _dir + _projectName + @"Service\Mappers\" + _featureName + @"/" + _internContext + "/";
        string nameSpace = "namespace " + _nameSpace + @"Service.Mappers." + _featureName + @"." + _nameSpacePath;
        string dtoNameSpace = _nameSpace + @"Crosscutting.DTO." + _featureName + @"." + _nameSpacePath;

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        var fileDir = dir + _subModuleName + "Mapper.cs";
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine();
        Console.WriteLine("Gerando arquivo de mapper!");

        await File.WriteAllTextAsync(fileDir, MapperTemplateGenerator.WriteModelClass(_nameSpace, _featureName, _subModuleName, nameSpace, dtoNameSpace));

        Console.WriteLine("Arquivo gerado com sucesso!");
        Console.WriteLine();
        Console.WriteLine("------------------------------------------------------");
    }
    private async void GenerateValidations()
    {
        string dir = _dir + _projectName + @"Service\Validations\Modules\" + _featureName + @"/" + _internContext + "/";
        string nameSpace = "namespace " + _nameSpace + @"Service.Validations.Modules." + _featureName + @"." + _nameSpacePath;

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        var fileDir = dir + _subModuleName + "Validator.cs";
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine();
        Console.WriteLine("Gerando arquivo de validator!");

        await File.WriteAllTextAsync(fileDir, ValidatorTemplateGenerator.WriteModelClass(_nameSpace, _featureName, _subModuleName, _entityLocationUsing, nameSpace));

        Console.WriteLine("Arquivo gerado com sucesso!");
        Console.WriteLine();
        Console.WriteLine("------------------------------------------------------");
    }
    private async void GenerateDtos()
    {
        string dir = _dir + _projectName + @"Crosscutting\DTO\" + _featureName + @"/" + _internContext + "/";
        string nameSpace = "namespace " + _nameSpace + @"Crosscutting.DTO." + _featureName + @"." + _nameSpacePath;

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        var fileDir = dir + _subModuleName;
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine();
        Console.WriteLine("Gerando arquivos de dto!");

        await File.WriteAllTextAsync(fileDir + @"GetDto.cs", DtoTemplateGenerator.WriteModelClass(_nameSpace, _featureName, _subModuleName, "GetDto", nameSpace));
        await File.WriteAllTextAsync(fileDir + @"GridDto.cs", DtoTemplateGenerator.WriteModelClass(_nameSpace, _featureName, _subModuleName, "GridDto", nameSpace));
        await File.WriteAllTextAsync(fileDir + @"PostDto.cs", DtoTemplateGenerator.WriteModelClass(_nameSpace, _featureName, _subModuleName, "PostDto", nameSpace));
        await File.WriteAllTextAsync(fileDir + @"PutDto.cs", DtoTemplateGenerator.WriteModelClass(_nameSpace, _featureName, _subModuleName, "PutDto", nameSpace));

        Console.WriteLine("Arquivo gerado com sucesso!");
        Console.WriteLine();
        Console.WriteLine("------------------------------------------------------");
    }
    //    private async void GenerateTestsMocks()
    //    {
    //        string dir = _dir + _projectName + @"Service.Tests\Mockups\" + _featureName + @"\" + _internContext + @"Ctx\";

    //        if (!Directory.Exists(dir))
    //        {
    //            Directory.CreateDirectory(dir);
    //        }

    //        var fileDir = dir + _internContext + "Mocks.cs";
    //        Console.WriteLine("------------------------------------------------------");
    //        Console.WriteLine();
    //        Console.WriteLine("Gerando arquivo de mocks!");

    //        await File.WriteAllTextAsync(fileDir, "");

    //        Console.WriteLine("Arquivo gerado com sucesso!");
    //        Console.WriteLine();
    //        Console.WriteLine("------------------------------------------------------");
    //    }
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
