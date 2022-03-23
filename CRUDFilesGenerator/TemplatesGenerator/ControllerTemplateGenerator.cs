public static class ControllerTemplateGenerator
{
    public static string WriteModelClass(string projectName, string featureName, string moduleName)
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
using " + projectName + @"Service.Modules." + featureName + @"." + moduleName + @"Ctx.Interfaces;" + @"
using " + projectName + @"Crosscutting.DTO." + featureName + @"." + moduleName + @"Ctx;" + @"


namespace " + projectName + @"Interface.Controllers." + featureName + @"." + moduleName + @"Ctx" + @"
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
        [HttpGet(" + "\"{ id:int}\"" + @")]
        [SwaggerResponse((int)HttpStatusCode.OK, " + "\"Dados do " + moduleName + " buscado.\"" + @", typeof(" + moduleName + @"GetDto))]
        public async Task<IActionResult> GetById(int id, CancellationToken ct) => Ok(await _appService.GetById(id, ct));

        /// <summary>
        /// Exclusão de " + moduleName + @" através de um Id de entrada.
        /// </summary>
        [HttpDelete(" + "\"{ id:int}\"" + @")]
        [SwaggerResponse((int)HttpStatusCode.OK, " + moduleName + " excluído." + @")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            await _appService.Delete(id, ct);
            return Ok();
        }

        /// <summary>
        /// Exclusão em massa de " + moduleName + @"s através de Ids de entrada.
        /// </summary>
        [HttpDelete(" + "\"massdelete\"" + @")]
        [SwaggerResponse((int)HttpStatusCode.OK, " + moduleName + " excluídos." + @")]
        public async Task<IActionResult> MassDelete(IEnumerable<int> data, CancellationToken ct)
        {
            await _appService.Delete(data, ct);
            return Ok();
        }

        /// <summary>
        /// Inserção de um novo " + moduleName + @" através de um DTO de entrada.
        /// </summary>
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, " + "\"Ppra inserido com sucesso.\"" + @", typeof(int))]
        public async Task<IActionResult> Post(" + moduleName + @"PostDto dto, CancellationToken ct) => Ok(await _appService.Create(dto, ct));

        /// <summary>
        /// Busca de " + moduleName + @" por suggestion
        /// </summary>
        [HttpGet(" + "\"suggestion\"" + @")]
        [SwaggerResponse((int)HttpStatusCode.OK, " + "\"Dados do Ppra em formato de suggestion.\"" + @", typeof(SuggestionView<GenericSuggestionDto>))]
        public async Task<IActionResult> GetSuggestion([FromUri] string busca, [FromUri] int pageSize = 10, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var parameters = HttpContext.Request.Query[" + "\"parameters\"" + @"].ToString();
            dynamic obj = JsonConvert.DeserializeObject(" + "\"parameters\"" + @");

            return Ok(await _appService.GetSuggestion(busca, pageSize, obj, cancellationToken));
        }

        /// <summary>
        /// Edição de um " + moduleName + @" existente através de um DTO de entrada.
        /// </summary>
        [HttpPut(" + "\"{ id:int}\"" + @")]
        [SwaggerResponse((int)HttpStatusCode.OK, " + "\"Ppra editado com sucesso.\"" + @")]
        public async Task<IActionResult> Put(int id, " + moduleName + @"PutDto dto, CancellationToken ct)
        {
            await _appService.Update(id, dto, ct);
            return Ok();
        }

        [HttpPost]
        [Route(" + "\"lookup\"" + @")]
        [SwaggerResponse((int)HttpStatusCode.OK, " + "\"Dados do Ppra em formato de Grid.\"" + @", typeof(GridView<" + moduleName + @"GridDto>))]
        public IActionResult GetByFilterLookup(Filter filter, CancellationToken ct) => Ok(_appService.FindByFilterLookup(filter, ct)); ";

        stringFile = stringFile + "\r\n\t} \r\n}";

        return stringFile;
    }
}

