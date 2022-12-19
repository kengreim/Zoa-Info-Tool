using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ZOAHelper.Models;
using ZOAHelper.Services.Interfaces;

namespace ZOAHelper.Services
{
    public class FlightAwareRouteService : IRouteSummaryService
    {
        private readonly HttpClient _httpClient;
        public FlightAwareRouteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<RouteSummary>> FetchRouteSummariesAsync(string departureIcao, string arrivalIcao)
        {
            List<RouteSummary> returnList = new();

            try
            {
                string responseBody = await _httpClient.GetStringAsync(MakeUrl(departureIcao, arrivalIcao));
                var parser = new HtmlParser();
                IDocument document = await parser.ParseDocumentAsync(responseBody);
                var tableRows = document.QuerySelector("table.prettyTable.fullWidth")?.QuerySelectorAll("tr");

                for (int i = 0; i < tableRows.Length; i++)
                {
                    // Ignore the first two rows which are table headers; every row after that is a data row
                    if (i > 1)
                    {
                        var tds = tableRows[i].QuerySelectorAll("td");
                        int frequency = int.Parse(tds[0].TextContent);
                        string origin = tds[1].TextContent;
                        string destination = tds[2].TextContent;
                        string altitudes = tds[3].TextContent;
                        string fullRoute = tds[4].TextContent;
                        returnList.Add(new RouteSummary(origin, destination, fullRoute, altitudes, frequency));
                    }
                }
                return returnList;
            }
            catch (HttpRequestException e)
            {
                throw e;
            }
        }

        private static string MakeUrl(string departureIcao, string arrivalIcao)
        {
            return Constants.FlightAwareIfrRouteBaseUrl + @"origin=" + departureIcao + @"&destination=" + arrivalIcao;
        }
    }
}
