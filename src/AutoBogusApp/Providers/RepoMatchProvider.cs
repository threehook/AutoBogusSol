// using Vum.Backend.OpenApi.SourceCandidate.Models;
// using Vum.Backend.OpenApi.SourceVacancy.Models;
// using Vum.Backend.SourceService.Models;
// using Microsoft.Extensions.Logging;
// using Vum.Backend.SourceService.Extensions;
// using Vum.Backend.SourceService.Repositories;
//
// namespace AutoBogusApp.Providers
// {
//     /// <summary>
//     /// A basic implementation of IMatchProvider that returns empty results
//     /// This is used as a fallback provider in the chain
//     /// </summary>
//     public class RepoMatchProvider(ILogger<RepoMatchProvider> logger, IResponseRepository _repository) : IMatchProvider
//     {
//         public async Task<MatchResponse> GetWerkzoekendeMatchesAsync(MatchesWerkzoekendeProfielenRequest request) =>
//             await GetResponseAsync(request);
//         
//         public async Task<DetailResponse> GetWerkzoekendeAsync(string id) =>
//             await GetDetailResponseAsync(id);
//
//         public async Task<MatchResponse> GetVacatureMatchesAsync(MatchesVacaturesRequest request) =>
//           await GetResponseAsync(request);
//
//         public async Task<DetailResponse> GetVacatureAsync(string id) =>
//             await GetDetailResponseAsync(id);
//         
//         
//         private async Task<MatchResponse> GetResponseAsync(object request)
//         {
//             var identifier = request.ToJson().ToSHA256();
//             var response = await _repository.Get<MatchResponse>(identifier);
//             return response ?? new MatchResponse();
//         }
//         
//         private async Task<DetailResponse> GetDetailResponseAsync(string id)
//         {
//             var response = await _repository.Get<DetailResponse>(id);
//             return response ?? new DetailResponse();
//         }
//     }
// }