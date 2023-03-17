using AutoMapper;
using Hireportal.Data.Abstractions;
using Hireportal.Data.Request.Contracts;
using Hireportal.Data.Request.Queries;
using Hireportal.Entites.Main;
using MediatR;
namespace Hireportal.Data.Management.Queries
{
    internal class GetLookupTypeByIdQuery : IRequestHandler<GetLookupTypeByIdRequest, LookupTypeDto>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetLookupTypeByIdQuery(IUnitOfWork unitOfWork ,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<LookupTypeDto> Handle(GetLookupTypeByIdRequest request, CancellationToken cancellationToken)
        {
            var repository=unitOfWork.GetRepository<LookUpType>();
            var entity=await repository.Get(f=>f.Id==request.Id,cancellationToken);
            if (entity == null)
            {
                return null;
            }
            var result=mapper.Map<LookupTypeDto>(entity);   
            return result;
        }
    }
}
