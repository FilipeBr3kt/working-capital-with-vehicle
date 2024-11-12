namespace ApiGiroComVeiculo.Api.Common.Constants;

public static class BusinessSize
{
    public record BusinessSizeType(int Id, string Name);

    public static IEnumerable<BusinessSizeType> GetBusinessSize()
    {
        return new List<BusinessSizeType>
        {
            new(2, "Micro"),
            new(3, "Pequena"),
            new(4, "Média"),
            new(5, "Grande")
        };
    }
}