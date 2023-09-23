
using Paperboy.Web.Models;
using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Api;
using IntelliTect.Coalesce.Api.Controllers;
using IntelliTect.Coalesce.Api.DataSources;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Mapping.IncludeTrees;
using IntelliTect.Coalesce.Models;
using IntelliTect.Coalesce.TypeDefinition;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Paperboy.Web.Api
{
    [Route("api/ApplicationUser")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class ApplicationUserController
        : BaseApiController<Paperboy.Data.Models.ApplicationUser, ApplicationUserDtoGen, Paperboy.Data.AppDbContext>
    {
        public ApplicationUserController(CrudContext<Paperboy.Data.AppDbContext> context) : base(context)
        {
            GeneratedForClassViewModel = context.ReflectionRepository.GetClassViewModel<Paperboy.Data.Models.ApplicationUser>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<ApplicationUserDtoGen>> Get(
            int id,
            DataSourceParameters parameters,
            IDataSource<Paperboy.Data.Models.ApplicationUser> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<ApplicationUserDtoGen>> List(
            ListParameters parameters,
            IDataSource<Paperboy.Data.Models.ApplicationUser> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<Paperboy.Data.Models.ApplicationUser> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<ApplicationUserDtoGen>> Save(
            [FromForm] ApplicationUserDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<Paperboy.Data.Models.ApplicationUser> dataSource,
            IBehaviors<Paperboy.Data.Models.ApplicationUser> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<ApplicationUserDtoGen>> Delete(
            int id,
            IBehaviors<Paperboy.Data.Models.ApplicationUser> behaviors,
            IDataSource<Paperboy.Data.Models.ApplicationUser> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);
    }
}
