using OnionDemo.Domain.ValueObjects;

namespace OnionDemo.Application.Query;

public interface IDawaQuery
{
    bool ValidateAddress(Address address);
    
}