using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace MyToDoList.Data
{
    internal class DataHandler
    {
        private readonly string _path;

        public DataHandler(string path)
        {
            _path = path;
        }

        public IToDoList Read()
        {
            using (StreamReader r = new(_path))
            {
                string json = r.ReadToEnd();
                var parsed = JsonSerializer.Deserialize<List<JsonParser>>(json, JsonParser.options);

                if (parsed != null)
                {
                    var goals = new List<MyTask>();
                    var completed = new List<MyTask>();

                    foreach (var item in parsed) 
                    {
                        if (MyTask.TryParse(item.Date, out DateTime? date) && date != null)
                        {
                            if (item.IsCompleted)
                            {
                                completed.Add(new MyTask(item.Description, date));
                            }
                            else 
                            {
                                goals.Add(new MyTask(item.Description, date));
                            }
                        }
                    }

                    return new ToDoList(goals, completed);
                }
            }

            return new ToDoList();
        }

        public void Write(List<MyTask> goals, List<MyTask> completed)
        {
            File.WriteAllText(_path, string.Empty);

            var result = new List<JsonParser>();

            foreach (var goal in goals) 
            {
                result.Add(new JsonParser(goal.Description, goal.CreationDate.ToString(), false));
            }

            foreach (var task in completed)
            {
                result.Add(new JsonParser(task.Description, task.CreationDate.ToString(), true));
            }

            string jsonString = JsonSerializer.Serialize(result, JsonParser.options);

            using StreamWriter outputFile = new(_path);

            outputFile.WriteLine(jsonString);

        }
    }
}
