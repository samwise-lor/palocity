namespace Api.Models;

[Flags]
public enum Relationship
{
    None = 0,
    Spouse = 1,
    DomesticPartner = 2,
    Child = 4
}

