using NCalc;
namespace FinancialCalculator;

public static class Evaluation
{
    public static String EvaluateExpression(String entry) {

        // Replace our visual characters with the correct operators
        String expression = entry.Replace(" ", "").Replace("×", "*").Replace("÷", "/").Replace("[", "(").Replace("]", ")").Replace("{", "(").Replace("}", ")").Replace("π", "Pi");
        Expression e = new Expression(expression);

        // Define some special delegations
        e.EvaluateParameter += delegate(string name, ParameterArgs args) {
            if (name == "Pi") {
                args.Result = (double)Math.PI;
            }
            if (name == "e") {
                args.Result = (double)Math.E;
            }
        };

        // Evaluate the expression
        var answer = e.Evaluate();

        // If the answer is a decimal or double, let's round it to 8 points
        if (answer is Double || answer is Decimal) {
            answer = Math.Round(Convert.ToDecimal(answer), 15);
        }
        return $"{answer}";
    }

    public static String RemoveCharacter(String entry) {

        // Handle edge case 0 or 1 length
        int entryLength = entry.Length;
        if (entryLength <= 1) {
            return "";
        }

        // Find the first non-whitespace character that comes before the final non-whitespace character
        // Return the string sliced at this position
        bool FirstCharFound = false;
        for (int i = entryLength - 1; i >= 0; i--) {
            if (char.IsWhiteSpace(entry[i])) {
                continue;
            }
            else if (!FirstCharFound) {
                FirstCharFound = true;
                continue;
            }
            else if (FirstCharFound) {
                if (char.IsDigit(entry[i])) {
                    return entry.Substring(0, i + 1);
                }
                return entry.Substring(0, i + 1) + " "; // It's not a digit, leave the space after operator
            }
        }
        return ""; // Only triggers if there was whitespace before just 1 real character in entry " + "
    }

    public static String ChangeSign(String entry) {
        double val = Convert.ToDouble(entry);
        return $"{-val}";
    }
}