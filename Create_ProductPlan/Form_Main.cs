using System;
using System.Data;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using DevExpress.DataAccess.Excel;
using DevExpress.XtraEditors.Repository;
using System.Drawing;
using System.Diagnostics;

namespace Create_ProductPlan
{
    public partial class Form_Main : RibbonForm
    {
        private GridColumn gridCol_Production_Order_Number = new GridColumn();
        private GridColumn gridCol_Delivery_Date = new GridColumn();
        private GridColumn gridCol_Item_Number = new GridColumn();
        private GridColumn gridCol_Item_Batch_Number = new GridColumn();
        private GridColumn gridCol_Parent_Production_Order_Number = new GridColumn();
        private GridColumn gridCol_Production_Pool_ID = new GridColumn();
        private GridColumn gridCol_Production_Site_ID = new GridColumn();
        private GridColumn gridCol_Production_Warehouse_ID = new GridColumn();
        private GridColumn gridCol_Schedule_Quantity = new GridColumn();
        private GridColumn gridCol_Source_Bom_ID = new GridColumn();
        private GridColumn gridCol_Source_Route_ID = new GridColumn();
        private GridColumn gridCol_Default_Ledge_Dimension_Display_Value = new GridColumn();

        DataTable tablePlan;

        public Form_Main()
        {
            InitializeComponent();
        }

        private void Form_Main_Load(object sender, System.EventArgs e)
        {
            Define_GridView();
        }

