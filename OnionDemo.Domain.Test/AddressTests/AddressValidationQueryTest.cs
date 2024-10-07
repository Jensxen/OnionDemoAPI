//using OnionDemo.Application.Query;
//using OnionDemo.Domain.ValueObjects;
//using OnionDemo.Infrastructure.Queries;
//using Moq;
//using Moq.Protected;
//using Xunit;
//using System.Net;
//using System.Net.Http;
//using System.Threading;
//using System.Threading.Tasks;

//namespace OnionDemo.Tests
//{
//    public class AddressValidationQueryTests
//    {
//        private readonly IDawaQuery _addressValidationQuery;

//        public AddressValidationQueryTests()
//        {
//            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
//            mockHttpMessageHandler.Protected()
//                .Setup<Task<HttpResponseMessage>>(
//                    "SendAsync",
//                    ItExpr.IsAny<HttpRequestMessage>(),
//                    ItExpr.IsAny<CancellationToken>()
//                )
//                .ReturnsAsync((HttpRequestMessage request, CancellationToken cancellationToken) =>
//                {
//                    if (request.RequestUri.ToString().Contains("https://api.dataforsyningen.dk/adresser?q="))
//                    {
//                        return new HttpResponseMessage
//                        {
//                            StatusCode = HttpStatusCode.OK,
//                            Content = new StringContent("[{\"id\": \"1\", \"vejnavn\": \"Valid Street\", \"postnr\": \"1234\", \"postnrnavn\": \"City\"}]"),
//                        };
//                    }
//                    return new HttpResponseMessage
//                    {
//                        StatusCode = HttpStatusCode.NotFound,
//                    };
//                });

//            var httpClient = new HttpClient(mockHttpMessageHandler.Object)
//            {
//                BaseAddress = new System.Uri("https://api.dataforsyningen.dk")
//            };

//            var mockHttpClientFactory = new Mock<IHttpClientFactory>();
//            mockHttpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(httpClient);

//            _addressValidationQuery = new AddressValidationQuery(mockHttpClientFactory.Object);
//        }

//        [Fact]
//        public void ValidateAddress_ShouldReturnTrue_WhenAddressIsValid()
//        {
//            // Arrange
//            var validAddress = new Address("Valid Street", "City", "1234");

//            // Act
//            var result = _addressValidationQuery.ValidateAddress(validAddress);

//            // Assert
//            Assert.True(result);
//        }

//        [Fact]
//        public void ValidateAddress_ShouldReturnFalse_WhenStreetIsEmpty()
//        {
//            // Arrange
//            var invalidAddress = new Address("", "City", "1234");

//            // Act
//            var result = _addressValidationQuery.ValidateAddress(invalidAddress);

//            // Assert
//            Assert.False(result);
//        }

//        [Fact]
//        public void ValidateAddress_ShouldReturnFalse_WhenCityIsEmpty()
//        {
//            // Arrange
//            var invalidAddress = new Address("Valid Street", "", "1234");

//            // Act
//            var result = _addressValidationQuery.ValidateAddress(invalidAddress);

//            // Assert
//            Assert.False(result);
//        }

//        [Fact]
//        public void ValidateAddress_ShouldReturnFalse_WhenZipCodeIsEmpty()
//        {
//            // Arrange
//            var invalidAddress = new Address("Valid Street", "City", "");

//            // Act
//            var result = _addressValidationQuery.ValidateAddress(invalidAddress);

//            // Assert
//            Assert.False(result);
//        }
//    }
//}
