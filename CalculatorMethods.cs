using NCalc;
namespace FinancialCalculator;

public static class Evaluation
{
    public static String EvaluateExpression(String entry) {

        // Replace our visual characters with the correct operators
        String expression = entry.Replace(" ", "").Replace("×", "*").Replace("÷", "/").Replace("[", "(").Replace("]", ")").Replace("{", "(").Replace("}", ")").Replace("π", $"{(double)Math.PI}").Replace("e", $"{(double)Math.E}").Replace("root", "√");

        // Parse expression for nth power and nth root conversions
        char[] symbols = {'^', '√'};
        expression = SymbolValueParserPowLogic(entry: expression, symbols: symbols);

        Expression e = new Expression(expression);

        // // Define some special delegations
        // e.EvaluateParameter += delegate(string name, ParameterArgs args) {};

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

    // This method takes in a string mathematical expression and a character such as '^' and will fetch the left and rights blocks of the character
    // The two blocks will be replaced with a Pow() call where the left block becomes the base and the right block becomes the exponent
    // If the char is '^', Pow(base, exponent) is inserted | If the char is '√', Pow(base, 1/exponent) is inserted
    public static String SymbolValueParserPowLogic(String entry, char[] symbols) {

        // Apply our custom parser for exponents and other unique criteria
        for (int i = entry.IndexOfAny(symbols); i >= 0; i = entry.IndexOfAny(symbols)) {

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
                if (entry[j] == ')') {
                    parenthesisCounter++;
                    // First time we enter this if statement represents finding the end of the block (if there are parenthesis)
                    if (!endOfBaseBlockFound) {
                        baseBlockWrapped = true;
                        endOfBaseBlockFound = true;
                        endOfBaseBlock = j;
                    }
                    continue;
                }
                if (entry[j] == '(') {
                    parenthesisCounter--;
                    // entry = "2+(5^2)" example | 
                    // entry = "(5^2)" example | if parenthesis counter goes negative, end block in front of parenthesis
                    if (parenthesisCounter < 0) {
                        baseIndex = (j+1, endOfBaseBlock);
                        parenthesisCounter = 0;
                        break;
                    }
                    // entry = "((5)^2)" example | if parenthesis counter hits 0, we've closed the block
                    // entry = "(5)^2" example | if we hit the 0th index and above if statement did not trigger, treat this as the close of the block
                    else if (j == 0 || parenthesisCounter == 0) {
                        baseIndex = (j, endOfBaseBlock);
                        parenthesisCounter = 0;
                        break;
                    }
                    continue;
                }

                // Given we've already translated all special values to their (double)numerical equivalents, check if this char is part of a value
                // On first entry, we've found the end of the base block | on 0 index of j, we've found the natural beginning of the base block
                if (char.IsDigit(entry[j]) || entry[j] == '.') {

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
            for (int k = i+1; k < entry.Length; k++) {

                // We'll count the number of parenthesis blocks to apply to the exponent of the Pow
                if (entry[k] == '(') {
                    parenthesisCounter++;
                    // First time we enter this if statement represents finding the start of the block (if there are parenthesis)
                    if (!startOfExponentBlockFound) {
                        expBlockWrapped = true;
                        startOfExponentBlockFound = true;
                        startOfExponentBlock = k;
                    }
                    continue;
                }
                if (entry[k] == ')') {
                    parenthesisCounter--;
                    // entry = "(5^2)" example | if parenthesis counter goes negative, close block before parenthesis
                    if (parenthesisCounter < 0) {
                        expIndex = (startOfExponentBlock, k-1);
                        parenthesisCounter = 0;
                        break;
                    }
                    // entry = "(5^(2))" example | if parenthesis counter hits 0, we've closed this block, grab parenthesis
                    // entry = "5^(2)" example | if we've hit max length and above if statement didn't trigger, treat this as close of block
                    else if (k == entry.Length - 1 || parenthesisCounter == 0) {
                        expIndex = (startOfExponentBlock, k);
                        parenthesisCounter = 0;
                        break;
                    }
                    continue;
                }

                // Given we've already translated all special values to their (double)numerical equivalents, check if this char is part of a value
                // On first entry, we've found the start of the exponent block | on final index of entry, we've found the natural end of the exponent block
                if (char.IsDigit(entry[k]) || entry[k] == '.' || entry[k] == '-') {

                    // First time we enter this if statement represents finding the start of the block (if there were no parenthesis to start)
                    if (!startOfExponentBlockFound) {
                        startOfExponentBlockFound = true;
                        startOfExponentBlock = k;
                    }

                    // Capture max index as the natural end of this block and i+1 as the start of the block | this block represents the exponent of the Pow
                    if (k == entry.Length - 1) {
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

            // Check which symbol we are handling and insert Pow() accordingly
            if (entry[i] == '^') {
                // Insert Pow() method into entry before fetching next exponent index
                // Create Pow to replace the exponent call in entry and fetch the exponent entry to replace
                String insertPow = $"(Pow({entry.Substring(baseIndex.start, baseIndex.end - baseIndex.start + 1)}, {entry.Substring(expIndex.start, expIndex.end - expIndex.start + 1)}))";
                String removePow = entry.Substring(baseIndex.start, expIndex.end - baseIndex.start + 1);
                // Replace the characters of the string
                entry = entry.Replace(removePow, insertPow);
            }
            else if (entry[i] == '√') {
                // Same as above, but exponent is 1/exp because this is to the nth root, not the nth power
                String insertPow = $"(Pow({entry.Substring(baseIndex.start, baseIndex.end - baseIndex.start + 1)}, 1/{entry.Substring(expIndex.start, expIndex.end - expIndex.start + 1)}))";
                String removePow = entry.Substring(baseIndex.start, expIndex.end - baseIndex.start + 1);
                // Replace the characters of the string
                entry = entry.Replace(removePow, insertPow);
            }
        }
        return entry; // Spits out the entry with Pow() blocks added
    }
}