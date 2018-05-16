using System;
using System.Drawing;
using System.Windows.Forms;

namespace PasswordGenerator {
  class FormPasswordGenerator : Form {
    public static void Main(string[] args) {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(true);
      Application.Run(new FormPasswordGenerator());
    }

    public FormPasswordGenerator() {
      this.SuspendLayout();

      this.panel.Parent = this;
      this.panel.Location = new Point(10, 10);
      this.panel.Size = new Size(380, 220);
      this.panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.panel.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;

      this.labelPasswordLength.Parent = this.panel;
      this.labelPasswordLength.Text = "Password Length";
      this.labelPasswordLength.AutoSize = true;
      this.labelPasswordLength.Location = new Point(10, 14);

      this.numericUpdDownPasswordLength.Parent = this.panel;
      this.numericUpdDownPasswordLength.BackColor = Color.White;
      this.numericUpdDownPasswordLength.Location = new Point(130, 10);
      this.numericUpdDownPasswordLength.Width = 50;
      this.numericUpdDownPasswordLength.Minimum = 2;
      this.numericUpdDownPasswordLength.Maximum = 128;
      this.numericUpdDownPasswordLength.Value = 16;

      this.checkBoxIncludeSymbols.Parent = this.panel;
      this.checkBoxIncludeSymbols.Text = "Include symbols ( e.g. ##$% )";
      this.checkBoxIncludeSymbols.AutoSize = true;
      this.checkBoxIncludeSymbols.Location = new Point(10, 35);
      this.checkBoxIncludeSymbols.Click += this.OnCheckBoxChecked;

      this.checkBoxIncludeNumbers.Parent = this.panel;
      this.checkBoxIncludeNumbers.Text = "Include numbers ( e.g. 123456 )";
      this.checkBoxIncludeNumbers.AutoSize = true;
      this.checkBoxIncludeNumbers.Location = new Point(10, 60);
      this.checkBoxIncludeNumbers.Click += this.OnCheckBoxChecked;

      this.checkBoxIncludeLowercaseCharacters.Parent = this.panel;
      this.checkBoxIncludeLowercaseCharacters.Text = "Include Lowercase Characters ( e.g. abcdefgh )";
      this.checkBoxIncludeLowercaseCharacters.AutoSize = true;
      this.checkBoxIncludeLowercaseCharacters.Location = new Point(10, 85);
      this.checkBoxIncludeLowercaseCharacters.Click += this.OnCheckBoxChecked;

      this.checkBoxIncludeUppercaseCharacters.Parent = this.panel;
      this.checkBoxIncludeUppercaseCharacters.Text = "Include uppercase Characters ( e.g. ABCDEFGH )";
      this.checkBoxIncludeUppercaseCharacters.AutoSize = true;
      this.checkBoxIncludeUppercaseCharacters.Location = new Point(10, 110);
      this.checkBoxIncludeUppercaseCharacters.Click += this.OnCheckBoxChecked;

      this.checkBoxExcludeSimilarCharacters.Parent = this.panel;
      this.checkBoxExcludeSimilarCharacters.Text = "Exclude Similar Characters ( e.g. i, l, 1, L, o, 0, O )";
      this.checkBoxExcludeSimilarCharacters.AutoSize = true;
      this.checkBoxExcludeSimilarCharacters.Location = new Point(10, 135);

      this.checkBoxExcludeAmbigousCharacters.Parent = this.panel;
      this.checkBoxExcludeAmbigousCharacters.Text = "Exclude Ambigous Characters ( { } [ ] ( ) / \\ ' \" ` ~ , ; : . < > )";
      this.checkBoxExcludeAmbigousCharacters.AutoSize = true;
      this.checkBoxExcludeAmbigousCharacters.Location = new Point(10, 160);

      this.labelPasswordsNumber.Parent = this.panel;
      this.labelPasswordsNumber.Text = "Passwords Number";
      this.labelPasswordsNumber.AutoSize = true;
      this.labelPasswordsNumber.Location = new Point(10, 190);

      this.numericUpdDownPasswordsNumber.Parent = this.panel;
      this.numericUpdDownPasswordsNumber.BackColor = Color.White;
      this.numericUpdDownPasswordsNumber.Location = new Point(130, 185);
      this.numericUpdDownPasswordsNumber.Width = 50;
      this.numericUpdDownPasswordsNumber.Minimum = 1;
      this.numericUpdDownPasswordsNumber.Maximum = 999;
      this.numericUpdDownPasswordsNumber.Value = 1;

      this.buttonGenerate.Parent = this;
      this.buttonGenerate.Text = "Generate";
      this.buttonGenerate.Location = new Point(10, 239);
      this.buttonGenerate.Size = new Size(380, 23);
      this.buttonGenerate.Enabled = false;
      this.buttonGenerate.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
      this.buttonGenerate.Click += this.OnButtonGenerateClick;

      this.listBoxPasswords.Parent = this;
      this.listBoxPasswords.BackColor = Color.White;
      this.listBoxPasswords.Location = new Point(10, 270);
      this.listBoxPasswords.Size = new Size(380, 220);
      this.listBoxPasswords.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom;

      this.BackColor = Color.FromArgb(255, 236, 236, 236);
      this.Location = new Point(400, 200);
      this.ClientSize = new Size(400, 500);
      this.Text = "Secure Password Generator";
      this.MaximizeBox = false;
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private void OnCheckBoxChecked(object sender, EventArgs e) {
      this.buttonGenerate.Enabled = this.checkBoxIncludeSymbols.Checked || this.checkBoxIncludeNumbers.Checked || this.checkBoxIncludeLowercaseCharacters.Checked || this.checkBoxIncludeUppercaseCharacters.Checked;
    }

    private void OnButtonGenerateClick(object sender, EventArgs e) {
      this.listBoxPasswords.Items.Clear();
      Random random = new Random();
      for (int number = 0; number < this.numericUpdDownPasswordsNumber.Value; ++number) {
        string password = "";
        for (int index = 0; index < this.numericUpdDownPasswordLength.Value; ++index) {
          char character;
          bool valid = false;
          do {
            character = (char)random.Next(33, 126);
            if (this.checkBoxIncludeSymbols.Checked && char.IsLetterOrDigit(character) == false)
              valid = true;
            if (this.checkBoxIncludeNumbers.Checked && char.IsDigit(character))
              valid = true;
            if (this.checkBoxIncludeLowercaseCharacters.Checked && char.IsLetter(character) && char.IsLower(character))
              valid = true;
            if (this.checkBoxIncludeUppercaseCharacters.Checked && char.IsLetter(character) && char.IsUpper(character))
              valid = true;
            if (this.checkBoxExcludeSimilarCharacters.Checked && "1iIlL2zZ5sS6G8B0oO".IndexOf(character) != -1)
              valid = false;
            if (this.checkBoxExcludeAmbigousCharacters.Checked && "{}[]()/\\'\"`~,;:.<>".IndexOf(character) != -1)
              valid = false;
          } while (valid == false);
          password += character;
        }
        this.listBoxPasswords.Items.Add(password);
      }
    }

    private Panel panel = new Panel();
    private Label labelPasswordLength = new Label();
    private NumericUpDown numericUpdDownPasswordLength = new NumericUpDown();
    private CheckBox checkBoxIncludeSymbols = new CheckBox();
    private CheckBox checkBoxIncludeNumbers = new CheckBox();
    private CheckBox checkBoxIncludeLowercaseCharacters = new CheckBox();
    private CheckBox checkBoxIncludeUppercaseCharacters = new CheckBox();
    private CheckBox checkBoxExcludeSimilarCharacters = new CheckBox();
    private CheckBox checkBoxExcludeAmbigousCharacters = new CheckBox();
    private Label labelPasswordsNumber = new Label();
    private NumericUpDown numericUpdDownPasswordsNumber = new NumericUpDown();
    private Button buttonGenerate = new Button();
    private ListBox listBoxPasswords = new ListBox();
  }
}
