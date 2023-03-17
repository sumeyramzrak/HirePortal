using AutoMapper;
using Hireportal.Data.Abstractions;
using Hireportal.Data.Request.Contracts;
using Hireportal.Data.Request.Queries;
using Hireportal.Entites.CompanyManager;
using MediatR;

namespace Hireportal.Data.Management.Queries
{
    internal class GetByIdPermissionQuery : IRequestHandler<GetPermissionByIdRequest, PermissionDto>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetByIdPermissionQuery(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<PermissionDto> Handle(GetPermissionByIdRequest request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<Permission>();
            return await repository.Get<PermissionDto>(f => !f.IsDeleted && f.Id == request.Id, cancellationToken);
        }
    }
}
