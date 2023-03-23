using Microsoft.Win32;

namespace FinancialCalculator;

public partial class CalculatorWindow
{
    public static CalculatorWindow Instance;
    public static ExpressionBox expressionBox;
    public static OutputBox outputBox;

    // Components of Calculator Declared
    private HelpLink helpLink;
    private EnterButton enterButton;
    private BackButton backButton;
    private ClearButton clearButton;
    private PercentButton percentButton;
    private PlusButton plusButton;
    private MinusButton minusButton;
    private DivideButton divideButton;
    private MultiplyButton multiplyButton;
    private ChangeSignButton changeSignButton;
    private NaturalLogButton naturalLogButton;
    private LogTenButton logTenButton;
    private SquareRootButton squareRootButton;
    private SquaredButton squaredButton;
    private PowerOfButton powerOfButton;
    private NRootButton nRootButton;
    private NLogBaseButton nLogBaseButton;
    private InverseButton inverseButton;
    private EToXButton eToXButton;
    private AbsoluteValueButton absoluteValueButton;
    private LeftParenthesis leftParenthesis;
    private RightParenthesis rightParenthesis;
    private NumberPeriod numberPeriod;
    private NumberZero numberZero;
    private NumberOne numberOne;
    private NumberTwo numberTwo;
    private NumberThree numberThree;
    private NumberFour numberFour;
    private NumberFive numberFive;
    private NumberSix numberSix;
    private NumberSeven numberSeven;
    private NumberEight numberEight;
    private NumberNine numberNine;
    private NumberPI numberPI;
    private NumberE numberE;

    // Required designer variable.
    private System.ComponentModel.IContainer components = null;


    // Clean up any resources being used.
    // <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code
    // Required method for Designer support - do not modify the contents of this method with the code editor.
    private void InitializeComponent() {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(430, 600);
        this.MinimumSize = new Size(430, 600);
        this.Text = "YAFC [YetAnotherFinancialCalculator]";
        // Icon YAFCicon = new Icon("images/YAFCicon.ico");
        // this.Icon = YAFCicon;
        this.BackColor = Color.FromArgb(unchecked((int)0xFF202020));
    }
    #endregion

