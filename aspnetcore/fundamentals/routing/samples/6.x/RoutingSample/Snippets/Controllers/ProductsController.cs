using Microsoft.AspNetCore.Mvc;

namespace RoutingSample.Snippets.Controllers;

// <snippet_ClassGet>
[ApiController]
[Route("/api/Products")]
public class ProductsController : ControllerBase
{
    [HttpGet("{id}", Name = nameof(GetProduct))]
    public IActionResult GetProduct(string id)
        // </snippet_ClassGet>
        => Ok();

    [HttpPost("{id}/Related")]
    // <snippet_AddRelatedProduct>
    public IActionResult AddRelatedProduct(
        string id, string pathToRelatedProduct, [FromServices] LinkParser linkParser)
    {
        var routeValues = linkParser.ParsePathByEndpointName(
            nameof(GetProduct), pathToRelatedProduct);
        var relatedProductId = routeValues?["id"];

        // ...
        // </snippet_AddRelatedProduct>

        return NoContent();
    }
}
