using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text;
using zdt_application.Data;
using zdt_application.DTOs;
using zdt_application.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace zdt_application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultsController : Controller
    {
        private readonly DBContext _context;
        private readonly HttpClient _httpClient = new HttpClient();
        public ResultsController(DBContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> GetFullInfo()
        {
            string url = "http://api.isportsapi.com/sport/football/league/basic?api_key=NDYCvrKY4dBFgk9w";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            // GET request
            request.Method = "GET";
            request.ReadWriteTimeout = 5000;
            request.ContentType = "text/html;charset=UTF-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));

            // Return content
            string retString = myStreamReader.ReadToEnd();
            return Ok(retString);
        }

        [AllowAnonymous]
        [HttpGet("getMatchesByDate/{date}")]
        public async Task<ActionResult> GetMatchesByDate(string date)
        {
            string url = $"http://api.isportsapi.com/sport/football/league/basic?api_key=NDYCvrKY4dBFgk9w&date={date}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            // GET request
            request.Method = "GET";
            request.ReadWriteTimeout = 5000;
            request.ContentType = "text/html;charset=UTF-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));

            // Return content
            string retString = myStreamReader.ReadToEnd();
            return Ok(retString);
        }

        [AllowAnonymous]
        [HttpGet("getMatchesById/{id}")]
        public async Task<ActionResult> GetMatchesById(string id)
        {
            string url = $"http://api.isportsapi.com/sport/football/league/basic?api_key=NDYCvrKY4dBFgk9w&matchid={id}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            // GET request
            request.Method = "GET";
            request.ReadWriteTimeout = 5000;
            request.ContentType = "text/html;charset=UTF-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));

            // Return content
            string retString = myStreamReader.ReadToEnd();
            return Ok(retString);
        }

        [AllowAnonymous]
        [HttpGet("getAllSeasonMatchesByLeagueId/{id}")]
        public async Task<ActionResult> GetAllSeasonMatchesByLeagueId(string id)
        {
            string url = $"http://api.isportsapi.com/sport/football/league/basic?api_key=NDYCvrKY4dBFgk9w&leagueId={id}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            // GET request
            request.Method = "GET";
            request.ReadWriteTimeout = 5000;
            request.ContentType = "text/html;charset=UTF-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));

            // Return content
            string retString = myStreamReader.ReadToEnd();
            return Ok(retString);
        }

        [AllowAnonymous]
        [HttpGet("getTeamByName/{teamName}")]
        public async Task<ActionResult> GetTeamInfo(string teamName)
        {
            string url = $"http://api.isportsapi.com/sport/football/team/search?api_key=NDYCvrKY4dBFgk9w&name={teamName}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            // GET request
            request.Method = "GET";
            request.ReadWriteTimeout = 5000;
            request.ContentType = "text/html;charset=UTF-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));

            // Return content
            string retString = myStreamReader.ReadToEnd();
            return Ok(retString);
        }

        [AllowAnonymous]
        [HttpGet("getLeagueById/{id}")]
        public async Task<ActionResult> GetLeagueInfo(string id)
        {
            string url = $"http://api.isportsapi.com/sport/football/team?api_key=NDYCvrKY4dBFgk9w&leagueId={id}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            // GET request
            request.Method = "GET";
            request.ReadWriteTimeout = 5000;
            request.ContentType = "text/html;charset=UTF-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));

            // Return content
            string retString = myStreamReader.ReadToEnd();
            return Ok(retString);
        }

        [AllowAnonymous]
        [HttpGet("getPlayersByTeamId/{id}")]
        public async Task<ActionResult> GetPlayersByTeam(string id)
        {
            string url = $"http://api.isportsapi.com/sport/football/player?api_key=NDYCvrKY4dBFgk9w&teamId={id}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            // GET request
            request.Method = "GET";
            request.ReadWriteTimeout = 5000;
            request.ContentType = "text/html;charset=UTF-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));

            // Return content
            string retString = myStreamReader.ReadToEnd();
            return Ok(retString);
        }

        [AllowAnonymous]
        [HttpGet("getPlayerStatsByLeagueId/{id}")]
        public async Task<ActionResult> GetPlayerStatsByLeague(string id)
        {
            string url = $"http://api.isportsapi.com/sport/football/playerstats/league?api_key=NDYCvrKY4dBFgk9w&leagueId={id}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            // GET request
            request.Method = "GET";
            request.ReadWriteTimeout = 5000;
            request.ContentType = "text/html;charset=UTF-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));

            // Return content
            string retString = myStreamReader.ReadToEnd();
            return Ok(retString);
        }

        [AllowAnonymous]
        [HttpGet("getLeagueStandingsById/{id}")]
        public async Task<ActionResult> GetStandingsByLeague(string id)
        {
            string url = $"http://api.isportsapi.com/sport/football/standing/league?api_key=NDYCvrKY4dBFgk9w&leagueId={id}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            // GET request
            request.Method = "GET";
            request.ReadWriteTimeout = 5000;
            request.ContentType = "text/html;charset=UTF-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));

            // Return content
            string retString = myStreamReader.ReadToEnd();
            return Ok(retString);
        }

        [AllowAnonymous]
        [HttpGet("getTopScoresByLeague/{id}")]
        public async Task<ActionResult> GetTopScorersByLeague(string id)
        {
            string url = $"http://api.isportsapi.com/sport/football/topscorer?api_key=NDYCvrKY4dBFgk9w&leagueId={id}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            // GET request
            request.Method = "GET";
            request.ReadWriteTimeout = 5000;
            request.ContentType = "text/html;charset=UTF-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));

            // Return content
            string retString = myStreamReader.ReadToEnd();
            return Ok(retString);
        }

        [AllowAnonymous]
        [HttpGet("getPlayerInfoById/{id}")]
        public async Task<ActionResult> GetPlayerInfoById(string id)
        {
            string url = $"http://api.isportsapi.com/sport/football/player?api_key=NDYCvrKY4dBFgk9w&playerId={id}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            // GET request
            request.Method = "GET";
            request.ReadWriteTimeout = 5000;
            request.ContentType = "text/html;charset=UTF-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));

            // Return content
            string retString = myStreamReader.ReadToEnd();
            return Ok(retString);
        }

        [AllowAnonymous]
        [HttpGet("getPlayerInfoByName/{name}")]
        public async Task<ActionResult> GetPlayerInfoByName(string name)
        {
            string url = $"http://api.isportsapi.com/sport/football/player/search?api_key=NDYCvrKY4dBFgk9w&name={name}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            // GET request
            request.Method = "GET";
            request.ReadWriteTimeout = 5000;
            request.ContentType = "text/html;charset=UTF-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));

            // Return content
            string retString = myStreamReader.ReadToEnd();
            return Ok(retString);
        }

        [AllowAnonymous]
        [HttpPost("pinLeague/{userId}/{leagueId}")]
        public async Task<ActionResult> PinLeague(string userId, int leagueId)
        {
            try
            {
                var user = await _context.Users.FindAsync(userId);
                var league = new PinnedLeagues{
                    LeagueId = leagueId
                };

                if (user == null || league == null)
                {
                    return NotFound("User or League not found");
                }

                // Check if the relationship already exists
               var existingRelationship = await _context.UserPinnedLeagues
                    .FirstOrDefaultAsync(upl => upl.UserId == userId && upl.PinnedLeagues.LeagueId == leagueId);
               
                if (existingRelationship != null)
                {
                    _context.UserPinnedLeagues.Remove(existingRelationship);
                    return Ok("League unpinned successfully");
                }
                _context.PinnedLeagues.Add(league);
                await _context.SaveChangesAsync();
                var userPinnedLeagues = new UserLeague()
                {
                    UserId = userId,
                    PinnedLeaguesId = league.Id
                };

               // _context.PinnedLeagues.Add(league);
                _context.UserPinnedLeagues.Add(userPinnedLeagues);

                await _context.SaveChangesAsync();

                return Ok("League pinned successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [AllowAnonymous]
        [HttpPost("comment/{userId}/{matchid}/{comment}")]
        public async Task<ActionResult> Comment(string userId, int matchid, string comment)
        {
            var userComment = new UserComment
            {
                UserId = userId,
                MatchId = matchid,
                Comment = comment
            };

            await _context.AddAsync(userComment);
            await _context.SaveChangesAsync();
            return Ok("Comment created successfully");
        }

        [AllowAnonymous]
        [HttpGet("get/comments/{matchId}")]
        public async Task<ActionResult<List<UserCommentDto>>> GetComments(int matchId)
        {
            var comments = await _context.UserComments.Where(uc => uc.MatchId == matchId).ToListAsync();
            var user = _context.Users;

            var commentLists = new List<UserCommentDto>();

            foreach (var comment in comments)
            {
              commentLists.Add(new UserCommentDto
              {
                  Comment = comment.Comment,
                  User = await user.FirstOrDefaultAsync(u => u.Id == comment.UserId)
              });   
            }
            return Ok(commentLists);
        }

        [AllowAnonymous]
        [HttpPost("predict/{userId}/{matchId}/{prediction}")]
        public async Task<ActionResult> PredictMatch(string userId, int matchId, int prediction)
        {
            var hasUserPredict = await _context.UserMatchPredictions.FirstOrDefaultAsync(p => p.UserId == userId && p.MatchId == matchId);

            if (hasUserPredict != null)
            {
                return new ContentResult
                {
                    StatusCode = 202,
                    Content = "User has already made a prediction for this match.",
                    ContentType = "text/plain"
                };
            }

            var userPrediction = new UserMatchPrediction()
            {
                UserId = userId,
                MatchId = matchId,
                Prediction = prediction
            };

            await _context.AddAsync(userPrediction);
            await _context.SaveChangesAsync();
            return Ok("Prediction saved successfully");
        }

        [AllowAnonymous]
        [HttpGet("getPrediction/{matchId}")]
        public async Task<ActionResult> GetPrediction(int matchId)
        {
            var totalHomeTeamPoints = await _context.UserMatchPredictions.CountAsync(p => p.Prediction == 1);
            var totalAwayTeamPoints = await _context.UserMatchPredictions.CountAsync(p => p.Prediction == 2);
            var totalDrawPoints = await _context.UserMatchPredictions.CountAsync(p => p.Prediction == 3);

            var response = new UserPredictionDto
            {
                HomeTeamPoints = totalHomeTeamPoints,
                AwayTimePoints = totalAwayTeamPoints,
                DrawPoints = totalDrawPoints
            };

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("rateMatch/{userId}/{matchId}/{rate}")]
        public async Task<ActionResult> RateMatch(string userId, int matchId, double rate)
        {
            var hasUserRate = await _context.MatchRatings.FirstOrDefaultAsync(p => p.UserId == userId && p.MatchId == matchId);

            if (hasUserRate != null)
            {
                return new ContentResult
                {
                    StatusCode = 202,
                    Content = "User has already made a rate for this match.",
                    ContentType = "text/plain"
                };
            }

            var userPrediction = new MatchRating()
            {
                UserId = userId,
                MatchId = matchId,
                Rate = rate
            };

            await _context.AddAsync(userPrediction);
            await _context.SaveChangesAsync();
            return Ok("Rate saved successfully");
        }

        [AllowAnonymous]
        [HttpGet("getRating/{matchId}")]
        public async Task<ActionResult> GetRating(int matchId)
        {
            var totalRateCount = await _context.MatchRatings.Where(r => r.MatchId == matchId).SumAsync(x => x.Rate);
            var totalUserRatings = await _context.MatchRatings.CountAsync(r => r.MatchId == matchId);
            var response = totalRateCount / totalUserRatings;
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("click/{matchId}")]
        public async Task<ActionResult> ClickedMatch(int matchId)
        {
            var isMatchClicked = await _context.ClickedMatches.FirstOrDefaultAsync(m => m.MatchId == matchId);

            if (isMatchClicked != null)
            {
                isMatchClicked.Clicked = isMatchClicked.Clicked + 1;
                _context.Update(isMatchClicked);
            }
            else
            {
                var clickedMatch = new MostClickedMatch()
                {
                    MatchId = matchId,
                    Clicked = 1
                };
                await _context.AddAsync(clickedMatch);
            }

            await _context.SaveChangesAsync();
            return Ok("Match click saved successfully");
        }

        [AllowAnonymous]
        [HttpGet("getMostClickedMatches")]
        public async Task<ActionResult> MostClickedMatch()
        {
            var mostClickedMatches = _context.ClickedMatches.OrderBy(m => m.Clicked);
            return Ok(mostClickedMatches);
        }
    }
}