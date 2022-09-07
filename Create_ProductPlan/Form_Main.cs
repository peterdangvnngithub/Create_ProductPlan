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
using DevExpress.XtraEditors.Controls;
using System.Linq;
using System.Collections.Generic;

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
        private GridColumn gridCol_Tkk_Address_Code = new GridColumn();
        private GridColumn gridCol_TKK_Is_KYB = new GridColumn();
        private GridColumn gridCol_TKK_Sale_Id = new GridColumn();
        private GridColumn gridCol_Production_Order_Priority = new GridColumn();

        DataTable tablePlan = new DataTable();
        DataTable tableMasterD365 = new DataTable();

        public Form_Main()
        {
            InitializeComponent();
        }

        private void Form_Main_Load(object sender, System.EventArgs e)
        {
            CreateRadioEditors();

            Define_Table();

            Define_GridView();
        }

        private void Define_Table()
        {
            //Table containing data displayed on gridview
            tablePlan.Columns.Add("PRODUCTIONORDERNUMBER");
            tablePlan.Columns.Add("DELIVERYDATE");
            tablePlan.Columns.Add("ITEMNUMBER");
            tablePlan.Columns.Add("SCHEDULEDQUANTITY", typeof(int));
            tablePlan.Columns.Add("PRODUCTIONSITEID", typeof(int));

            //Table containing data displayed on gridview
            tableMasterD365.Columns.Add("ITEMNUMBER");
            tableMasterD365.Columns.Add("PRODUCTIONWAREHOUSEID");
            tableMasterD365.Columns.Add("PRODUCTIONPOOLID");
            tableMasterD365.Columns.Add("SOURCEBOMID");
            tableMasterD365.Columns.Add("SOURCEROUTEID");
            tableMasterD365.Columns.Add("DEFAULTLEDGERDIMENSIONDISPLAYVALUE");
            tableMasterD365.Columns.Add("TKKADDRESSCODE");
            tableMasterD365.Columns.Add("TKKISKYB");
            tableMasterD365.Columns.Add("TKKSALESID");
            tableMasterD365.Columns.Add("PRODUCTIONORDERPRIORITY");
            tableMasterD365.Columns.Add("ITEMBATCHNUMBER");
            tableMasterD365.Columns.Add("PARENTPRODUCTIONORDERNUMBER");
        }

        private void CreateRadioEditors()
        {
            // Creating and initializing the radio group items
            RadioGroupItem rdBtnTVC1 = new RadioGroupItem();
            rdBtnTVC1.Value = "1";
            rdBtnTVC1.Description = "TVC1";

            RadioGroupItem rdBtnTVC2 = new RadioGroupItem();
            rdBtnTVC2.Value = "2";
            rdBtnTVC2.Description = "TVC2";

            radioGroupSiteID.Properties.Items.Add(rdBtnTVC1);
            radioGroupSiteID.Properties.Items.Add(rdBtnTVC2);
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

            // DELIVERY DATE
            gridCol_Delivery_Date.Name = "gridCol_Delivery_Date";
            gridCol_Delivery_Date.Caption = "DELIVERYDATE";
            gridCol_Delivery_Date.FieldName = "DELIVERYDATE";
            gridCol_Delivery_Date.ColumnEdit = new RepositoryItemDateEdit();
            gridCol_Delivery_Date.VisibleIndex = 0;
            gridCol_Delivery_Date.Width = 104;
            gridCol_Delivery_Date.AppearanceCell.Options.UseTextOptions = true;
            gridCol_Delivery_Date.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;

            // ITEM NUMBER
            gridCol_Item_Number.Name = "gridCol_Item_Number";
            gridCol_Item_Number.Caption = "ITEMNUMBER";
            gridCol_Item_Number.FieldName = "ITEMNUMBER";
            gridCol_Item_Number.VisibleIndex = 0;
            gridCol_Item_Number.Width = 120;
            gridCol_Item_Number.AppearanceCell.Options.UseTextOptions = true;
            gridCol_Item_Number.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;

            // ITEM BATCH NUMBER
            gridCol_Item_Batch_Number.Name = "gridCol_Item_Batch_Number";
            gridCol_Item_Batch_Number.Caption = "ITEMBATCHNUMBER";
            gridCol_Item_Batch_Number.FieldName = "ITEMBATCHNUMBER";
            gridCol_Item_Batch_Number.VisibleIndex = 0;
            gridCol_Item_Batch_Number.Width = 80;

            // PARENT PRODUCTION ORDER NUMBER
            gridCol_Parent_Production_Order_Number.Name = "gridCol_Parent_Production_Order_Number";
            gridCol_Parent_Production_Order_Number.Caption = "PARENTPRODUCTIONORDERNUMBER";
            gridCol_Parent_Production_Order_Number.FieldName = "PARENTPRODUCTIONORDERNUMBER";
            gridCol_Parent_Production_Order_Number.VisibleIndex = 0;
            gridCol_Parent_Production_Order_Number.Width = 135;

            // PRODUCTION POOL ID
            gridCol_Production_Pool_ID.Name = "gridCol_Production_Pool_ID";
            gridCol_Production_Pool_ID.Caption = "PRODUCTIONPOOLID";
            gridCol_Production_Pool_ID.FieldName = "PRODUCTIONPOOLID";
            gridCol_Production_Pool_ID.VisibleIndex = 0;
            gridCol_Production_Pool_ID.Width = 90;

            // PRODUCTION SITE ID
            gridCol_Production_Site_ID.Name = "gridCol_Production_Site_ID";
            gridCol_Production_Site_ID.Caption = "PRODUCTIONSITEID";
            gridCol_Production_Site_ID.FieldName = "PRODUCTIONSITEID";
            gridCol_Production_Site_ID.VisibleIndex = 0;
            gridCol_Production_Site_ID.Width = 92;

            // PRODUCTION WARE HOUSE ID
            gridCol_Production_Warehouse_ID.Name = "gridCol_Production_Warehouse_ID";
            gridCol_Production_Warehouse_ID.Caption = "PRODUCTIONWAREHOUSEID";
            gridCol_Production_Warehouse_ID.FieldName = "PRODUCTIONWAREHOUSEID";
            gridCol_Production_Warehouse_ID.VisibleIndex = 0;
            gridCol_Production_Warehouse_ID.Width = 80;

            // SCHEDULED QUANTITY
            gridCol_Schedule_Quantity.Name = "gridCol_Schedule_Quantity";
            gridCol_Schedule_Quantity.Caption = "SCHEDULEDQUANTITY";
            gridCol_Schedule_Quantity.FieldName = "SCHEDULEDQUANTITY";
            gridCol_Schedule_Quantity.VisibleIndex = 0;
            gridCol_Schedule_Quantity.Width = 150;
            gridCol_Schedule_Quantity.AppearanceCell.Options.UseTextOptions = true;
            gridCol_Schedule_Quantity.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
            gridCol_Schedule_Quantity.DisplayFormat.FormatString = "#,##0";
            gridCol_Schedule_Quantity.DisplayFormat.FormatType = FormatType.Numeric;

            //SOURCE BOM ID
            gridCol_Source_Bom_ID.Name = "gridCol_Source_Bom_ID";
            gridCol_Source_Bom_ID.Caption = "SOURCEBOMID";
            gridCol_Source_Bom_ID.FieldName = "SOURCEBOMID";
            gridCol_Source_Bom_ID.VisibleIndex = 0;
            gridCol_Source_Bom_ID.Width = 150;

            // SOURCE ROUTE ID
            gridCol_Source_Route_ID.Name = "gridCol_Source_Route_ID";
            gridCol_Source_Route_ID.Caption = "SOURCEROUTEID";
            gridCol_Source_Route_ID.FieldName = "SOURCEROUTEID";
            gridCol_Source_Route_ID.VisibleIndex = 0;
            gridCol_Source_Route_ID.Width = 150;

            // DEFAULT LEDGER DIMENSION DISPLAY VALUE
            gridCol_Default_Ledge_Dimension_Display_Value.Name = "gridCol_Default_Ledge_Dimension_Display_Value";
            gridCol_Default_Ledge_Dimension_Display_Value.Caption = "DEFAULTLEDGERDIMENSIONDISPLAYVALUE";
            gridCol_Default_Ledge_Dimension_Display_Value.FieldName = "DEFAULTLEDGERDIMENSIONDISPLAYVALUE";
            gridCol_Default_Ledge_Dimension_Display_Value.VisibleIndex = 0;
            gridCol_Default_Ledge_Dimension_Display_Value.Width = 230;

            // TKK ADDRESS CODE
            gridCol_Tkk_Address_Code.Name = "gridCol_Tkk_Address_Code";
            gridCol_Tkk_Address_Code.Caption = "TKKADDRESSCODE";
            gridCol_Tkk_Address_Code.FieldName = "TKKADDRESSCODE";
            gridCol_Tkk_Address_Code.VisibleIndex = 0;
            gridCol_Tkk_Address_Code.Width = 150;

            // TKK IS KYB
            gridCol_TKK_Is_KYB.Name = "gridCol_TKK_Is_KYB";
            gridCol_TKK_Is_KYB.Caption = "TKKISKYB";
            gridCol_TKK_Is_KYB.FieldName = "TKKISKYB";
            gridCol_TKK_Is_KYB.VisibleIndex = 0;
            gridCol_TKK_Is_KYB.Width = 150;

            // TKK SALES ID
            gridCol_TKK_Sale_Id.Name = "gridCol_TKK_Sale_Id";
            gridCol_TKK_Sale_Id.Caption = "TKKSALESID";
            gridCol_TKK_Sale_Id.FieldName = "TKKSALESID";
            gridCol_TKK_Sale_Id.VisibleIndex = 0;
            gridCol_TKK_Sale_Id.Width = 150;

            // PRODUCTION ORDER PRIORITY
            gridCol_Production_Order_Priority.Name = "gridCol_Production_Order_Priority";
            gridCol_Production_Order_Priority.Caption = "PRODUCTIONORDERPRIORITY";
            gridCol_Production_Order_Priority.FieldName = "PRODUCTIONORDERPRIORITY";
            gridCol_Production_Order_Priority.VisibleIndex = 0;
            gridCol_Production_Order_Priority.Width = 190;

            // Add column to gridview
            Product_Import_View.Columns.Add(gridCol_Production_Order_Number);
            Product_Import_View.Columns.Add(gridCol_Delivery_Date);
            Product_Import_View.Columns.Add(gridCol_Item_Number);
            Product_Import_View.Columns.Add(gridCol_Schedule_Quantity);
            Product_Import_View.Columns.Add(gridCol_Production_Site_ID);
            Product_Import_View.Columns.Add(gridCol_Production_Warehouse_ID);
            Product_Import_View.Columns.Add(gridCol_Production_Pool_ID);
            Product_Import_View.Columns.Add(gridCol_Source_Bom_ID);
            Product_Import_View.Columns.Add(gridCol_Source_Route_ID);
            Product_Import_View.Columns.Add(gridCol_Default_Ledge_Dimension_Display_Value);
            Product_Import_View.Columns.Add(gridCol_TKK_Is_KYB);
            Product_Import_View.Columns.Add(gridCol_TKK_Sale_Id);
            Product_Import_View.Columns.Add(gridCol_Tkk_Address_Code);
            Product_Import_View.Columns.Add(gridCol_Production_Order_Priority);
            Product_Import_View.Columns.Add(gridCol_Item_Batch_Number);
            Product_Import_View.Columns.Add(gridCol_Parent_Production_Order_Number);

            // Set common attribute
            foreach (GridColumn c in Product_Import_View.Columns)
            {
                c.AppearanceHeader.Options.UseFont = true;
                c.AppearanceHeader.Options.UseForeColor = true;
                c.AppearanceHeader.Options.UseTextOptions = true;
                c.AppearanceHeader.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                c.AppearanceHeader.ForeColor = Color.Black;
                c.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                c.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
            }
        }


        private bool Check_Error()
        {
            if (radioGroupSiteID.EditValue == null)
            {
                MessageBox.Show("Chưa chọn Site ID", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                radioGroupSiteID.Focus();
                return false;
            }
            return true;
        }

        private void barBtn_ImportData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(!Check_Error())
            {
                return;
            }   
            
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
                // 0: sheet 1
                // 1: sheet 2
                // 2: sheet 3
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

                DataTable temp = excelDataSource.ExcelToDataTable();

                // Loop all tables rows
                foreach (DataRow row in temp.Rows)
                {
                    int count = 0;
                    // Loop all tables columns
                    foreach (DataColumn col in temp.Columns)
                    {
                        if (col.ColumnName == "No" 
                            || col.ColumnName == "Group" 
                            || col.ColumnName == "Total" 
                            || col.ColumnName == "Item Code")
                        {
                        } else
                        {
                            string columnName = col.ColumnName; // Get the current column header
                            var scheduleQuantity = row[count];  // Get the current quantity

                            if (scheduleQuantity != DBNull.Value)
                            {
                                if(Convert.ToInt16(scheduleQuantity) > 0)
                                {
                                    DataRow dtrow = tablePlan.NewRow();
                                    dtrow["ITEMNUMBER"] = Convert.ToString(row.Field<string>("Item Code"));
                                    dtrow["DELIVERYDATE"] = Convert.ToDateTime(columnName).ToString("MM/dd/yyyy");
                                    dtrow["SCHEDULEDQUANTITY"] = Convert.ToInt16(scheduleQuantity);
                                    dtrow["PRODUCTIONSITEID"] = Convert.ToInt16(radioGroupSiteID.EditValue);
                                    tablePlan.Rows.Add(dtrow);
                                }
                            }
                        }
                        count++;
                    }
                }

                gridControl_ProductPlan.DataSource = tablePlan.AsEnumerable().OrderBy(x=>x[1]).CopyToDataTable() ;

                //SaveFileDialog theoutputDialog = new SaveFileDialog
                //{
                //    Title = "Chọn đường dẫn lưu file kế hoạch",
                //    Filter = "Files Excel|*.xlsx;*.xls"
                //};
                //if (theoutputDialog.ShowDialog() == DialogResult.OK)
                //{
                //    string path = theoutputDialog.FileName;

                //    // Export gridview data to excel type .Xlsx
                //    gridControl_ProductPlan.ExportToXlsx(path);

                //    // Open the created XLSX file with the default application.
                //    Process.Start(path);
                //}    
            }
        }

        private void barBtn_ClearData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl_ProductPlan.DataSource=null;
            radioGroupSiteID.EditValue=false;
        }

        private void barBtn_ImportMasterD365_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
                // 0: sheet 1
                // 1: sheet 2
                // 2: sheet 3
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

                DataTable temp = excelDataSource.ExcelToDataTable();

                foreach (DataRow dtRow in temp.Rows)
                {
                    DataRow newRow = tableMasterD365.NewRow();
                    newRow["ITEMNUMBER"] = dtRow["Item number"];
                    newRow["PRODUCTIONWAREHOUSEID"] = dtRow["Default WH"];
                    newRow["PRODUCTIONPOOLID"] = dtRow["Pool ID"];
                    newRow["SOURCEBOMID"] = dtRow["BOM ID"];
                    newRow["SOURCEROUTEID"] = dtRow["Route ID"];
                    newRow["DEFAULTLEDGERDIMENSIONDISPLAYVALUE"] = dtRow["Dimension"];
                    newRow["TKKADDRESSCODE"] = "";
                    newRow["TKKISKYB"] = "";
                    newRow["TKKSALESID"] = "";
                    newRow["PRODUCTIONORDERPRIORITY"] = "";
                    newRow["ITEMBATCHNUMBER"] = "";
                    newRow["PARENTPRODUCTIONORDERNUMBER"] = "";
                    tableMasterD365.Rows.Add(newRow);
                }

                var query = 
                    (
                    from dataRows1 in tablePlan.AsEnumerable()
                    join dataRows2 in tableMasterD365.AsEnumerable()
                    on dataRows1.Field<string>("ITEMNUMBER") equals dataRows2.Field<string>("ITEMNUMBER") into lj
                    from r in lj.DefaultIfEmpty()
                    select new DataPlan
                    {
                        PRODUCTIONORDERNUMBER               = dataRows1.Field<string>("PRODUCTIONORDERNUMBER"),
                        DELIVERYDATE                        = dataRows1.Field<string>("DELIVERYDATE"),
                        ITEMNUMBER                          = dataRows1.Field<string>("ITEMNUMBER"),
                        SCHEDULEDQUANTITY                   = dataRows1.Field<int>("SCHEDULEDQUANTITY"),
                        PRODUCTIONSITEID                    = dataRows1.Field<int>("PRODUCTIONSITEID"),
                        PRODUCTIONWAREHOUSEID               = r.Field<string>("PRODUCTIONWAREHOUSEID"),
                        PRODUCTIONPOOLID                    = r.Field<string>("PRODUCTIONPOOLID"),
                        SOURCEBOMID                         = r.Field<string>("SOURCEBOMID"),
                        SOURCEROUTEID                       = r.Field<string>("SOURCEROUTEID"),
                        DEFAULTLEDGERDIMENSIONDISPLAYVALUE  = r.Field<string>("DEFAULTLEDGERDIMENSIONDISPLAYVALUE"),
                        TKKADDRESSCODE                      = r.Field<string>("TKKADDRESSCODE"),
                        TKKISKYB                            = r.Field<string>("TKKISKYB"),
                        TKKSALESID                          = r.Field<string>("TKKSALESID"),
                        PRODUCTIONORDERPRIORITY             = r.Field<string>("PRODUCTIONORDERPRIORITY"),
                        ITEMBATCHNUMBER                     = r.Field<string>("ITEMBATCHNUMBER"),
                        PARENTPRODUCTIONORDERNUMBER         = r.Field<string>("PARENTPRODUCTIONORDERNUMBER")
                    });

                DataTable dt = new DataTable();
                dt.Columns.Add("PRODUCTIONORDERNUMBER");
                dt.Columns.Add("DELIVERYDATE");
                dt.Columns.Add("ITEMNUMBER");
                dt.Columns.Add("SCHEDULEDQUANTITY", typeof(int));
                dt.Columns.Add("PRODUCTIONSITEID", typeof(int));
                dt.Columns.Add("PRODUCTIONWAREHOUSEID");
                dt.Columns.Add("PRODUCTIONPOOLID");
                dt.Columns.Add("SOURCEBOMID");
                dt.Columns.Add("SOURCEROUTEID");
                dt.Columns.Add("DEFAULTLEDGERDIMENSIONDISPLAYVALUE");
                dt.Columns.Add("TKKADDRESSCODE");
                dt.Columns.Add("TKKISKYB");
                dt.Columns.Add("TKKSALESID");
                dt.Columns.Add("PRODUCTIONORDERPRIORITY");
                dt.Columns.Add("ITEMBATCHNUMBER");
                dt.Columns.Add("PARENTPRODUCTIONORDERNUMBER");

                foreach (DataPlan dtPlanRow in query)
                {
                    dt.Rows.Add(new object[]
                    {
                        dtPlanRow.PARENTPRODUCTIONORDERNUMBER,
                        dtPlanRow.DELIVERYDATE,
                        dtPlanRow.ITEMNUMBER,
                        dtPlanRow.SCHEDULEDQUANTITY,
                        dtPlanRow.PRODUCTIONSITEID,
                        dtPlanRow.PRODUCTIONWAREHOUSEID,
                        dtPlanRow.PRODUCTIONPOOLID,
                        dtPlanRow.SOURCEBOMID,
                        dtPlanRow.SOURCEROUTEID,
                        dtPlanRow.DEFAULTLEDGERDIMENSIONDISPLAYVALUE,
                        dtPlanRow.TKKADDRESSCODE,
                        dtPlanRow.TKKISKYB,
                        dtPlanRow.TKKSALESID,
                        dtPlanRow.PRODUCTIONORDERPRIORITY,
                        dtPlanRow.ITEMBATCHNUMBER,
                        dtPlanRow.PARENTPRODUCTIONORDERNUMBER
                    });
                }    

                gridControl_ProductPlan.DataSource = dt;

                SaveFileDialog theoutputDialog = new SaveFileDialog
                {
                    Title = "Chọn đường dẫn lưu file kế hoạch sản xuất",
                    Filter = "Files Excel|*.xlsx;*.xls"
                };
                if (theoutputDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = theoutputDialog.FileName;

                    // Export gridview data to excel type .Xlsx
                    gridControl_ProductPlan.ExportToXlsx(path);

                    // Open the created XLSX file with the default application.
                    Process.Start(path);
                }
            }
        }
    }
}

