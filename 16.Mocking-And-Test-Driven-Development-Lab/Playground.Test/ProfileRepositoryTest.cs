using Moq;

namespace Playground.Test
{
    public class ProfileRepositoryTest
    {
        [Test]
        public void GetAllAdultsShouldReturnProfilesWithAgeAbove18()
        {
            // Assert
            var profileDataMock = new Mock<IProfileData>();

            profileDataMock.Setup(data => data.All())
                .Returns(new List<Profile>
                {
                     new Profile {Age = 19},
                     new Profile {Age = 30}
                });

            var profileRepository = new ProfileRepository(profileDataMock.Object);

            //var profileRepository = new ProfileRepository(new FakeProfileData());

            // Act
            var allAdults = profileRepository.GetAllAdults();

            // Assert
            //Assert.That(allAdults.All(u => u.Age >= 18));
            Assert.That(allAdults.Count == 2);
        }

        [Test]
        public void GetByUsernameReturnsCorrectProfile()
        {
            // Arrange
            var username = "testprofile34";

            var profileDataMock = new Mock<IProfileData>();
            profileDataMock
                .Setup(data => data.All())
                .Returns(new List<Profile>()
                {
                   new Profile {Username = username, Age = 20},
                   new Profile {Username = "kesten.111", Age = 30}
                });

            var profileRepository = new ProfileRepository(profileDataMock.Object);

            // Act
            var profile = profileRepository.GetByUsername(username);

            // Assert
            Assert.That(profile.Username == username);
            Assert.That(profile.Age == 20);
        }
    }
}