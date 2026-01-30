using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using HtmlAgilityPack;
using Newtonsoft.Json;

namespace project2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        public string WordCount1(Stream fileStream)
        {
            // Initialize a stream reader with the provided file stream
            StreamReader reader = new StreamReader(fileStream);
            // Read the entire content of the file into a string
            string content = reader.ReadToEnd();
            // Define a regular expression to match words (one or more consecutive word characters)
            Regex wordPattern = new Regex(@"\w+");

            // Find all matches of the word pattern in the content
            MatchCollection matches = wordPattern.Matches(content);
            // Initialize a dictionary to count the frequency of each word
            Dictionary<string, int> wordCountDictionary = new Dictionary<string, int>();
            // Iterate over each match
            foreach (Match match in matches) {
                string word = match.Value.ToLower();// Convert the matched word to lower case
                // If the word is already in the dictionary, increment its count
                if (wordCountDictionary.ContainsKey(word)) {
                    wordCountDictionary[word]++;
                }
                else
                {
                    wordCountDictionary[word] = 1;
                }
            }
            // Initialize a StringBuilder to create a JSON string
            StringBuilder json = new StringBuilder();
            // Start the JSON object
            json.Append("{\n");
            int i = 0;
            // Iterate over each word and its count in the dictionary
            foreach (KeyValuePair<string, int> pair in wordCountDictionary)
            {
                // Append the word and its count to the JSON object
                json.Append($"\"{pair.Key}\": {pair.Value}");
                i++;
                // Add a comma and a new line every 6 words for formatting
                if (i % 6 == 0)
                {
                    json.Append(",\n");
                }
                else if (i != wordCountDictionary.Count)
                {
                    json.Append(", ");
                }
            }
            // End the JSON object
            json.Append("\n}");

            return json.ToString();// Return the JSON string
        }
        // Define a mapping from phone keypad numbers to letters
        private Dictionary<char, string> phoneKeyMapping = new Dictionary<char, string>
        {
                { '0', "0" },
                { '1', "1" },
                { '2', "ABC" },
                { '3', "DEF" },
                { '4', "GHI" },
                { '5', "JKL" },
                { '6', "MNO" },
                { '7', "PQRS" },
                { '8', "TUV" },
                { '9', "WXYZ" },
        };
        // List of predefined words ordered by length in descending order
        private List<string> predefinedWords = new List<string>
        {
            "CSE445598",
            "ASU",
            "helloClass",
            "CSE110",
            "SCIDSE",
            "1800FLOWERS"
        }.OrderByDescending(w => w.Length).ToList();
        // Method to convert a string of numbers into words
        public string Number2Words(string number)
        {
            // Check if the number matches a predefined word
            foreach (string word in predefinedWords)
            {
                string wordAsNumbers = string.Empty;
                foreach (char c in word.ToUpper())
                {
                    // For every character in the predefined word, find the corresponding number
                    // on a phone keypad
                    var key = phoneKeyMapping.FirstOrDefault(x => x.Value.Contains(c));
                    // If a matching key is found, add it to the string
                    if (!key.Equals(default(KeyValuePair<char, string>)))
                    {
                        wordAsNumbers += key.Key;
                    }
                }
                // If the number matches the numeric representation of the predefined word,
                // return the words
                if (number.StartsWith(wordAsNumbers))
                {
                    return word;
                }
            }

            // Otherwise, convert the number to words
            string result = string.Empty;

            foreach (char c in number) {
                if (phoneKeyMapping.ContainsKey(c)) {
                    result += phoneKeyMapping[c][0];  // Select the first letter for simplicity.
                }
            }

            return result;
        }

        
        public string[] getWsdlAddress(string url)
        {
            try
            {
                WebClient client = new WebClient();
                string pageContent = client.DownloadString(url);

                // A regular expression to find WSDL addresses
                Regex regex = new Regex(@"(http(s)?:\/\/[^\s]*\.wsdl|http(s)?:\/\/[^\s]*\?wsdl)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                MatchCollection matches = regex.Matches(pageContent);

                string[] wsdlAddresses = new string[matches.Count];
                for (int i = 0; i < matches.Count; i++)
                {
                    wsdlAddresses[i] = matches[i].Value;
                }

                return wsdlAddresses;
            }
            catch (Exception ex)
            {
                // Log the exception and return null
                // You should replace this with your actual logging framework
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public string[] GetWsOperations(string url)
        {
            MetadataExchangeClient mexClient = new MetadataExchangeClient(new Uri(url), MetadataExchangeClientMode.HttpGet);
            mexClient.ResolveMetadataReferences = true;
            MetadataSet metaDocs = mexClient.GetMetadata();
            WsdlImporter importer = new WsdlImporter(metaDocs);
            System.Collections.ObjectModel.Collection<ContractDescription> contracts = importer.ImportAllContracts();
            var operations = contracts.SelectMany(c => c.Operations, (c, o) => $"{o.Name} {string.Join(", ", o.Messages.Select(m => m.Body.ReturnValue.Type.Name))}");
            return operations.ToArray();
        }
    }
}
