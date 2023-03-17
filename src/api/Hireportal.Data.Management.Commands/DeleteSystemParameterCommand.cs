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
    internal class DeleteSystemParameterCommand : IRequestHandler<DeleteSystemParameterByIdRequest, bool>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteSystemParameterCommand(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeleteSystemParameterByIdRequest request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<SystemParameter>();
            var entity=await repository.Get(x=>x.Id==request.Id&&!x.IsDeleted,cancellationToken);
            if (entity == null)
            {
                return false;   
            }
            repository.Delete(entity);
            var result = await unitOfWork.SaveChanges(cancellationToken);
            return result > 0;
        }
    }
}
