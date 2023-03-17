using AutoMapper;
using Hireportal.Data.Abstractions;
using Hireportal.Data.Request.Contracts;
using Hireportal.Data.Request.Queries;
using Hireportal.Entites.Main;
using MediatR;
namespace Hireportal.Data.Management.Queries
{
    public class GetSystemParameterByIdQuery : IRequestHandler<GetSystemParameterByIdRequest, SystemParameterDto>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetSystemParameterByIdQuery(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<SystemParameterDto> Handle(GetSystemParameterByIdRequest request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<SystemParameter>();
            var entity = await repository.Get(s => s.Id == request.Id, cancellationToken);
            if (entity is null)
            {
                return null;
            }
            var result = mapper.Map<SystemParameterDto>(entity);
            return result;
        }
    }
}
