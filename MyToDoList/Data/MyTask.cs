using System.Globalization;
using System;
using System.Text.Json.Serialization;


namespace MyToDoList.Data
{
    internal class MyTask
    {
        public string Description { get; }

        public DateTime CreationDate { get; }
        

        public MyTask(string? description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentNullException(nameof(description));
            }

            Description = description;
            CreationDate = DateTime.Now;
        }

        public MyTask(string? description, DateTime? creationDate) 
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentNullException(nameof(description));
            }

            Description = description;
            CreationDate = creationDate ?? throw new ArgumentNullException(nameof(creationDate));

        }

        public static bool TryParse(string? text, out DateTime? date)
        {
            if (DateTime.TryParseExact(text, "dd/MM/yyyy hh:mm:ss tt", CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime result))
            {
                date = result;
                return true;
            }

            date = null;
            return false;
        }


        public override string ToString()
        {
            return $"{Description}\ncreated at: {CreationDate}";
        }
    }
}
