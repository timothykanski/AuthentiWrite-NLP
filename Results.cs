using AIWritingDetector;

public class Results
{
    public List<int> WordCount { get; set; }
    public List<int> AverageWordLengths { get; internal set; }
    public List<int> GradeLevels { get; set; }
    public List<SentenceVoice> SentenceVoices { get; set; }
    public List<SentencePerspective> SentencePerspectives { get; set; }
    public List<int> ContractionCounts { get; set; }
    public List<string> SlangWords { get; set; }
    public List<string> StudentWords { get; internal set; }

    public void Report()
    {
        Console.WriteLine("Word Count per Sentence:");
        foreach (var count in WordCount)
        {
            Console.WriteLine(count);
        }
        Console.WriteLine($"Average Number of Words per Sentence: {WordCount.Average()}");
        
        Console.WriteLine("Average Word Length per Sentence:");
        foreach (var length in AverageWordLengths)
        {
            Console.WriteLine(length);
        }
        Console.WriteLine($"Overall Average Word Length: {AverageWordLengths.Average()}");

        Console.WriteLine("Flesch-Kincaid Grade Levels:");
        foreach (var score in GradeLevels)
        {
            Console.WriteLine(score);
        }
        Console.WriteLine($"Average Flesch-Kincaid Grade Levels: {GradeLevels.Average()}");


        Console.WriteLine("Sentence Voice:");
        foreach (var voice in SentenceVoices)
        {
            Console.WriteLine(voice);
        }
        Console.WriteLine("Sentence Perspectives:");
        foreach (var perspective in SentencePerspectives)
        {
            Console.WriteLine(perspective);
        }
        Console.WriteLine("Contraction Counts:");
        foreach (var contractionCount in ContractionCounts)
        {
            Console.WriteLine(contractionCount);
        }
        Console.WriteLine("Slang Words:");
        foreach (var list in SlangWords)
        {
            Console.WriteLine(list);
        }
        Console.WriteLine("Student Words:");
        foreach (var list in StudentWords)
        {
            Console.WriteLine(list);
        }
    }
}



