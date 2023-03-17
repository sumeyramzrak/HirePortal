using AutoMapper;
using Hireportal.Data.Abstractions;
using Hireportal.Data.Request.Contracts;
using Hireportal.Data.Request.Queries;
using Hireportal.Entites.Main;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireportal.Data.Management.Queries
{
    internal class GetSystemParameterListQuery : IRequestHandler<SystemParameterListRequest, List<SystemParameterDto>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetSystemParameterListQuery(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public Task<List<SystemParameterDto>> Handle(SystemParameterListRequest request, CancellationToken cancellationToken)
        {
            var repository=unitOfWork.GetRepository<SystemParameter>();
            return repository.GetAll<SystemParameterDto>(u=>!u.IsDeleted,u=>u.Key,cancellationToken);
        }
    }
}
