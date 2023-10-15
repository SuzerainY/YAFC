namespace FinancialCalculator;

#region TextBoxes
public class ExpressionBox : TextBox
{
    public ExpressionBox(Size FormSize) {
        Text = "";
        Multiline = false;
        Width = FormSize.Width - 80;
        Height = 20;
        BackColor = Color.FromArgb(unchecked((int)0xFF202020));
        ForeColor = Color.DimGray;
        BorderStyle = BorderStyle.None;
        Location = new Point(
            FormSize.Width - Width - 40, // We will center it with 40px margins on the edges
            40 // 40 pixels from top edge
        );
        Font = new Font("Times New Roman", 18, FontStyle.Bold);
        KeyPress += new KeyPressEventHandler(expressionBox_KeyPress);
    }

    public void expressionBox_OnWindowResize(Size FormSize) {
        Width = FormSize.Width - 80;
        Location = new Point(
            FormSize.Width - Width - 40, // We will center it with 40px margins on the edges
            40 // 40 pixels from top edge
        );
    }

    private void expressionBox_KeyPress(object? sender, KeyPressEventArgs e) {
        if (e.KeyChar == (char)Keys.Enter) {
            e.Handled = true;
        }
    }
}

public class OutputBox : TextBox
{
    public OutputBox(Size FormSize) {
        Text = "";
        Multiline = false;
        Width = FormSize.Width - 80;
        Height = 20;
        BackColor = Color.FromArgb(unchecked((int)0xFF202020));
        ForeColor = Color.White;
        BorderStyle = BorderStyle.None;
        Location = new Point(
            FormSize.Width - Width - 40, // We will center it with 40px margins on the edges
            80 // 80 pixels from top edge
        );
        Font = new Font("Times New Roman", 24, FontStyle.Bold);
        KeyPress += new KeyPressEventHandler(outputBox_KeyPress);
    }

    public void outputBox_OnWindowResize(Size FormSize) {
        Width = FormSize.Width - 80;
        Location = new Point(
            FormSize.Width - Width - 40, // We will center it with 40px margins on the edges
            80 // 80 pixels from top edge
        );
    }

    private void outputBox_KeyPress(object? sender, KeyPressEventArgs e) {
        if (e.KeyChar == (char)Keys.Enter) {
            e.Handled = true;
        }
    }
}
#endregion

#region Basic Functions ( + - ÷ ×  and other simple math)
public class PlusButton : Button
{
    public PlusButton(Size FormSize) {
        Text = "+";
        Width = 80; // 80 pixels in width
        Height = 40; // 40 pixels in height
        Location = new Point(
            FormSize.Width - Width - 40, // 40 pixels from right edge
            FormSize.Height - Height - 90 // 90 pixels from bottom edge
        );
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        ForeColor = Color.White;
        Font = new Font("Times New Roman", 22, FontStyle.Bold);
        Click += new EventHandler(plusButton_Click);
    }

    public void plusButton_Click(object? sender, EventArgs e) {

        // If there is a value in the outputBox, we start building off that value, else keep building the expressionBox
        // Allows us to call Enter in the middle of an expression, then pickup from there
        if (CalculatorWindow.outputBox.Text.Length > 0) {
            CalculatorWindow.expressionBox.Text = CalculatorWindow.outputBox.Text + " + ";
            CalculatorWindow.outputBox.Text = "";
        }
        else {
            CalculatorWindow.expressionBox.Text += " + ";
        }
        CalculatorWindow.Instance.OnButtonPress();
    }

    public void plusButton_OnWindowResize(Size FormSize) {
        Location = new Point(
            FormSize.Width - Width - 40, // 40 pixels from right edge
            FormSize.Height - Height - 90 // 90 pixels from bottom edge
        );
    }
}

public class MinusButton : Button
{
    public MinusButton(Size FormSize) {
        Text = "-";
        Width = 80; // 80 pixels in width
        Height = 40; // 40 pixels in height
        Location = new Point(
            FormSize.Width - Width - 40, // 40 pixels from right edge
            FormSize.Height - Height - 140 // 140 pixels from bottom edge
        );
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        ForeColor = Color.White;
        Font = new Font("Times New Roman", 26, FontStyle.Bold);
        Click += new EventHandler(minusButton_Click);
    }

    public void minusButton_Click(object? sender, EventArgs e) {
        // If there is a value in the outputBox, we start building off that value, else keep building the expressionBox
        // Allows us to call Enter in the middle of an expression, then pickup from there
        if (CalculatorWindow.outputBox.Text.Length > 0) {
            CalculatorWindow.expressionBox.Text = CalculatorWindow.outputBox.Text + " - ";
            CalculatorWindow.outputBox.Text = "";
        }
        else {
            CalculatorWindow.expressionBox.Text += " - ";
        }
        CalculatorWindow.Instance.OnButtonPress();
    }

    public void minusButton_OnWindowResize(Size FormSize) {
        Location = new Point(
            FormSize.Width - Width - 40, // 40 pixels from right edge
            FormSize.Height - Height - 140 // 140 pixels from bottom edge
        );
    }
}

public class DivideButton : Button
{
    public DivideButton(Size FormSize) {
        Text = "÷";
        Width = 80; // 80 pixels in width
        Height = 40; // 40 pixels in height
        Location = new Point(
            FormSize.Width - Width - 40, // 40 pixels from right edge
            FormSize.Height - Height - 190 // 190 pixels from bottom edge
        );
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        ForeColor = Color.White;
        Font = new Font("Times New Roman", 22, FontStyle.Bold);
        Click += new EventHandler(divideButton_Click);
    }

