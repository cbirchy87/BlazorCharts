using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using PetShelter.UI;

namespace PetShelter.UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            //Add the Pet shelter Service
            //Microsoft.Extensions.Http - IS REQUIRED
            builder.Services.AddHttpClient<PetShelterService>(client =>
            {
                //This is the base URI
                client.BaseAddress = new Uri("https://localhost:7054/api/");
            });
            builder.Services.AddMudServices();
            await builder.Build().RunAsync();
        }
    }
}