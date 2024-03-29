﻿public static class ControllerTemplateGenerator
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
        public async Task<IActionResult> FindByFilterAsync(Filter filter, CancellationToken ct) => Ok(await _appService.FindByFilterAsync(filter, ct));

        /// <summary>
        /// Busca de " + moduleName + @" através de um Id de entrada.
        /// </summary>
        [HttpGet(" + "\"{id:int}\"" + @")]
        [SwaggerResponse((int)HttpStatusCode.OK, " + "\"Dados do " + moduleName + " buscado.\"" + @", typeof(" + moduleName + @"GetDto))]
        public async Task<IActionResult> GetByIdAsync(int id, CancellationToken ct) => Ok(await _appService.GetByIdAsync(id, ct));

        /// <summary>
        /// Exclusão de " + moduleName + @" através de um Id de entrada.
        /// </summary>
        [HttpDelete(" + "\"{id:int}\"" + @")]
        [SwaggerResponse((int)HttpStatusCode.OK, " + $"\"{moduleName} excluído.\"" + @")]
        public async Task<IActionResult> DeleteAsync(int id, CancellationToken ct)
        {
            await _appService.DeleteAsync(id, ct);
            return Ok();
        }

        /// <summary>
        /// Exclusão em massa de " + moduleName + @"s através de Ids de entrada.
        /// </summary>
        [HttpDelete(" + "\"massdelete\"" + @")]
        [SwaggerResponse((int)HttpStatusCode.OK, " + $"\"{moduleName} excluídos.\"" + @")]
        public async Task<IActionResult> MassDeleteAsync(IEnumerable<int> data, CancellationToken ct)
        {
            await _appService.DeleteAsync(data, ct);
            return Ok();
        }

        /// <summary>
        /// Inserção de " + moduleName + @" através de um DTO de entrada.
        /// </summary>
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, " + $"\"{moduleName} inserido com sucesso.\"" + @", typeof(int))]
        public async Task<IActionResult> PostAsync(" + moduleName + @"PostDto dto, CancellationToken ct) => Ok(await _appService.CreateAsync(dto, ct));

        /// <summary>
        /// Edição de " + moduleName + @" existente através de um DTO de entrada.
        /// </summary>
        [HttpPut(" + "\"{id:int}\"" + @")]
        [SwaggerResponse((int)HttpStatusCode.OK, " + $"\"{moduleName} editado com sucesso.\"" + @")]
        public async Task<IActionResult> PutAsync(int id, " + moduleName + @"PutDto dto, CancellationToken ct)
        {
            await _appService.UpdateAsync(id, dto, ct);
            return Ok();
        }";

        stringFile = stringFile + "\r\n\t} \r\n}";

        return stringFile;
    }
}

