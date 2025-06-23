using BuberDinner.Application.Common.Interfaces.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Services.Authentication;
public class AuthenticationService : IAuthenticationService {

    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator) {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Login(string email, string password) {

        // Check if the user exists in the database

        return new AuthenticationResult(
            UserId: Guid.NewGuid(),
            FirstName: "John",
            LastName: "Doe",
            Email: email,
            "Token");

    }

    public AuthenticationResult Register(string fistName, string lastName, string email, string password) {
        // Check if the user already exists in the database

        // If not, create a new user in the database

        // Generate a token for the new user
        Guid userId = Guid.NewGuid();
        string token = _jwtTokenGenerator.GenerateToken(userId, fistName, lastName);

        return new AuthenticationResult(
            userId,
            fistName,
            lastName,
            email,
            token);
    }
}
