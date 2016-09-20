namespace PizzaEmporium
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnFinishOrder = new System.Windows.Forms.Button();
            this.lstReceipt = new System.Windows.Forms.ListBox();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.gbHolder = new System.Windows.Forms.GroupBox();
            this.pnlMenuItems = new System.Windows.Forms.Panel();
            this.btnNewOrder = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.gbHolder.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(387, 206);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add->";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Visible = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(387, 235);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "<-Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Visible = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnFinishOrder
            // 
            this.btnFinishOrder.Location = new System.Drawing.Point(631, 404);
            this.btnFinishOrder.Name = "btnFinishOrder";
            this.btnFinishOrder.Size = new System.Drawing.Size(104, 47);
            this.btnFinishOrder.TabIndex = 2;
            this.btnFinishOrder.Text = "Finish Order";
            this.btnFinishOrder.UseVisualStyleBackColor = true;
            this.btnFinishOrder.Visible = false;
            this.btnFinishOrder.Click += new System.EventHandler(this.btnFinishOrder_Click);
            // 
            // lstReceipt
            // 
            this.lstReceipt.FormattingEnabled = true;
            this.lstReceipt.Location = new System.Drawing.Point(480, 160);
            this.lstReceipt.Name = "lstReceipt";
            this.lstReceipt.Size = new System.Drawing.Size(255, 225);
            this.lstReceipt.TabIndex = 3;
            // 
            // pnlOptions
            // 
            this.pnlOptions.Location = new System.Drawing.Point(6, 17);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(338, 224);
            this.pnlOptions.TabIndex = 4;
            // 
            // gbHolder
            // 
            this.gbHolder.Controls.Add(this.pnlOptions);
            this.gbHolder.Location = new System.Drawing.Point(31, 144);
            this.gbHolder.Name = "gbHolder";
            this.gbHolder.Size = new System.Drawing.Size(350, 254);
            this.gbHolder.TabIndex = 5;
            this.gbHolder.TabStop = false;
            this.gbHolder.Text = "Menu Options";
            this.gbHolder.Visible = false;
            // 
            // pnlMenuItems
            // 
            this.pnlMenuItems.Location = new System.Drawing.Point(37, 13);
            this.pnlMenuItems.Name = "pnlMenuItems";
            this.pnlMenuItems.Size = new System.Drawing.Size(680, 100);
            this.pnlMenuItems.TabIndex = 6;
            // 
            // btnNewOrder
            // 
            this.btnNewOrder.Location = new System.Drawing.Point(480, 404);
            this.btnNewOrder.Name = "btnNewOrder";
            this.btnNewOrder.Size = new System.Drawing.Size(104, 47);
            this.btnNewOrder.TabIndex = 7;
            this.btnNewOrder.Text = "Start New Order";
            this.btnNewOrder.UseVisualStyleBackColor = true;
            this.btnNewOrder.Click += new System.EventHandler(this.btnNewOrder_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(31, 404);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(104, 47);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 479);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnNewOrder);
            this.Controls.Add(this.pnlMenuItems);
            this.Controls.Add(this.gbHolder);
            this.Controls.Add(this.lstReceipt);
            this.Controls.Add(this.btnFinishOrder);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Name = "frmMain";
            this.Text = "Pizza Emporium";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbHolder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnFinishOrder;
        private System.Windows.Forms.ListBox lstReceipt;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.GroupBox gbHolder;
        private System.Windows.Forms.Panel pnlMenuItems;
        private System.Windows.Forms.Button btnNewOrder;
        private System.Windows.Forms.Button btnExit;
    }
}

