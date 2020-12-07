using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day7
{
    public class Rule
    {
        public string BagType { get; }
        public Dictionary<string, int> Content { get; } = new Dictionary<string, int>();
        private Regex _ruleRegex = new Regex(@"(?<bagType>.*) bags contain (?<content>.*).");
        private Regex _contentRegex = new Regex(@"(?<count>\d+) (?<bagType>.*) bags?");
        public Rule(string ruleAsString)
        {
            var match = _ruleRegex.Match(ruleAsString);
            BagType = match.Groups["bagType"].Value;
            var content = match.Groups["content"].Value;
            AddContent(content);
        }

        private void AddContent(string content)
        {
            if (content == "no other bags")
                return;
            
            content.Split(",").Select(x => x.Trim()).ToList()
                .ForEach(x => 
                {
                    var match = _contentRegex.Match(x);
                    Content.Add(match.Groups["bagType"].Value, int.Parse(match.Groups["count"].Value));
                });
        }
    }
}