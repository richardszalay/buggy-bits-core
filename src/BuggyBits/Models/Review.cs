using System;

namespace BuggyBits.Models
{
    /// <summary>
    /// Summary description for Review
    /// </summary>
    public class Review
    {
        public string quote;
        public string source;

        public Review()
        {
        }

        ~Review()
        {
            if (quote.ToString() != string.Empty)
            {
                quote = null;
            }
        }

        public void GenerateReview1()
        {
            Random rnd = new Random();
            int val = rnd.Next(3);

            if (val == 0)
            {
                quote = "Buggy Bits is the best thing since sliced bread";
                source = "The bug observer";
            }
            else if (val == 1)
            {
                quote = "I have never seen such buggy bits, Buggy Bits are truly breaking new ground";
                source = "Bug Magazine";
            }
            else if (val == 2)
            {
                quote = "Once you have start using Buggy Bits there is no going back";
                source = "Bug Chronicles";
            }
        }

        public void ClearReview()
        {
            quote = null;
            source = null;
        }

        public void GenerateReview2()
        {
            Random rnd = new Random();
            int val = rnd.Next(3);

            if (val == 0)
            {
                quote = "Truly amazing";
                source = "Bug Bashers";
            }
            else if (val == 1)
            {
                quote = "We have been using Buggy Bits since 1995 and the quality is always outstanding";
                source = "Delusional Software inc.";
            }
            else if (val == 2)
            {
                quote = "Buggy Bits always delivers what it promises";
                source = "BuggySite.com";
            }
        }
    }
}