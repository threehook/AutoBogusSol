// using Vum.Backend.OpenApi.SourceCandidate.Handlers;
// using Vum.Backend.OpenApi.SourceVacancy.Handlers;
// using Vum.Backend.OpenApi.SourceVacancy.Models;
// using System.Linq;
// using Vum.Backend.SourceService.Providers;
// using Microsoft.Extensions.Logging;
// using Vum.Backend.SourceService.Services;
//
// namespace Vum.Backend.SourceService.Handlers;
//
// public class SourceVacancyHandler(
//     IChainProvider matchProvider,
//     ILogger<SourceVacancyHandler> logger,
//     RequestMetadataService requestMetadataService,
//     ResponseConverterService converter) : ISourceVacancyRequestHandler
// {
//     public async Task<Vacature> GetVacatureAsync(string idVacature, string xVUMBerichtVersie, string xVUMFromParty, string xVUMToParty,
//         string xVUMViaParty, bool xVUMSUWIparty, string aPIVersion, CancellationToken cancellationToken)
//     {
//         try
//         {
//             var detailResponse = await matchProvider.GetVacatureAsync(idVacature);
//             if (detailResponse == null)
//             {
//                 logger.LogWarning("Vacature not found");
//                 return new Vacature();
//             }
//
//             // Store metadata in the scoped service if available
//             if (detailResponse.Metadata is { Count: > 0 })
//             {
//                 requestMetadataService.Metadata = new Dictionary<string, string>(detailResponse.Metadata);
//                 logger.LogDebug("Stored metadata from detail response: {Count} items", detailResponse.Metadata.Count);
//             }
//
//             // Use the converter service to convert response
//             return converter.ConvertResponse<Vacature>(detailResponse.Response);
//         }
//         catch (Exception ex)
//         {
//             logger.LogError(ex, "Error getting vacature details");
//             return new Vacature();
//         }
//     }
//
//     public async Task<MatchesVacatures200Response> MatchesVacaturesAsync(string xVUMBerichtVersie, string xVUMFromParty, string xVUMToParty, string xVUMViaParty,
//         bool xVUMSUWIparty, string aPIVersion, MatchesVacaturesRequest matchesVacaturesRequest,
//         CancellationToken cancellationToken)
//     {
//         try
//         {
//             var matchResponse = await matchProvider.GetVacatureMatchesAsync(matchesVacaturesRequest);
//             if (matchResponse == null)
//             {
//                 logger.LogWarning("Match response was null");
//                 return new MatchesVacatures200Response
//                 {
//                     MaximumAantalResultatenBereikt = false,
//                     Matches = []
//                 };
//             }
//
//             // Store metadata in the scoped service if available
//             if (matchResponse.Metadata != null && matchResponse.Metadata.Count > 0)
//             {
//                 requestMetadataService.Metadata = new Dictionary<string, string>(matchResponse.Metadata);
//                 logger.LogDebug("Stored metadata from match response: {Count} items", matchResponse.Metadata.Count);
//             }
//
//             // Use the converter service to convert response list
//             var vacatureMatches = converter.ConvertResponseList<MPVacatureMatch>(matchResponse.Response);
//
//             var response = new MatchesVacatures200Response
//             {
//                 MaximumAantalResultatenBereikt = matchResponse.More,
//                 Matches = vacatureMatches
//             };
//
//             return response;
//         }
//         catch (Exception ex)
//         {
//             logger.LogError(ex, "Error getting vacature matches");
//             return new MatchesVacatures200Response
//             {
//                 MaximumAantalResultatenBereikt = false,
//                 Matches = []
//             };
//         }
//     }
// }