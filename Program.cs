using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace AcumaticaImportScenarioRetrievalBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This console app retrieves import scenario fields from an Acumatica screen-based SOAP API.");

            Console.Write("Please type in URL to Acumatica instance: ");
            string acumaticaUrl = Console.ReadLine();

            Console.Write("Tenant: ");
            string tenant = Console.ReadLine();

            Console.Write("Username: ");
            string username = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            Console.Write("Import scenario name: ");
            string scenarioName = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Retrieving...");
            Console.WriteLine();

            RetrieveScenarioFieldsAsync(
                acumaticaUrl,
                tenant,
                username,
                password,
                scenarioName).GetAwaiter().GetResult();

            Console.WriteLine();
            Console.WriteLine("Finished!");
            Console.ReadKey();
        }

        private static async Task RetrieveScenarioFieldsAsync(
            string acumaticaUrl,
            string tenant,
            string username,
            string password,
            string scenarioName)
        {
            var importScenarioService = new ImportScenarioService();
            var fields = await importScenarioService
                .GetScenariosWithScreenApiAsync(acumaticaUrl, tenant, username, password, scenarioName)
                .ConfigureAwait(false);

            Console.WriteLine(JsonSerializer.Serialize(fields, new JsonSerializerOptions
            {
                WriteIndented = true
            }));
        }
    }
}
