using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebionLibraryAPI;

public class SwaggerTagDescriptions : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        swaggerDoc.Tags = new List<OpenApiTag>
        {
            new OpenApiTag { Name = "Books", Description = "Gestione dei libri"},
            new OpenApiTag {Name = "Customer", Description = "Gestione dei clienti"}
        };
    }
}