    public void divideButton_Click(object? sender, EventArgs e) {

        // If there is a value in the outputBox, we start building off that value, else keep building the expressionBox
        // Allows us to call Enter in the middle of an expression, then pickup from there
        if (CalculatorWindow.outputBox.Text.Length > 0) {
            CalculatorWindow.expressionBox.Text = CalculatorWindow.outputBox.Text + " ÷ ";
            CalculatorWindow.outputBox.Text = "";
        }
        else {
            CalculatorWindow.expressionBox.Text += " ÷ ";
        }
        CalculatorWindow.Instance.OnButtonPress();
    }

    public void divideButton_OnWindowResize(Size FormSize) {
        Location = new Point(
            FormSize.Width - Width - 40, // 40 pixels from right edge
            FormSize.Height - Height - 190 // 190 pixels from bottom edge
        );
    }
}

public class MultiplyButton : Button
{
    public MultiplyButton(Size FormSize) {
        Text = "×";
        Width = 80; // 80 pixels in width
        Height = 40; // 40 pixels in height
        Location = new Point(
            FormSize.Width - Width - 40, // 40 pixels from right edge
            FormSize.Height - Height - 240 // 240 pixels from bottom edge
        );
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        ForeColor = Color.White;
        Font = new Font("Times New Roman", 22, FontStyle.Bold);
        Click += new EventHandler(multiplyButton_Click);
    }

    public void multiplyButton_Click(object? sender, EventArgs e) {

        // If there is a value in the outputBox, we start building off that value, else keep building the expressionBox
        // Allows us to call Enter in the middle of an expression, then pickup from there
        if (CalculatorWindow.outputBox.Text.Length > 0) {
            CalculatorWindow.expressionBox.Text = CalculatorWindow.outputBox.Text + " × ";
            CalculatorWindow.outputBox.Text = "";
        }
        else {
            CalculatorWindow.expressionBox.Text += " × ";
        }
        CalculatorWindow.Instance.OnButtonPress();
    }

    public void multiplyButton_OnWindowResize(Size FormSize) {
        Location = new Point(
            FormSize.Width - Width - 40, // 40 pixels from right edge
            FormSize.Height - Height - 240 // 240 pixels from bottom edge
        );
    }
}

public class ChangeSignButton : Button
{
    public ChangeSignButton(Size FormSize) {
        Text = "+/-";
        Width = 80; // 80 pixels in width
        Height = 40; // 40 pixels in height
        Location = new Point(
            FormSize.Width - Width - 40, // 40 pixels from right edge
            FormSize.Height - Height - 290 // 290 pixels from bottom edge
        );
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        ForeColor = Color.DimGray;
        Font = new Font("Times New Roman", 16, FontStyle.Bold);
        Click += new EventHandler(changeSignButton_Click);
    }

    public void changeSignButton_Click(object? sender, EventArgs e) {
        try {
            CalculatorWindow.outputBox.Text = Evaluation.ChangeSign(entry: CalculatorWindow.outputBox.Text);
        }
        catch (Exception) {
            // Don't do anything
        }
        CalculatorWindow.Instance.OnButtonPress();
    }

    public void changeSignButton_OnWindowResize(Size FormSize) {
        Location = new Point(
            FormSize.Width - Width - 40, // 40 pixels from right edge
            FormSize.Height - Height - 290 // 290 pixels from bottom edge
        );
    }
}

public class NaturalLogButton : Button
{
    public NaturalLogButton(Size FormSize) {
        Text = "ln";
        Width = 40; // 40 pixels in width
        Height = 40; // 40 pixels in height
        Location = new Point(
            FormSize.Width - Width - 220, // 220 pixels from right edge
            FormSize.Height - Height - 290 // 290 pixels from bottom edge
        );
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        ForeColor = Color.DimGray;
        Font = new Font("Times New Roman", 12, FontStyle.Bold);
        Click += new EventHandler(naturalLogButton_Click);
    }

    public void naturalLogButton_Click(object? sender, EventArgs e) {
        try {
            CalculatorWindow.outputBox.Text = $"{Math.Log(Convert.ToDouble(CalculatorWindow.outputBox.Text))}";
        }
        catch (Exception) {
            // Don't do anything
        }
        CalculatorWindow.Instance.OnButtonPress();
    }

    public void naturalLogButton_OnWindowResize(Size FormSize) {
        Location = new Point(
            FormSize.Width - Width - 220, // 220 pixels from right edge
            FormSize.Height - Height - 290 // 290 pixels from bottom edge
        );
    }
}

public class LogTenButton : Button
{
    public LogTenButton(Size FormSize) {
        Text = "log";
        Width = 40; // 40 pixels in width
        Height = 40; // 40 pixels in height
        Location = new Point(
            FormSize.Width - Width - 260, // 260 pixels from right edge
            FormSize.Height - Height - 290 // 290 pixels from bottom edge
        );
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        ForeColor = Color.DimGray;
        Font = new Font("Times New Roman", 12, FontStyle.Bold);
        Click += new EventHandler(logTenButton_Click);
    }

    public void logTenButton_Click(object? sender, EventArgs e) {
        try {
            CalculatorWindow.outputBox.Text = $"{Math.Log10(Convert.ToDouble(CalculatorWindow.outputBox.Text))}";
        }
        catch (Exception) {
            // Don't do anything
        }
        CalculatorWindow.Instance.OnButtonPress();
    }

    public void logTenButton_OnWindowResize(Size FormSize) {
        Location = new Point(
            FormSize.Width - Width - 260, // 260 pixels from right edge
            FormSize.Height - Height - 290 // 290 pixels from bottom edge
        );
    }
}

public class SquareRootButton : Button
{
    public SquareRootButton(Size FormSize) {
        Text = "√x";
        Width = 40; // 40 pixels in width
        Height = 40; // 40 pixels in height
        Location = new Point(
            FormSize.Width - Width - 310, // 310 pixels from right edge
            FormSize.Height - Height - 290 // 290 pixels from bottom edge
        );
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        ForeColor = Color.DimGray;
        Font = new Font("Times New Roman", 14, FontStyle.Bold);
        Click += new EventHandler(squareRootButton_Click);
    }

