﻿using AutoMapper;
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
    public class EditLookupTypeCommand : IRequestHandler<EditLookupTypeRequest, bool>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        public EditLookupTypeCommand(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(EditLookupTypeRequest request, CancellationToken cancellationToken)
        {
            var repository = unitOfWork.GetRepository<LookUpType>();
            var entity = await repository.Get(f => f.Id == request.Data.Id, cancellationToken);
            if (entity is null)
            {
                return false;
            }
            var mapped = mapper.Map(request.Data, entity);
            repository.Update(mapped);
            var result = await unitOfWork.SaveChanges(cancellationToken);
            return result > 0;
        }
    }
}