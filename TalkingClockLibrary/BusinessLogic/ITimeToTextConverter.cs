namespace TimeToTextLibrary.BusinessLogic
{
    /// <summary>
    /// ITimeToTextConverter interface 
    /// </summary>
    public interface ITimeToTextConverter
    {

        /// <summary>
        /// Method which takes timespan and returns human readable text format of the same . 
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        string TimeToText(TimeSpan time);
    }
}