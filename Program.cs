using AIWritingDetector.Helpers;
using AuthentiWrite.Service;
using System.Security.Principal;
using AuthentiWrite.Service.Helpers;
using AuthentiWrite.Service.Models;

var list = new List<Text>();

List<string> contents = FileHelper.GetDocsFromFile("example_AI_3.txt", "|||");

foreach (var txt in contents)
{
    Text text = new(txt, false);
    Console.WriteLine(text);
    list.Add(text);
}



FileHelper.WriteToFile(list, "result.csv");




//// Step 1 - Convert files to the JSON syntax.
////EssayHelpers.ConvertAndSaveEssays("C:\\AuthentiWrite\\docs\\example_AI_2.txt", "C:\\AuthentiWrite\\datasets\\example_2.txt", "AI");
////EssayHelpers.ConvertAndSaveEssays("C:\\AuthentiWrite\\docs\\example_H_2.txt", "C:\\AuthentiWrite\\datasets\\example_2.txt", "Human");


//EssayHelpers.ConvertAndSaveEssays("C:\\AuthentiWrite\\docs\\example_AI_3.txt", "C:\\AuthentiWrite\\datasets\\example_3.txt", "AI");
//EssayHelpers.ConvertAndSaveEssays("C:\\AuthentiWrite\\docs\\example_H_3.txt", "C:\\AuthentiWrite\\datasets\\example_3.txt", "H");

// Step 2 - Load the list of essays from disk.
var myEssays = EssayHelpers.LoadEssaysFromJson("C:\\AuthentiWrite\\datasets\\example_3.txt");

// Step 3 - Perform Feature Engineering / Feature Extraction
List<Text> texts = myEssays.Select(x => new Text(x.Content, isAIGenerated: x.Author == "AI")).ToList();

// Step 4 - Convert results to the dataset format.
MLDataset dataset = texts.ConvertToMLDataset(nameof(Text.IsAIGenerated));

// Step 5 - Verify the dataset
dataset.Print();

// Step 6 - Save the dataset to disk
dataset.SaveAsJson("C:\\AuthentiWrite\\datasets\\example_3b_dataset.json");

Console.WriteLine("Done!");