    public void squareRootButton_Click(object? sender, EventArgs e) {
        try {
            CalculatorWindow.outputBox.Text = $"{Math.Sqrt(Convert.ToDouble(CalculatorWindow.outputBox.Text))}";
        }
        catch (Exception) {
            // Don't do anything
        }
        CalculatorWindow.Instance.OnButtonPress();
    }

    public void squareRootButton_OnWindowResize(Size FormSize) {
        Location = new Point(
            FormSize.Width - Width - 310, // 310 pixels from right edge
            FormSize.Height - Height - 290 // 290 pixels from bottom edge
        );
    }
}

public class SquaredButton : Button
{
    public SquaredButton(Size FormSize) {
        Text = "x²";
        Width = 40; // 40 pixels in width
        Height = 40; // 40 pixels in height
        Location = new Point(
            FormSize.Width - Width - 350, // 350 pixels from right edge
            FormSize.Height - Height - 290 // 290 pixels from bottom edge
        );
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        ForeColor = Color.DimGray;
        Font = new Font("Times New Roman", 14, FontStyle.Bold);
        Click += new EventHandler(squaredButton_Click);
    }

    public void squaredButton_Click(object? sender, EventArgs e) {
        try {
            CalculatorWindow.outputBox.Text = $"{Math.Pow(Convert.ToDouble(CalculatorWindow.outputBox.Text), 2)}";
        }
        catch (Exception) {
            // Don't do anything
        }
        CalculatorWindow.Instance.OnButtonPress();
    }

    public void squaredButton_OnWindowResize(Size FormSize) {
        Location = new Point(
            FormSize.Width - Width - 350, // 350 pixels from right edge
            FormSize.Height - Height - 290 // 290 pixels from bottom edge
        );
    }
}

public class PowerOfButton : Button
{
    public PowerOfButton(Size FormSize) {
        Text = "xⁿ";
        Width = 40; // 40 pixels in width
        Height = 40; // 40 pixels in height
        Location = new Point(
            FormSize.Width - Width - 350, // 350 pixels from right edge
            FormSize.Height - Height - 340 // 340 pixels from bottom edge
        );
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        ForeColor = Color.DimGray;
        Font = new Font("Times New Roman", 14, FontStyle.Bold);
        Click += new EventHandler(powerOfButton_Click);
    }

    public void powerOfButton_Click(object? sender, EventArgs e) {

        // If there is a value in the outputBox, we start building off that value, else keep building the expressionBox
        // Allows us to call Enter in the middle of an expression, then pickup from there
        if (CalculatorWindow.outputBox.Text.Length > 0) {
            CalculatorWindow.expressionBox.Text = CalculatorWindow.outputBox.Text + "^";
            CalculatorWindow.outputBox.Text = "";
        }
        else {
            CalculatorWindow.expressionBox.Text += "^";
        }
        CalculatorWindow.Instance.OnButtonPress();
    }

    public void powerOfButton_OnWindowResize(Size FormSize) {
        Location = new Point(
            FormSize.Width - Width - 350, // 350 pixels from right edge
            FormSize.Height - Height - 340 // 340 pixels from bottom edge
        );
    }
}

public class NRootButton : Button
{
    public NRootButton(Size FormSize) {
        Text = "ⁿ√";
        Width = 40; // 40 pixels in width
        Height = 40; // 40 pixels in height
        Location = new Point(
            FormSize.Width - Width - 310, // 310 pixels from right edge
            FormSize.Height - Height - 340 // 340 pixels from bottom edge
        );
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        ForeColor = Color.DimGray;
        Font = new Font("Times New Roman", 14, FontStyle.Bold);
        Click += new EventHandler(nRootButton_Click);
    }

    public void nRootButton_Click(object? sender, EventArgs e) {

        // If there is a value in the outputBox, we start building off that value, else keep building the expressionBox
        // Allows us to call Enter in the middle of an expression, then pickup from there
        if (CalculatorWindow.outputBox.Text.Length > 0) {
            CalculatorWindow.expressionBox.Text = CalculatorWindow.outputBox.Text + "root";
            CalculatorWindow.outputBox.Text = "";
        }
        else {
            CalculatorWindow.expressionBox.Text += "root";
        }
        CalculatorWindow.Instance.OnButtonPress();
    }

    public void nRootButton_OnWindowResize(Size FormSize) {
        Location = new Point(
            FormSize.Width - Width - 310, // 310 pixels from right edge
            FormSize.Height - Height - 340 // 340 pixels from bottom edge
        );
    }
}

public class NLogBaseButton : Button
{
    public NLogBaseButton(Size FormSize) {
        Text = "logₙ";
        Width = 40; // 40 pixels in width
        Height = 40; // 40 pixels in height
        Location = new Point(
            FormSize.Width - Width - 260, // 260 pixels from right edge
            FormSize.Height - Height - 340 // 340 pixels from bottom edge
        );
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        ForeColor = Color.DimGray;
        Font = new Font("Times New Roman", 10, FontStyle.Bold);
        Click += new EventHandler(nLogBaseButton_Click);
    }

    public void nLogBaseButton_Click(object? sender, EventArgs e) {

        // If there is a value in the outputBox, we start building off that value, else keep building the expressionBox
        // Allows us to call Enter in the middle of an expression, then pickup from there
        if (CalculatorWindow.outputBox.Text.Length > 0) {
            CalculatorWindow.expressionBox.Text = CalculatorWindow.outputBox.Text + "logbase";
            CalculatorWindow.outputBox.Text = "";
        }
        else {
            CalculatorWindow.expressionBox.Text += "logbase";
        }
        CalculatorWindow.Instance.OnButtonPress();
    }

