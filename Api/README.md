## Database migrations

In Infrastructure project,
run `dotnet ef migrations add InitialCreate -s ../Api`
then run `dotnet ef database update -s ../Api`
for create the migration and update the database

## Run

In Api project, run `dotnet run`, the project will be running in [localhost](https://localhost:7170/).

# Authentication

This project uses [JWT Token](https://jwt.io/) for authentication, so make sure that
before start to make requests to the api, you have to logged in using
[Auth Endpoint](https://localhost:7170/api/User/Authenticate) and use the token
that endpoint provides. Then you can add the token to your request headers, or 
if you are using `Swagger UI`, you can use the `Authorize` button that is at the top right
of the page.

## Sedding

The app uses [EF Core date seeding](https://docs.microsoft.com/en-us/ef/core/modeling/data-seeding)
for register default values to the database (this is because the project scope).

## Default values

The app have two users by default: `Admin` and `User`, each one have their authorities.

**Admin user**:
`username`: admin 
`password`: admin

**Regular user**:
`username`: user
`password`: 1234

## API documentation

This project uses [Swagger](https://swagger.io/docs/) for documentation, when running the app
you can
access to the [JSON API DOCs](https://localhost:7170/swagger/v1/swagger.json) or
[Swagger UI](https://localhost:7170/swagger/index.html) as well.