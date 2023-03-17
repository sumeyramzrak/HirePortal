using AutoMapper;
using Hireportal.Data.Abstractions;
using Hireportal.Data.Request.Queries;
using Hireportal.Entites.Profile;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireportal.Data.Management.Commands
{
    internal class NewCompanyUserCommand : IRequestHandler<NewCompanyUserRequest, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public NewCompanyUserCommand(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(NewCompanyUserRequest request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<CompanyUser>();
            var conflict = await repository.Get(f => !f.IsDeleted && f.UserId == request.Data.UserId, cancellationToken);
            if (conflict is not null)
            {
                return false;
            }
            var entity = mapper.Map<CompanyUser>(request.Data);
            repository.Insert(entity);
            var result = await unitOfWork.SaveChanges(cancellationToken);
            return result > 0;
        }
    }
}
