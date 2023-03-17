using AutoMapper;
using Hireportal.Common.Extensions;
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
    internal class RegisterUserCommand : IRequestHandler<RegisterUserRequest, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public RegisterUserCommand(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<bool> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<User>();
            var existingUser = await repository.Get(f => f.Email == request.Data.Email, cancellationToken);
            if (existingUser != null)
            {
                return false;
            }
            var entity = mapper.Map<User>(request.Data);
            entity.Password = request.Data.Password.CreateHash();
            entity.VerificationId = Guid.NewGuid().ToString();
            repository.Insert(entity);
            var result = await unitOfWork.SaveChanges(cancellationToken);
            return result > 0;
        }
    }
}
