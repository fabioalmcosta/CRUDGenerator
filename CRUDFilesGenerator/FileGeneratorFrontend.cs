

namespace CRUDFilesGenerator
{
    public class FileGeneratorFrontend
    {
        private string _featureName;
        private string _moduleName;
        private string _projectName;
        private string _internContext;
        private string _dir;
        private string _pathImport;
        private string _pathActions;
        private string _actionsName;
        private string _actionsTypes;
        public FileGeneratorFrontend(string projectName, string featureName, string moduleName, string dir, string internContext, string pathImports, string pathActions, string actionsName, string actionsTypes)
        {
            _featureName = featureName;
            _moduleName = moduleName;
            _projectName = projectName;
            _dir = dir;
            _internContext = internContext;
            _pathImport = pathImports;
            _pathActions = pathActions;
            _actionsName = actionsName;
            _actionsTypes = actionsTypes;
        }

        public void GenerateFrontend()
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

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.WriteLine("■■■■■■■■■ Arquivos do frontend gerados com sucesso! ■■■■■■■■■■■■");
            Console.WriteLine("■■■■■■■■■           Aperte para continuar!         ■■■■■■■■■■■■■");
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
            Console.Clear();
        }
        private async void GenerateGrid()
        {
            string dir = _dir + _projectName + @"\WebApp\src\modules\" + _featureName + @"/" + _internContext + @"\components\";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var fileDir = dir + _moduleName + ".grid.tsx";


            await File.WriteAllTextAsync(fileDir, GridTemplateGenerator.WriteGridClass(_featureName, _moduleName, _pathImport, _pathActions));
        }
        private async void GenerateForm()
        {
            string dir = _dir + _projectName + @"\WebApp\src\modules\" + _featureName + @"/" + _internContext + @"\components\";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var fileDir = dir + _moduleName + ".form.tsx";


            await File.WriteAllTextAsync(fileDir, FormTemplateGenerator.WriteFormClass(_featureName, _moduleName, _pathImport));
        }
        private async void GenerateSearchFile()
        {
            string dir = _dir + _projectName + @"\WebApp\src\modules\" + _featureName + @"/" + _internContext + @"\container\";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var fileDir = dir + _moduleName + ".search.tsx";

            await File.WriteAllTextAsync(fileDir, SearchTemplateGenerator.WriteSearchClass(_moduleName));
        }
        private async void GenerateNewFile()
        {
            string dir = _dir + _projectName + @"\WebApp\src\modules\" + _featureName + @"/" + _internContext + @"\container\";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var fileDir = dir + _moduleName + ".new.tsx";

            await File.WriteAllTextAsync(fileDir, NewTemplateGenerator.WriteNewClass(_moduleName));
        }
        private async void GenerateViewFile()
        {
            string dir = _dir + _projectName + @"\WebApp\src\modules\" + _featureName + @"/" + _internContext + @"\container\";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var fileDir = dir + _moduleName + ".view.tsx";


            await File.WriteAllTextAsync(fileDir, ViewTemplateGenerator.WriteViewClass(_moduleName));
        }
        private async void GenerateEditFile()
        {
            string dir = _dir + _projectName + @"\WebApp\src\modules\" + _featureName + @"/" + _internContext + @"\container\";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var fileDir = dir + _moduleName + ".edit.tsx";


            await File.WriteAllTextAsync(fileDir, EditTemplateGenerator.WriteEditClass(_moduleName));
        }
        private async void GenerateServiceFile()
        {
            string dir = _dir + _projectName + @"\WebApp\src\modules\" + _featureName + @"/" + _internContext + @"\service\";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var fileDir = dir + _moduleName + ".service.js";

            await File.WriteAllTextAsync(fileDir, ServiceTemplateGenerator.WriteServiceClass(_moduleName));
        }
        private async void GenerateActionsFile()
        {
            string dir = _dir + _projectName + @"\WebApp\src\modules\" + _featureName + @"/" + _internContext + @"\store\";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var fileDir = dir + _moduleName + ".actions.ts";


            await File.WriteAllTextAsync(fileDir, ActionsTemplateGenerator.WriteActionsClass(_moduleName, _actionsName, _actionsTypes));
        }
        private async void GenerateActionTypesFile()
        {
            string dir = _dir + _projectName + @"\WebApp\src\modules\" + _featureName + @"/" + _internContext + @"\store\";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var fileDir = dir + _moduleName + ".actionTypes.ts";

            await File.WriteAllTextAsync(fileDir, ActionTypesTemplateGenerator.WriteActionsTypesClass(_featureName, _moduleName, _actionsTypes, _pathImport));
        }
        private async void GenerateReducerFile()
        {
            string dir = _dir + _projectName + @"\WebApp\src\modules\" + _featureName + @"/" + _internContext + @"\store\";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var fileDir = dir + _moduleName + ".reducer.ts";

            await File.WriteAllTextAsync(fileDir, ReducerTemplateGenerator.WriteReducerClass(_featureName, _moduleName, _actionsTypes));
        }
        private async void GenerateSagaFile()
        {
            string dir = _dir + _projectName + @"\WebApp\src\modules\" + _featureName + @"/" + _internContext + @"\store\";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var fileDir = dir + _moduleName + ".saga.js";

            await File.WriteAllTextAsync(fileDir, SagaTemplateGenerator.WriteSagaClass(_featureName, _moduleName, _actionsTypes, _pathImport));
        }
        private async void GenerateSelectorsFile()
        {
            string dir = _dir + _projectName + @"\WebApp\src\modules\" + _featureName + @"/" + _internContext + @"\store\";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var fileDir = dir + _moduleName + ".selectors.ts";


            await File.WriteAllTextAsync(fileDir, SelectorsTemplateGenerator.WriteSelectorsClass(_featureName, _moduleName, _pathImport));
        }
        private async void GenerateDdadosFile()
        {
            string dir = _dir + _projectName + @"\WebApp\src\modules\" + _featureName + @"/" + _internContext + @"\";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var fileDir = dir + _moduleName + ".ddados.ts";

            await File.WriteAllTextAsync(fileDir, DDadosTemplateGenerator.WriteDDadosClass(_moduleName));
        }
        private async void GenerateGridDdadosFile()
        {
            string dir = _dir + _projectName + @"\WebApp\src\modules\" + _featureName + @"/" + _internContext + @"\";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var fileDir = dir + _moduleName + ".grid.ddados.ts";

            await File.WriteAllTextAsync(fileDir, GridDDadosTemplateGenerator.WriteGridDDadosClass(_moduleName));
        }
        private async void GenerateRoutesFile()
        {
            string dir = _dir + _projectName + @"\WebApp\src\modules\" + _featureName + @"/" + _internContext + @"\";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var fileDir = dir + _moduleName + ".routes.ts";

            await File.WriteAllTextAsync(fileDir, RoutesTemplateGenerator.WriteRoutesClass(_featureName, _moduleName, _pathImport, _pathActions));
        }
    }
}

