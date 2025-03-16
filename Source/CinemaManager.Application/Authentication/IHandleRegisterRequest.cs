using CinemaManger.Contracts.Authentication;

namespace CinemaManager.Application.Authentication
{
    public interface IHandleRegisterRequest
    {
        AuthenticationResponse Handle(RegisterRequest request);
    }
}