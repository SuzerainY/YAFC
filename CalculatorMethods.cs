using NCalc;
namespace FinancialCalculator;

public static class Evaluation
{
    public static String EvaluateExpression(String entry) {

        // Replace our visual characters with the correct operators
        String expression = entry.Replace(" ", "").Replace("×", "*").Replace("÷", "/").Replace("[", "(").Replace("]", ")").Replace("{", "(").Replace("}", ")").Replace("π", $"{(double)Math.PI}").Replace("logbase", "@").Replace("e", $"{(double)Math.E}").Replace("root", "√");

        // Parse expression for nth power and nth root conversions
        char[] symbols = {'^', '√', '@'};
        expression = SymbolValueParseAndReplace(entry: expression, symbols: symbols);

        Expression e = new Expression(expression);

        // // Define some special delegations
        // e.EvaluateParameter += delegate(string name, ParameterArgs args) {};

        // Evaluate the expression
        var answer = e.Evaluate();

        // If the answer is a decimal or double, let's round it to 15 points
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
    // The two blocks will be replaced with the symbol's respective method call for the context of the left and right blocks
    // For instance: "left^right" will become "(Pow(left, right))"
    public static String SymbolValueParseAndReplace(String entry, char[] symbols) {

        // Apply our custom parser for exponents and other unique criteria
        for (int i = entry.IndexOfAny(symbols); i >= 0; i = entry.IndexOfAny(symbols)) {

            int parenthesisCounter = 0;
            bool leftBlockWrapped = false;
            int endOfLeftBlock = i-1;
            bool endOfLeftBlockFound = false;
            bool rightBlockWrapped = false;
            int startOfRightBlock = i+1;
            bool startOfRightBlockFound = false;

            // Tuples for fetching left and right arguments for this operator
            (int start, int end) leftBlockIndex = default;
            (int start, int end) rightBlockIndex = default;
            
            // Find the Base block for the Pow
            for (int j = i-1; j >= 0; j--) {

                // We'll count the number of parenthesis blocks to apply to the left argument of this operator
                if (entry[j] == ')') {
                    parenthesisCounter++;
                    // First time we enter this if statement represents finding the end of the block (if there are parenthesis)
                    if (!endOfLeftBlockFound) {
                        leftBlockWrapped = true;
                        endOfLeftBlockFound = true;
                        endOfLeftBlock = j;
                    }
                    continue;
                }
                if (entry[j] == '(') {
                    parenthesisCounter--;
                    // entry = "2+(5^2)" example | 
                    // entry = "(5^2)" example | if parenthesis counter goes negative, end block in front of parenthesis
                    if (parenthesisCounter < 0) {
                        leftBlockIndex = (j+1, endOfLeftBlock);
                        parenthesisCounter = 0;
                        break;
                    }
                    // entry = "((5)^2)" example | if parenthesis counter hits 0, we've closed the block
                    // entry = "(5)^2" example | if we hit the 0th index and above if statement did not trigger, treat this as the close of the block
                    else if (j == 0 || parenthesisCounter == 0) {
                        leftBlockIndex = (j, endOfLeftBlock);
                        parenthesisCounter = 0;
                        break;
                    }
                    continue;
                }

                // Given we've already translated all special values to their (double)numerical equivalents, check if this char is part of a value
                // On first entry, we've found the end of the left component | on 0 index of j, we've found the natural beginning of the left component
                if (char.IsDigit(entry[j]) || entry[j] == '.') {

                    // First time we enter this if statement represents finding the end of the block (if there were no parenthesis to start)
                    if (!endOfLeftBlockFound) {
                        endOfLeftBlockFound = true;
                        endOfLeftBlock = j;
                    }

                    // Capture 0 as the natural start of this block and i-1 as the end of the block | this block represents the left side of the argument
                    if (j == 0) {
                        leftBlockIndex = (0, endOfLeftBlock);
                        parenthesisCounter = 0;
                        break;
                    }
                    continue; // Continue checking until we either run into a non-digit and parenthesis counter is 0 or we reach start of string
                }

                // Capture j+1 as the start of this block and i-1 as the end of the block | this block represents the left side of the argument
                else {
                    if (parenthesisCounter == 0) {
                        if (leftBlockWrapped) {
                            leftBlockIndex = (j, endOfLeftBlock);
                        }
                        else {
                            leftBlockIndex = (j+1, endOfLeftBlock);
                        }
                        parenthesisCounter = 0;
                        break;
                    }
                    continue; // We still need to find the closing parenthesis
                }
            }

            // Find the right side of the block
            for (int k = i+1; k < entry.Length; k++) {

                // We'll count the number of parenthesis blocks to apply to the right side of the new argument
                if (entry[k] == '(') {
                    parenthesisCounter++;
                    // First time we enter this if statement represents finding the start of the block (if there are parenthesis)
                    if (!startOfRightBlockFound) {
                        rightBlockWrapped = true;
                        startOfRightBlockFound = true;
                        startOfRightBlock = k;
                    }
                    continue;
                }
                if (entry[k] == ')') {
                    parenthesisCounter--; 
                    // entry = "(5^2)" example | if parenthesis counter goes negative, close block before parenthesis
                    if (parenthesisCounter < 0) {
                        rightBlockIndex = (startOfRightBlock, k-1);
                        // parenthesisCounter = 0; // Not necessary as we will break for loop and close method. Variable disallocated.
                        break;
                    }
                    // entry = "(5^(2))" example | if parenthesis counter hits 0, we've closed this block, grab parenthesis
                    // entry = "5^(2)" example | if we've hit max length and above if statement didn't trigger, treat this as close of block
                    else if (k == entry.Length - 1 || parenthesisCounter == 0) {
                        rightBlockIndex = (startOfRightBlock, k);
                        // parenthesisCounter = 0; // Not necessary as we will break for loop and close method. Variable disallocated.
                        break;
                    }
                    continue;
                }

                // Given we've already translated all special values to their (double)numerical equivalents, check if this char is part of a value
                // On first entry, we've found the start of the right block | on final index of entry, we've found the natural end of the right block
                if (char.IsDigit(entry[k]) || entry[k] == '.' || entry[k] == '-') {
                    
                    // First time we enter this if statement represents finding the start of the block (if there were no parenthesis to start)
                    if (!startOfRightBlockFound) {
                        startOfRightBlockFound = true;
                        startOfRightBlock = k;
                    }
                    // We found a '-', but this is not at the start of the expression, and we are not wrapped in parenthesis, then we have found the end of the right block
                    // Example: "5^2-1" we will trigger this when we hit the '-' | Example: "5^(2-1)" this will not trigger because parenthesisCounter != 0
                    else if (entry[k] == '-' && parenthesisCounter == 0) {
                        rightBlockIndex = (startOfRightBlock, k-1);
                        // parenthesisCounter = 0; // Not necessary as we will break for loop and close method. Variable disallocated.
                        break;
                    }

                    // Capture max index as the natural end of this block and i+1 as the start of the block | this block represents the right side of operator
                    if (k == entry.Length - 1) {
                        rightBlockIndex = (startOfRightBlock, k);
                        // parenthesisCounter = 0; // Not necessary as we will break for loop and close method. Variable disallocated.
                        break;
                    }
                    continue; // Continue checking until we either run into a non-digit and parenthesis counter is 0 or we reach end of string
                }

                // Capture k-1 as the end of this block and i+1 as the start of the block | this block represents the right side of operator
                else {
                    if (parenthesisCounter == 0) {
                        if (rightBlockWrapped) {
                            rightBlockIndex = (startOfRightBlock, k);
                        }
                        else {
                            rightBlockIndex = (startOfRightBlock, k-1);
                        }
                        // parenthesisCounter = 0; // Not necessary as we will break for loop and close method. Variable disallocated.
                        break;
                    }
                    continue; // We still need to find the closing parenthesis
                }
            }

            // Check which symbol we are handling and insert Pow() accordingly
            switch (entry[i])
            {
                case '^':
                    {
                        // Insert Pow() method into entry before fetching next exponent index
                        // Create Pow to replace the exponent call in entry and fetch the exponent entry to replace
                        String insertPow = $"(Pow({entry.Substring(leftBlockIndex.start, leftBlockIndex.end - leftBlockIndex.start + 1)}, {entry.Substring(rightBlockIndex.start, rightBlockIndex.end - rightBlockIndex.start + 1)}))";
                        String removePow = entry.Substring(leftBlockIndex.start, rightBlockIndex.end - leftBlockIndex.start + 1);
                        // Replace the characters of the string
                        entry = entry.Replace(removePow, insertPow);
                        break;
                    }
                case '√':
                    {
                        // Same as above, but exponent is 1/exp because this is to the nth root, not the nth power
                        String insertPow = $"(Pow({entry.Substring(leftBlockIndex.start, leftBlockIndex.end - leftBlockIndex.start + 1)}, 1/{entry.Substring(rightBlockIndex.start, rightBlockIndex.end - rightBlockIndex.start + 1)}))";
                        String removePow = entry.Substring(leftBlockIndex.start, rightBlockIndex.end - leftBlockIndex.start + 1);
                        // Replace the characters of the string
                        entry = entry.Replace(removePow, insertPow);
                        break;
                    }
                case '@':
                    {
                        // Continue as above, but this is for Log base of n
                        String insertLog = $"(Log({entry.Substring(leftBlockIndex.start, leftBlockIndex.end - leftBlockIndex.start + 1)}, {entry.Substring(rightBlockIndex.start, rightBlockIndex.end - rightBlockIndex.start + 1)}))";
                        String removeLog = entry.Substring(leftBlockIndex.start, rightBlockIndex.end - leftBlockIndex.start + 1);
                        // Replace the characters of the string
                        entry = entry.Replace(removeLog, insertLog);
                        break;
                    }
            }
        }
        return entry; // Spits out the entry w/new blocks added
    }
}