    public void nLogBaseButton_OnWindowResize(Size FormSize) {
        Location = new Point(
            FormSize.Width - Width - 260, // 260 pixels from right edge
            FormSize.Height - Height - 340 // 340 pixels from bottom edge
        );
    }
}

public class InverseButton : Button
{
    public InverseButton(Size FormSize) {
        Text = "1/x";
        Width = 40; // 40 pixels in width
        Height = 40; // 40 pixels in height
        Location = new Point(
            FormSize.Width - Width - 220, // 220 pixels from right edge
            FormSize.Height - Height - 340 // 340 pixels from bottom edge
        );
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        ForeColor = Color.DimGray;
        Font = new Font("Times New Roman", 12, FontStyle.Bold);
        Click += new EventHandler(inverseButton_Click);
    }

    public void inverseButton_Click(object? sender, EventArgs e) {
        try {
            CalculatorWindow.outputBox.Text = $"{1/Convert.ToDouble(CalculatorWindow.outputBox.Text)}";
        }
        catch (Exception) {
            // Don't do anything
        }
        CalculatorWindow.Instance.OnButtonPress();
    }

    public void inverseButton_OnWindowResize(Size FormSize) {
        Location = new Point(
            FormSize.Width - Width - 220, // 220 pixels from right edge
            FormSize.Height - Height - 340 // 340 pixels from bottom edge
        );
    }
}

public class EToXButton : Button
{
    public EToXButton(Size FormSize) {
        Text = "eˣ";
        Width = 40; // 40 pixels in width
        Height = 40; // 40 pixels in height
        Location = new Point(
            FormSize.Width - Width - 170, // 170 pixels from right edge
            FormSize.Height - Height - 340 // 340 pixels from bottom edge
        );
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        ForeColor = Color.DimGray;
        Font = new Font("Times New Roman", 16, FontStyle.Bold);
        Click += new EventHandler(eToXButton_Click);
    }

    public void eToXButton_Click(object? sender, EventArgs e) {
        try {
            CalculatorWindow.outputBox.Text = $"{Math.Pow(Math.E, Convert.ToDouble(CalculatorWindow.outputBox.Text))}";
        }
        catch (Exception) {
            // Don't do anything
        }
        CalculatorWindow.Instance.OnButtonPress();
    }

    public void eToXButton_OnWindowResize(Size FormSize) {
        Location = new Point(
            FormSize.Width - Width - 170, // 170 pixels from right edge
            FormSize.Height - Height - 340 // 340 pixels from bottom edge
        );
    }
}

public class AbsoluteValueButton : Button
{
    public AbsoluteValueButton(Size FormSize) {
        Text = "Abs";
        Width = 40; // 40 pixels in width
        Height = 40; // 40 pixels in height
        Location = new Point(
            FormSize.Width - Width - 130, // 130 pixels from right edge
            FormSize.Height - Height - 340 // 340 pixels from bottom edge
        );
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        ForeColor = Color.DimGray;
        Font = new Font("Times New Roman", 10, FontStyle.Bold);
        Click += new EventHandler(absoluteValueButton_Click);
    }

    public void absoluteValueButton_Click(object? sender, EventArgs e) {

        // If there is a value in the outputBox, we take the absolute value of it, else keep building the expressionBox
        // Allows us to call Enter in the middle of an expression, then pickup from there
        if (CalculatorWindow.outputBox.Text.Length > 0) {
            Double CurrentOutput = Convert.ToDouble(CalculatorWindow.outputBox.Text);
            CalculatorWindow.outputBox.Text = $"{Math.Abs(CurrentOutput)}";
        }
        else {
            CalculatorWindow.expressionBox.Text += "Abs(";
        }
        CalculatorWindow.leftParenthesisLabel.leftParenthesisLabelCount();
        CalculatorWindow.rightParenthesisLabel.rightParenthesisLabelCount();
        CalculatorWindow.Instance.OnButtonPress();
    }

    public void absoluteValueButton_OnWindowResize(Size FormSize) {
        Location = new Point(
            FormSize.Width - Width - 130, // 130 pixels from right edge
            FormSize.Height - Height - 340 // 340 pixels from bottom edge
        );
    }
}
#endregion

#region Number And Value Buttons
public class LeftParenthesis : Button
{
    public LeftParenthesis(Size FormSize) {
        Text = "(";
        Width = 40;
        Height = 40;
        Location = new Point(
            FormSize.Width - Width - 350, // flush with left of other numbers
            FormSize.Height - Height - 40 // 40 pixels from bottom edge
        );
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        Font = new Font("Times New Roman", 18, FontStyle.Bold);
        ForeColor = Color.White;
        Click += new EventHandler(leftParenthesis_Click);
    }

    public void leftParenthesis_Click(object? sender, EventArgs e) {
        CalculatorWindow.expressionBox.Text += "(";
        CalculatorWindow.Instance.OnButtonPress();
        CalculatorWindow.leftParenthesisLabel.leftParenthesisLabelCount();
        CalculatorWindow.rightParenthesisLabel.rightParenthesisLabelCount();
    }
    public void leftParenthesis_OnWindowResize(Size FormSize) {

        Location = new Point(
            FormSize.Width - Width - 350, // flush with left of other numbers
            FormSize.Height - Height - 40 // 40 pixels from bottom edge
        );
    }
}

public class LeftParenthesisLabel : Label
{
    public LeftParenthesisLabel(LeftParenthesis leftParenthesis) {
        Text = "";
        AutoSize = true;
        Location = new Point(leftParenthesis.Location.X, leftParenthesis.Location.Y + leftParenthesis.Height - Height); // Set label to bottom left corner of leftParenthesis
        Font = new Font("Times New Roman", 12, FontStyle.Regular);
        ForeColor = Color.DimGray;
    }

