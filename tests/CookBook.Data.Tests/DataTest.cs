namespace CookBook.Data.Tests;

public class DataTest : IClassFixture<CookBookDbFixture>
{
    private readonly CookBookDbFixture _fixture;

    public DataTest(CookBookDbFixture fixture)
    {
        _fixture = fixture;
    }
    
    protected TService GetRequiredService<TService>()
    {
        return _fixture.GetRequiredService<TService>();
    }
}