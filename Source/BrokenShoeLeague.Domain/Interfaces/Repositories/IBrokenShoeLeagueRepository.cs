using System;
using System.Linq;

namespace BrokenShoeLeague.Domain.Repositories
{
    public interface IBrokenShoeLeagueRepository
    {
        //Seasons
        void CreateSeason(Season season);
        Season GetSeasonById(int id);
        void RemoveSeason(Season season);
        IQueryable<Season> GetAllSeasons();
        bool SeasonExist(int seasonId);



        //Player
        void CreatePlayer(Player newPlayer);
        Player GetPlayerById(int id);
        Player GetPlayerByName(string name);
        void RemovePlayer(Player player);
        IQueryable<Player> GetAllPlayers();
        bool PlayerExist(int playerId);



        //ImageCarousel
        void CreateImageCarousel(ImageCarousel imageCarousel);
        ImageCarousel GetImageCarouselById(int id);
        void RemoveImageCarousel(ImageCarousel imageCarousel);
        IQueryable<ImageCarousel> GetAllImageCarousel();

        //Matchdays
        void CreateMatchday(Matchday matchday);
        Matchday GetMatchdayById(int id);
        void RemoveMatchday(Matchday matchday);
        IQueryable<Matchday> GetAllMatchdays();
        void AddPlayerToMatchday(Matchday matchday, int playerId);
        bool MatchdayExist(int matchdayId);


        //PlayerRecords
        void CreatePlayerRecord(PlayerRecord playerRecord);
        PlayerRecord GetPlayerRecordById(int id);
        void RemovePlayerRecord(PlayerRecord playerRecord);
        IQueryable<PlayerRecord> GetAllPlayerRecords();
        void UpdatePlayerRecord(int playerRecordId, PlayerRecord data);

        //transaction manager
        void SaveChanges();

        void UpdateImageCarousel(int id, ImageCarousel data);

        //Users
        IQueryable<UserProfile> GetAllUsers();
        UserProfile FindUser(Func<UserProfile, bool> pred);

        //comments
        IQueryable<Comment> GetAllComments();
        void AddComment(Comment c);
        void RemoveComment(Comment c);
        void RemoveComment(int id);
        Comment GetCommentById(int id);

    }
}
