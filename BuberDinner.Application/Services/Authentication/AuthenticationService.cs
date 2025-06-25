using BuberDinner.Api.Common.Exceptions;
using BuberDinner.Application.Common.Exceptions;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Services.Authentication;
public class AuthenticationService : IAuthenticationService {

    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository) {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Login(string email, string password) {

        // Check if the user exists in the database
        if (_userRepository.GetUserByEmail(email) is not User user) {
            throw new Exception("Invalid credentials");
        }

        // Check if the password is correct
        if (user.Password != password) {
            throw new Exception("Invalid credentials");
        }

        // Generate a token for the user
        string token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);

    }

    public AuthenticationResult Register(string fistName, string lastName, string email, string password) {
        // Check if the user already exists in the database
        if (_userRepository.GetUserByEmail(email) is not null) {
            throw new DuplicateEmailException();
        }

        // If not, create a new user in the database
        var user = new User { FirstName = fistName, LastName = lastName, Email = email, Password = password };

        _userRepository.AddUser(user);

        // Generate a token for the new user
        string token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}
