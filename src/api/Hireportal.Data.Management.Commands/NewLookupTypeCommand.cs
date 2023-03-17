using AutoMapper;
using Hireportal.Data.Abstractions;
using Hireportal.Data.Request.Queries;
using Hireportal.Entites.Main;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireportal.Data.Management.Commands
{
    internal class NewLookupTypeCommand : IRequestHandler<NewLookupTypeRequest, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public NewLookupTypeCommand(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(NewLookupTypeRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Data.Name))
            {
                return false;
            }
            var repository = unitOfWork.GetRepository<LookUpType>();
            var conflict = await repository.Get(f => !f.IsDeleted && f.Name == request.Data.Name, cancellationToken);
            if (conflict is not null)
            {
                return false;
            }
            var entity = mapper.Map<LookUpType>(request.Data);
            repository.Insert(entity);
            var result = await unitOfWork.SaveChanges(cancellationToken);
            return result > 0;
        }
    }
}
