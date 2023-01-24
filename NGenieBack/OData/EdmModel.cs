using Microsoft.AspNetCore.SignalR;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using NGenieBack.Database.Models;

namespace NGenieBack.OData
{
    public static class Edm
    {
       public static IEdmModel Model()
        {
            var builder = new ODataConventionModelBuilder();

            builder.EntitySet<User>("users");
            builder.EntitySet<Article>("articles");

            return builder.GetEdmModel();

        }


    }
}
