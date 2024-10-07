using OnionDemo.Domain.ValueObjects;

namespace OnionDemo.Application.Query;

public interface IAddressValidationQuery
{
    public bool ValidateAddress(Address address);
    void CheckPendingAddresses();
}