using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace ErrorsChecker.Services
{
    public class ErrorAnalyzer
    {
        public static List<string> CheckSyntaxErrors(string code)
        {
            List<string> errors = new List<string>();

            var syntaxTree = CSharpSyntaxTree.ParseText(code);
            var diagnostics = syntaxTree.GetDiagnostics();

            foreach (var diagnostic in diagnostics)
            {
                if (diagnostic.Severity == DiagnosticSeverity.Error)
                {
                    errors.Add($"Error: {diagnostic.GetMessage()} at line {diagnostic.Location.GetLineSpan().StartLinePosition.Line + 1}");
                }
            }

            return errors;
        }
    }
}
