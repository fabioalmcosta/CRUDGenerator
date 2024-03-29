﻿public static class ApplicationServiceTemplateGenerator
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

        stringFile = stringFile + "\r\n\t\t" + @"public async Task<GridView<" + moduleName + @"GridDto>> FindByFilterAsync(Filter filter, CancellationToken ct = default)
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

        public async Task<" + moduleName + @"GetDto> GetByIdAsync(int id, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            var " + char.ToLower(moduleName[0]) + moduleName.Substring(1) + @" = await _uow." + moduleName + @"Repository.GetByIdAsync(id);

            VerifyExists(" + char.ToLower(moduleName[0]) + moduleName.Substring(1) + @", _funcName);

            return _mapper.MapearEntidade(" + char.ToLower(moduleName[0]) + moduleName.Substring(1) + @");
        }

        public async Task<int> CreateAsync(" + moduleName + @"PostDto dto, CancellationToken ct = default)
        {
            " + moduleName + " " + char.ToLower(moduleName[0]) + moduleName.Substring(1) + @" = _mapper.MapearEntidade(dto);

            await Validate(" + char.ToLower(moduleName[0]) + moduleName.Substring(1) + @", _validator);

            _uow." + moduleName + @"Repository.Add(" + char.ToLower(moduleName[0]) + moduleName.Substring(1) + @");

            await _uow.CommitAsync(true);

            return " + char.ToLower(moduleName[0]) + moduleName.Substring(1) + @".Id;
        }

        public async Task UpdateAsync(int id, " + moduleName + @"PutDto dto, CancellationToken ct = default)
        {
            " + moduleName + @" " + char.ToLower(moduleName[0]) + moduleName.Substring(1) + @"Db = await _uow." + moduleName + @"Repository.GetByIdAsync(id);

            VerifyExists(" + char.ToLower(moduleName[0]) + moduleName.Substring(1) + @"Db, string.Format(CommonMessages.InvalidValue, " + $"\"{moduleName}\"" + @"), true);

            " + char.ToLower(moduleName[0]) + moduleName.Substring(1) + @"Db = _mapper.MapearEntidade(" + char.ToLower(moduleName[0]) + moduleName.Substring(1) + @"Db, dto);

            await Validate(" + char.ToLower(moduleName[0]) + moduleName.Substring(1) + @"Db, _validator);

            await _uow.CommitAsync(true);
        }

        public async Task DeleteAsync(int id, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            var " + char.ToLower(moduleName[0]) + moduleName.Substring(1) + @" = await _uow." + moduleName + @"Repository.GetByIdAsync(id);
            VerifyExists(" + char.ToLower(moduleName[0]) + moduleName.Substring(1) + @", _funcName);

            _uow." + moduleName + @"Repository.Delete(" + char.ToLower(moduleName[0]) + moduleName.Substring(1) + @");
            await _uow.CommitAsync(true);
        }

        public async Task DeleteAsync(IEnumerable<int> ids, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            var data = await _uow." + moduleName + @"Repository.GetAll().Where(x => ids.Contains(x.Id)).ToListAsync();
            VerifyExists(data, _funcName);

            _uow." + moduleName + @"Repository.MassDelete(data);
            await _uow.CommitAsync(true);
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
            Task<GridView<" + moduleName + @"GridDto>> FindByFilterAsync(Filter filter, CancellationToken ct = default);

            Task<" + moduleName + @"GetDto> GetByIdAsync(int id, CancellationToken ct);

            Task<int> CreateAsync(" + moduleName + @"PostDto dto, CancellationToken ct = default);

            Task UpdateAsync(int id, " + moduleName + @"PutDto dto, CancellationToken ct = default);

            Task DeleteAsync(int id, CancellationToken ct = default);

            Task DeleteAsync(IEnumerable<int> ids, CancellationToken ct = default);
";

        stringFile = stringFile + "\r\n\t} \r\n}";

        return stringFile;
    }
}

