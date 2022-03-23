

namespace CRUDFilesGenerator
{
    public class FileGeneratorFrontend
    {
        private string _featureName;
        private string _moduleName;
        private string _projectName;
        private string _dir;
        public FileGeneratorFrontend(string projectName, string featureName, string moduleName, string dir)
        {
            _featureName = featureName;
            _moduleName = moduleName;
            _projectName = projectName;
            _dir = dir;
        }

        public async void GenerateFrontend()
        {
            if (char.IsUpper(_featureName[0]) == true)
            {
                _featureName = char.ToLower(_featureName[0]) + _featureName.Substring(1);
            }

            if (char.IsUpper(_moduleName[0]) == true)
            {
                _moduleName = char.ToLower(_moduleName[0]) + _moduleName.Substring(1);
            }

            GenerateGrid();
            GenerateForm();
            GenerateSearchFile();
            GenerateNewFile();
            GenerateViewFile();
            GenerateEditFile();
            GenerateServiceFile();
            GenerateActionsFile();
            GenerateActionTypesFile();
            GenerateReducerFile();
            GenerateSagaFile();
            GenerateSelectorsFile();
            GenerateDdadosFile();
            GenerateGridDdadosFile();
            GenerateRoutesFile();

            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Arquivos gerados com sucesso!");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("||||||||||||||||||||||||||||||||||||||||||||||||||||||");
            Console.WriteLine("******************************************************");
        }

        private async void GenerateGrid()
        {
            string dir = _dir + _projectName + @"\WebApp\src\modules\" + _featureName + @"\" + _moduleName + @"\components\";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var fileDir = dir + _moduleName + ".grid.tsx";
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Gerando arquivo de grid!");

            await File.WriteAllTextAsync(fileDir, GridTemplateGenerator.WriteGridClass(_featureName, _moduleName));

            Console.WriteLine("Arquivo gerado com sucesso!");
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------");
        }

        private async void GenerateForm()
        {
            string dir = _dir + _projectName + @"\WebApp\src\modules\" + _featureName + @"\" + _moduleName + @"\components\";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var fileDir = dir + _moduleName + ".form.tsx";
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Gerando arquivo de formulário!");

            await File.WriteAllTextAsync(fileDir, FormTemplateGenerator.WriteFormClass(_featureName, _moduleName));

            Console.WriteLine("Arquivo gerado com sucesso!");
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------");
        }

        private async void GenerateSearchFile()
        {
            string dir = _dir + _projectName + @"\WebApp\src\modules\" + _featureName + @"\" + _moduleName + @"\container\";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var fileDir = dir + _moduleName + ".search.tsx";
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Gerando container da grid da entidade!");

            await File.WriteAllTextAsync(fileDir, SearchTemplateGenerator.WriteSearchClass( _moduleName));

            Console.WriteLine("Arquivo gerado com sucesso!");
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------");
        }

        private async void GenerateNewFile()
        {
            string dir = _dir + _projectName + @"\WebApp\src\modules\" + _featureName + @"\" + _moduleName + @"\container\";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var fileDir = dir + _moduleName + ".new.tsx";
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Gerando container de adição da entidade!");

            await File.WriteAllTextAsync(fileDir, NewTemplateGenerator.WriteNewClass( _moduleName));

            Console.WriteLine("Arquivo gerado com sucesso!");
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------");
        }

        private async void GenerateViewFile()
        {
            string dir = _dir + _projectName + @"\WebApp\src\modules\" + _featureName + @"\" + _moduleName + @"\container\";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var fileDir = dir + _moduleName + ".view.tsx";
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Gerando container de visualização da entidade!");

            await File.WriteAllTextAsync(fileDir, ViewTemplateGenerator.WriteViewClass(_moduleName));

            Console.WriteLine("Arquivo gerado com sucesso!");
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------");
        }

        private async void GenerateEditFile()
        {
            string dir = _dir + _projectName + @"\WebApp\src\modules\" + _featureName + @"\" + _moduleName + @"\container\";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var fileDir = dir + _moduleName + ".edit.tsx";
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Gerando container de edição da entidade!");

            await File.WriteAllTextAsync(fileDir, EditTemplateGenerator.WriteEditClass(_moduleName));

            Console.WriteLine("Arquivo gerado com sucesso!");
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------");
        }

