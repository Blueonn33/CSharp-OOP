namespace Playground.Test
{
    public class ProfileRepositoryTest
    {
        [Test]
        public void GetAllAdultsShouldReturnProfilesWithAgeAbove18()
        {
            // Assert
            var profileRepository = new ProfileRepository(new FakeProfileData());

            // Act
            var allAdults = profileRepository.GetAllAdults();

            // Assert
            Assert.That(allAdults.All(u => u.Age >= 18));
            // Assert.That(allAdults.Count == 2);
        }

        [Test]
        public void GetByUsernameReturnsCorrectProfile()
        {
            // Arrange
            var profileRepository = new ProfileRepository(new FakeProfileData());
            var usernameToSearchFor = "testprofile34";

            // Act
            var profile = profileRepository.GetByUsername(usernameToSearchFor);

            // Assert
            Assert.That(profile.Username == usernameToSearchFor);
            Assert.That(profile.Age == 22);
        }
    }
}