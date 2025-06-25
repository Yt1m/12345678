namespace CarListApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox listBoxCars;
        private System.Windows.Forms.GroupBox groupBoxDetails;
        private System.Windows.Forms.RichTextBox richTextBoxDetails;
        private System.Windows.Forms.Button buttonShowDetails;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.listBoxCars = new System.Windows.Forms.ListBox();
            this.groupBoxDetails = new System.Windows.Forms.GroupBox();
            this.richTextBoxDetails = new System.Windows.Forms.RichTextBox();
            this.buttonShowDetails = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // listBoxCars
            this.listBoxCars.Location = new System.Drawing.Point(10, 10);
            this.listBoxCars.Size = new System.Drawing.Size(200, 300);
            this.listBoxCars.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxCars.SelectedIndexChanged += new System.EventHandler(this.listBoxCars_SelectedIndexChanged);

            // groupBoxDetails
            this.groupBoxDetails.Location = new System.Drawing.Point(220, 10);
            this.groupBoxDetails.Size = new System.Drawing.Size(400, 300);
            this.groupBoxDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDetails.Text = "Детальная информация";

            // richTextBoxDetails
            this.richTextBoxDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxDetails.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxDetails.ReadOnly = true;

            // buttonShowDetails
            this.buttonShowDetails.Location = new System.Drawing.Point(10, 320);
            this.buttonShowDetails.Size = new System.Drawing.Size(100, 30);
            this.buttonShowDetails.Text = "Показать";
            this.buttonShowDetails.Click += new System.EventHandler(this.buttonShowDetails_Click);

            // Form1
            this.ClientSize = new System.Drawing.Size(650, 400);
            this.Controls.Add(this.listBoxCars);
            this.Controls.Add(this.groupBoxDetails);
            this.Controls.Add(this.buttonShowDetails);
            this.Text = "Список автомобилей";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxDetails.Controls.Add(this.richTextBoxDetails); // Добавляем RichTextBox в GroupBox
            this.ResumeLayout(false);
        }
    }
}