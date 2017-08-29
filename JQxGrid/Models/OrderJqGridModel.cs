//using system;
//using system.collections.generic;
//using system.linq;
//using system.web;
//using system.web.mvc;
//using system.web.ui.webcontrols;


//namespace jqxgrid.models
//{
//    public class ordersjqgridmodel
//    {
//        public jqgrid ordersgrid { get; set; }

//        public ordersjqgridmodel()
//        {
//            ordersgrid = new jqgrid
//            {
//                columns = new list()
//                                 {
//                                     new jqgridcolumn { datafield = "orderid", 
//                                                        // always set primarykey for add,edit,delete operations
//                                                        // if not set, the first column will be assumed as primary key
//                                                        primarykey = true,
//                                                        editable = false,
//                                                        width = 50 },
//                                     new jqgridcolumn { datafield = "id",
//                                                        editable = true,
//                                                        width = 100 },
//                                     new jqgridcolumn { datafield = "orderdate",
//                                                        editable = true,
//                                                        width = 100,
//                                                        dataformatstring = "{0:yyyy/mm/dd}" },
//                                     new jqgridcolumn { datafield = "freight",
//                                                        editable = true,
//                                                        width = 75 },
//                                     new jqgridcolumn { datafield = "shipname",
//                                                        editable =  true
//                                                      }
//                                 },
//                width = unit.pixel(640),
//                height = unit.percentage(100)
//            };

//            ordersgrid.toolbarsettings.showrefreshbutton = true;
//        }

//    }
//}