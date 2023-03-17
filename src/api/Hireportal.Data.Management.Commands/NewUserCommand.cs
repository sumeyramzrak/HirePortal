using AutoMapper;
using Hireportal.Common.Extensions;
using Hireportal.Data.Abstractions;
using Hireportal.Data.Request.Queries;
using Hireportal.Entites.Profile;
using MediatR;

namespace Hireportal.Data.Management.Commands
{
    internal class NewUserCommand : IRequestHandler<NewUserRequest, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public NewUserCommand(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<bool> Handle(NewUserRequest request, CancellationToken cancellationToken)
        {
            var repository=unitOfWork.GetRepository<User>();
            var conflict = await repository.Get(f => !f.IsDeleted && f.UserName == request.Data.UserName, cancellationToken);
            if(conflict is not null)
            {
                return false;
            }
            var entity=mapper.Map<User>(request.Data);
            entity.Password = request.Data.Password.CreateHash();
            repository.Insert(entity);
            var result=await unitOfWork.SaveChanges(cancellationToken);
            return result > 0;
        }
    }

}
