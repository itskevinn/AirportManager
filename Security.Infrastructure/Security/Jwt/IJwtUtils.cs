namespace Security.Infrastructure.Security.Jwt;

public interface IJwtUtils<in T>
{
    /// <summary>
    /// Method to generate the JWT token for the signed user.
    /// The given entity must have an "Id" property
    /// </summary>
    /// <param name="userDto"></param>
    /// <returns></returns>
    string GenerateJwtToken(T userDto);

    /// <summary>
    /// Method that validates the given JWT token and returns the id of the user 
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    Guid ValidateJwtToken(string token);
}