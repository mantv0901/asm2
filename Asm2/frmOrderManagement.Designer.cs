namespace Asm2
{
    partial class frmOrderManagement
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
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.btnSearchOrderID = new System.Windows.Forms.Button();
            this.txtSearchOrderID = new System.Windows.Forms.TextBox();
            this.btnAddNewOrder = new System.Windows.Forms.Button();
            this.btnDeleteOrder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOrders
            // 
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(0, 97);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.RowTemplate.Height = 25;
            this.dgvOrders.Size = new System.Drawing.Size(756, 318);
            this.dgvOrders.TabIndex = 0;
            // 
            // btnSearchOrderID
            // 
            this.btnSearchOrderID.Location = new System.Drawing.Point(177, 44);
            this.btnSearchOrderID.Name = "btnSearchOrderID";
            this.btnSearchOrderID.Size = new System.Drawing.Size(104, 23);
            this.btnSearchOrderID.TabIndex = 1;
            this.btnSearchOrderID.Text = "Search By ID";
            this.btnSearchOrderID.UseVisualStyleBackColor = true;
            this.btnSearchOrderID.Click += new System.EventHandler(this.btnSearchOrderID_Click);
            // 
            // txtSearchOrderID
            // 
            this.txtSearchOrderID.Location = new System.Drawing.Point(60, 44);
            this.txtSearchOrderID.Name = "txtSearchOrderID";
            this.txtSearchOrderID.Size = new System.Drawing.Size(111, 23);
            this.txtSearchOrderID.TabIndex = 2;
            this.txtSearchOrderID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchOrderID_KeyPress);
            // 
            // btnAddNewOrder
            // 
            this.btnAddNewOrder.Location = new System.Drawing.Point(466, 44);
            this.btnAddNewOrder.Name = "btnAddNewOrder";
            this.btnAddNewOrder.Size = new System.Drawing.Size(127, 23);
            this.btnAddNewOrder.TabIndex = 3;
            this.btnAddNewOrder.Text = "Add New Order";
            this.btnAddNewOrder.UseVisualStyleBackColor = true;
            this.btnAddNewOrder.Click += new System.EventHandler(this.btnAddNewOrder_Click);
            // 
            // btnDeleteOrder
            // 
            this.btnDeleteOrder.Location = new System.Drawing.Point(625, 44);
            this.btnDeleteOrder.Name = "btnDeleteOrder";
            this.btnDeleteOrder.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteOrder.TabIndex = 4;
            this.btnDeleteOrder.Text = "Delete";
            this.btnDeleteOrder.UseVisualStyleBackColor = true;
            this.btnDeleteOrder.Click += new System.EventHandler(this.btnDeleteOrder_Click);
            // 
            // frmOrderManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 415);
            this.Controls.Add(this.btnDeleteOrder);
            this.Controls.Add(this.btnAddNewOrder);
            this.Controls.Add(this.txtSearchOrderID);
            this.Controls.Add(this.btnSearchOrderID);
            this.Controls.Add(this.dgvOrders);
            this.Name = "frmOrderManagement";
            this.Text = "Order Management";
            this.Load += new System.EventHandler(this.frmOrderManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Button btnSearchOrderID;
        private System.Windows.Forms.TextBox txtSearchOrderID;
        private System.Windows.Forms.Button btnAddNewOrder;
        private System.Windows.Forms.Button btnDeleteOrder;
    }
}