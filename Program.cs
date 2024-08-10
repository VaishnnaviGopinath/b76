using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var data = new List<(string Country, string City)>
        {
            ("India", "Delhi"),
            ("India", "Bangalore"),
            ("India", "Chennai"),
            ("India", "Trivandrum"),
            ("India", "Goa"),
            ("USA", "New York"),
            ("USA", "Seattle"),
            ("USA", "San Diego"),
            ("USA", "California"),
            ("Canada", "Montreal"),
            ("Canada", "Toronto"),
            ("Canada", "Vancouver"),
            ("Canada", "Ottawa")
        };

        // Group the data by Country
        var groupedData = data.GroupBy(x => x.Country)
                              .ToDictionary(g => g.Key, g => g.Select(x => x.City).ToList());

        foreach (var country in groupedData.Keys)
        {
            var cities = groupedData[country];
            var result = new List<string>();
            string currentLine = "";

            foreach (var city in cities)
            {
                // Check length without comma
                int candidateLength = string.IsNullOrEmpty(currentLine) ? city.Length : currentLine.Length + city.Length;

                // If the candidate length exceeds 15 characters, finalize the current line and start a new one
                if (candidateLength > 15)
                {
                    result.Add(currentLine);
                    currentLine = city; // Start a new line with the current city
                }
                else
                {
                    if (!string.IsNullOrEmpty(currentLine))
                    {
                        currentLine += ",";
                    }
                    currentLine += city;
                }
            }

            // Add the last line if it's not empty
            if (!string.IsNullOrEmpty(currentLine))
            {
                result.Add(currentLine);
            }

            // Print the results in a tabular format
            Console.Write($"{country.PadRight(15)}"); // Print the country name

            foreach (var line in result)
            {
                Console.Write($"{line.PadRight(20)}");
            }

            Console.WriteLine(); // Move to the next line for the next country
        }
    }
}
