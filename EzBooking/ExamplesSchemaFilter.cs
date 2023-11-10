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
                ["priceyear"] = new OpenApiDouble(Examples.PriceYearExample),
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
                // Adicione exemplos para outras propriedades aqui...
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
    }
}
