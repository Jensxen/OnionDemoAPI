namespace OnionDemo.Domain.ValueObjects;

public class Address
{
    public string Street { get; protected set; }
    public string City { get; protected set; }
    public string PostalCode { get; protected set; }

    public Address(string street, string city, string postalCode)
    {
        Street = street;
        City = city;
        PostalCode = postalCode;
    }

    public override string ToString()
    {
        return $"{Street}, {City}, {PostalCode}";
    }
}