        private void Define_GridView()
        {
            Product_Import_View.OptionsPrint.AutoWidth = false;
            Product_Import_View.OptionsView.ColumnAutoWidth = false;

            // PRODUCTION ORDER NUMBER
            gridCol_Production_Order_Number.Name = "gridCol_Production_Order_Number";
            gridCol_Production_Order_Number.Caption = "PRODUCTIONORDERNUMBER";
            gridCol_Production_Order_Number.FieldName = "PRODUCTIONORDERNUMBER";
            gridCol_Production_Order_Number.VisibleIndex = 0;
            gridCol_Production_Order_Number.Width = 140;

            gridCol_Delivery_Date.Name = "gridCol_Delivery_Date";
            gridCol_Delivery_Date.Caption = "DELIVERYDATE";
            gridCol_Delivery_Date.FieldName = "DELIVERYDATE";
            gridCol_Delivery_Date.ColumnEdit = new RepositoryItemDateEdit();
            gridCol_Delivery_Date.VisibleIndex = 0;
            gridCol_Delivery_Date.Width = 104;
            gridCol_Delivery_Date.AppearanceCell.Options.UseTextOptions = true;
            gridCol_Delivery_Date.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;

            gridCol_Item_Number.Name = "gridCol_Item_Number";
            gridCol_Item_Number.Caption = "ITEMNUMBER";
            gridCol_Item_Number.FieldName = "ITEMNUMBER";
            gridCol_Item_Number.VisibleIndex = 0;
            gridCol_Item_Number.Width = 120;
            gridCol_Item_Number.AppearanceCell.Options.UseTextOptions = true;
            gridCol_Item_Number.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;

            gridCol_Item_Batch_Number.Name = "gridCol_Item_Batch_Number";
            gridCol_Item_Batch_Number.Caption = "ITEMBATCHNUMBER";
            gridCol_Item_Batch_Number.FieldName = "ITEMBATCHNUMBER";
            gridCol_Item_Batch_Number.VisibleIndex = 0;
            gridCol_Item_Batch_Number.Width = 80;

            gridCol_Parent_Production_Order_Number.Name = "gridCol_Parent_Production_Order_Number";
            gridCol_Parent_Production_Order_Number.Caption = "PARENTPRODUCTIONORDERNUMBER";
            gridCol_Parent_Production_Order_Number.FieldName = "PARENTPRODUCTIONORDERNUMBER";
            gridCol_Parent_Production_Order_Number.VisibleIndex = 0;
            gridCol_Parent_Production_Order_Number.Width = 135;

            gridCol_Production_Pool_ID.Name = "gridCol_Production_Pool_ID";
            gridCol_Production_Pool_ID.Caption = "PRODUCTIONPOOLID";
            gridCol_Production_Pool_ID.FieldName = "PRODUCTIONPOOLID";
            gridCol_Production_Pool_ID.VisibleIndex = 0;
            gridCol_Production_Pool_ID.Width = 90;

            gridCol_Production_Site_ID.Name = "gridCol_Production_Site_ID";
            gridCol_Production_Site_ID.Caption = "PRODUCTIONSITEID";
            gridCol_Production_Site_ID.FieldName = "PRODUCTIONSITEID";
            gridCol_Production_Site_ID.VisibleIndex = 0;
            gridCol_Production_Site_ID.Width = 92;

            gridCol_Production_Warehouse_ID.Name = "gridCol_Production_Warehouse_ID";
            gridCol_Production_Warehouse_ID.Caption = "PRODUCTIONWAREHOUSEID";
            gridCol_Production_Warehouse_ID.FieldName = "PRODUCTIONWAREHOUSEID";
            gridCol_Production_Warehouse_ID.VisibleIndex = 0;
            gridCol_Production_Warehouse_ID.Width = 80;

            gridCol_Schedule_Quantity.Name = "gridCol_Schedule_Quantity";
            gridCol_Schedule_Quantity.Caption = "SCHEDULEDQUANTITY";
            gridCol_Schedule_Quantity.FieldName = "SCHEDULEDQUANTITY";
            gridCol_Schedule_Quantity.VisibleIndex = 0;
            gridCol_Schedule_Quantity.Width = 150;
            gridCol_Schedule_Quantity.AppearanceCell.Options.UseTextOptions = true;
            gridCol_Schedule_Quantity.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
            gridCol_Schedule_Quantity.DisplayFormat.FormatString = "#,##0";
            gridCol_Schedule_Quantity.DisplayFormat.FormatType = FormatType.Numeric;

            gridCol_Source_Bom_ID.Name = "gridCol_Source_Bom_ID";
            gridCol_Source_Bom_ID.Caption = "SOURCEBOMID";
            gridCol_Source_Bom_ID.FieldName = "SOURCEBOMID";
            gridCol_Source_Bom_ID.VisibleIndex = 0;
            gridCol_Source_Bom_ID.Width = 150;

            gridCol_Source_Route_ID.Name = "gridCol_Source_Route_ID";
            gridCol_Source_Route_ID.Caption = "SOURCEROUTEID";
            gridCol_Source_Route_ID.FieldName = "SOURCEROUTEID";
            gridCol_Source_Route_ID.VisibleIndex = 0;
            gridCol_Source_Route_ID.Width = 150;

            gridCol_Default_Ledge_Dimension_Display_Value.Name = "gridCol_Default_Ledge_Dimension_Display_Value";
            gridCol_Default_Ledge_Dimension_Display_Value.Caption = "DEFAULTLEDGERDIMENSIONDISPLAYVALUE";
            gridCol_Default_Ledge_Dimension_Display_Value.FieldName = "DEFAULTLEDGERDIMENSIONDISPLAYVALUE";
            gridCol_Default_Ledge_Dimension_Display_Value.VisibleIndex = 0;
            gridCol_Default_Ledge_Dimension_Display_Value.Width = 190;

            Product_Import_View.Columns.Add(gridCol_Production_Order_Number);
            Product_Import_View.Columns.Add(gridCol_Delivery_Date);
            Product_Import_View.Columns.Add(gridCol_Item_Number);
            Product_Import_View.Columns.Add(gridCol_Item_Batch_Number);
            Product_Import_View.Columns.Add(gridCol_Parent_Production_Order_Number);
            Product_Import_View.Columns.Add(gridCol_Production_Pool_ID);
            Product_Import_View.Columns.Add(gridCol_Production_Site_ID);
            Product_Import_View.Columns.Add(gridCol_Production_Warehouse_ID);
            Product_Import_View.Columns.Add(gridCol_Schedule_Quantity);
            Product_Import_View.Columns.Add(gridCol_Source_Bom_ID);
            Product_Import_View.Columns.Add(gridCol_Source_Route_ID);
            Product_Import_View.Columns.Add(gridCol_Default_Ledge_Dimension_Display_Value);

            foreach (GridColumn c in Product_Import_View.Columns)
            {
                c.AppearanceHeader.Options.UseFont = true;
                c.AppearanceHeader.Options.UseForeColor = true;
                c.AppearanceHeader.Options.UseTextOptions = true;
                c.AppearanceHeader.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                c.AppearanceHeader.ForeColor = Color.Black;
                c.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            }
        }

