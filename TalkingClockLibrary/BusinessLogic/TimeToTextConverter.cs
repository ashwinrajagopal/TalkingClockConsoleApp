namespace TimeToTextLibrary.BusinessLogic;

/// <summary>
/// TimeToTextConverter class which incorporates the core functionality method
/// </summary>
public class TimeToTextConverter : ITimeToTextConverter
{

    /// <summary>
    /// Method which takes timespan and returns human readable text format of the same . 
    /// </summary>
    /// <param name="time">DateTime</param>
    /// <returns>text</returns>
    public string TimeToText(TimeSpan time)

    {
        string timeText = string.Empty;

        int hour = time.Hours % 12;

        if (hour == 0) hour = 12;



        string minuteText = "";

        int minute = time.Minutes;



        if (minute == 0)

        {

            return $"{NumberToText(hour)} o'clock";
        }

        else if (minute == 15)

        {

            minuteText = "Quarter past";

        }

        else if (minute == 30)

        {

            minuteText = "Half past";

        }

        else if (minute == 45)

        {

            hour = (hour + 1) % 12;

            if (hour == 0) hour = 12;



            minuteText = "Quarter to";

        }

        else if (minute < 30)

        {

            minuteText = NumberToText(minute) + " past";

        }

        else if (minute > 30)

        {

            hour = (hour + 1) % 12;

            if (hour == 0) hour = 12;



            minuteText = NumberToText(60 - minute) + " to";

        }



        string hourText = NumberToText(hour);

        return !string.IsNullOrEmpty(minuteText) && !string.IsNullOrEmpty(hourText) ?
            $"{minuteText} {hourText}" : string.Empty;

    }


    /// <summary>
    /// Method to convert number to text 
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    private string NumberToText(int number)

    {

        switch (number)

        {

            case 1: return "One";

            case 2: return "Two";

            case 3: return "Three";

            case 4: return "Four";

            case 5: return "Five";

            case 6: return "Six";

            case 7: return "Seven";

            case 8: return "Eight";

            case 9: return "Nine";

            case 10: return "Ten";

            case 11: return "Eleven";

            case 12: return "Twelve";

            case 13: return "Thirteen";

            case 14: return "Fourteen";

            case 16: return "Sixteen";

            case 17: return "Seventeen";

            case 18: return "Eighteen";

            case 19: return "Nineteen";

            default: break;

        }



        if (number >= 20 && number <= 59)

        {

            int tenth = number / 10;

            int ones = number % 10;



            string tenthText = "";

            switch (tenth)

            {

                case 2: tenthText = "Twenty"; break;

                case 3: tenthText = "Thirty"; break;

                case 4: tenthText = "Fourty"; break;

                case 5: tenthText = "Fifty"; break;

            }



            if (ones != 0)

            {

                string onesText = NumberToText(ones);

                return $"{tenthText} {onesText}";

            }

            else

            {

                return tenthText;

            }

        }



        return "";

    }

}