    public void leftParenthesisLabel_OnWindowResize(LeftParenthesis leftParenthesis) {
        Location = new Point(leftParenthesis.Location.X, leftParenthesis.Location.Y + leftParenthesis.Height - Height); // Set label to bottom left corner of leftParenthesis
    }

    public void leftParenthesisLabelCount() {
        int leftParenthesisOffset = CalculatorWindow.expressionBox.Text.Count(c => c == '(') - CalculatorWindow.expressionBox.Text.Count(c => c == ')');
        if (leftParenthesisOffset > 0) {
            Text = $"{leftParenthesisOffset}";
        }
        else {
            Text = "";
        }
    }
}

public class RightParenthesis : Button
{
    public RightParenthesis(Size FormSize) {
        Text = ")";
        Width = 40;
        Height = 40;
        Location = new Point(
            FormSize.Width - Width - 310, // flush with left of other numbers
            FormSize.Height - Height - 40 // 40 pixels from bottom edge
        );
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        Font = new Font("Times New Roman", 18, FontStyle.Bold);
        ForeColor = Color.White;
        Click += new EventHandler(rightParenthesis_Click);
    }

    public void rightParenthesis_Click(object? sender, EventArgs e) {
        CalculatorWindow.expressionBox.Text += ")";
        CalculatorWindow.Instance.OnButtonPress();
        CalculatorWindow.leftParenthesisLabel.leftParenthesisLabelCount();
        CalculatorWindow.rightParenthesisLabel.rightParenthesisLabelCount();
    }

    public void rightParenthesis_OnWindowResize(Size FormSize) {
        Location = new Point(
            FormSize.Width - Width - 310, // flush with left of other numbers
            FormSize.Height - Height - 40 // 40 pixels from bottom edge
        );
    }
}

public class RightParenthesisLabel : Label
{
    public RightParenthesisLabel(RightParenthesis rightParenthesis) {
        Text = "";
        AutoSize = true;
        Location = new Point(rightParenthesis.Location.X, rightParenthesis.Location.Y + rightParenthesis.Height - Height); // Set label to bottom left corner of rightParenthsis
        Font = new Font("Times New Roman", 12, FontStyle.Regular);
        ForeColor = Color.DimGray;
    }

    public void rightParenthesisLabel_OnWindowResize(RightParenthesis rightParenthesis) {
        Location = new Point(rightParenthesis.Location.X, rightParenthesis.Location.Y + rightParenthesis.Height - Height); // Set label to bottom left corner of rightParenthesis
    }

    public void rightParenthesisLabelCount() {
        int rightParenthesisOffset = CalculatorWindow.expressionBox.Text.Count(c => c == ')') - CalculatorWindow.expressionBox.Text.Count(c => c == '(');
        if (rightParenthesisOffset > 0) {
            Text = $"{rightParenthesisOffset}";
        }
        else {
            Text = "";
        }
    }
}

public class NumberPeriod : Button
{
    public NumberPeriod(Size FormSize) {
        Text = ".";
        Width = 80;
        Height = 40;
        Location = new Point(
            FormSize.Width - Width - 130, // flush with left of other numbers
            FormSize.Height - Height - 40 // 40 pixels from bottom edge
        );
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        Font = new Font("Times New Roman", 18, FontStyle.Bold);
        ForeColor = Color.White;
        Click += new EventHandler(numberPeriod_Click);
    }

    public void numberPeriod_Click(object? sender, EventArgs e) {
        CalculatorWindow.expressionBox.Text += ".";
        CalculatorWindow.Instance.OnButtonPress();
    }

    public void numberPeriod_OnWindowResize(Size FormSize) {
        Location = new Point(
            FormSize.Width - Width - 130, // flush with left of other numbers
            FormSize.Height - Height - 40 // 40 pixels from bottom edge
        );
    }
}

public class NumberZero : Button
{
    public NumberZero(Size FormSize) {
        Text = "0";
        Width = 80;
        Height = 40;
        Location = new Point(
            FormSize.Width - Width - 220, // flush with left of other numbers
            FormSize.Height - Height - 40 // 40 pixels from bottom edge
        );
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        Font = new Font("Times New Roman", 18, FontStyle.Bold);
        ForeColor = Color.White;
        Click += new EventHandler(numberZero_Click);
    }

    public void numberZero_Click(object? sender, EventArgs e) {
        CalculatorWindow.expressionBox.Text += "0";
        CalculatorWindow.Instance.OnButtonPress();
    }

    public void numberZero_OnWindowResize(Size FormSize) {
        Location = new Point(
            FormSize.Width - Width - 220, // flush with left of other numbers
            FormSize.Height - Height - 40 // 40 pixels from bottom edge
        );
    }
}

public class NumberOne : Button
{
    public NumberOne(Size FormSize) {
        Text = "1";
        Width = 80;
        Height = 40;
        Location = new Point(
            FormSize.Width - Width - 310, // flush with left of other numbers
            FormSize.Height - Height - 90 // 90 pixels from bottom edge
        );
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        Font = new Font("Times New Roman", 18, FontStyle.Bold);
        ForeColor = Color.White;
        Click += new EventHandler(numberOne_Click);
    }

    public void numberOne_Click(object? sender, EventArgs e) {
        CalculatorWindow.expressionBox.Text += "1";
        CalculatorWindow.Instance.OnButtonPress();
    }

    public void numberOne_OnWindowResize(Size FormSize) {
        Location = new Point(
            FormSize.Width - Width - 310, // flush with left of other numbers
            FormSize.Height - Height - 90 // 90 pixels from bottom edge
        );
    }
}

public class NumberTwo : Button
{
    public NumberTwo(Size FormSize) {
        Text = "2";
        Width = 80;
        Height = 40;
        Location = new Point(
            FormSize.Width - Width - 220, // flush with left of other numbers
            FormSize.Height - Height - 90 // 90 pixels from bottom edge
        );
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        Font = new Font("Times New Roman", 18, FontStyle.Bold);
        ForeColor = Color.White;
        Click += new EventHandler(numberTwo_Click);
    }

