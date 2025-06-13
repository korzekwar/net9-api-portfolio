namespace UnitTests;

public class ExternalApiTests
{
    private readonly HttpClient _httpClient;

    public ExternalApiTests()
    {
        _httpClient = new HttpClient();
    }

    [Fact]
    public async Task GetTodoFromExternalApi_ShouldReturnSuccessStatusCode()
    {
        var requestUri = "https://jsonplaceholder.typicode.com/todos/1";

        var response = await _httpClient.GetAsync(requestUri);

        response.EnsureSuccessStatusCode();
        Assert.True(response.IsSuccessStatusCode);
    }
}