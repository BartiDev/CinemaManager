using CinemaManager.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManger.Contracts.Authentication
{
    public record AuthenticationResponse(
        User user,
        string Token);
}