    public void numberTwo_Click(object? sender, EventArgs e) {
        CalculatorWindow.expressionBox.Text += "2";
        CalculatorWindow.Instance.OnButtonPress();
    }

    public void numberTwo_OnWindowResize(Size FormSize) {
        Location = new Point(
            FormSize.Width - Width - 220, // flush with left of other numbers
            FormSize.Height - Height - 90 // 90 pixels from bottom edge
        );
    }
}

public class NumberThree : Button
{
    public NumberThree(Size FormSize) {
        Text = "3";
        Width = 80;
        Height = 40;
        Location = new Point(
            FormSize.Width - Width - 130, // flush with left of other numbers
            FormSize.Height - Height - 90 // 90 pixels from bottom edge
        );
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        Font = new Font("Times New Roman", 18, FontStyle.Bold);
        ForeColor = Color.White;
        Click += new EventHandler(numberThree_Click);
    }

    public void numberThree_Click(object? sender, EventArgs e) {
        CalculatorWindow.expressionBox.Text += "3";
        CalculatorWindow.Instance.OnButtonPress();
    }

    public void numberThree_OnWindowResize(Size FormSize) {
        Location = new Point(
            FormSize.Width - Width - 130, // flush with left of other numbers
            FormSize.Height - Height - 90 // 90 pixels from bottom edge
        );
    }
}

public class NumberFour : Button
{
    public NumberFour(Size FormSize) {
        Text = "4";
        Width = 80;
        Height = 40;
        Location = new Point(
            FormSize.Width - Width - 310, // flush with left of other numbers
            FormSize.Height - Height - 140 // 140 pixels from bottom edge
        );
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        Font = new Font("Times New Roman", 18, FontStyle.Bold);
        ForeColor = Color.White;
        Click += new EventHandler(numberFour_Click);
    }

    public void numberFour_Click(object? sender, EventArgs e) {
        CalculatorWindow.expressionBox.Text += "4";
        CalculatorWindow.Instance.OnButtonPress();
    }

    public void numberFour_OnWindowResize(Size FormSize) {
        Location = new Point(
            FormSize.Width - Width - 310, // flush with left of other numbers
            FormSize.Height - Height - 140 // 140 pixels from bottom edge
        );
    }
}

public class NumberFive : Button
{
    public NumberFive(Size FormSize) {
        Text = "5";
        Width = 80;
        Height = 40;
        Location = new Point(
            FormSize.Width - Width - 220, // flush with left of other numbers
            FormSize.Height - Height - 140 // 140 pixels from bottom edge
        );
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        Font = new Font("Times New Roman", 18, FontStyle.Bold);
        ForeColor = Color.White;
        Click += new EventHandler(numberFive_Click);
    }

    public void numberFive_Click(object? sender, EventArgs e) {
        CalculatorWindow.expressionBox.Text += "5";
        CalculatorWindow.Instance.OnButtonPress();
    }

    public void numberFive_OnWindowResize(Size FormSize) {
        Location = new Point(
            FormSize.Width - Width - 220, // flush with left of other numbers
            FormSize.Height - Height - 140 // 140 pixels from bottom edge
        );
    }
}

public class NumberSix : Button
{
    public NumberSix(Size FormSize) {
        Text = "6";
        Width = 80;
        Height = 40;
        Location = new Point(
            FormSize.Width - Width - 130, // flush with left of other numbers
            FormSize.Height - Height - 140 // 140 pixels from bottom edge
        );
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        Font = new Font("Times New Roman", 18, FontStyle.Bold);
        ForeColor = Color.White;
        Click += new EventHandler(numberSix_Click);
    }

    public void numberSix_Click(object? sender, EventArgs e) {
        CalculatorWindow.expressionBox.Text += "6";
        CalculatorWindow.Instance.OnButtonPress();
    }

    public void numberSix_OnWindowResize(Size FormSize) {
        Location = new Point(
            FormSize.Width - Width - 130, // flush with left of other numbers
            FormSize.Height - Height - 140 // 140 pixels from bottom edge
        );
    }
}

public class NumberSeven : Button
{
    public NumberSeven(Size FormSize) {
        Text = "7";
        Width = 80;
        Height = 40;
        Location = new Point(
            FormSize.Width - Width - 310, // flush with left of other numbers
            FormSize.Height - Height - 190 // 190 pixels from bottom edge
        );
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        Font = new Font("Times New Roman", 18, FontStyle.Bold);
        ForeColor = Color.White;
        Click += new EventHandler(numberSeven_Click);
    }

    public void numberSeven_Click(object? sender, EventArgs e) {
        CalculatorWindow.expressionBox.Text += "7";
        CalculatorWindow.Instance.OnButtonPress();
    }

    public void numberSeven_OnWindowResize(Size FormSize) {
        Location = new Point(
            FormSize.Width - Width - 310, // flush with left of other numbers
            FormSize.Height - Height - 190 // 190 pixels from bottom edge
        );
    }
}

public class NumberEight : Button
{
    
    public NumberEight(Size FormSize) {
        
        Text = "8";
        Width = 80;
        Height = 40;
        Location = new Point(
            FormSize.Width - Width - 220, // flush with left of other numbers
            FormSize.Height - Height - 190 // 190 pixels from bottom edge
        );
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        Font = new Font("Times New Roman", 18, FontStyle.Bold);
        ForeColor = Color.White;
        Click += new EventHandler(numberEight_Click);
    }

    public void numberEight_Click(object? sender, EventArgs e) {
        CalculatorWindow.expressionBox.Text += "8";
        CalculatorWindow.Instance.OnButtonPress();
    }

