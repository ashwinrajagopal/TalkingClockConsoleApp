using TimeToTextLibrary.BusinessLogic;
using Microsoft.Extensions.DependencyInjection;

namespace TimeToTextLibraryTest
{
    /// <summary>
    /// Unit Test class for TimeToText class in TimeToText Lib
    /// </summary>
    public class TimeToTextTest
    {

        /// <summary>
        /// IEnumerable used to execute the Unit Test with multiple values
        /// </summary>
        public static IEnumerable<object[]> DifferentTime =>
        new List<object[]>
        {
            new object[] { new TimeSpan(19,00,00) , "Seven o'clock"},
            new object[] { new TimeSpan(13,55,00) , "Five to Two"},
        };

        /// <summary>
        /// Unit test which runs multiple inputs for the unit method 
        /// </summary>
        /// <param name="time"></param>
        /// <param name="expected"></param>
        [Theory]
        [MemberData(nameof(DifferentTime))]
        public void TimeToText_ReturnsExpectedOutput(TimeSpan time, string expected)
        {
            // Arrange
            var services = new ServiceCollection();
            services.AddTransient<ITimeToTextConverter, TimeToTextConverter>(); // add the service to the DI container

            var serviceProvider = services.BuildServiceProvider();
            var myService = serviceProvider.GetService<ITimeToTextConverter>(); // resolve the service from the container

            // Act
            var result = myService?.TimeToText(time);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}