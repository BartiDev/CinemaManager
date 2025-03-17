using CinemaManager.Application.Common.Interfaces.Authentication;
using CinemaManager.Application.Common.Interfaces.Persistance;
using CinemaManager.Domain.User;
using CinemaManger.Contracts.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManager.Application.Authentication
{
    public class HandleRegisterRequest : IHandleRegisterRequest
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public HandleRegisterRequest(IUserRepository userRepository, 
            IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public AuthenticationResponse Handle(RegisterRequest request)
        {
            if (_userRepository.GetUserByEmail(request.Email) is not null)
            {
                throw new InvalidOperationException();
            }

            var newUser = User.CreateUser(request.FirstName,
                request.LastName,
                request.Email,
                request.Password);

            _userRepository.Add(newUser);

            string token = _jwtTokenGenerator.GenerateToken(newUser);

            return new AuthenticationResponse(
                newUser,
                token);
        }
    }
}
