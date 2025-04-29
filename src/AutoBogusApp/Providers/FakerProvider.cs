// using AutoBogusApp.Vum;
// using AutoBogusApp.DataGeneration;
// using AutoBogusApp.Models;
//
// // using Vum.Backend.OpenApi.SourceCandidate.Models;
// // using Vum.Backend.OpenApi.SourceVacancy.Models;
// // using Vum.Backend.SourceService.Models;
// // using Microsoft.Extensions.Logging;
// // using Vum.Backend.SourceService.Extensions;
// // using Vum.Backend.SourceService.Repositories;
//
//
// namespace AutoBogusApp.Providers;
//
//     /// <summary>
//     /// A faker implementation of IMatchProvider that returns faked results
//     /// </summary>
//     public class FakerMatchProvider (ILogger<FakerMatchProvider> logger) : IMatchProvider
//     {
//         public Task<MatchResponse> GetWerkzoekendeMatchesAsync(MatchesWerkzoekendeProfielenRequest request, int responseCount)
//         {
//             // Create the response object with the matches
//             var matches = new List<object>();
//             var faker = new WerkzoekendeFaker();
//             
//             for (int i = 0; i < responseCount; i++)
//             {
//                 matches.Add(faker.FakeMpWerkzoekendeMatch());
//             }
//
//             var response = new MatchResponse()
//             {
//                 // Don't forget the metadata
//                 Response = matches,
//                 More = false
//             };
//             
//             return Task.FromResult(response);
//         }
//
//         public Task<DetailResponse> GetWerkzoekendeAsync(string id)
//         {
//             // Create the response object with the details
//             var faker = new WerkzoekendeFaker();
//             var details = faker.FakeWerkzoekende();
//             
//             var response = new DetailResponse()
//             {
//                 // Don't forget the metadata
//                 Response = details,
//             };
//             
//             return Task.FromResult(response);
//         }
//
//         public Task<MatchResponse> GetVacatureMatchesAsync(MatchesVacaturesRequest request, int responseCount)
//         {
//             // Create the response object with the matches
//             var matches = new List<object>();
//             var faker = new VacatureFaker();
//             
//             for (int i = 0; i < responseCount; i++)
//             {
//                 matches.Add(faker.FakeMpVacatureMatch());
//             }
//
//             var response = new MatchResponse()
//             {
//                 // Don't forget the metadata
//                 Response = matches,
//                 More = false
//             };
//             
//             return Task.FromResult(response);
//         }
//
//         public Task<DetailResponse> GetVacatureAsync(string id)
//         {
//             // Create the response object with the details
//             var faker = new VacatureFaker();
//             var details = faker.FakeVacature();
//             
//             var response = new DetailResponse()
//             {
//                 // Don't forget the metadata
//                 Response = details,
//             };
//             
//             return Task.FromResult(response);
//         }
//     }    
//     
// // func (p *FakerMatchProvider) WerkzoekendeMatches(_ model.MatchRequest, responseCount *int) (*model.MatchResponse, error) {
// //     matches := []*model.MPWerkzoekendeMatch{}
// //     count := defaultResponseCount
// //     if responseCount != nil {
// //         count = *responseCount
// //     }
// //     for i := 0; i < count; i++ {
// //         match := model.MPWerkzoekendeMatch{}
// //         err := faker.FakeData(&match)
// //         if err != nil {
// //             return nil, errors.Wrap(err, "faking data")
// //         }
// //         matches = append(matches, &match)
// //     }
// //
// //     stringMatches, err := json.Marshal(matches)
// //     if err != nil {
// //         return nil, errors.Wrap(err, "marshalling")
// //     }
// //
// //     return &model.MatchResponse{
// //         Response: stringMatches,
// //         More:     false,
// //     }, nil
// // }
