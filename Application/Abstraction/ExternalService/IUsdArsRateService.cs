namespace Application.Abstraction.ExternalService
{
    public interface IUsdArsRateService
    {
        Task<decimal?> GetUsdArsRateAsync();
    }
}
