using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Services.Authentication;
public class AuthenticationService : IAuthenticationService {
    public AuthenticationResult Login(string email, string password) {
        return new AuthenticationResult(
            UserId: Guid.NewGuid(),
            FirstName: "John",
            LastName: "Doe",
            Email: email,
            "Token");

    }

    public AuthenticationResult Register(string fistName, string lastName, string email, string password) {
        return new AuthenticationResult(
            UserId: Guid.NewGuid(),
            FirstName: fistName,
            LastName: lastName,
            Email: email,
            "Token");
    }
}
