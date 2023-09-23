using DBChoose.Business.Services.Interfaces;
using DBChoose.DataAccess.Ef;

namespace DBChoose.Business.Services
{
    public class ProviderInfoService : IProviderInfoService
    {
        private readonly DBChooseContext _dbContext;
        public ProviderInfoService(DBChooseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string GetProviderInfo()
        {
            var providerInfo = _dbContext.ProvidersInfo.FirstOrDefault();

            if (providerInfo != null)
            {
                return providerInfo.Description!;
            }
            else
            {
                return "No se encontraron datos de proveedor.";
            }
        }
    }
}