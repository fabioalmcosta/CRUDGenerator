// See https://aka.ms/new-console-template for more information
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
    Console.WriteLine("Digite o nome do projeto ou pressione enter para utilizar o nome definido no código: ");
    string projectName = Console.ReadLine();
    projectName = string.IsNullOrEmpty(projectName) ? "SMARAPD.SS-API." : projectName;


    Console.WriteLine("------------------------------------------------------");
    Console.WriteLine("Digite o nome da feature ou pressione enter para utilizar o nome definido no código: ");
    string featureName = Console.ReadLine();
    featureName = string.IsNullOrEmpty(featureName) ? "Medicina" : featureName;


    Console.WriteLine("------------------------------------------------------");
    Console.WriteLine("Digite o nome do módulo ou pressione enter para utilizar o nome definido no código: ");
    string moduleName = Console.ReadLine();
    moduleName = string.IsNullOrEmpty(moduleName) ? "Atestado" : moduleName;

    Console.WriteLine();
    Console.WriteLine("------------------------------------------------------");
    Console.WriteLine("O nome do projeto definido é: " + projectName);
    Console.WriteLine();
    Console.WriteLine("O nome da feature definida é: " + featureName);
    Console.WriteLine();
    Console.WriteLine("O nome do módulo definido é: " + moduleName);
    Console.WriteLine();
    Console.WriteLine("------------------------------------------------------");
    Console.WriteLine("Para gerar os arquivos pressione enter!");
    Console.ReadLine();


    string dir = @"C:\CRUDFilesOutput\";
    if (!Directory.Exists(dir))
    {
        Directory.CreateDirectory(dir);
    }

    var fileGenerator = new FileGenerator(projectName, featureName, moduleName, dir);

    Console.WriteLine("------------------------------------------------------");
    Console.WriteLine("Iniciando a geração dos arquivos");
    Console.WriteLine("------------------------------------------------------");
    fileGenerator.Generate();
}
