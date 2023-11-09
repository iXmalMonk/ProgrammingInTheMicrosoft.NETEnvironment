namespace Program
{
    partial class FormProperty
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            propertyGrid1 = new PropertyGrid();
            propertyGrid2 = new PropertyGrid();
            button1 = new Button();
            SuspendLayout();
            // 
            // propertyGrid1
            // 
            propertyGrid1.Location = new Point(738, 406);
            propertyGrid1.Name = "propertyGrid1";
            propertyGrid1.Size = new Size(8, 8);
            propertyGrid1.TabIndex = 0;
            // 
            // propertyGrid2
            // 
            propertyGrid2.Location = new Point(12, 12);
            propertyGrid2.Name = "propertyGrid2";
            propertyGrid2.Size = new Size(282, 389);
            propertyGrid2.TabIndex = 1;
            // 
            // button1
            // 
            button1.DialogResult = DialogResult.OK;
            button1.Location = new Point(12, 415);
            button1.Name = "button1";
            button1.Size = new Size(282, 23);
            button1.TabIndex = 2;
            button1.Text = "ОК";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FormProperty
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(306, 450);
            Controls.Add(button1);
            Controls.Add(propertyGrid2);
            Controls.Add(propertyGrid1);
            Name = "FormProperty";
            Text = "FormProperty";
            ResumeLayout(false);
        }

        #endregion

        private PropertyGrid propertyGrid1;
        private PropertyGrid propertyGrid2;
        private Button button1;
    }
}