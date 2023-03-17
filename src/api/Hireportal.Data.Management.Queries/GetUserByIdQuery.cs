using AutoMapper;
using Hireportal.Data.Abstractions;
using Hireportal.Data.Request.Contracts;
using Hireportal.Data.Request.Queries;
using Hireportal.Entites.Profile;
using MediatR;

namespace Hireportal.Data.Management.Queries
{
    internal class GetUserByIdQuery : IRequestHandler<GetUserByIdRequest, UserListDto>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetUserByIdQuery(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<UserListDto> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<User>();
            return await repository.Get<UserListDto>(f => !f.IsDeleted && f.Id == request.Id, cancellationToken);
        }
    }
}
