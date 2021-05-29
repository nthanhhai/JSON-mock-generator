using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine.Text;
using CommandLine;

namespace JSON_mock_generator
{
    class Options
    {
        [Option("output", Required = false, HelpText = "Output JSON mock data filename.")]
        public string outputFileName { get; set; }

        [Option("number", Required = true, HelpText = "Number of record to generate.")]
        public string number { get; set; }

        [Option("invalid", Required = false, HelpText = "To generate invlid data. Y/N")]
        public string isInvalid { get; set; }

        [Usage(ApplicationAlias = "json-mock-generator")]
        public static IEnumerable<Example> Examples
        {
            get
            {
                return new List<Example>() {
                    new Example("Generate mnock test data based on a provided template", new Options { outputFileName = "testdata.json", number = "1000", isInvalid = "N" })
                };
            }
        }
    }
}
