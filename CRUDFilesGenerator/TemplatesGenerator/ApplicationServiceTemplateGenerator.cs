public static class ApplicationServiceTemplateGenerator
{
    public static string WriteModelClass(string projectName, string featureName, string moduleName)
    {
        var stringFile = @"using Microsoft.EntityFrameworkCore;
using SMARAPD.Common.DTO;
using SMARAPD.Common.DTO.Generic;
using SMARAPD.Common.DTO.Suggestion;
using SMARAPD.Common.Exceptions;
using SMARAPD.Common.Infrastructure.ErrorMessage.Persistence.FilterExtension;
using SMARAPD.Common.Infrastructure.Persistence.FilterExtension;
using SMARAPD.Common.Resources;
using " + projectName + @"Crosscutting.DTO." + featureName + @"." + moduleName + @"Ctx;" + @"
using " + projectName + @"Domain.Entities." + featureName + @"." + moduleName + @"Ctx;" + @"
using " + projectName + @"Infrastructure.Persistence.Repository." + featureName + @"." + moduleName + @"Ctx.Interfaces;" + @"
using " + projectName + @"Infrastructure.Persistence.UnitOfWork." + featureName + @"." + moduleName + @"Ctx.Interfaces;" + @"
using " + projectName + @"Service.Mappers." + featureName + @"." + moduleName + @"Ctx;" + @"
using " + projectName + @"Service.Modules.Base;
using " + projectName + @"Service.Modules." + featureName + @"." + moduleName + @"Ctx.Interfaces;" + @"
using " + projectName + @"Service.Validations.Modules." + featureName + @"." + moduleName + @"Ctx;" + @"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace " + projectName + @"Service.Modules." + featureName + @"." + moduleName + @"Ctx" + @"
{";

        stringFile = stringFile + "\r\n\tpublic class " + moduleName + "ApplicationService : BaseApplicationService<I" + moduleName + "UnitOfWork, I" + moduleName + "Repository, " + moduleName + ">, I" + moduleName + "ApplicationService \r\n\t{\r\n";

        stringFile = stringFile + "\t\tprivate readonly string _funcName = \"" + moduleName + "\"; " + @"
        " + moduleName + @"Mapper _mapper;
        " + moduleName + "Validator _validator; ";

        stringFile = stringFile + @"public " + moduleName + @"ApplicationService(I" + moduleName + @"UnitOfWork uow, " + moduleName + @"Mapper mapper, " + moduleName + @"Validator validator) : base(uow)
        {
            _mapper = mapper;
            _validator = validator;
        }";

        stringFile = stringFile + "\r\n\t\t" + @"public async Task<GridView<" + moduleName + @"GridDto>> FindByFilter(Filter filter, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            VerifyExists(filter);

            var queryDto = _uow." + moduleName + @"Repository.GetAllReadOnly()
                .Select(x => new " + moduleName + @"GridDto
                {
                   
                });

            VerifyExists(queryDto, _funcName);

            queryDto = queryDto.FindByFilter(filter, filter.pageNumber, filter.pageSize, out int pageCount);

            return new GridView<" + moduleName + @"GridDto> { dataList = await queryDto.ToListAsync(ct), pageCount = pageCount };
        }

        public async Task<" + moduleName + @"GetDto> GetById(int id, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            var " + char.ToLower(moduleName[0]) + moduleName.Substring(1) + @" = await _uow." + moduleName + @"Repository.GetByIdAsync(id);

            VerifyExists(ppra, _funcName);

            return _mapper.MapearEntidade(" + char.ToLower(moduleName[0]) + moduleName.Substring(1) + @");
        }

        public async Task<int> Create(" + moduleName + @"PostDto dto, CancellationToken ct = default)
        {
            "+ moduleName + " " + char.ToLower(moduleName[0]) + moduleName.Substring(1) + @" = _mapper.MapearEntidade(dto);

            await Validate(" + char.ToLower(moduleName[0]) + moduleName.Substring(1) + @", _validator);

            _uow." + moduleName + @"Repository.Add(" + char.ToLower(moduleName[0]) + moduleName.Substring(1) + @");

            await _uow.CommitAsync(true);

            return " + char.ToLower(moduleName[0]) + moduleName.Substring(1) + @".Id;
        }

        public async Task Update(int id, " + moduleName + @"PutDto dto, CancellationToken ct = default)
        {
            " + moduleName + @" " + char.ToLower(moduleName[0]) + moduleName.Substring(1) + @"Db = await _uow." + moduleName + @"Repository.GetByIdAsync(id);

            VerifyExists(" + char.ToLower(moduleName[0]) + moduleName.Substring(1) + @"Db, string.Format(CommonMessages.InvalidValue, " + $"\"{moduleName}\"" + @"), true);

            " + char.ToLower(moduleName[0]) + moduleName.Substring(1) + @"Db = _mapper.MapearEntidade(" + char.ToLower(moduleName[0]) + moduleName.Substring(1) + @"Db, dto);

            await Validate(" + char.ToLower(moduleName[0]) + moduleName.Substring(1) + @"Db, _validator);

            await _uow.CommitAsync(true);
        }

        public async Task Delete(int id, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            var " + char.ToLower(moduleName[0]) + moduleName.Substring(1) + @" = await _uow." + moduleName + @"Repository.GetByIdAsync(id);
            VerifyExists(" + char.ToLower(moduleName[0]) + moduleName.Substring(1) + @", _funcName);

            _uow." + moduleName + @"Repository.Delete(" + char.ToLower(moduleName[0]) + moduleName.Substring(1) + @");
            await _uow.CommitAsync(true);
        }

        public async Task Delete(IEnumerable<int> ids, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            var data = await _uow." + moduleName + @"Repository.GetAll().Where(x => ids.Contains(x.Id)).ToListAsync();
            VerifyExists(data, _funcName);

            _uow." + moduleName + @"Repository.MassDelete(data);
            await _uow.CommitAsync(true);
        }

        public async Task<SuggestionView<GenericSuggestionDto>> GetSuggestion(string busca, int pageSize, dynamic obj, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var query = _uow." + moduleName + @"Repository.GetAllReadOnly()
                .Where(x => (x.Id + " + $"\" - \"" + @" + x.Nome).Contains(busca));

            var result = query.Select(x => new GenericSuggestionDto
            {
                Id = x.Id,
                Descricao = x.Nome,
                Exibicao = x.Id + " + $"\" - \"" + @" + x.Nome
            });

            int dataCount = await result.CountAsync(cancellationToken);
            result = result.Take(pageSize);

            var suggestionView = new SuggestionView<GenericSuggestionDto> { dataCount = dataCount, dataList = await result.ToListAsync(cancellationToken) };

            return suggestionView;
        }

        public GridView<" + moduleName + @"GridLookupDto> FindByFilterLookup(Filter filter, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            VerifyExists(filter);

            int pageCount;

            var query = _uow." + moduleName + @"Repository.GetAllReadOnly();

            var queryDto = query.Select(x => new " + moduleName + @"GridLookupDto()
            {

            });

            queryDto = queryDto.FindByFilter(filter, filter.pageNumber, filter.pageSize, out pageCount);

            var gridView = new GridView<" + moduleName + @"GridLookupDto> { dataList = queryDto.ToList(), pageCount = pageCount };

            return gridView;
        }";

        stringFile = stringFile + "\r\n\t} \r\n}";

        return stringFile;
    }

    public static string WriteInterfaceModelClass(string projectName, string featureName, string moduleName)
    {
        var stringFile = @"using SMARAPD.Common.DTO;
using SMARAPD.Common.DTO.Generic;
using SMARAPD.Common.DTO.Suggestion;
using SMARAPD.Common.Infrastructure.Persistence.FilterExtension;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using " + projectName + @"Crosscutting.DTO." + featureName + @"." + moduleName + @"Ctx;" + @"

namespace " + projectName + @"Service.Modules." + featureName + @"." + moduleName + @"Ctx.Interfaces" + @"
{";

        stringFile = stringFile + "\r\n\tpublic interface I" + moduleName + "ApplicationService \r\n\t{\r\n" + @"
        Task<GridView<" + moduleName + @"GridDto>> FindByFilter(Filter filter, CancellationToken ct = default);

        Task<" + moduleName + @"GetDto> GetById(int id, CancellationToken ct);

        Task<int> Create(" + moduleName + @"PostDto dto, CancellationToken ct = default);

        Task Update(int id, " + moduleName + @"PutDto dto, CancellationToken ct = default);

        Task Delete(int id, CancellationToken ct = default);

        Task Delete(IEnumerable<int> ids, CancellationToken ct = default);

        Task<SuggestionView<GenericSuggestionDto>> GetSuggestion(string busca, int pageSize, dynamic obj, CancellationToken cancellationToken = default);

        GridView<" + moduleName + @"GridLookupDto> FindByFilterLookup(Filter filter, CancellationToken ct = default);

";

        stringFile = stringFile + "\r\n\t} \r\n}";

        return stringFile;
    }
}

