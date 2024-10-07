using OnionDemo.Domain.ValueObjects;

namespace OnionDemo.Application.IRepository;

public interface IAddressRepository
{
    void NotifyBookMyHome(string addressKey, AddressValidationStatus status);
}