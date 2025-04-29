// using Vum.Backend.OpenApi.SourceCandidate.Handlers;
// using Vum.Backend.OpenApi.SourceCandidate.Models;
// using AutoBogusApp.Providers;
// using System.Linq;
// using AutoBogusApp.Vum;
// using Microsoft.Extensions.Logging;
// using Vum.Backend.SourceService.Services;
//
// namespace AutoBogusApp.Handlers;
//
// public class SourceCandidateHandler(
//     IChainProvider matchProvider,
//     ILogger<SourceCandidateHandler> logger,
//     RequestMetadataService requestMetadataService,
//     ResponseConverterService converter) : ISourceCandidateRequestHandler
// {
//     public async Task<Werkzoekende> GetWerkzoekendeProfielAsync(string idWerkzoekende, string xVUMBerichtVersie, string xVUMFromParty,
//         string xVUMToParty, string xVUMViaParty, bool xVUMSUWIparty, string aPIVersion,
//         CancellationToken cancellationToken)
//     {
//         try
//         {
//             var detailResponse = await matchProvider.GetWerkzoekendeAsync(idWerkzoekende);
//             if (detailResponse == null)
//             {
//                 logger.LogWarning("Werkzoekende not found");
//                 return new Werkzoekende();
//             }
//
//             // Store metadata in the scoped service if available
//             if (detailResponse.Metadata is { Count: > 0 })
//             {
//                 requestMetadataService.Metadata = new(detailResponse.Metadata);
//                 logger.LogDebug("Stored metadata from detail response: {Count} items", detailResponse.Metadata.Count);
//             }
//
//             // Use the converter service to convert response
//             return converter.ConvertResponse<Werkzoekende>(detailResponse.Response);
//         }
//         catch (Exception ex)
//         {
//             logger.LogError(ex, "Error getting werkzoekende details");
//             return new Werkzoekende();
//         }
//     }
//
//     public async Task<MatchesWerkzoekendeProfielen200Response> MatchesWerkzoekendeProfielenAsync(string xVUMBerichtVersie, string xVUMFromParty, string xVUMToParty,
//         string xVUMViaParty, bool xVUMSUWIparty, string aPIVersion,
//         MatchesWerkzoekendeProfielenRequest matchesWerkzoekendeProfielenRequest, CancellationToken cancellationToken)
//     {
//         try
//         {
//             var matchResponse = await matchProvider.GetWerkzoekendeMatchesAsync(matchesWerkzoekendeProfielenRequest);
//             if (matchResponse == null)
//             {
//                 logger.LogWarning("Match response was null");
//                 return new MatchesWerkzoekendeProfielen200Response
//                 {
//                     MaximumAantalResultatenBereikt = false,
//                     Matches = []
//                 };
//             }
//             // Store metadata in the scoped service if available
//             if (matchResponse.Metadata is { Count: > 0 })
//             {
//                 requestMetadataService.Metadata = new(matchResponse.Metadata);
//                 logger.LogDebug("Stored metadata from match response: {Count} items", matchResponse.Metadata.Count);
//             }
//
//             // Use the converter service to convert response list
//             var werkzoekendeMatches = converter.ConvertResponseList<MPWerkzoekendeMatch>(matchResponse.Response);
//
//             var response = new MatchesWerkzoekendeProfielen200Response
//             {
//                 MaximumAantalResultatenBereikt = matchResponse.More,
//                 Matches = werkzoekendeMatches
//             };
//
//             return response;
//         }
//         catch (Exception ex)
//         {
//             logger.LogError(ex, "Error getting werkzoekende matches");
//             return new MatchesWerkzoekendeProfielen200Response
//             {
//                 MaximumAantalResultatenBereikt = false,
//                 Matches = []
//             };
//         }
//     }
// }