Using Refresh Token in Asp.net core Web API project

Learn How to implement refresh token in asp.net core web api project along with its benefits

What is Refresh Token?

A refresh token is a special token that lets the user to refresh the access token without asking the user to login again. A refresh token will be generated with expiry time until that the user can make request for getting a new access token with the refresh token.

Benefits of Refresh Token

The benefits of including refresh token in your project includes

Uninterrupted User Experience:

Usage of refresh token extends the session duration of user and prevents unnecessary reauthentication. For example, if an access token is only valid for 10 minutes, but the user is on the application for 15 minutes, the session may abruptly terminate. This is not ideal and leads to poor user experience. Usage of refresh token is a better approach, which enables new access tokens to be issued without a delay or additional effort

Improved Security:

The use of refresh token makes it feasible to short the lifespan of access tokens. Since the access tokens are used for accessing APIs, any legitimate user that possesses it is considered authenticated without any additional identification. The longer the access token remains valid, the higher the risk of it becoming stolen. Pairing long duration of refresh tokens and short duration of access tokens enhances security.
