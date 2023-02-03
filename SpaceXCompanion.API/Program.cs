using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SpaceXCompanion.API.Helpers;
using SpaceXCompanion.API.Models;
using SpaceXCompanion.API.Models.Launches;

#region Constants

const string SpaceXAPIV4ClientName = "SpacexDataV4";
const string SpaceXAPIV5ClientName = "SpacexDataV5";

#endregion

#region Build & Configuration

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient(SpaceXAPIV4ClientName, client =>
{
    var baseAddres = builder.Configuration.GetSection($"HttpClients:{SpaceXAPIV4ClientName}:BaseAddress").Value;
    client.BaseAddress = new Uri(baseAddres ?? "");
});

builder.Services.AddHttpClient(SpaceXAPIV5ClientName, client =>
{
    var baseAddres = builder.Configuration.GetSection($"HttpClients:{SpaceXAPIV5ClientName}:BaseAddress").Value;
    client.BaseAddress = new Uri(baseAddres ?? "");
});

builder.Services.AddScoped<IExternalRequestHelper, ExternalRequestHelper>();

var app = builder.Build();

#endregion

#region Launches

app.MapGet("api/launches", 
    async ([FromServices] IExternalRequestHelper externalRequestHelper) =>
    {
        try
        {
            var result = await externalRequestHelper
                .ExecuteRequest(HttpMethod.Get, SpaceXAPIV5ClientName, "launches");

            if (!result.Response.IsSuccessStatusCode)
                return Results.BadRequest(new
                {
                    success = false,
                    message = "Some error has occurred when requesting for the SpaceX launches data from the API."
                });
        
            var launches = JsonConvert.DeserializeObject<Launch[]>(result.Content);
            
            return Results.Ok(new
            {
                success = true,
                message = "SpaceX launches data successfully recovered from the API.",
                launches
            });
        }
        catch (Exception)
        {
            return Results.StatusCode(500);
        }
    });

app.MapGet("api/launches/{id}", 
    async ([FromServices] IExternalRequestHelper externalRequestHelper, string id) =>
    {
        try
        {
            if (string.IsNullOrEmpty(id)) return Results.BadRequest(new
            {
                success = false,
                message = "The launch ID must be informed."
            }); 
            
            var result = await externalRequestHelper
                .ExecuteRequest(HttpMethod.Get, SpaceXAPIV5ClientName, $"launches/{id}");

            if (!result.Response.IsSuccessStatusCode)
                return Results.BadRequest(new
                {
                    success = false,
                    message = "Some error has occurred when requesting for the SpaceX launch data from the API."
                });
        
            var launch = JsonConvert.DeserializeObject<Launch>(result.Content);
            
            return Results.Ok(new
            {
                success = true,
                message = "SpaceX launch data successfully recovered from the API.",
                launch
            });
        }
        catch (Exception)
        {
            return Results.StatusCode(500);
        }
    });

app.MapGet("api/launches/options/{option}", 
    async ([FromServices] IExternalRequestHelper externalRequestHelper, string option) =>
    {
        try
        {
            if (option is not ("latest" or "next" or "past")) return Results.BadRequest(new
            {
                success = false,
                message = "No valid option informed for filtering launch data. Must be 'latest', 'next' or 'past'."
            }); 
        
            var result = await externalRequestHelper
                .ExecuteRequest(HttpMethod.Get, SpaceXAPIV5ClientName, $"launches/{option}");

            if (!result.Response.IsSuccessStatusCode)
                return Results.BadRequest(new
                {
                    success = false,
                    message = $"Some error has occurred when requesting for the SpaceX {option} launch data from the API."
                });

            if (option is not "past")
            {
                var launch = JsonConvert.DeserializeObject<Launch>(result.Content);
        
                return Results.Ok(new
                {
                    success = true,
                    message = $"SpaceX {option} launch data successfully recovered from the API.",
                    launch
                });
            }
            
            var launches = JsonConvert.DeserializeObject<Launch[]>(result.Content);
        
            return Results.Ok(new
            {
                success = true,
                message = "SpaceX launches data successfully recovered from the API.",
                launches
            });
        }
        catch (Exception)
        {
            return Results.StatusCode(500);
        }
    });

#endregion

#region Landpads

app.MapGet("api/landpads", 
    async ([FromServices] IExternalRequestHelper externalRequestHelper) =>
    {
        try
        {
            var result = await externalRequestHelper
                .ExecuteRequest(HttpMethod.Get, SpaceXAPIV4ClientName, "landpads");

            if (!result.Response.IsSuccessStatusCode)
                return Results.BadRequest(new
                {
                    success = false,
                    message = "Some error has occurred when requesting for the SpaceX landpads data from the API."
                });
        
            var landpads = JsonConvert.DeserializeObject<Landpad[]>(result.Content);
            
            return Results.Ok(new
            {
                success = true,
                message = "SpaceX landpads data successfully recovered from the API.",
                landpads
            });
        }
        catch (Exception)
        {
            return Results.StatusCode(500);
        }
    });


