using System;
using System.Net;
using Moq;
using Moq.Protected;

public class NetworkStub
{
    private readonly Dictionary<string, HttpResponseMessage> _responseMap = new Dictionary<string, HttpResponseMessage>();
    private readonly Mock<HttpMessageHandler> _mockHttpMessageHandler;

    public NetworkStub()
    {
        _mockHttpMessageHandler = new Mock<HttpMessageHandler>();
    }

    public void SetupResponse(string url, HttpStatusCode statusCode, string content)
    {
        _responseMap[url] = new HttpResponseMessage(statusCode)
        {
            Content = new StringContent(content)
        };
    }

    public HttpClient GetStubbedHttpClient()
    {
        _mockHttpMessageHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync((HttpRequestMessage request, CancellationToken cancellationToken) =>
            {
                var url = request.RequestUri.AbsoluteUri;
                if (_responseMap.TryGetValue(url, out var response))
                {
                    return response;
                }

                return new HttpResponseMessage(HttpStatusCode.NotFound);
            });

        return new HttpClient(_mockHttpMessageHandler.Object, false);
    }

    public void VerifyNoOutstandingRequest()
    {
        _mockHttpMessageHandler.Verify();
    }

}

