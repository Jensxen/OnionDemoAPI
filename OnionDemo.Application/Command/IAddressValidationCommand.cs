using OnionDemo.Domain.ValueObjects;

namespace OnionDemo.Application.Command;

public interface IAddressValidationCommand
{
    AddressValidationStatus ValidateAddress(Address address);
    void CheckPendingAddresses();
}