app.MapGet("api/landpads/{id}", 
    async ([FromServices] IExternalRequestHelper externalRequestHelper, string id) =>
    {
        try
        {
            var result = await externalRequestHelper
                .ExecuteRequest(HttpMethod.Get, SpaceXAPIV4ClientName, $"landpads/{id}");

            if (!result.Response.IsSuccessStatusCode)
                return Results.BadRequest(new
                {
                    success = false,
                    message = "Some error has occurred when requesting for the SpaceX landpad data from the API."
                });
        
            var landpad = JsonConvert.DeserializeObject<Landpad>(result.Content);
            
            return Results.Ok(new
            {
                success = true,
                message = "SpaceX landpad data successfully recovered from the API.",
                landpads = landpad
            });
        }
        catch (Exception)
        {
            return Results.StatusCode(500);
        }
    });

#endregion

#region Rockets

app.MapGet("api/rockets", 
    async ([FromServices] IExternalRequestHelper externalRequestHelper) =>
    {
        try
        {
            var result = await externalRequestHelper
                .ExecuteRequest(HttpMethod.Get, SpaceXAPIV4ClientName, "rockets");

            if (!result.Response.IsSuccessStatusCode)
                return Results.BadRequest(new
                {
                    success = false,
                    message = "Some error has occurred when requesting for the SpaceX rockets data from the API."
                });
        
            var rockets = JsonConvert.DeserializeObject<Rocket[]>(result.Content);
            
            return Results.Ok(new
            {
                success = true,
                message = "SpaceX rockets data successfully recovered from the API.",
                rockets
            });
        }
        catch (Exception)
        {
            return Results.StatusCode(500);
        }
    });


app.MapGet("api/rockets/{id}", 
    async ([FromServices] IExternalRequestHelper externalRequestHelper, string id) =>
    {
        try
        {
            var result = await externalRequestHelper
                .ExecuteRequest(HttpMethod.Get, SpaceXAPIV4ClientName, $"rockets/{id}");

            if (!result.Response.IsSuccessStatusCode)
                return Results.BadRequest(new
                {
                    success = false,
                    message = "Some error has occurred when requesting for the SpaceX rocket data from the API."
                });
        
            var rocket = JsonConvert.DeserializeObject<Rocket>(result.Content);
            
            return Results.Ok(new
            {
                success = true,
                message = "SpaceX rocket data successfully recovered from the API.",
                rocket
            });
        }
        catch (Exception)
        {
            return Results.StatusCode(500);
        }
    });

#endregion

#region Cores

app.MapGet("api/cores", 
    async ([FromServices] IExternalRequestHelper externalRequestHelper) =>
    {
        try
        {
            var result = await externalRequestHelper
                .ExecuteRequest(HttpMethod.Get, SpaceXAPIV4ClientName, "cores");

            if (!result.Response.IsSuccessStatusCode)
                return Results.BadRequest(new
                {
                    success = false,
                    message = "Some error has occurred when requesting for the SpaceX cores data from the API."
                });
        
            var cores = JsonConvert.DeserializeObject<Core[]>(result.Content);
            
            return Results.Ok(new
            {
                success = true,
                message = "SpaceX cores data successfully recovered from the API.",
                cores
            });
        }
        catch (Exception)
        {
            return Results.StatusCode(500);
        }
    });


app.MapGet("api/cores/{id}", 
    async ([FromServices] IExternalRequestHelper externalRequestHelper, string id) =>
    {
        try
        {
            var result = await externalRequestHelper
                .ExecuteRequest(HttpMethod.Get, SpaceXAPIV4ClientName, $"cores/{id}");

            if (!result.Response.IsSuccessStatusCode)
                return Results.BadRequest(new
                {
                    success = false,
                    message = "Some error has occurred when requesting for the SpaceX core data from the API."
                });
        
            var core = JsonConvert.DeserializeObject<Core>(result.Content);
            
            return Results.Ok(new
            {
                success = true,
                message = "SpaceX core data successfully recovered from the API.",
                core
            });
        }
        catch (Exception)
        {
            return Results.StatusCode(500);
        }
    });

#endregion

#region Crew

app.MapGet("api/crew", 
    async ([FromServices] IExternalRequestHelper externalRequestHelper) =>
    {
        try
        {
            var result = await externalRequestHelper
                .ExecuteRequest(HttpMethod.Get, SpaceXAPIV4ClientName, "crew");

            if (!result.Response.IsSuccessStatusCode)
                return Results.BadRequest(new
                {
                    success = false,
                    message = "Some error has occurred when requesting for the SpaceX crew data from the API."
                });
        
            var crew = JsonConvert.DeserializeObject<CrewMember[]>(result.Content);
            
            return Results.Ok(new
            {
                success = true,
                message = "SpaceX crew data successfully recovered from the API.",
                crew
            });
        }
        catch (Exception)
        {
            return Results.StatusCode(500);
        }
    });


app.MapGet("api/crew/{id}", 
    async ([FromServices] IExternalRequestHelper externalRequestHelper, string id) =>
    {
        try
        {
            var result = await externalRequestHelper
                .ExecuteRequest(HttpMethod.Get, SpaceXAPIV4ClientName, $"crew/{id}");

            if (!result.Response.IsSuccessStatusCode)
                return Results.BadRequest(new
                {
                    success = false,
                    message = "Some error has occurred when requesting for the SpaceX crew member data from the API."
                });
        
            var crewMember = JsonConvert.DeserializeObject<CrewMember>(result.Content);
            
            return Results.Ok(new
            {
                success = true,
                message = "SpaceX crew member data successfully recovered from the API.",
                crewMember
            });
        }
        catch (Exception)
        {
            return Results.StatusCode(500);
        }
    });

#endregion

app.Run();