    private void InitializeButtons() {
        expressionBox = new ExpressionBox(FormSize: this.ClientSize);
        this.Controls.Add(expressionBox); // Add Component to CalculatorWindow's Controls Collection
        outputBox = new OutputBox(FormSize: this.ClientSize);
        this.Controls.Add(outputBox);
        helpLink = new HelpLink(); // HELP Link
        this.Controls.Add(helpLink);
        enterButton = new EnterButton(FormSize: this.ClientSize); // ENTER Button
        this.Controls.Add(enterButton);
        backButton = new BackButton(FormSize: this.ClientSize); // BACK Button
        this.Controls.Add(backButton);
        clearButton = new ClearButton(FormSize: this.ClientSize); // CLEAR Button
        this.Controls.Add(clearButton);
        percentButton = new PercentButton(FormSize: this.ClientSize); // PERCENT Button
        this.Controls.Add(percentButton);

        plusButton = new PlusButton(FormSize: this.ClientSize); // PLUS Button
        this.Controls.Add(plusButton);
        minusButton = new MinusButton(FormSize: this.ClientSize); // MINUS Button
        this.Controls.Add(minusButton);
        divideButton = new DivideButton(FormSize: this.ClientSize); // DIVIDE Button
        this.Controls.Add(divideButton);
        multiplyButton = new MultiplyButton(FormSize: this.ClientSize); // MULTIPLY Button
        this.Controls.Add(multiplyButton);
        changeSignButton = new ChangeSignButton(FormSize: this.ClientSize); // CHANGE SIGN Button
        this.Controls.Add(changeSignButton);
        naturalLogButton = new NaturalLogButton(FormSize: this.ClientSize); // NATURAL LOGARITHM Button
        this.Controls.Add(naturalLogButton);
        logTenButton = new LogTenButton(FormSize: this.ClientSize); // LOGARITHM BASE 10 Button
        this.Controls.Add(logTenButton);
        squareRootButton = new SquareRootButton(FormSize: this.ClientSize); // SQUARE ROOT Button
        this.Controls.Add(squareRootButton);
        squaredButton = new SquaredButton(FormSize: this.ClientSize); // SQUARED Button
        this.Controls.Add(squaredButton);
        powerOfButton = new PowerOfButton(FormSize: this.ClientSize); // POWER OF Button
        this.Controls.Add(powerOfButton);
        nRootButton = new NRootButton(FormSize: this.ClientSize); // N ROOT Button
        this.Controls.Add(nRootButton);
        nLogBaseButton = new NLogBaseButton(FormSize: this.ClientSize); // N LOG BASE Button
        this.Controls.Add(nLogBaseButton);
        inverseButton = new InverseButton(FormSize: this.ClientSize); // INVERSE Button
        this.Controls.Add(inverseButton);
        eToXButton = new EToXButton(FormSize: this.ClientSize); // E TO THE POWER OF X Button
        this.Controls.Add(eToXButton);
        absoluteValueButton = new AbsoluteValueButton(FormSize: this.ClientSize); // ABSOLUTE VALUE Button
        this.Controls.Add(absoluteValueButton);

        leftParenthesis = new LeftParenthesis(FormSize: this.ClientSize); // Left Parenthesis
        this.Controls.Add(leftParenthesis);
        rightParenthesis = new RightParenthesis(FormSize: this.ClientSize); // Right Parenthesis
        this.Controls.Add(rightParenthesis);
        numberPeriod = new NumberPeriod(FormSize: this.ClientSize); // Number .
        this.Controls.Add(numberPeriod);
        numberZero = new NumberZero(FormSize: this.ClientSize); // Number 0
        this.Controls.Add(numberZero);
        numberOne = new NumberOne(FormSize: this.ClientSize); // Number 1
        this.Controls.Add(numberOne);
        numberTwo = new NumberTwo(FormSize: this.ClientSize); // Number 2
        this.Controls.Add(numberTwo);
        numberThree = new NumberThree(FormSize: this.ClientSize); // Number 3
        this.Controls.Add(numberThree);
        numberFour = new NumberFour(FormSize: this.ClientSize); // Number 4
        this.Controls.Add(numberFour);
        numberFive = new NumberFive(FormSize: this.ClientSize); // Number 5
        this.Controls.Add(numberFive);
        numberSix = new NumberSix(FormSize: this.ClientSize); // Number 6
        this.Controls.Add(numberSix);
        numberSeven = new NumberSeven(FormSize: this.ClientSize); // Number 7
        this.Controls.Add(numberSeven);
        numberEight = new NumberEight(FormSize: this.ClientSize); // Number 8
        this.Controls.Add(numberEight);
        numberNine = new NumberNine(FormSize: this.ClientSize); // Number 9
        this.Controls.Add(numberNine);
        numberPI = new NumberPI(FormSize: this.ClientSize); // Number PI / π
        this.Controls.Add(numberPI);
        numberE = new NumberE(FormSize: this.ClientSize); // Number E / e
        this.Controls.Add(numberE);
    }

    // This Method Fetches Windows Theme Color And Applies To Calculator UI
    private void LoadWindowsTheme() {
        var themeColor = FinancialCalculatorWindowsTheme.WindowsTheme.GetAccentColor();

        // Change Buttons To Match Theme
        foreach (Button button in this.Controls.OfType<Button>()) {
            button.FlatAppearance.BorderColor = themeColor;
        }
    }

    // Capture when the user updates visual preferences
    private void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e) {
        if (e.Category == UserPreferenceCategory.General || e.Category == UserPreferenceCategory.VisualStyle) {
            LoadWindowsTheme();
        }
    }

    // When form is disposed, remove event handler from system events
    private void Form_Disposed(object sender, EventArgs e) {
        SystemEvents.UserPreferenceChanged -= UserPreferenceChanged;
    }
}