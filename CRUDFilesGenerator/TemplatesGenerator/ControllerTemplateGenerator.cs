public static class ControllerTemplateGenerator
{
    public static string WriteModelClass(string projectName, string featureName, string moduleName, string _nameSpacePath, string nameSpace, string _dtoNameSpace, string _appServiceImport)
    {
        var stringFile = @"using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SMARAPD.Common.DTO;
using SMARAPD.Common.Infrastructure.Persistence.FilterExtension;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using " + _appServiceImport + @".Interfaces;
using " + _dtoNameSpace + @";


" + nameSpace + @"
{";

        stringFile = stringFile + "\r\n\t" + @"/// <summary>
    /// Controller de " + moduleName + @".
    /// </summary>
    [ApiController]";

        stringFile = stringFile + "\r\n\t[Route(\"[controller]\")]";
    
        stringFile = stringFile + "\r\n\tpublic class " + moduleName + "Controller  : ControllerBase \r\n\t{\r\n";

        stringFile = stringFile + "\t\tprivate readonly I" + moduleName + "ApplicationService _appService;\r\n\t\t";

        stringFile = stringFile + @" /// <summary>
        /// Construtor da classe.
        /// </summary>
        public " + moduleName + "Controller(I" + moduleName + "ApplicationService appService) => _appService = appService;";

        stringFile = stringFile + @"
        /// <summary>
        /// Busca de " + moduleName + @" em formato de Grid.
        /// </summary>
        [HttpPost(" + "\"filter\"" + @")]
        [SwaggerResponse((int)HttpStatusCode.OK, " + "\"Dados de " + moduleName + " em formato de Grid.\"" + @", typeof(GridView<" + moduleName + @"GridDto>))]
        public async Task<IActionResult> FindByFilter(Filter filter, CancellationToken ct) => Ok(await _appService.FindByFilter(filter, ct));

        /// <summary>
        /// Busca de " + moduleName + @" através de um Id de entrada.
        /// </summary>
        [HttpGet(" + "\"{id:int}\"" + @")]
        [SwaggerResponse((int)HttpStatusCode.OK, " + "\"Dados do " + moduleName + " buscado.\"" + @", typeof(" + moduleName + @"GetDto))]
        public async Task<IActionResult> GetById(int id, CancellationToken ct) => Ok(await _appService.GetById(id, ct));

        /// <summary>
        /// Exclusão de " + moduleName + @" através de um Id de entrada.
        /// </summary>
        [HttpDelete(" + "\"{id:int}\"" + @")]
        [SwaggerResponse((int)HttpStatusCode.OK, " + $"\"{moduleName} excluído.\"" + @")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            await _appService.Delete(id, ct);
            return Ok();
        }

        /// <summary>
        /// Exclusão em massa de " + moduleName + @"s através de Ids de entrada.
        /// </summary>
        [HttpDelete(" + "\"massdelete\"" + @")]
        [SwaggerResponse((int)HttpStatusCode.OK, " + $"\"{moduleName} excluídos.\"" + @")]
        public async Task<IActionResult> MassDelete(IEnumerable<int> data, CancellationToken ct)
        {
            await _appService.Delete(data, ct);
            return Ok();
        }

        /// <summary>
        /// Inserção de " + moduleName + @" através de um DTO de entrada.
        /// </summary>
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, " + $"\"{moduleName} inserido com sucesso.\"" + @", typeof(int))]
        public async Task<IActionResult> Post(" + moduleName + @"PostDto dto, CancellationToken ct) => Ok(await _appService.Create(dto, ct));

        /// <summary>
        /// Edição de " + moduleName + @" existente através de um DTO de entrada.
        /// </summary>
        [HttpPut(" + "\"{id:int}\"" + @")]
        [SwaggerResponse((int)HttpStatusCode.OK, " + $"\"{moduleName} editado com sucesso.\"" + @")]
        public async Task<IActionResult> Put(int id, " + moduleName + @"PutDto dto, CancellationToken ct)
        {
            await _appService.Update(id, dto, ct);
            return Ok();
        }";

        stringFile = stringFile + "\r\n\t} \r\n}";

        return stringFile;
    }
}

