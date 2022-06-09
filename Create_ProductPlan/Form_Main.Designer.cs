namespace Create_ProductPlan
{
    partial class Form_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.gridControl_ProductPlan = new DevExpress.XtraGrid.GridControl();
            this.Product_Import_View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.skinRibbonGalleryBarItem = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.skinDropDownButtonItem = new DevExpress.XtraBars.SkinDropDownButtonItem();
            this.skinPaletteRibbonGalleryBarItem = new DevExpress.XtraBars.SkinPaletteRibbonGalleryBarItem();
            this.barBtn_ImportData = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_ProductPlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Product_Import_View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_ProductPlan
            // 
            this.gridControl_ProductPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_ProductPlan.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControl_ProductPlan.Location = new System.Drawing.Point(0, 158);
            this.gridControl_ProductPlan.MainView = this.Product_Import_View;
            this.gridControl_ProductPlan.Name = "gridControl_ProductPlan";
            this.gridControl_ProductPlan.Size = new System.Drawing.Size(905, 482);
            this.gridControl_ProductPlan.TabIndex = 0;
            this.gridControl_ProductPlan.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.Product_Import_View});
            // 
            // Product_Import_View
            // 
            this.Product_Import_View.GridControl = this.gridControl_ProductPlan;
            this.Product_Import_View.Name = "Product_Import_View";
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.ribbonControl.SearchEditItem,
            this.skinRibbonGalleryBarItem,
            this.skinDropDownButtonItem,
            this.skinPaletteRibbonGalleryBarItem,
            this.barBtn_ImportData,
            this.barButtonItem1});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 5;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage});
            this.ribbonControl.Size = new System.Drawing.Size(905, 158);
            // 
            // skinRibbonGalleryBarItem
            // 
            this.skinRibbonGalleryBarItem.Caption = "skinRibbonGalleryBarItem";
            this.skinRibbonGalleryBarItem.Id = 1;
            this.skinRibbonGalleryBarItem.Name = "skinRibbonGalleryBarItem";
            // 
            // skinDropDownButtonItem
            // 
            this.skinDropDownButtonItem.Id = 2;
            this.skinDropDownButtonItem.Name = "skinDropDownButtonItem";
            // 
            // skinPaletteRibbonGalleryBarItem
            // 
            this.skinPaletteRibbonGalleryBarItem.Caption = "skinPaletteRibbonGalleryBarItem";
            this.skinPaletteRibbonGalleryBarItem.Id = 3;
            this.skinPaletteRibbonGalleryBarItem.Name = "skinPaletteRibbonGalleryBarItem";
            // 
            // barBtn_ImportData
            // 
            this.barBtn_ImportData.Caption = "Import Data";
            this.barBtn_ImportData.Id = 2;
            this.barBtn_ImportData.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBtn_ImportData.ImageOptions.Image")));
            this.barBtn_ImportData.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBtn_ImportData.ImageOptions.LargeImage")));
            this.barBtn_ImportData.Name = "barBtn_ImportData";
            this.barBtn_ImportData.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtn_ImportData_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Save Data";
            this.barButtonItem1.Id = 3;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // ribbonPage
            // 
            this.ribbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage.Name = "ribbonPage";
            this.ribbonPage.Text = "Main";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barBtn_ImportData);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 640);
            this.Controls.Add(this.gridControl_ProductPlan);
            this.Controls.Add(this.ribbonControl);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("Form_Main.IconOptions.Image")));
            this.Name = "Form_Main";
            this.Ribbon = this.ribbonControl;
            this.Text = "Form";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_ProductPlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Product_Import_View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_ProductPlan;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem;
        private DevExpress.XtraBars.SkinDropDownButtonItem skinDropDownButtonItem;
        private DevExpress.XtraBars.SkinPaletteRibbonGalleryBarItem skinPaletteRibbonGalleryBarItem;
        private DevExpress.XtraBars.BarButtonItem barBtn_ImportData;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraGrid.Views.Grid.GridView Product_Import_View;
    }
}
