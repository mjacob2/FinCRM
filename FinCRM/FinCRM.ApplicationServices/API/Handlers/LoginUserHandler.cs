using AutoMapper;
using FinCRM.ApplicationServices.API.Domain;
using FinCRM.DataAccess.CQRS;
using FinCRM.DataAccess.CQRS.Commands;
using MediatR;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace FinCRM.ApplicationServices.API.Handlers
{
    internal class LoginUserHandler : IRequestHandler<ValidateUserRequest, ValidateUserResponse>
    {


        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public LoginUserHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<ValidateUserResponse> Handle(ValidateUserRequest request, CancellationToken cancellationToken)
        {

            //mamy w kontekście aktualnie zalogowanego Usera
            var loggedUserRole = request.LoggedUserRole;
            var loggedUserId = request.LoggedUserId;

            // stwórz losowy saltString
            string salt = Hasher.GetSalt();
            //przypisz Salt do modelu
            request.Salt = salt;

            //zahashuj hasło podane przez użytkownika z użyciem Salt
            var passwordHashed = Hasher.HashPassword(request.Password, salt);
            //przypisz zahashowane hasło do modelu
            request.Password = passwordHashed;



            var user = this.mapper.Map<DataAccess.Entities.User>(request);
            user.Password = request.Password;

            var command = new LoginUserCommand() { Parameter = user };
            var userFromDb = await this.commandExecutor.Execute(command);
            return new ValidateUserResponse()
            {
                Data = this.mapper.Map<Domain.Models.User>(userFromDb)
            };
        }



    }
}