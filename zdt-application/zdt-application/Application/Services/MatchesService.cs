using AutoMapper;
using zdt_application.Application.Services.Base;
using zdt_application.Application.Wrappers;
using zdt_application.DTOs;
using zdt_application.DTOs.Matches;
using zdt_application.Infrastructure;
using zdt_application.Models;

namespace zdt_application.Application.Services
{
    public class MatchesService : BaseService, IMatchesService
    {
        private readonly IMatchRepository _matchRepository;
        private readonly IMapper _mapper;

        public MatchesService(IMatchRepository matchRepository, IMapper mapper)
        {
            _matchRepository = matchRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<string>> AddComment(string userId, int matchId, string comment)
        {
            var model = new UserComment
            {
                UserId = userId,
                Comment = comment,
                MatchId = matchId
            };

            await _matchRepository.AddComment(model);

            return BaseResponse<string>.Success("Comment was succesfully created!");
        }

        public async Task<BaseResponse<string>> ClickedMatch(int matchId)
        {
            var isMatchClicked = await _matchRepository.GetClickedMatch(matchId);
            
            if (isMatchClicked != null)
            {
                isMatchClicked.Clicked = isMatchClicked.Clicked + 1;
                await _matchRepository.UpdateClickedMatch(isMatchClicked);
            }
            else
            {
                var clickedMatch = new MostClickedMatch()
                {
                    MatchId = matchId,
                    Clicked = 1
                };

                await _matchRepository.AddClickedMatch(clickedMatch);
            }

            return BaseResponse<string>.Success("Match click saved successfully");
        }

        public async Task<BaseResponse<string>> DeleteComment(Guid commentId)
        {
            var userComment = await _matchRepository.GetCommentAsync(commentId);
            
            if(userComment != null)
            {
                return BaseResponse<string>.NotFound("Comment not found!");
            }

            await _matchRepository.DeleteComment(userComment);

            return BaseResponse<string>.Success("Comment deleted successfully");
        }

        public async Task<BaseResponse<string>> DeleteResultPrediction(Guid predictionId)
        {
            var prediction = await _matchRepository.GetUserPrediction(predictionId);

            if (prediction != null)
            {
                return BaseResponse<string>.NotFound("User Prediction not found!");
            }

            await _matchRepository.RemoveUserPrediction(prediction);
            
            return BaseResponse<string>.Success("Successfully deleted");
        }

        public async Task<BaseResponse<string>> EditComment(Guid commentId, string comment)
        {
            var userComment = await _matchRepository.GetCommentAsync(commentId);

            if (userComment != null)
            {
                return BaseResponse<string>.NotFound("User Comment not found!");
            }

            userComment.Comment = comment;
            await _matchRepository.UpdateCommentAsync(userComment);

            return BaseResponse<string>.Success("Comment edited successfully");
        }

        public async Task<BaseResponse<string>> EditResultPrediction(Guid predictionId, int? homeScore, int? awayScore)
        {
            var prediction = await _matchRepository.GetUserPrediction(predictionId);

            if (prediction != null)
            {
                return BaseResponse<string>.NotFound("User prediction not found!");
            }

            prediction.HomeScore = homeScore ?? prediction.HomeScore;
            prediction.AwayScore = awayScore ?? prediction.AwayScore;


            await _matchRepository.UpdateResultPredictionAsync(prediction);

            return BaseResponse<string>.Success("Successfully edited");
        }

        public async Task<BaseResponse<string>> GetAllMatches()
        {
            string url = $"{BaseUrl}/league/basic?api_key={ApiKey}";
            return await MakeHttpRequest(url);
        }

        public Task<BaseResponse<string>> GetAllSeasonMatchesByLeagueId(string leagueId)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<string>> GetMatchesByDate(string date)
        {
            string url = $"{BaseUrl}/schedule/basic?api_key={ApiKey}&date={date}";
            return await MakeHttpRequest(url);
        }

        public async Task<BaseResponse<string>> GetMatchesById(string id)
        {
            string url = $"{BaseUrl}/league/basic?api_key={ApiKey}&matchid={id}";
            return await MakeHttpRequest(url);
        }

        public async Task<BaseResponse<UserPredictionDto>> GetPredictionWithResultMatches(string userId)
        {
            var userPrediction = await _matchRepository.GetUserPredictionByUserId(userId);
            var response = _mapper.Map<UserPredictionDto>(userPrediction);

            return BaseResponse<UserPredictionDto>.Success(response);
        }

        public async Task<BaseResponse<int>> GetRating(int matchId)
        {
            var totalRateCount = await _matchRepository.SumRatingForMatch(matchId);
            var totalUserRatings = await _matchRepository.CountRatingForMatch(matchId);
          
            var response = totalRateCount / totalUserRatings;

            return BaseResponse<int>.Success(response);
        }

        public async Task<BaseResponse<List<MostClickedMatchDto>>> MostClickedMatch()
        {
            var mostClickedMatches = await _matchRepository.GetMostClickedMatch();
            var response = _mapper.Map<List<MostClickedMatchDto>>(mostClickedMatches);

            return BaseResponse<List<MostClickedMatchDto>>.Success(response);
        }

        public async Task<BaseResponse<string>> PredictMatch(string userId, int matchId, int prediction)
        {
            var predictionExists = _matchRepository.GetUserPredictionByUserAndMatchId(userId, matchId);

            if (predictionExists != null)
            {
                return BaseResponse<string>.BadRequest("User has already made a prediction for this match.");
            }

            var userPrediction = new UserMatchPrediction()
            {
                UserId = userId,
                MatchId = matchId,
                Prediction = prediction
            };

            await _matchRepository.CreateUserPrediction(userPrediction);

            return BaseResponse<string>.Success("Prediction saved successfully.");
        }

        public async Task<BaseResponse<string>> PredictWithResultMatches(List<UserResultPredictionDto> matchesPredictions)
        {
            var ratingsToAdd = new List<UserResultPrediction>();

            foreach (var userResultPrediction in matchesPredictions)
            {
                ratingsToAdd.Add(new UserResultPrediction
                {
                    HomeScore = userResultPrediction.HomeScore,
                    AwayScore = userResultPrediction.AwayScore,
                    MatchId = userResultPrediction.MatchId,
                    UserId = userResultPrediction.UserId
                });
            }

            await _matchRepository.CreateRatingsAsync(ratingsToAdd); 

            return BaseResponse<string>.Success("Prediction saved successfully");
        }

        public async Task<BaseResponse<string>> RateMatch(string userId, int matchId, double rate)
        {
            var userRateExists = await _matchRepository.GetMatchRatingAsync(userId, matchId);

            if (userRateExists != null)
            {
                return BaseResponse<string>.Success("Can not rate one game twice from same user!");
            }

            var userPrediction = new MatchRating()
            {
                UserId = userId,
                MatchId = matchId,
                Rate = rate
            };

            await _matchRepository.CreateRatingAsync(userPrediction);

            return BaseResponse<string>.Success("Rate saved successfully");
        }

        public async Task<BaseResponse<List<MatchRatingDto>>> TopRatedMatches()
        {
            var mostClickedMatches = await _matchRepository.GetAllMatchRating();
            var response = _mapper.Map<List<MatchRatingDto>>(mostClickedMatches);

            return BaseResponse<List<MatchRatingDto>>.Success(response);
        }
    }
}