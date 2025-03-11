using FrejaClient;
using FrejaClient.Dto.AuthenticationService;
using FrejaClient.Extensions;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Started");

var serviceCollection = new ServiceCollection();

serviceCollection.AddFrejaClient();

var serviceProvider = serviceCollection.BuildServiceProvider();

var client = serviceProvider.GetRequiredService<IFrejaClient>();

var response = await client.InitAuthentication(
    new InitAuthenticationRequest(
        new InitAuthenticationRequestData(
            "INFERRED", 
            "N/A"
            )
        )
    );

Console.WriteLine(response);
