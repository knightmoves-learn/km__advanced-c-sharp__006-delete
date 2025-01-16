using System.Text;
using System.Text.Json;
using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

[TestCaseOrderer("HomeEnergyApi.Tests.Extensions.PriorityOrderer", "HomeEnergyApi.Tests")]
public class Test
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private string testHome1 = JsonSerializer.Serialize(new Home(1, "Test", "123 Test St.", "Test City", 123));
    private string testHome2 = JsonSerializer.Serialize(new Home(2, "Testy", "456 Assert St.", "Unitville", 456));

    public Test(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Theory, TestPriority(1)]
    [InlineData("/Homes")]
    public async Task HomeEnergyApiReturnsSuccessfulHTTPResponseCodeOnGETHomes(string url)
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync(url);

        Assert.True(response.IsSuccessStatusCode, $"HomeEnergyApi did not return successful HTTP Response Code on GET request at {url}; instead received {(int)response.StatusCode}: {response.StatusCode}");
    }

    [Theory, TestPriority(2)]
    [InlineData("/Homes")]
    public async Task HomeEnergyApiReturnsSuccessfulHTTPResponseOnAddingHomeThroughPOST(string url)
    {
        var client = _factory.CreateClient();

        HttpRequestMessage sendRequest = new HttpRequestMessage(HttpMethod.Post, url);
        sendRequest.Content = new StringContent(testHome1,
                                                Encoding.UTF8,
                                                "application/json");

        var response = await client.SendAsync(sendRequest);
        Assert.True(response.IsSuccessStatusCode, $"HomeEnergyApi did not return successful HTTP Response Code on POST request at {url}; instead received {(int)response.StatusCode}: {response.StatusCode}");

        string responseContent = await response.Content.ReadAsStringAsync();
        Assert.True(responseContent == testHome1, $"HomeEnergyApi did not return the home being added as a response from the POST request at {url}; \n Expected : {testHome1} \n Received : {responseContent} \n");
    }

    [Theory, TestPriority(2)]
    [InlineData("/Homes")]
    public async Task HomeEnergyApiReturnsSuccessfulHTTPResponseOnAddingASecondHomeThroughPOST(string url)
    {
        var client = _factory.CreateClient();

        HttpRequestMessage sendRequest = new HttpRequestMessage(HttpMethod.Post, url);
        sendRequest.Content = new StringContent(testHome2,
                                                Encoding.UTF8,
                                                "application/json");

        var response = await client.SendAsync(sendRequest);
        Assert.True(response.IsSuccessStatusCode, $"HomeEnergyApi did not return successful HTTP Response Code on POST request at {url}; instead received {(int)response.StatusCode}: {response.StatusCode}");

        string responseContent = await response.Content.ReadAsStringAsync();
        Assert.True(responseContent == testHome2, $"HomeEnergyApi did not return the home being added as a response from the POST request at {url}; \n Expected : {testHome2} \n Received : {responseContent} \n");
    }

    [Theory, TestPriority(3)]
    [InlineData("/Homes")]
    public async Task HomeEnergyApiReturnsBothHomesAddedFromPOSTsOnGETs(string url)
    {
        var client = _factory.CreateClient();

        var response1 = await client.GetAsync(url + "/1");
        var response2 = await client.GetAsync(url + "/2");

        Assert.True(response1.IsSuccessStatusCode, $"HomeEnergyApi did not return successful HTTP Response Code on first GET request at {url + "/1"}; instead received {(int)response1.StatusCode}: {response1.StatusCode}");
        Assert.True(response2.IsSuccessStatusCode, $"HomeEnergyApi did not return successful HTTP Response Code on second GET request at {url + "/2"}; instead received {(int)response2.StatusCode}: {response2.StatusCode}");

        string responseContent1 = await response1.Content.ReadAsStringAsync();
        string responseContent2 = await response2.Content.ReadAsStringAsync();

        Assert.True(responseContent1 == testHome1, $"HomeEnergyApi did not return the correct home on first GET request after making POST at {url + "/1"}; \n Expected : {testHome1} \n Received : {responseContent1} \n");
        Assert.True(responseContent2 == testHome2, $"HomeEnergyApi did not return the correct home on second GET request after making POST at {url + "/2"}; \n Expected : {testHome2} \n Received : {responseContent2} \n");
    }

    [Theory, TestPriority(4)]
    [InlineData("/Homes")]
    public async Task HomeEnergyApiReturnsSuccessfulHTTPResponseOnDelete(string url)
    {
        var client = _factory.CreateClient();

        var response = await client.DeleteAsync(url + "/2");
        Assert.True(response.IsSuccessStatusCode, $"HomeEnergyApi did not return successful HTTP Response Code on DELETE request at {url + "/2"}; instead received {(int)response.StatusCode}: {response.StatusCode}");

        string responseContent = await response.Content.ReadAsStringAsync();
        Assert.True(responseContent == testHome2, $"HomeEnergyApi did not return the correct home being deleted as a response from the DELETE request at {url + "/2"}; \n Expected : {testHome2} \n Received : {responseContent} \n");
    }


    [Theory, TestPriority(6)]
    [InlineData("/Homes")]
    public async Task HomeEnergyApiReturnsNoContentHTTPResponseIfTryingToDELETEHomeThatDoesntExist(string url)
    {
        var client = _factory.CreateClient();

        var response = await client.DeleteAsync(url + "/2");
        Assert.True((int)response.StatusCode == 204, $"HomeEnergyApi did not return HTTP Response \"204: NoContent\" on DELETE request at {url + "/2"}; instead received {(int)response.StatusCode}: {response.StatusCode}");
    }
}
