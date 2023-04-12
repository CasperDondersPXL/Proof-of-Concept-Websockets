using Newtonsoft.Json;

namespace SignalR_Chat_App.Helpers
{
    public class FileHandler
    {
        public void SaveListToJsonFile<T>(IList<T> list, string filePath)
        {
            // Convert the list to a JSON string
            string json = JsonConvert.SerializeObject(list);

            // Write the JSON string to a file
            using (StreamWriter file = File.CreateText(filePath))
            {
                file.Write(json);
            }
        }
    }
}
