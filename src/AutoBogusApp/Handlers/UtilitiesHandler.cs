// using Newtonsoft.Json;
// using Newtonsoft.Json.Converters;
// using System;
// using System.Text;
// using System.Text.Json;
// using Vum.Backend.OpenApi.SourceUtilities.Handlers;
// using Vum.Backend.OpenApi.SourceUtilities.Models;
// using Vum.Backend.SourceService.Extensions;
// using Vum.Backend.SourceService.Models;
// using Vum.Backend.SourceService.Repositories;
//
// namespace Vum.Backend.SourceService.Handlers;
//
// /// <summary>
// /// Handler for utilities operations
// /// </summary>
// public class UtilitiesHandler(ILogger<UtilitiesHandler> logger, IResponseRepository repository) : ISourceUtilitiesRequestHandler
// {
//     /// <summary>
//     /// Get log operations - currently returns an empty list
//     /// </summary>
//     public Task<List<Log>> GetLogOperationsAsync(CancellationToken cancellationToken)
//     {
//         return Task.FromResult(new List<Log>());
//     }
//
//     /// <summary>
//     /// Sets a detail response in the repository
//     /// </summary>
//     public async Task SetDetailResponseAsync(SetDetailResponseRequest? setDetailResponseRequest, CancellationToken cancellationToken)
//     {
//         DetailResponse detailResponse = new()
//         {
//             Response = setDetailResponseRequest?.Response ?? new(),
//             Metadata = setDetailResponseRequest?.Metadata ?? []
//         };
//
//         if (setDetailResponseRequest?.Id == null)
//         {
//             logger.LogWarning("Id is null for setDetailResponse");
//             throw new InvalidOperationException("Id cannot be null");
//         }
//
//         var id = setDetailResponseRequest.Id;
//         logger.LogDebug("Storing detail response for ID: {Id}", id);
//
//         var success = await repository.Store(id, detailResponse);
//         if (!success)
//         {
//             logger.LogError("Failed to store detail response for ID: {Id}", id);
//             throw new InvalidOperationException("Failed to store detail response");
//         }
//
//         logger.LogInformation("Detail response successfully stored for ID: {Id}", id);
//     }
//
//     /// <summary>
//     /// Sets a response in the repository for a given request
//     /// </summary>
//     public async Task SetResponseAsync(SetResponseRequest? setResponseRequest, CancellationToken cancellationToken)
//     {
//         if (setResponseRequest?.Request == null)
//         {
//             logger.LogWarning("Request is null for setResponse");
//             throw new InvalidOperationException("Request cannot be null");
//         }
//         
//         MatchResponse matchResponse = new()
//         {
//             Response = setResponseRequest?.Response ?? [],
//             Metadata = setResponseRequest?.Metadata ?? []
//         };
//
//
//         var id = setResponseRequest.Request.ToJson().ToSHA256();
//         var success = await repository.Store(id, matchResponse);
//         if (!success)
//         {
//             logger.LogError("Failed to store response for request");
//             throw new InvalidOperationException("Failed to store response");
//         }
//
//         logger.LogInformation("Response successfully stored for request hash");
//     }
// }