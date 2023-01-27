using Microsoft.AspNetCore.SignalR;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using NGenieBack.Auth;
using NGenieBack.Database.Models;
using NGenieBack.Primitives;

namespace NGenieBack.OData
{
    public static class Edm
    {
        public static IEdmModel Model()
        {
            var builder = new ODataConventionModelBuilder();

            builder.EntitySet<User>("Users");
            builder.EntitySet<Article>("Articles");

            builder.Action("CreateToken")
                .Returns<string>()
                .Parameter<AuthenticationRequest>("AuthRequest");

            var model = builder.GetEdmModel();

            var typeReference = new EdmTypeDefinitionReference(new EdmTypeDefinition("NGenie.Primitives", "Username", EdmPrimitiveTypeKind.String), true);

            model.SetPrimitiveValueConverter(typeReference, new UsernameConverter());
            return model;

        }

    }

    public class UsernameConverter : IPrimitiveValueConverter
    {
        public object ConvertFromUnderlyingType(object value)
        {
            throw new NotImplementedException();
        }

        public object ConvertToUnderlyingType(object value)
        {
            throw new NotImplementedException();
        }
    }
}
