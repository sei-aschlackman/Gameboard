using System.Threading.Tasks;
using Gameboard.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Gameboard.Api.Features.UnityGames;

public class UnityStore : Store<Data.ChallengeSpec>, IUnityStore
{
    public UnityStore(GameboardDbContext dbContext)
        : base(dbContext) { }

    public async Task<Data.ChallengeEvent> AddUnityChallengeEvent(Data.ChallengeEvent challengeEvent)
    {
        this.DbContext.ChallengeEvents.Add(challengeEvent);
        await this.DbContext.SaveChangesAsync();

        return challengeEvent;
    }

    public async Task<Data.Challenge> HasChallengeData(string gamespaceId)
    {
        return await DbContext
            .Challenges
            .AsNoTracking()
            .Include(c => c.Events)
            .FirstOrDefaultAsync(c => c.Id == gamespaceId);
    }
}