        private async void GenerateServiceFile()
        {
            string dir = _dir + _projectName + @"\WebApp\src\modules\" + _featureName + @"\" + _moduleName + @"\service\";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var fileDir = dir + _moduleName + ".service.js";
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Gerando service da entidade!");

            await File.WriteAllTextAsync(fileDir, ServiceTemplateGenerator.WriteServiceClass(_moduleName));

            Console.WriteLine("Arquivo gerado com sucesso!");
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------");
        }

        private async void GenerateActionsFile()
        {
            string dir = _dir + _projectName + @"\WebApp\src\modules\" + _featureName + @"\" + _moduleName + @"\store\";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var fileDir = dir + _moduleName + ".actions.ts";
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Gerando arquivo de actions da entidade!");

            await File.WriteAllTextAsync(fileDir, ActionsTemplateGenerator.WriteActionsClass(_moduleName));

            Console.WriteLine("Arquivo gerado com sucesso!");
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------");
        }

        private async void GenerateActionTypesFile()
        {
            string dir = _dir + _projectName + @"\WebApp\src\modules\" + _featureName + @"\" + _moduleName + @"\store\";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var fileDir = dir + _moduleName + ".actionTypes.ts";
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Gerando arquivo de actionsTypes da entidade!");

            await File.WriteAllTextAsync(fileDir, ActionTypesTemplateGenerator.WriteActionsTypesClass(_featureName, _moduleName));

            Console.WriteLine("Arquivo gerado com sucesso!");
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------");
        }

        private async void GenerateReducerFile()
        {
            string dir = _dir + _projectName + @"\WebApp\src\modules\" + _featureName + @"\" + _moduleName + @"\store\";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var fileDir = dir + _moduleName + ".reducer.ts";
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Gerando arquivo de reducer da entidade!");

            await File.WriteAllTextAsync(fileDir, ReducerTemplateGenerator.WriteReducerClass(_featureName, _moduleName));

            Console.WriteLine("Arquivo gerado com sucesso!");
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------");
        }

        private async void GenerateSagaFile()
        {
            string dir = _dir + _projectName + @"\WebApp\src\modules\" + _featureName + @"\" + _moduleName + @"\store\";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var fileDir = dir + _moduleName + ".saga.js";
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Gerando arquivo saga da entidade!");

            await File.WriteAllTextAsync(fileDir, SagaTemplateGenerator.WriteSagaClass(_featureName, _moduleName));

            Console.WriteLine("Arquivo gerado com sucesso!");
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------");
        }

        private async void GenerateSelectorsFile()
        {
            string dir = _dir + _projectName + @"\WebApp\src\modules\" + _featureName + @"\" + _moduleName + @"\store\";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var fileDir = dir + _moduleName + ".selectors.ts";
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Gerando arquivo de selectors da entidade!");

            await File.WriteAllTextAsync(fileDir, SelectorsTemplateGenerator.WriteSelectorsClass(_featureName, _moduleName));

            Console.WriteLine("Arquivo gerado com sucesso!");
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------");
        }

        private async void GenerateDdadosFile()
        {
            string dir = _dir + _projectName + @"\WebApp\src\modules\" + _featureName + @"\" + _moduleName + @"\";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var fileDir = dir + _moduleName + ".ddados.ts";
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Gerando arquivo ddados da entidade!");

            await File.WriteAllTextAsync(fileDir, DDadosTemplateGenerator.WriteDDadosClass( _moduleName));

            Console.WriteLine("Arquivo gerado com sucesso!");
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------");
        }

        private async void GenerateGridDdadosFile()
        {
            string dir = _dir + _projectName + @"\WebApp\src\modules\" + _featureName + @"\" + _moduleName + @"\";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var fileDir = dir + _moduleName + ".grid.ddados.ts";
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Gerando arquivo Grid Ddados da entidade!");

            await File.WriteAllTextAsync(fileDir, GridDDadosTemplateGenerator.WriteGridDDadosClass(_moduleName));

            Console.WriteLine("Arquivo gerado com sucesso!");
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------");
        }

        private async void GenerateRoutesFile()
        {
            string dir = _dir + _projectName + @"\WebApp\src\modules\" + _featureName + @"\" + _moduleName + @"\";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var fileDir = dir + _moduleName + ".routes.ts";
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Gerando arquivo routes da entidade!");

            await File.WriteAllTextAsync(fileDir, RoutesTemplateGenerator.WriteRoutesClass(_featureName, _moduleName));

            Console.WriteLine("Arquivo gerado com sucesso!");
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------");
        }
    }
}

