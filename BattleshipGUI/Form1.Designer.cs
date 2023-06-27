namespace BattleshipGUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            myGrid = new Grid();
            opponentGrid = new Grid();
            newFleetButton = new Button();
            startGameButton = new Button();
            SuspendLayout();
            // 
            // myGrid
            // 
            myGrid.Location = new Point(39, 107);
            myGrid.Name = "myGrid";
            myGrid.Size = new Size(457, 364);
            myGrid.TabIndex = 0;
            myGrid.Load += myGrid_Load;
            // 
            // opponentGrid
            // 
            opponentGrid.Location = new Point(586, 107);
            opponentGrid.Name = "opponentGrid";
            opponentGrid.Size = new Size(457, 364);
            opponentGrid.TabIndex = 1;
            opponentGrid.Load += opponentGrid_Load;
            // 
            // newFleetButton
            // 
            newFleetButton.Location = new Point(309, 529);
            newFleetButton.Name = "newFleetButton";
            newFleetButton.Size = new Size(187, 46);
            newFleetButton.TabIndex = 2;
            newFleetButton.Text = "New Fleet";
            newFleetButton.UseVisualStyleBackColor = true;
            newFleetButton.Click += newFleetButton_Click;
            // 
            // startGameButton
            // 
            startGameButton.Location = new Point(39, 532);
            startGameButton.Name = "startGameButton";
            startGameButton.RightToLeft = RightToLeft.No;
            startGameButton.Size = new Size(167, 43);
            startGameButton.TabIndex = 3;
            startGameButton.Text = "Start Game";
            startGameButton.UseVisualStyleBackColor = true;
            startGameButton.Click += startGameButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1092, 623);
            Controls.Add(startGameButton);
            Controls.Add(newFleetButton);
            Controls.Add(opponentGrid);
            Controls.Add(myGrid);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Grid myGrid;
        private Grid opponentGrid;
        private Button newFleetButton;
        private Button startGameButton;
    }
}