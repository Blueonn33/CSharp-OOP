namespace Playground.Test
{
    public class ProfileRepositoryTest
    {
        [Test]
        public void GetAllAdultsShouldReturnProfilesWithAgeAbove18()
        {
            // Assert
            var profileRepository = new ProfileRepository();

            // Act
            var allAdults = profileRepository.GetAllAdults();

            // Assert
            Assert.That(allAdults.All(u => u.Age >= 18));
            // Assert.That(allAdults.Count == 2);
        }
    }
}