    public void numberEight_OnWindowResize(Size FormSize) {
        Location = new Point(
            FormSize.Width - Width - 220, // flush with left of other numbers
            FormSize.Height - Height - 190 // 190 pixels from bottom edge
        );
    }
}

public class NumberNine : Button
{
    public NumberNine(Size FormSize) {
        Text = "9";
        Width = 80;
        Height = 40;
        Location = new Point(
            FormSize.Width - Width - 130, // flush with left of other numbers
            FormSize.Height - Height - 190 // 190 pixels from bottom edge
        );
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        Font = new Font("Times New Roman", 18, FontStyle.Bold);
        ForeColor = Color.White;
        Click += new EventHandler(numberNine_Click);
    }

    public void numberNine_Click(object? sender, EventArgs e) {
        CalculatorWindow.expressionBox.Text += "9";
        CalculatorWindow.Instance.OnButtonPress();
    }

    public void numberNine_OnWindowResize(Size FormSize) {
        Location = new Point(
            FormSize.Width - Width - 130, // flush with left of other numbers
            FormSize.Height - Height - 190 // 190 pixels from bottom edge
        );
    }
}

public class NumberPI : Button
{
    public NumberPI(Size FormSize) {
        Text = "π";
        Width = 40;
        Height = 40;
        Location = new Point(
            FormSize.Width - Width - 130, // flush with left of other numbers
            FormSize.Height - Height - 290 // 290 pixels from bottom edge
        );
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        Font = new Font("Times New Roman", 16, FontStyle.Bold);
        ForeColor = Color.DimGray;
        Click += new EventHandler(numberPI_Click);
    }

    public void numberPI_Click(object? sender, EventArgs e) {
        CalculatorWindow.expressionBox.Text += "π";
        CalculatorWindow.Instance.OnButtonPress();
    }

    public void numberPI_OnWindowResize(Size FormSize) {
        Location = new Point(
            FormSize.Width - Width - 130, // flush with left of other numbers
            FormSize.Height - Height - 290 // 290 pixels from bottom edge
        );
    }
}

public class NumberE : Button
{
    public NumberE(Size FormSize) {
        Text = "e";
        Width = 40;
        Height = 40;
        Location = new Point(
            FormSize.Width - Width - 170, // flush with left of other numbers
            FormSize.Height - Height - 290 // 290 pixels from bottom edge
        );
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        Font = new Font("Times New Roman", 16, FontStyle.Bold);
        ForeColor = Color.DimGray;
        Click += new EventHandler(numberE_Click);
    }

    public void numberE_Click(object? sender, EventArgs e) {
        CalculatorWindow.expressionBox.Text += "e";
        CalculatorWindow.Instance.OnButtonPress();
    }

    public void numberE_OnWindowResize(Size FormSize) {
        Location = new Point(
            FormSize.Width - Width - 170, // flush with left of other numbers
            FormSize.Height - Height - 290 // 290 pixels from bottom edge
        );
    }
}
#endregion

#region Command Buttons
public class HelpLink : Button
{
    public HelpLink() {
        Text = "Help | GitHub";
        Width = 80; // 80 pixels in width
        Height = 25; // 20 pixels in height
        Location = new Point(
            33, // 33 pixels from left border | appears as 40 pixels due to text padding (unable to give perfect 0 pixel padding for some reason)
            5 // 5 pixels from top border
        );
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        TextAlign = ContentAlignment.TopLeft;
        ForeColor = Color.DimGray;
        Font = new Font("Times New Roman", 8, FontStyle.Regular);
        Click += new EventHandler(helpLink_Click);
    }

    public void helpLink_Click(object? sender, EventArgs e) {
        try {
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo {
                UseShellExecute = true,
                FileName = "https://github.com/SuzerainY/YAFC"
            };
            System.Diagnostics.Process.Start(startInfo); // GitHub Project Link to README
        }
        catch (Exception) {
            CalculatorWindow.outputBox.Text = "Cannot Open Link";
        }
        CalculatorWindow.Instance.OnButtonPress();
    }

    public void helpLink_OnWindowResize() {
        Location = new Point(
            33, // 33 pixels from left border | appears as 40 pixels due to text padding (unable to give perfect 0 pixel padding for some reason)
            5 // 5 pixels from top border
        );
    }
}

public class EnterButton : Button
{
    public EnterButton(Size FormSize) {
        Text = "ENTER";
        Width = 80; // 80 pixels in width
        Height = 40; // 40 pixels in height
        Location = new Point(
            FormSize.Width - Width - 40, // 40 pixels from right edge
            FormSize.Height - Height - 40 // 40 pixels from bottom edge
        );
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderColor = Color.White;
        FlatAppearance.BorderSize = 2;
        ForeColor = Color.White;
        Font = new Font("Times New Roman", 12, FontStyle.Bold);
        Click += new EventHandler(enterButton_Click);
    }

    public void enterButton_Click(object? sender, EventArgs e) {
        try {
            if (CalculatorWindow.expressionBox.Text.Length > 0) {
                CalculatorWindow.outputBox.Text = Evaluation.EvaluateExpression(entry: CalculatorWindow.expressionBox.Text);
            }
        }
        catch (Exception) {
            CalculatorWindow.outputBox.Text = "ERROR";
        }
        CalculatorWindow.Instance.OnButtonPress();
    }

    public void enterButton_OnWindowResize(Size FormSize) {
        Location = new Point(
            FormSize.Width - Width - 40, // 40 pixels from right edge
            FormSize.Height - Height - 40 // 40 pixels from bottom edge
        );
    }
}

