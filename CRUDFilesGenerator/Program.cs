using CRUDFilesGenerator;

Console.WriteLine("------------------------------------------------------");
Console.WriteLine("Iniciando o projeto de gerador de arquivos de CRUD");
Console.WriteLine("------------------------------------------------------");
await CrudFilesGenerator();

static async Task CrudFilesGenerator()
{
    Console.WriteLine("------------------------------------------------------");
    Console.WriteLine("");
    Console.WriteLine("Vamos começar pelo Backend: ");
    Console.WriteLine("");
    Console.WriteLine("------------------------------------------------------");
    Console.WriteLine("Digite o nome do projeto ou pressione enter para utilizar o nome definido no código: (Padrão: 'SMARAPD.SS-API')");

    string projectName = Console.ReadLine();
    projectName = string.IsNullOrEmpty(projectName) ? "SMARAPD.SS-API" : projectName;

    string nameSpace = projectName.Replace("-", "_");
    nameSpace = nameSpace + ".";

    Console.WriteLine("------------------------------------------------------");
    Console.WriteLine("Digite o caminho do diretório de backend: ");

    string dir = Console.ReadLine();
    dir = string.IsNullOrEmpty(dir) ? @"C:\CRUDFilesOutput\backend\" + projectName + @"\" : dir + projectName + @"\";

    if (!Directory.Exists(dir))
    {
        Directory.CreateDirectory(dir);
    }

    Console.WriteLine("Digite caminho da entidade separando por '/' cada nivel");
    string path = Console.ReadLine();
    string[] teste = path.Split('/');

    string featureName = teste[0];
    string moduleNome = teste[teste.Length - 1];
    string caminhoInternoContext = string.Join(@"Ctx/", teste.Skip(1).ToArray()) + "Ctx";
    string caminhoInternoNameSpace = string.Join("Ctx.", teste.Skip(1).ToArray()) + "Ctx";

    Console.WriteLine(caminhoInternoContext);

    var fileGenerator = new FileGenerator(projectName + ".", featureName, caminhoInternoContext, dir, nameSpace, caminhoInternoNameSpace, moduleNome);
    fileGenerator.Generate();

    Console.WriteLine("------------------------------------------------------");
    Console.WriteLine("");
    Console.WriteLine("Agora vamos criar os arquivos do frontend: ");
    Console.WriteLine("");
    Console.WriteLine("------------------------------------------------------");
    Console.WriteLine("Digite o nome do projeto do frontend ou pressione enter para utilizar o nome definido no código: ");
    Console.WriteLine("");

    string projectFrontName = Console.ReadLine();
    projectFrontName = string.IsNullOrEmpty(projectFrontName) ? "SMARAPD.SS-WebApp" : projectFrontName;

    Console.WriteLine("------------------------------------------------------");
    Console.WriteLine("Digite o caminho do diretório de frontend: ");

    string dirFront = Console.ReadLine();
    dirFront = string.IsNullOrEmpty(dirFront) ? @"C:\CRUDFilesOutput\frontend\" : dirFront;


    Console.WriteLine("------------------------------------------------------");
    Console.WriteLine("Para gerar os arquivos pressione enter!");
    Console.ReadLine();


    var folderPaths = teste.Skip(1).Select(x => char.ToLower(x[0]) + x.Substring(1)).ToArray();
    var pathImportsArr = teste.Select(x => char.ToLower(x[0]) + x.Substring(1)).ToArray();
    var actionsNameArr = teste.Select(x => char.ToUpper(x[0]) + x.Substring(1).ToLower()).ToArray();
    var actionsTypesArr = teste.Select(x => x.ToUpper()).ToArray();

    caminhoInternoContext = string.Join(@"/", folderPaths);
    var pathImports = string.Join(".", pathImportsArr);
    var pathActions = string.Join("/", pathImportsArr);
    var actionsName = string.Join("", actionsNameArr);
    var actionsTypes = string.Join("_", actionsTypesArr);

    var fileGeneratorFrontend = new FileGeneratorFrontend(projectFrontName, featureName, moduleNome, dirFront, caminhoInternoContext, pathImports, pathActions , actionsName, actionsTypes);

    fileGeneratorFrontend.GenerateFrontend();

    //Console.WriteLine("------------------------------------------------------");
    //Console.WriteLine("Iniciando a geração dos arquivos");
    //Console.WriteLine("------------------------------------------------------");

    //fileGeneratorFrontend.GenerateFrontend();

    //Console.WriteLine("------------------------------------------------------");
    //Console.WriteLine("Iniciando a criação das migrations");
    //Console.WriteLine("------------------------------------------------------");

    //Console.WriteLine("------------------------------------------------------");
    //Console.WriteLine("Digite o ID do projeto ou pressione enter para utilizar o nome definido no código: ");

    //string projectId = Console.ReadLine();
    //string ID = string.IsNullOrEmpty(projectId) ? "29" : projectId;

    //Console.WriteLine("------------------------------------------------------");
    //Console.WriteLine("Digite o prefixo do projeto ou pressione enter para utilizar o nome definido no código: ");

    //string prefixo = Console.ReadLine();
    //string prefixoP = string.IsNullOrEmpty(prefixo) ? "SS" : prefixo;

    //string migrationPath = @"C:\CRUDFilesOutput\Migration\";
    //var migrations = new FileGeneratorMigration(projectFrontName, featureName, moduleName, migrationPath, ID, prefixoP);
    //migrations.GenerateMigration();
}
