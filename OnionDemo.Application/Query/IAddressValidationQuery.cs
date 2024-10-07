using OnionDemo.Domain.ValueObjects;

namespace OnionDemo.Application.Query;

public interface IAddressValidationQuery
{
    bool ValidateAddress(Address address);
}