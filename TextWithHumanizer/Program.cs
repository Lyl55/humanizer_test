using System;
using System.ComponentModel;
using Humanizer;

namespace TextWithHumanizer
{
    class Program
    {
        static void Main(string[] args)
        {
            var texts = new Func<string>[]
            {
                ()=>"user_not_found",
                ()=>"user_not_found".Humanize(),//user not found
                ()=>"user_not_found".Humanize(LetterCasing.Sentence),//User not found
                ()=>"user_not_found".Dehumanize(),//UserNotFound
                ()=>"user not found".Underscore(),//user_not_found
                ()=>"This is the history".Truncate(14,"..."),//This is the...
                ()=>MyEnum.First.Humanize(),
                ()=>"person".Pluralize(),
                ()=>DateTime.UtcNow.AddHours(-24).Humanize(),//yesterday
                ()=>1.ToWords().Humanize(),//one
                ()=>50.Millions().ToString()
            };
            foreach (var text in texts)
            {
                Console.WriteLine(text());
            }
        }
        public enum MyEnum
        {
            [Description("First element")]
            First,
            Second,
            Third
        }
    }
}
