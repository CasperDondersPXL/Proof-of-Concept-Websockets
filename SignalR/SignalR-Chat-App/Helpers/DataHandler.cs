namespace SignalR_Chat_App.Helpers
{
    public class DataHandler
    {
        private readonly IList<DataItem> _data;
        private readonly FileHandler _fileHandler;

        public DataHandler(FileHandler fileHandler)
        {
            _data = new List<DataItem>();
            _fileHandler = fileHandler;
        }

        public async Task AddDataItem(DataItem item)
        {
            _data.Add(item);
        }

        public async Task Flush()
        {
            string filePath = @"test.json";
            _fileHandler.SaveListToJsonFile(_data, filePath);
        }
    }
}
