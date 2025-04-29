// using AutoBogusApp.Models;
// using Vum.Backend.OpenApi.SourceCandidate.Models;
// using Vum.Backend.OpenApi.SourceVacancy.Models;
// using Vum.Backend.SourceService.Models;
// using Microsoft.Extensions.Logging;
//
// namespace AutoBogusApp.Providers
// {
//     public class ChainProvider(
//         ILogger<ChainProvider> logger,
//         IEnumerable<IMatchProvider> providers) : IChainProvider
//     {
//         public Task<MatchResponse> GetWerkzoekendeMatchesAsync(MatchesWerkzoekendeProfielenRequest request) =>
//             ExecuteChainAsync(provider => provider.GetWerkzoekendeMatchesAsync(request),
//                 "werkzoekende matches",
//                 () => new MatchResponse());
//
//         public Task<DetailResponse> GetWerkzoekendeAsync(string id) =>
//             ExecuteChainAsync(provider => provider.GetWerkzoekendeAsync(id),
//                 $"werkzoekende details for ID {id}",
//                 () => new DetailResponse());
//
//         public Task<MatchResponse> GetVacatureMatchesAsync(MatchesVacaturesRequest request) =>
//             ExecuteChainAsync(provider => provider.GetVacatureMatchesAsync(request),
//                 "vacature matches",
//                 () => new MatchResponse());
//
//         public Task<DetailResponse> GetVacatureAsync(string id) =>
//             ExecuteChainAsync(provider => provider.GetVacatureAsync(id),
//                 $"vacature details for ID {id}",
//                 () => new DetailResponse());
//
//         private async Task<T> ExecuteChainAsync<T>(
//             Func<IMatchProvider, Task<T>> operation,
//             string operationDescription,
//             Func<T> fallback) where T : class
//         {
//             foreach (var provider in providers)
//             {
//                 try
//                 {
//                     var result = await operation(provider);
//                     if (result is not null)
//                         return result;
//                 }
//                 catch (Exception ex)
//                 {
//                     logger.LogError(ex,
//                         "Error during {OperationDescription} from provider {ProviderType}",
//                         operationDescription, provider.GetType().Name);
//                 }
//             }
//
//             logger.LogWarning("No provider returned a result for {OperationDescription}", operationDescription);
//             return fallback();
//         }
//     }
// }
