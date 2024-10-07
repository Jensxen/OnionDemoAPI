using System.Collections.Concurrent;
using OnionDemo.Application.IRepository;
using OnionDemo.Application.Query;
using OnionDemo.Domain.ValueObjects;

namespace OnionDemo.Application.Command;

public class AddressValidationCommand : IAddressValidationCommand
{
    private readonly IDawaQuery _dawaQuery;
    private readonly IAddressRepository _addressRepository;
    private static ConcurrentDictionary<string, AddressValidationStatus> addressCache =
        new ConcurrentDictionary<string, AddressValidationStatus>();

    public AddressValidationCommand(IDawaQuery dawaQuery, IAddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
        _dawaQuery = dawaQuery;
    }
    public AddressValidationStatus ValidateAddress(Address address)
    {
        string addressKey = $"{address.Street}-{address.City}-{address.PostalCode}";
        if (addressCache.TryGetValue(addressKey, out AddressValidationStatus status))
        {
            return status;
        }
        //Mark as pending
        addressCache[addressKey] = AddressValidationStatus.Pending;

        //Check if address is valid with DAWA
        var isValid = _dawaQuery.ValidateAddress(address);
        status = isValid ? AddressValidationStatus.Valid : AddressValidationStatus.Invalid;
        addressCache[addressKey] = status;

        return status;
    }

    public void CheckPendingAddresses()
    {
        var pendingAddresses = addressCache
            .Where(x => x.Value == AddressValidationStatus.Pending)
            .Select(x => x.Key)
            .ToList();

        foreach (var addressKey in pendingAddresses)
        {
            var parts = addressKey.Split('-');
            var address = new Address(parts[0], parts[1], parts[2]);

            var isValid = _dawaQuery.ValidateAddress(address);
            var status = isValid ? AddressValidationStatus.Valid : AddressValidationStatus.Invalid;
            addressCache[addressKey] = status;

            _addressRepository.NotifyBookMyHome(addressKey, status);
        }
    }
}