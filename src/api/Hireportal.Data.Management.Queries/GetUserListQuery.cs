﻿using Hireportal.Data.Abstractions;
using Hireportal.Data.Request.Contracts;
using Hireportal.Data.Request.Queries;
using Hireportal.Entites.Profile;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hireportal.Data.Management.Queries
{
    internal class GetUserListQuery : IRequestHandler<GetUserRequest, List<UserListDto>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetUserListQuery(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public Task<List<UserListDto>> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<User>();
            return repository.GetAll<UserListDto>(f=>true,o=>o.Email,cancellationToken);
        }
    }
}
