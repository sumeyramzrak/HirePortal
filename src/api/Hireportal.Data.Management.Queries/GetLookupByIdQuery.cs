using AutoMapper;
using Hireportal.Data.Abstractions;
using Hireportal.Data.Request.Contracts;
using Hireportal.Data.Request.Queries;
using Hireportal.Entites.Main;
using MediatR;


namespace Hireportal.Data.Management.Queries
{
    internal class GetLookupByIdQuery : IRequestHandler<GetLookupByIdRequest, LookUpDto>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetLookupByIdQuery(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<LookUpDto> Handle(GetLookupByIdRequest request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<LookUp>();
            return await repository.Get<LookUpDto>(f => !f.IsDeleted && f.Id == request.Id, cancellationToken);
        }
    }
}
