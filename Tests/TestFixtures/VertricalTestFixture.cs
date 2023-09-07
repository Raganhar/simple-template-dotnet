using Xunit;

namespace Tests.TestFixtures;

[CollectionDefinition(nameof(VertricalTestFixture))]
public class VertricalTestFixture: ICollectionFixture<VerticalTestFactory>
{
    
}
