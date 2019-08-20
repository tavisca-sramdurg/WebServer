namespace WebServer
{
    public class ApiMethodList
    {
        [ApiMethod("POST", "/year")]
        public bool IsLeapYear(string requestBody)
        {
            //Refactor acc to you
            string[] body = requestBody.Split(',');
            string[] data = new string[2];
            int year = 0;
            for (int i = 0; i < body.Length; i++)
            {
                if (body[i].Contains("year"))
                {
                    data = body[i].Split(':');
                    break;
                }
            }
            string[] tempArray = data[1].Split('}');
            int.TryParse(tempArray[0], out year);
            if (year % 100 == 0)
            {
                if (year % 400 == 0)
                    return true;
            }
            else if (year % 4 == 0)
            {
                return true;
            }
            return false;
        }
    }
}