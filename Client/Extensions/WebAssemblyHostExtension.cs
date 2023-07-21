using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using System.Globalization;

namespace HotelManagementSystem.Client.Extensions
{
    /// <summary>
    /// Extension method class to remove extra logic from Program.cs
    /// </summary>
    public static class WebAssemblyHostExtension
    {
        /// <summary>
        /// Extend WebAssemblyHost and use JSInterop to call get accesor from
        /// blazorCulture Javascript object
        /// </summary>
        /// <param name="host"></param>
        /// <returns>async Task</returns>
       public async static Task SetDefaultCulture(this WebAssemblyHost host)
        {
            var jsInterop = host.Services.GetRequiredService<IJSRuntime>();

            //returns the culture name from the locale storate
            var result = await jsInterop.InvokeAsync<string>("blazorCulture.get");

            CultureInfo culture;

            //if the name is returned, a new CultureInfo object is created
            //otherwise we create a new CultureInfo with default en-Us as a parameter
            if (result != null)
                culture = new CultureInfo(result);
            else
                culture = new CultureInfo("en-US");

            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }
    }
}