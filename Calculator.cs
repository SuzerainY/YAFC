namespace FinancialCalculator;

public partial class CalculatorWindow : Form
{
    public CalculatorWindow() {

        Instance = this; // Singleton Instance for CalculatorWindow

        InitializeComponent(); // Create Form Window
        InitializeButtons(); // Create Buttons

        KeyPreview = true; // Prioritize Key Presses
        this.Resize += new EventHandler(Window_Resize); // Add Resize Handling
        this.KeyDown += new KeyEventHandler(Capture_Keypress); // Add Keypress Handling

        this.ActiveControl = enterButton; // Open the Application Focused on ENTER Button
    }

    // Process for Handling Form Resizing
    private void Window_Resize(object? sender, EventArgs trigger) {
        expressionBox.expressionBox_OnWindowResize(FormSize: this.ClientSize);
        outputBox.outputBox_OnWindowResize(FormSize: this.ClientSize);
        helpLink.helpLink_OnWindowResize();
        enterButton.enterButton_OnWindowResize(FormSize: this.ClientSize);
        backButton.backButton_OnWindowResize(FormSize: this.ClientSize);
        clearButton.clearButton_OnWindowResize(FormSize: this.ClientSize);
        percentButton.percentButton_OnWindowResize(FormSize: this.ClientSize);

        plusButton.plusButton_OnWindowResize(FormSize: this.ClientSize);
        minusButton.minusButton_OnWindowResize(FormSize: this.ClientSize);
        divideButton.divideButton_OnWindowResize(FormSize: this.ClientSize);
        multiplyButton.multiplyButton_OnWindowResize(FormSize: this.ClientSize);
        changeSignButton.changeSignButton_OnWindowResize(FormSize: this.ClientSize);
        naturalLogButton.naturalLogButton_OnWindowResize(FormSize: this.ClientSize);
        logTenButton.logTenButton_OnWindowResize(FormSize: this.ClientSize);
        squareRootButton.squareRootButton_OnWindowResize(FormSize: this.ClientSize);
        squaredButton.squaredButton_OnWindowResize(FormSize: this.ClientSize);
        powerOfButton.powerOfButton_OnWindowResize(FormSize: this.ClientSize);
        nRootButton.nRootButton_OnWindowResize(FormSize: this.ClientSize);

        leftParenthesis.leftParenthesis_OnWindowResize(FormSize: this.ClientSize);
        rightParenthesis.rightParenthesis_OnWindowResize(FormSize: this.ClientSize);
        numberPeriod.numberPeriod_OnWindowResize(FormSize: this.ClientSize);
        numberZero.numberZero_OnWindowResize(FormSize: this.ClientSize);
        numberOne.numberOne_OnWindowResize(FormSize: this.ClientSize);
        numberTwo.numberTwo_OnWindowResize(FormSize: this.ClientSize);
        numberThree.numberThree_OnWindowResize(FormSize: this.ClientSize);
        numberFour.numberFour_OnWindowResize(FormSize: this.ClientSize);
        numberFive.numberFive_OnWindowResize(FormSize: this.ClientSize);
        numberSix.numberSix_OnWindowResize(FormSize: this.ClientSize);
        numberSeven.numberSeven_OnWindowResize(FormSize: this.ClientSize);
        numberEight.numberEight_OnWindowResize(FormSize: this.ClientSize);
        numberNine.numberNine_OnWindowResize(FormSize: this.ClientSize);
        numberPI.numberPI_OnWindowResize(FormSize: this.ClientSize);
        numberE.numberE_OnWindowResize(FormSize: this.ClientSize);
    }

    #region Keypress Events
    // Link Calculator Buttons to Keyboard Keys
    private void Capture_Keypress(object? sender, KeyEventArgs e) {

        // If they are typing into the TextBox directly, don't call the buttons
        if (expressionBox.Focused) {
            if (e.KeyCode == Keys.Enter) {
                enterButton.PerformClick();
            }
            else if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Clear) {
                clearButton.PerformClick();
            }
            return;
        }

        // Check which key is pressed and handle accordingly
        switch (e.KeyCode) {
            case Keys.Enter: // Enter
                enterButton.PerformClick();
                return;
            case Keys.Oemplus: // Equals or Plus
                if ((e.Modifiers & Keys.Shift) == Keys.Shift) {
                    // 'Shift' + '=' pressed, handle +
                    plusButton.PerformClick();
                    return;
                }
                enterButton.PerformClick();
                return;
            case Keys.Back: // Backspace
                backButton.PerformClick();
                return;
            case Keys.Delete: case Keys.Clear: // Delete
                clearButton.PerformClick();
                return;
            case Keys.Add: // Plus
                plusButton.PerformClick();
                return;
            case Keys.Subtract: case Keys.OemMinus: // Minus
                minusButton.PerformClick();
                return;
            case Keys.Divide: case Keys.OemQuestion: // Divide
                divideButton.PerformClick();
                return;
            case Keys.Multiply: // Multiply
                multiplyButton.PerformClick();
                return;
            case Keys.OemOpenBrackets: // Left Parenthesis via Bracket
                leftParenthesis.PerformClick();
                return;
            case Keys.OemCloseBrackets: // Right Parenthesis via Bracket
                rightParenthesis.PerformClick();
                return;
            case Keys.Decimal: // Period / Decimal
                numberPeriod.PerformClick();
                return;
            case Keys.D0: case Keys.NumPad0: // 0
                if ((e.Modifiers & Keys.Shift) == Keys.Shift) {
                    // Shift + 0 pressed, handle right parenthesis
                    rightParenthesis.PerformClick();
                    return;
                }
                numberZero.PerformClick();
                return;
            case Keys.D1: case Keys.NumPad1: // 1
                numberOne.PerformClick();
                return;
            case Keys.D2: case Keys.NumPad2: // 2
                numberTwo.PerformClick();
                return;
            case Keys.D3: case Keys.NumPad3: // 3
                numberThree.PerformClick();
                return;
            case Keys.D4: case Keys.NumPad4: // 4
                numberFour.PerformClick();
                return;
            case Keys.D5: case Keys.NumPad5: // 5
                numberFive.PerformClick();
                return;
            case Keys.D6: case Keys.NumPad6: // 6
                numberSix.PerformClick();
                return;
            case Keys.D7: case Keys.NumPad7: // 7
                numberSeven.PerformClick();
                return;
            case Keys.D8: case Keys.NumPad8: // 8
                numberEight.PerformClick();
                return;
            case Keys.D9: case Keys.NumPad9: // 9
                if ((e.Modifiers & Keys.Shift) == Keys.Shift) {
                    // Shift + 9 pressed, handle left parenthesis
                    leftParenthesis.PerformClick();
                    return;
                }
                numberNine.PerformClick();
                return;
            case Keys.Escape: case Keys.End: // Escape and End Keys will close the Calculator
                this.Close();
                return;
        }
    }
    #endregion

    // Handle Focus Allocation on Button Select's w/Mouse
    public void OnButtonPress() {
        this.ActiveControl = null;
    }
}