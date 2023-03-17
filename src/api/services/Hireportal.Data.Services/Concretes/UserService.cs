using Hireportal.Data.Request.Contracts;
using Hireportal.Data.Request.Queries;
using Hireportal.Data.Services.Abstractions;
using MediatR;

namespace Hireportal.Data.Services.Concretes
{
    internal class UserService : IUserService
    {
        private readonly IMediator mediator;

        public UserService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public Task<bool> CreateUser(NewUserRequestDto data, CancellationToken cancellationToken)
        {
            return mediator.Send(new NewUserRequest(data), cancellationToken);
        }

        public Task<bool> DeleteUserById(Guid id, CancellationToken cancellationToken)
        {
            return mediator.Send(new DeleteUserByIdRequest(id), cancellationToken);
        }

        public Task<UserListDto> GetUserById(Guid id, CancellationToken cancellationToken)
        {
            return mediator.Send(new GetUserByIdRequest(id), cancellationToken);
        }

        public Task<List<UserListDto>> GetUsers(CancellationToken cancellationToken)
        {
            return mediator.Send(new GetUserRequest(), cancellationToken);
        }

        public Task<bool> UpdateUser(EditUserRequestDto data, CancellationToken cancellationToken)
        {
            return mediator.Send(new EditUserRequest(data), cancellationToken);
        }
    }

}