public class BackButton : Button
{
    public BackButton(Size FormSize) {
        Text = "«";
        Width = 40; // 40 pixels in width
        Height = 40; // 40 pixels in height
        Location = new Point(
            FormSize.Width - Width - 150, // 150 pixels from right edge
            FormSize.Height - Height - 240 // 240 pixels from bottom edge
        );
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        FlatAppearance.BorderColor = Color.White;
        ForeColor = CalculatorWindow.Instance.BackColor;
        Font = new Font("Times New Roman", 22, FontStyle.Bold);
        Click += new EventHandler(backButton_Click);
        Paint += backButton_Paint;
    }

    public void backButton_Click(object? sender, EventArgs e) {
        CalculatorWindow.expressionBox.Text = Evaluation.RemoveCharacter(entry: CalculatorWindow.expressionBox.Text);
        // Make sure we update the parenthesis counters in case we're removing parenthesis
        CalculatorWindow.leftParenthesisLabel.leftParenthesisLabelCount();
        CalculatorWindow.rightParenthesisLabel.rightParenthesisLabelCount();

        CalculatorWindow.Instance.OnButtonPress();
    }

    public void backButton_OnWindowResize(Size FormSize) {
        Location = new Point(
            FormSize.Width - Width - 150, // 150 pixels from right edge
            FormSize.Height - Height - 240 // 240 pixels from bottom edge
        );
    }

    private void backButton_Paint(object? sender, PaintEventArgs e) {

        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        e.Graphics.DrawEllipse(new Pen(FlatAppearance.BorderColor, 2), 0, 0, Width - 2, Height - 2);
        System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();

        RectangleF ellipseRect = new RectangleF(0, 0, Width, Height);
        ellipseRect.Inflate(2, 2);
        path.AddEllipse(ellipseRect);

        Region = new Region(path);
        SizeF textSize = e.Graphics.MeasureString(Text, Font);
        PointF textPosition = new PointF((Width - textSize.Width) / 2, (Height - textSize.Height) / 8);
        e.Graphics.DrawString(Text, Font, Brushes.White, textPosition);
    }
}

public class ClearButton : Button
{
    public ClearButton(Size FormSize) {
        Text = "C";
        Width = 40; // 40 pixels in width
        Height = 40; // 40 pixels in height
        Location = new Point(
            FormSize.Width - Width - 240, // 240 pixels from right edge
            FormSize.Height - Height - 240 // 240 pixels from bottom edge
        );
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        FlatAppearance.BorderColor = Color.White;
        ForeColor = CalculatorWindow.Instance.BackColor;
        Font = new Font("Times New Roman", 16, FontStyle.Bold);
        Click += new EventHandler(clearButton_Click);
        Paint += clearButton_Paint;
    }

    public void clearButton_Click(object? sender, EventArgs e) {

        // If there is a value in the output box, just clear the output box, else clear the expression box
        // Turns this button into a one-click for clear output and two-click for clear all
        if (CalculatorWindow.outputBox.Text.Length > 0) {
            CalculatorWindow.outputBox.Text = "";
        }
        else {
            CalculatorWindow.expressionBox.Text = "";
        }
        CalculatorWindow.Instance.OnButtonPress();
    }

    public void clearButton_OnWindowResize(Size FormSize) {
        Location = new Point(
            FormSize.Width - Width - 240, // 240 pixels from right edge
            FormSize.Height - Height - 240 // 240 pixels from bottom edge
        );
    }

    private void clearButton_Paint(object? sender, PaintEventArgs e) {

        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        e.Graphics.DrawEllipse(new Pen(FlatAppearance.BorderColor, 2), 0, 0, Width - 2, Height - 2);
        System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();

        RectangleF ellipseRect = new RectangleF(0, 0, Width, Height);
        ellipseRect.Inflate(2, 2);
        path.AddEllipse(ellipseRect);

        Region = new Region(path);
        SizeF textSize = e.Graphics.MeasureString(Text, Font);
        PointF textPosition = new PointF((Width - textSize.Width) / 2, (Height - textSize.Height) / 2);
        e.Graphics.DrawString(Text, Font, Brushes.White, textPosition);
    }
}

public class PercentButton : Button
{
    public PercentButton(Size FormSize) {
        Text = " % ";
        Width = 40; // 40 pixels in width
        Height = 40; // 40 pixels in height
        Location = new Point(
            FormSize.Width - Width - 330, // 330 pixels from right edge
            FormSize.Height - Height - 240 // 240 pixels from bottom edge
        );
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        FlatAppearance.BorderColor = Color.White;
        ForeColor = CalculatorWindow.Instance.BackColor;
        Font = new Font("Times New Roman", 16, FontStyle.Bold);
        Click += new EventHandler(percentButton_Click);
        Paint += percentButton_Paint;
    }

    public void percentButton_Click(object? sender, EventArgs e) {
        try {
            CalculatorWindow.outputBox.Text = $"{Convert.ToDouble(CalculatorWindow.outputBox.Text) / 100}";
        }
        catch (Exception) {}
        CalculatorWindow.Instance.OnButtonPress();
    }

    public void percentButton_OnWindowResize(Size FormSize) {
        Location = new Point(
            FormSize.Width - Width - 330, // 330 pixels from right edge
            FormSize.Height - Height - 240 // 240 pixels from bottom edge
        );
    }

    private void percentButton_Paint(object? sender, PaintEventArgs e) {

        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        e.Graphics.DrawEllipse(new Pen(FlatAppearance.BorderColor, 2), 0, 0, Width - 2, Height - 2);
        System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();

        RectangleF ellipseRect = new RectangleF(0, 0, Width, Height);
        ellipseRect.Inflate(2, 2);
        path.AddEllipse(ellipseRect);

        Region = new Region(path);
        SizeF textSize = e.Graphics.MeasureString(Text, Font);
        PointF textPosition = new PointF((Width - textSize.Width) / 8, (Height - textSize.Height) / 2);
        e.Graphics.DrawString(Text, Font, Brushes.White, textPosition);
    }
}
#endregion