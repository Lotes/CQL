using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MainCore.CQL.CQLParser;

namespace MainCore.CQL
{
    public class SpeakVisitor : CQLBaseVisitor<object>
    {
        public List<SpeakLine> Lines = new List<SpeakLine>();

        public override object VisitLine(CQLParser.LineContext context)
        {
            NameContext name = context.name();
            WordContext word = context.word();

            SpeakLine line = new SpeakLine() { Person = name.GetText(), Text = word.GetText() };
            Lines.Add(line);

            return line;
        }
    }

    public class SpeakLine
    {
        internal string Person;
        internal string Text;
    }

    public class Blubb
    {
        private static void Main(string[] args)
        {
            try
            {
                string input = "";
                StringBuilder text = new StringBuilder();
                Console.WriteLine("Input the chat.");

                // to type the EOF character and end the input: use CTRL+D, then press <enter>
                while ((input = Console.ReadLine()) != "\u0004")
                {
                    text.AppendLine(input);
                }

                AntlrInputStream inputStream = new AntlrInputStream(text.ToString());
                CQLLexer speakLexer = new CQLLexer(inputStream);
                CommonTokenStream commonTokenStream = new CommonTokenStream(speakLexer);
                var speakParser = new CQLParser(commonTokenStream);

                ChatContext chatContext = speakParser.chat();
                SpeakVisitor visitor = new SpeakVisitor();
                visitor.Visit(chatContext);

                foreach (var line in visitor.Lines)
                {
                    Console.WriteLine("{0} has said \"{1}\"", line.Person, line.Text);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
        }
    }
}
