namespace WebServer
{
    public class ApiMethodList
    {
        [ApiMethod("POST", "/year")]
        public bool IsLeapYear(string requestBody)
        {
            string[] tempArray = requestBody.Split(':');
            char[] charsToTrim = { ' ', '\n', '}' };
            string year = tempArray[1].Trim(charsToTrim);

            int yearValue = 0;
            int.TryParse(year, out yearValue);
            if (yearValue % 100 == 0)
            {
                if (yearValue % 400 == 0)
                    return true;
            }
            else if (yearValue % 4 == 0)
            {
                return true;
            }
            return false;
        }
    }
}