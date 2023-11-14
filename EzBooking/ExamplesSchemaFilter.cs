using EzBooking.Dtto;
using EzBooking.Models;
using EzBooking.SwaggerExamples;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class ExamplesSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.Type == typeof(House))
        {
            schema.Example = new OpenApiObject
            {
                ["name"] = new OpenApiString(Examples.NameExample),
                ["doorNumber"] = new OpenApiInteger(Examples.DoorNumberExample),
                ["floorNumber"] = new OpenApiInteger(Examples.FloorNumberExample),
                ["price"] = new OpenApiDouble(Examples.PriceExample),
                ["guestsNumber"] = new OpenApiInteger(Examples.GuestsNumberExample),
                ["road"] = new OpenApiString(Examples.RoadExample),
                ["propertyAssessment"] = new OpenApiString(Examples.PropertyAssessmentExample),
                ["codDoor"] = new OpenApiInteger(Examples.CodDoorExample),
                ["sharedRoom"] = new OpenApiBoolean(Examples.SharedRoomExample),
                ["postalCode"] = new OpenApiObject
                {
                    ["postalcode"] = new OpenApiInteger(Examples.postalCode),
                    ["concelho"] = new OpenApiString(Examples.concelho),
                    ["district"] = new OpenApiString(Examples.district)
                }
            };
        }
        else if (context.Type == typeof(User))
        {
            schema.Example = new OpenApiObject
            {
                ["name"] = new OpenApiString(Examples.UserNameExample),
                ["email"] = new OpenApiString(Examples.UserEmailExample),
                ["password"] = new OpenApiString(Examples.UserPasswordExample),
                ["phone"] = new OpenApiString(Examples.UserPhoneExample)
            };
        }
        else if (context.Type == typeof(Feedback))
        {
            schema.Example = new OpenApiObject
            {
                ["classification"] = new OpenApiInteger(Examples.ClassificationExample),
                ["comment"] = new OpenApiString(Examples.CommentExample)
            };
        }
        if (context.Type == typeof(StatusHouse))
        {
            schema.Example = new OpenApiObject
            {
                ["name"] = new OpenApiString("Disponivel")
            };
        }

        if (context.Type == typeof(PostalCode))
        {
            schema.Example = new OpenApiObject
            {
                ["postalcode"] = new OpenApiInteger(Examples.postalCode),
                ["concelho"] = new OpenApiString(Examples.concelho),
                ["district"] = new OpenApiString(Examples.district)
            };
        }
        else if (context.Type == typeof(LoginDto))
        {
            schema.Example = new OpenApiObject
            {
                ["email"] = new OpenApiString(Examples.EmailExample),
                ["password"] = new OpenApiString(Examples.PasswordExample)
            };
        }
        /*
        else if (context.Type == typeof(Payment))
        {
            schema.Example = new OpenApiObject
            {
                ["creationDate"] = new OpenApiDate(Examples.CreationDateExample),
                ["paymentDate"] = new OpenApiDate(Examples.PaymentDateExample),
                ["paymentMethod"] = new OpenApiString(Examples.PaymentMethodExample),
                ["paymentValue"] = new OpenApiInteger(Examples.PaymentValueExample),
                ["state"] = new OpenApiInteger(Examples.PaymentStateExample)
            };
        }*/
    }
}
