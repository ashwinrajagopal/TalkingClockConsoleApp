using Microsoft.Extensions.Logging;
using TimeToTextLibrary.BusinessLogic;
namespace TalkingClock;


/// <summary>
/// App Class which acts as the entry point class
/// </summary>
public class App
{

    private ITimeToTextConverter _timeToTextConverter;
    private ILogger<App> _logger;
    public App(ITimeToTextConverter timeToTextConverter, ILogger<App> logger)
    {
        _timeToTextConverter = timeToTextConverter;
        _logger = logger;
    }

    /// <summary>
    /// Entry point of the App 
    /// </summary>
    /// <param name="args"></param>
    public void Run(string[] args)
    {
        TimeSpan time = DateTime.Now.TimeOfDay;
        // In case if no args are passed ,
        // current time will be considered to output the result
        if (args.Length == 0)
        {
            _logger.LogInformation($"Current Time is ");
        }
        else
        {
            if (!TimeSpan.TryParse(args[0], out TimeSpan timespan))
            {
                _logger.LogError("Error: Invalid time format . Please type in HH:MM format");
                return;
            }
            time = timespan;
        }

        string text = _timeToTextConverter.TimeToText(time);
        if (!string.IsNullOrEmpty(text))
        {
            Console.WriteLine(text);
        }
        else
        {
            _logger.LogError("Error while coverting");
        }


    }
}