        private void barBtn_ImportData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Get link file excel
            OpenFileDialog theinputDialog = new OpenFileDialog
            {
                Title = "Chọn file dữ liệu production cần import",
                Filter = "Files Excel|*.xls;*.xlsx"
            };
            if (theinputDialog.ShowDialog() == DialogResult.OK)
            {
                // Create a new Excel data source.
                ExcelDataSource excelDataSource = new ExcelDataSource
                {
                    FileName = theinputDialog.FileName
            };

                // Select a required worksheet.
                ExcelWorksheetSettings excelWorksheetSettings = new ExcelWorksheetSettings
                {
                    WorksheetIndex = 0
                };

                // Specify import settings.
                ExcelSourceOptions excelSourceOptions = new ExcelSourceOptions
                {
                    ImportSettings = excelWorksheetSettings,
                    SkipHiddenRows = true,
                    SkipHiddenColumns = true,
                    UseFirstRowAsHeader = true
                };
                excelDataSource.SourceOptions = excelSourceOptions;

                excelDataSource.Fill();

                tablePlan = excelDataSource.ExcelToDataTable();

                DataTable tableImport = new DataTable();
                tableImport.Columns.Add("PRODUCTIONORDERNUMBER");
                tableImport.Columns.Add("DELIVERYDATE");
                tableImport.Columns.Add("ITEMNUMBER");
                tableImport.Columns.Add("ITEMBATCHNUMBER");
                tableImport.Columns.Add("PARENTPRODUCTIONORDERNUMBER");
                tableImport.Columns.Add("PRODUCTIONPOOLID");
                tableImport.Columns.Add("PRODUCTIONSITEID");
                tableImport.Columns.Add("PRODUCTIONWAREHOUSEID");
                tableImport.Columns.Add("SCHEDULEDQUANTITY");
                tableImport.Columns.Add("SOURCEBOMID");
                tableImport.Columns.Add("SOURCEROUTEID");
                tableImport.Columns.Add("DEFAULTLEDGERDIMENSIONDISPLAYVALUE");

                // On all tables' rows
                foreach (DataRow row in tablePlan.Rows)
                {

                    int count = 0;
                    // On all tables' columns
                    foreach (DataColumn col in tablePlan.Columns)
                    {
                        if (col.ColumnName == "No" || col.ColumnName == "Group" || col.ColumnName == "Total" || col.ColumnName == "Item Code")
                        {
                        } else
                        {
                            string columnName = col.ColumnName;
                            var scheduleQuantity = row[count];

                            if (scheduleQuantity != DBNull.Value)
                            {
                                if(Convert.ToInt16(scheduleQuantity) > 0)
                                {
                                    DataRow dtrow = tableImport.NewRow();
                                    dtrow["ITEMNUMBER"] = Convert.ToString(row.Field<string>("Item Code"));
                                    dtrow["DELIVERYDATE"] = Convert.ToDateTime(columnName).ToString("dd/MM/yyyy");
                                    dtrow["SCHEDULEDQUANTITY"] = scheduleQuantity;
                                    tableImport.Rows.Add(dtrow);
                                }
                            }
                        }
                        count++;
                    }
                }

                gridControl_ProductPlan.DataSource = tableImport.AsEnumerable().OrderBy(x=>x[1]).CopyToDataTable() ;

                SaveFileDialog theoutputDialog = new SaveFileDialog
                {
                    Title = "Chọn đường dẫn lưu file kế hoạch",
                    Filter = "Files Excel|*.xlsx;*.xls"
                };
                if (theoutputDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = theoutputDialog.FileName;

                    gridControl_ProductPlan.ExportToXlsx(path);

                    // Open the created XLSX file with the default application.
                    Process.Start(path);
                }    
            }
        }
    }
}

