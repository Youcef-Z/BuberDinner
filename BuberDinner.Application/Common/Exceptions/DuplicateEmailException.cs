using System.Net;

namespace BuberDinner.Application.Common.Exceptions;

public class DuplicateEmailException : Exception, IServiceException {

    public string ErrorMessage => "Invalid Credentials";

    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
}
