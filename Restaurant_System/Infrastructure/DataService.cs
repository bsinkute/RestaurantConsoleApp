using System.Security;
using System.Text.Json;

namespace RestaurantSystem.Infrastructure
{
    public class DataService<T> : IDataService<T>
    {
        public required string FileName { get; set; }

        public void WriteJson(T data)
        {
            try
            {
                var serializedData = JsonSerializer.Serialize(data);
                File.WriteAllText(FileName, serializedData);
            }
            catch (NotSupportedException) 
            {
                Console.WriteLine("Could not serialize data. It will not be saved.");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("One or both argument are null. Data will not be saved.");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Could not save data to file.");
            }
            catch (PathTooLongException) 
            {
                Console.WriteLine("File name to long. Data will not be saved.");
            }
            catch (DirectoryNotFoundException) 
            {
                Console.WriteLine("Directory not found. Data will not be saved.");
            }
            catch (IOException) 
            { 
                Console.WriteLine("IO Error occured. Data will not be saved.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Unauthorized access to file. Data will not be saved.");
            }
            catch (SecurityException)
            {
                Console.WriteLine("Security error. Data will not be saved.");
            }
        }

        public T ReadJson()
        {
            try
            {
                bool fileExist = File.Exists(FileName);
                if (!fileExist)
                {
                    return default;
                }
                string fileContent = File.ReadAllText(FileName);
                return JsonSerializer.Deserialize<T>(fileContent);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File was not found. Returning default value.");
                return default;
            }
            catch (JsonException)
            {
                Console.WriteLine("Invalid JSON. Returning default value.");
                return default;
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("Could not deserialize data. Returning default value.");
                return default;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid argument. Returning default value.");
                return default;
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("File name too long. Returning default value.");
                return default;
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Directory not found. Returning default value.");
                return default;
            }
            catch (IOException)
            {
                Console.WriteLine("IO Error occurred. Returning default value.");
                return default;
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Unauthorized access to file. Returning default value.");
                return default;
            }
            catch (SecurityException)
            {
                Console.WriteLine("Security error. Returning default value.");
                return default;
            }
        }
    }
}
