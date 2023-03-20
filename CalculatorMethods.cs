using NCalc;
namespace FinancialCalculator;

public static class Evaluation
{
    public static String EvaluateExpression(String entry) {

        // Replace our visual characters with the correct operators
        String expression = entry.Replace(" ", "").Replace("×", "*").Replace("÷", "/").Replace("[", "(").Replace("]", ")").Replace("{", "(").Replace("}", ")").Replace("π", $"{(double)Math.PI}").Replace("e", $"{(double)Math.E}");

        // Apply our custom parser for exponents and other unique criteria
        for (int i = expression.IndexOf('^'); i >= 0; i = expression.IndexOf('^')) {

            // Check for exponents and capture Pow base and exponent blocks
            // Will populate exponents list with key value pairs where each base block is followed by its exponent block | exponents[0] = base1, exponents[1] = exp1, exponents[2] = base2, exponents[3] = exp3, etc.
            int parenthesisCounter = 0;
            bool baseBlockWrapped = false;
            int endOfBaseBlock = i-1;
            bool endOfBaseBlockFound = false;
            bool expBlockWrapped = false;
            int startOfExponentBlock = i+1;
            bool startOfExponentBlockFound = false;

            // Tuples for fetching base and exponent
            (int start, int end) baseIndex = default;
            (int start, int end) expIndex = default;

            // Find the Base block for the Pow
            for (int j = i-1; j >= 0; j--) {

                // We'll count the number of parenthesis blocks to apply to the base of the Pow
                if (expression[j] == ')') {
                    parenthesisCounter++;
                    // First time we enter this if statement represents finding the end of the block (if there are parenthesis)
                    if (!endOfBaseBlockFound) {
                        baseBlockWrapped = true;
                        endOfBaseBlockFound = true;
                        endOfBaseBlock = j;
                    }
                    continue;
                }
                if (expression[j] == '(') {
                    parenthesisCounter--;
                    // There are no more indices to check
                    if (j == 0 && parenthesisCounter == 0) {
                        baseIndex = (j, endOfBaseBlock);
                        parenthesisCounter = 0;
                        break;
                    }
                    else if (parenthesisCounter < 0) {
                        baseIndex = (j+1, endOfBaseBlock);
                        parenthesisCounter = 0;
                        break;
                    }
                    continue;
                }

                // Given we've already translated all special values to their (double)numerical equivalents, check if this char is part of a value
                // On first entry, we've found the end of the base block | on 0 index of j, we've found the natural beginning of the base block
                if (char.IsDigit(expression[j]) || expression[j] == '.') {

                    // First time we enter this if statement represents finding the end of the block (if there were no parenthesis to start)
                    if (!endOfBaseBlockFound) {
                        endOfBaseBlockFound = true;
                        endOfBaseBlock = j;
                    }

                    // Capture 0 as the natural start of this block and i-1 as the end of the block | this block represents the base of the exponent
                    if (j == 0) {
                        baseIndex = (0, endOfBaseBlock);
                        parenthesisCounter = 0;
                        break;
                    }
                    continue; // Continue checking until we either run into a non-digit and parenthesis counter is 0 or we reach start of string
                }

                // Capture j+1 as the start of this block and i-1 as the end of the block | this block represents the base of the exponent
                else {
                    if (parenthesisCounter == 0) {
                        if (baseBlockWrapped) {
                            baseIndex = (j, endOfBaseBlock);
                        }
                        else {
                            baseIndex = (j+1, endOfBaseBlock);
                        }
                        parenthesisCounter = 0;
                        break;
                    }
                    continue; // We still need to find the closing parenthesis
                }
            }

            // Find the exponent block for the Pow
            for (int k = i+1; k < expression.Length; k++) {

                // We'll count the number of parenthesis blocks to apply to the exponent of the Pow
                if (expression[k] == '(') {
                    parenthesisCounter++;
                    // First time we enter this if statement represents finding the start of the block (if there are parenthesis)
                    if (!startOfExponentBlockFound) {
                        expBlockWrapped = true;
                        startOfExponentBlockFound = true;
                        startOfExponentBlock = k;
                    }
                    continue;
                }
                if (expression[k] == ')') {
                    parenthesisCounter--;
                    // There are no more indices to check
                    if (k == expression.Length - 1 && parenthesisCounter == 0) {
                        expIndex = (startOfExponentBlock, k);
                        parenthesisCounter = 0;
                        break;
                    }
                    else if (parenthesisCounter < 0) {
                        expIndex = (startOfExponentBlock, k-1);
                        parenthesisCounter = 0;
                        break;
                    }
                    continue;
                }

                // Given we've already translated all special values to their (double)numerical equivalents, check if this char is part of a value
                // On first entry, we've found the start of the exponent block | on final index of expression, we've found the natural end of the exponent block
                if (char.IsDigit(expression[k]) || expression[k] == '.' || expression[k] == '-') {

                    // First time we enter this if statement represents finding the start of the block (if there were no parenthesis to start)
                    if (!startOfExponentBlockFound) {
                        startOfExponentBlockFound = true;
                        startOfExponentBlock = k;
                    }

                    // Capture max index as the natural end of this block and i+1 as the start of the block | this block represents the exponent of the Pow
                    if (k == expression.Length - 1) {
                        expIndex = (startOfExponentBlock, k);
                        parenthesisCounter = 0;
                        break;
                    }
                    continue; // Continue checking until we either run into a non-digit and parenthesis counter is 0 or we reach end of string
                }

                // Capture k-1 as the end of this block and i+1 as the start of the block | this block represents the exponent of the exponent call
                else {
                    if (parenthesisCounter == 0) {
                        if (expBlockWrapped) {
                            expIndex = (startOfExponentBlock, k);
                        }
                        else {
                            expIndex = (startOfExponentBlock, k-1);
                        }
                        parenthesisCounter = 0;
                        break;
                    }
                    continue; // We still need to find the closing parenthesis
                }
            }

            // Insert Pow() method into expression before fetching next exponent index
            // Create Pow to replace the exponent call in expression and fetch the exponent expression to replace
            String insertPow = $"Pow({expression.Substring(baseIndex.start, baseIndex.end - baseIndex.start + 1)}, {expression.Substring(expIndex.start, expIndex.end - expIndex.start + 1)})";
            String removePow = expression.Substring(baseIndex.start, expIndex.end - baseIndex.start + 1);

            // Replace the characters of the string
            expression = expression.Replace(removePow, insertPow);
        }

        Expression e = new Expression(expression);

        // Define some special delegations
        e.EvaluateParameter += delegate(string name, ParameterArgs args) {};

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