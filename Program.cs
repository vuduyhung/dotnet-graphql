using Odyssey.MusicMatcher;
using SpotifyWeb;

var builder = WebApplication.CreateBuilder(args);

// spotify service
builder.Services.AddHttpClient<SpotifyService>();

// graphql anotation-first approach
builder
    .Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .RegisterService<SpotifyService>(); // .AddType<Odyssey.MusicMatcher.Playlist>();

// cors policy
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("https://studio.apollographql.com").AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors();

app.MapGraphQL();

app.Run();
