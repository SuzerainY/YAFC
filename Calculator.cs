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
        Size newSize = this.ClientSize;

        expressionBox.expressionBox_OnWindowResize(FormSize: newSize);
        outputBox.outputBox_OnWindowResize(FormSize: newSize);
        helpLink.helpLink_OnWindowResize();
        enterButton.enterButton_OnWindowResize(FormSize: newSize);
        backButton.backButton_OnWindowResize(FormSize: newSize);
        clearButton.clearButton_OnWindowResize(FormSize: newSize);
        percentButton.percentButton_OnWindowResize(FormSize: newSize);

        plusButton.plusButton_OnWindowResize(FormSize: newSize);
        minusButton.minusButton_OnWindowResize(FormSize: newSize);
        divideButton.divideButton_OnWindowResize(FormSize: newSize);
        multiplyButton.multiplyButton_OnWindowResize(FormSize: newSize);
        changeSignButton.changeSignButton_OnWindowResize(FormSize: newSize);
        naturalLogButton.naturalLogButton_OnWindowResize(FormSize: newSize);
        logTenButton.logTenButton_OnWindowResize(FormSize: newSize);
        squareRootButton.squareRootButton_OnWindowResize(FormSize: newSize);
        squaredButton.squaredButton_OnWindowResize(FormSize: newSize);
        powerOfButton.powerOfButton_OnWindowResize(FormSize: newSize);
        nRootButton.nRootButton_OnWindowResize(FormSize: newSize);
        nLogBaseButton.nLogBaseButton_OnWindowResize(FormSize: newSize);
        inverseButton.inverseButton_OnWindowResize(FormSize: newSize);
        eToXButton.eToXButton_OnWindowResize(FormSize: newSize);
        absoluteValueButton.absoluteValueButton_OnWindowResize(FormSize: newSize);

        leftParenthesis.leftParenthesis_OnWindowResize(FormSize: newSize);
        rightParenthesis.rightParenthesis_OnWindowResize(FormSize: newSize);
        numberPeriod.numberPeriod_OnWindowResize(FormSize: newSize);
        numberZero.numberZero_OnWindowResize(FormSize: newSize);
        numberOne.numberOne_OnWindowResize(FormSize: newSize);
        numberTwo.numberTwo_OnWindowResize(FormSize: newSize);
        numberThree.numberThree_OnWindowResize(FormSize: newSize);
        numberFour.numberFour_OnWindowResize(FormSize: newSize);
        numberFive.numberFive_OnWindowResize(FormSize: newSize);
        numberSix.numberSix_OnWindowResize(FormSize: newSize);
        numberSeven.numberSeven_OnWindowResize(FormSize: newSize);
        numberEight.numberEight_OnWindowResize(FormSize: newSize);
        numberNine.numberNine_OnWindowResize(FormSize: newSize);
        numberPI.numberPI_OnWindowResize(FormSize: newSize);
        numberE.numberE_OnWindowResize(FormSize: newSize);
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