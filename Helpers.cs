namespace AIWritingDetector
{
    internal static class Helpers
    {        
        // Helper method to count the number of syllables in a word
        internal static int CountSyllables(string word)
        {
            int syllableCount = 0;
            bool isPrevVowel = false;
            foreach (char c in word)
            {
                bool isVowel = "aeiouy".Contains(c.ToString().ToLower());
                if (isVowel && !isPrevVowel)
                {
                    syllableCount++;
                }
                isPrevVowel = isVowel;
            }
            if (word.EndsWith("e"))
            {
                syllableCount--;
            }
            if (syllableCount == 0)
            {
                syllableCount = 1;
            }
            return syllableCount;
        }

    }
}
