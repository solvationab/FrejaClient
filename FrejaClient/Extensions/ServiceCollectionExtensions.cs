using FrejaClient.DelegatingHandlers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using System.Collections.Concurrent;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;

namespace FrejaClient.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// This extension method adds Freja api to the service collection.
        /// 
        /// To work it need a FrejaConfig added to the service collection.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="baseurl"></param>
        /// <returns>The IServiceCollection to allow chaining</returns>
        public static IServiceCollection AddFrejaClient(this IServiceCollection services, string baseurl = "https://services.test.frejaeid.com")
        {
            // Add delegating handlers used by the Freja Client
            services
                .AddScoped<HttpLoggingHandler>();

            // Add the Freja API
            services
                .AddRefitClient<IFrejaClient>(sp =>
                {
                    var settings = new RefitSettings
                    {
                        ContentSerializer = new SystemTextJsonContentSerializer(GetJsonSerializerOptions()),
                        FormUrlEncodedParameterFormatter = new FrejaFormUrlEncodedParameterFormatter()
                    };

                    //settings.ExceptionFactory = async responseMessage =>
                    //{
                    //    if (responseMessage.IsSuccessStatusCode)
                    //        return null;

                    //    var frejaErrorResponse = await responseMessage.Content.ReadFromJsonAsync<FrejaErrorResponse>();

                    //    if (frejaErrorResponse != null)
                    //    {
                    //        return new FrejaException(frejaErrorResponse);
                    //    }

                    //    var requestMessage = responseMessage.RequestMessage;

                    //    var method = requestMessage.Method;

                    //    return await ApiException
                    //        .Create(requestMessage, method, responseMessage, settings);
                    //};

                    return settings;
                })
                .ConfigureHttpClient(httpClient => httpClient.BaseAddress = new Uri(baseurl))
                .AddHttpMessageHandler<HttpLoggingHandler>();

            return services;
        }

        public static IServiceCollection AddConfig<T>(this IServiceCollection services, IConfiguration configuration, string key)
            where T : class
        {
            var config = configuration
                    .GetRequiredSection(key)
                    .Get<T>()
                ?? throw new InvalidOperationException("Unable to get " + typeof(T).Name + " from section " + key + " in config");

            services.AddSingleton(config);

            return services;
        }

        public static JsonSerializerOptions GetJsonSerializerOptions()
        {
            return new JsonSerializerOptions
            {
                //NumberHandling = JsonNumberHandling.AllowReadingFromString,
                //DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                //Converters = { new FrejaDateTimeConverter(), new FrejaNullableDateTimeConverter(), new JsonStringEnumConverterEx() }
            };
        }
    }
}
