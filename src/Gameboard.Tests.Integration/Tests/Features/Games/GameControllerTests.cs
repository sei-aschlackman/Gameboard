using Gameboard.Api;
using Gameboard.Api.Data;

namespace Gameboard.Tests.Integration;

public class GameControllerTests : IClassFixture<GameboardTestContext<GameboardDbContextPostgreSQL>>
{
    private readonly GameboardTestContext<GameboardDbContextPostgreSQL> _testContext;

    public GameControllerTests(GameboardTestContext<GameboardDbContextPostgreSQL> testContext)
    {
        _testContext = testContext;
    }

    [Fact]
    public async Task GameController_Create_ReturnsGame()
    {
        // arrange
        var game = new NewGame()
        {
            Name = "Test game",
            Competition = "Test competition",
            Season = "1",
            Track = "Individual",
            Sponsor = "Test Sponsor",
            GameStart = DateTimeOffset.UtcNow,
            GameEnd = DateTime.UtcNow + TimeSpan.FromDays(30),
            RegistrationOpen = DateTimeOffset.UtcNow,
            RegistrationClose = DateTime.UtcNow + TimeSpan.FromDays(30),
            RegistrationType = GameRegistrationType.Open
        };

        var client = _testContext.CreateHttpClientWithAuth();

        // act
        var responseGame = await client
            .PostAsync("/api/game", game.ToJsonBody())
            .WithContentDeserializedAs<Api.Data.Game>(_testContext.GetJsonSerializerOptions());

        // assert
        responseGame.Name.ShouldBe(game.Name);
    }
}
