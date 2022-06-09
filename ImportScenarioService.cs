using System.Collections.Generic;
using System.Threading.Tasks;
using AcumaticaSoap;

namespace AcumaticaImportScenarioRetrievalBenchmark
{
    public class ImportScenarioService
    {
        public async Task<IReadOnlyCollection<Command>> GetScenariosWithScreenApiAsync(
            string acumaticaUrl,
            string tenant,
            string username,
            string password,
            string scenarioName)
        {
            var soapLoginService = new SoapLoginService();
            var soap = await soapLoginService.LoginAsync(acumaticaUrl, tenant, username, password);

            Command[] fields = await soap.GetScenarioAsync(scenarioName);

            await soap.LogoutAsync();

            return fields;
        }
    }
}