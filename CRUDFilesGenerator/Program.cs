using CRUDFilesGenerator;

Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
Console.WriteLine("■■■■■■ Iniciando o projeto de gerador de arquivos de CRUD ■■■■■■");
Console.WriteLine("■■■■■■       Aperte qualquer botão para continuar         ■■■■■■");
Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■\n");
Console.ReadLine();
Console.Clear();


#region [Backend]

Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
Console.WriteLine("■■■■■■■■■■■■      Vamos começar pelo Backend:       ■■■■■■■■■■■■");
Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■\n");
Console.WriteLine("Digite o nome do projeto ou pressione enter para utilizar o nome definido no código: (Padrão: 'SMARAPD.SS-API')");

string projectName = Console.ReadLine();
projectName = string.IsNullOrEmpty(projectName) ? "SMARAPD.SS-API" : projectName;

string baseNameSpace = projectName.Replace("-", "_");
baseNameSpace = baseNameSpace + ".";

Console.Clear();
Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
Console.WriteLine("■■■■■      Digite o caminho do diretório de backend:       ■■■■■");
Console.WriteLine("■■■■ Deixa em branco para o padrão ('C:/CRUDFilesOutput/'): ■■■■");
Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■\n");

string backendDirectory = Console.ReadLine();
backendDirectory = string.IsNullOrEmpty(backendDirectory) ? @"C:\CRUDFilesOutput\backend\" + projectName + @"\" : backendDirectory + projectName + @"\";

if (!Directory.Exists(backendDirectory))
{
    Directory.CreateDirectory(backendDirectory);
}

#endregion

#region [Entity]

Console.Clear();
Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
Console.WriteLine("■■■■■■■■■■■■■■■■■■■ Digite o nome da entidade ■■■■■■■■■■■■■■■■■■");
Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■\n");
string entity = Console.ReadLine();

if (string.IsNullOrEmpty(entity))
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("■■■■■■■■■■■■■■■■■■■ O nome da entidade é obrigatório ■■■■■■■■■■■■■■■■■■");
    return;
}

Console.Clear();
Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
Console.WriteLine("■■■■ Digite caminho da entidade separando por '/' cada nível ■■■■");
Console.WriteLine("■■■■            Em branco para utilizar a raiz               ■■■■");
Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■\n");

string projectPath = Console.ReadLine();
projectPath = projectPath + "/" + entity;
string[] pathArr = projectPath.Split('/');

string featureName = !string.IsNullOrEmpty(pathArr[0]) ? pathArr[0] : entity + "Ctx";
string moduleName = !string.IsNullOrEmpty(pathArr[0]) ? pathArr[pathArr.Length - 1] : entity;
string internContextPath = !string.IsNullOrEmpty(pathArr[0]) ? string.Join(@"Ctx/", pathArr.Skip(1).ToArray()) + "Ctx" : $"/";
string internNameSpacePath = !string.IsNullOrEmpty(pathArr[0]) ? string.Join("Ctx.", pathArr.Skip(1).ToArray()) + "Ctx" : $"";

var fileGenerator = new FileGenerator(projectName + ".", featureName, internContextPath, backendDirectory, baseNameSpace, internNameSpacePath, moduleName);
fileGenerator.Generate();


#endregion

#region [Frontend]

Console.Clear();
Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
Console.WriteLine("■■■■■         Agora vamos criar os arquivos do frontend:   ■■■■■");
Console.WriteLine("■ Digite o nome do projeto do frontend ou pressione enter para ■");
Console.WriteLine("■          utilizar o nome definido no código:                 ■");
Console.WriteLine("■             (Padrão: 'SMARAPD.SS-WebApp')                    ■");
Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■\n");

string projectFrontName = Console.ReadLine();
projectFrontName = string.IsNullOrEmpty(projectFrontName) ? "SMARAPD.SS-WebApp" : projectFrontName;

Console.Clear();
Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
Console.WriteLine("■■■■■      Digite o caminho do diretório de frontend:       ■■■■");
Console.WriteLine("■■■■ Deixa em branco para o padrão ('C:/CRUDFilesOutput/'): ■■■■");
Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■\n");

string frontendDirectory = Console.ReadLine();
frontendDirectory = string.IsNullOrEmpty(frontendDirectory) ? @"C:\CRUDFilesOutput\frontend\" : frontendDirectory;


Console.Clear();
Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");

if (pathArr.Length == 2)
{
    pathArr = pathArr.Skip(1).ToArray();
}


var folderPaths = pathArr.Skip(1).Select(x => char.ToLower(x[0]) + x.Substring(1)).ToArray();
var pathImportsArr = pathArr.Select(x => char.ToLower(x[0]) + x.Substring(1)).ToArray();
var actionsNameArr = pathArr.Select(x => char.ToUpper(x[0]) + x.Substring(1).ToLower()).ToArray();
var actionsTypesArr = pathArr.Select(x => x.ToUpper()).ToArray();

internContextPath = string.Join(@"/", folderPaths);
var pathImports = string.Join(".", pathImportsArr);
var pathActions = string.Join("/", pathImportsArr);
var actionsName = string.Join("", actionsNameArr);
var actionsTypes = string.Join("_", actionsTypesArr);

var fileGeneratorFrontend = new FileGeneratorFrontend(projectFrontName, featureName, moduleName, frontendDirectory, internContextPath, pathImports, pathActions, actionsName, actionsTypes);

fileGeneratorFrontend.GenerateFrontend();

Console.Clear();
Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
Console.WriteLine("■■■■                   Criação das Migrations                ■■■■");
Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■\n");
Console.ReadLine();

Console.Clear();
Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
Console.WriteLine("■   Digite o ID do projeto ou pressione enter para utilizar     ■");
Console.WriteLine("■          o nome definido no código: (Padrão: '29')            ■");
Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■\n");

string projectId = Console.ReadLine();
string ID = string.IsNullOrEmpty(projectId) ? "29" : projectId;

Console.Clear();
Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
Console.WriteLine("■  Digite o prefixo do projeto ou pressione enter para utilizar ■");
Console.WriteLine("■          o nome definido no código: (Padrão: 'SS')            ■");
Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■\n");

//Console.WriteLine("------------------------------------------------------");
//Console.WriteLine("Digite o prefixo do projeto ou pressione enter para utilizar o nome definido no código: ");

string prefixo = Console.ReadLine();
string prefixoP = string.IsNullOrEmpty(prefixo) ? "SS" : prefixo;

string migrationPath = @"C:\CRUDFilesOutput\Migration\";
var migrations = new FileGeneratorMigration(projectFrontName, featureName, moduleName, migrationPath, ID, prefixoP);
migrations.GenerateMigration();


#endregion