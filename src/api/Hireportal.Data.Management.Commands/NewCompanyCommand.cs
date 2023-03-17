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
    internal class NewCompanyCommand : IRequestHandler<NewCompanyRequest, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public NewCompanyCommand(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(NewCompanyRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Data.CompanyName))
            {
                return false;
            }
            var repository = unitOfWork.GetRepository<Company>();
            var conflict = await repository.Get(f => !f.IsDeleted && f.CompanyName == request.Data.CompanyName, cancellationToken);
            if (conflict is not null)
            {
                return false;
            }
            var entity = mapper.Map<Company>(request.Data);
            repository.Insert(entity);
            var result = await unitOfWork.SaveChanges(cancellationToken);
            return result > 0;
        }
    }
}
