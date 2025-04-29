using SpamDetector;

SpamDetector.SpamDetector.ModelInput sampleData = new SpamDetector.SpamDetector.ModelInput()
{
    Content = @"Hello John, Could you please review the attached design mockups and share your feedback by EOD Thursday? Let me know if you need any clarifications. Best regards, Alex",
};



Console.WriteLine("Using model to make single prediction -- Comparing actual IsSpam with predicted IsSpam from sample data...\n\n");


Console.WriteLine($"Content: {@"Hello John, Could you please review the attached design mockups and share your feedback by EOD Thursday? Let me know if you need any clarifications. Best regards, Alex"}");
Console.WriteLine($"IsSpam: {@"false"}");


var sortedScoresWithLabel = SpamDetector.SpamDetector.PredictAllLabels(sampleData);
Console.WriteLine($"{"Class",-40}{"Score",-20}");
Console.WriteLine($"{"-----",-40}{"-----",-20}");

foreach (var score in sortedScoresWithLabel)
{
    Console.WriteLine($"{score.Key,-40}{score.Value,-20}");
}

Console.WriteLine("=============== End of process ===============");
Console.ReadKey();