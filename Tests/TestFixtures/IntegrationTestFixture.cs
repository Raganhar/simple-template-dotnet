using Xunit;

namespace Tests.TestFixtures;

[CollectionDefinition(nameof(IntegrationTestFixture))]
public class IntegrationTestFixture: ICollectionFixture<TestWebApplicationFactory>
{
    
}
