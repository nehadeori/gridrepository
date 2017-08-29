$(function () {
    var IsDetailsDisplayed = false;
    var CurrentDetailId = "";
    $("#detailGridDiv").hide();
    $("#jqGrid").jqGrid({
        url: "/Customer/GetCustomers",
        datatype: 'json',
        mtype: 'Get',
        colNames: ['Id', 'Name', 'Address', 'Email', 'Phone'],
        colModel: [
            { key: true, hidden: true, name: 'Id', index: 'Id', editable: true },
            { key: false, name: 'Name', index: 'Name', editable: true },
            { key: false, name: 'Address', index: 'Address', editable: true },
            { key: false, name: 'Email', index: 'Email', editable: true, edittype: 'select', editoptions: { value: { 'M': 'Male', 'F': 'Female', 'N': 'None' } } },
            { key: false, name: 'Phone', index: 'Phone', editable: true }],
         //   { key: false, name: 'Age', index: 'Age', editable: true },
         //   { key: false, name: 'Batch', index: 'Batch', editable: true },
         //   { key: false, name: 'Class', index: 'Class', editable: true }],
        pager: jQuery('#jqControls'),
        rowNum: 10, 
        rowList: [10, 20, 30, 40, 50],
        height: '100%',
        viewrecords: true,
        caption: 'Students Master Records',
        emptyrecords: 'No Students Records are Available to Display',
        ondblClickRow: function (StudentId) {
            if (IsDetailsDisplayed == false) {
                var rowData = jQuery(this).getRowData(StudentId);
                CurrentDetailId = StudentId;
                ShowDetails(StudentId);
            }
            else {
                HideDetails(StudentId);
            }
        },
        jsonReader: {
            root: "rows",
            page: "page",
            total: "total",
            records: "records",
            repeatitems: false,
            Id: "0"
        },
        autowidth: true,
        multiselect: false
    }).navGrid('#jqControls', { edit: true, add: true, del: true, search: false, refresh: true },
        {
            zIndex: 100,
            url: '/Employee/Edit',
            closeOnEscape: true,
            closeAfterEdit: true,
            recreateForm: true,
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        },
        {
            zIndex: 100,
            url: "/Employee/Create",
            closeOnEscape: true,
            closeAfterAdd: true,
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        },
        {
            zIndex: 100,
            url: "/Employee/Delete",
            closeOnEscape: true,
            closeAfterDelete: true,
            recreateForm: true,
            msg: "Are you sure you want to delete Student... ? ",
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        });

    function ShowDetails(StudentId) {
        $("#detailGridDiv").show();
        ShowDetailsGrid(StudentId);
    }

    function HideDetails(StudentId) {
        if (StudentId == CurrentDetailId) {
            $("#detailGridDiv").hide();
            IsDetailsDisplayed = false;
        }
    }

    function ShowDetailsGrid(studentId) {
        CurrentDetailId = studentId;
        $("#jqGridDetail").jqGrid({
            url: "/Employee/GetStudents",
            datatype: 'json',
            mtype: 'Get',
            colNames: ['StudentId', 'First Name', 'Last Name', 'Gender', 'School', 'Age', 'Batch', 'Class'],
            colModel: [
                { key: true, hidden: true, name: 'StudentId', index: 'StudentId', editable: true },
                { key: false, name: 'FirstName', index: 'FirstName', editable: true },
                { key: false, name: 'LastName', index: 'LastName', editable: true },
                { key: false, name: 'Gender', index: 'Gender', editable: true, edittype: 'select', editoptions: { value: { 'M': 'Male', 'F': 'Female', 'N': 'None' } } },
                { key: false, name: 'School', index: 'School', editable: true },
                { key: false, name: 'Age', index: 'Age', editable: true },
                { key: false, name: 'Batch', index: 'Batch', editable: true },
                { key: false, name: 'Class', index: 'Class', editable: true }],
            pager: jQuery('#jqDetailControls'),
            rowNum: 10,
            rowList: [10, 20, 30, 40, 50],
            height: '100%',
            viewrecords: true,
            caption: 'Students Details Record',
            emptyrecords: 'No Students Records are Available to Display',
            jsonReader: {
                root: "rows",
                page: "page",
                total: "total",
                records: "records",
                repeatitems: false,
                Id: "0"
            },
            autowidth: true,
            multiselect: false
        }).navGrid('#jqDetailControls', { edit: true, add: true, del: true, search: false, refresh: true },
        {
            zIndex: 100,
            url: '/Employee/Edit',
            closeOnEscape: true,
            closeAfterEdit: true,
            recreateForm: true,
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        },
        {
            zIndex: 100,
            url: "/Employee/Create",
            closeOnEscape: true,
            closeAfterAdd: true,
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        },
        {
            zIndex: 100,
            url: "/Employee/Delete",
            closeOnEscape: true,
            closeAfterDelete: true,
            recreateForm: true,
            msg: "Are you sure you want to delete Student... ? ",
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        });
        IsDetailsDisplayed = true;
    }
});


/*

function AllcarDetails() {  
    $.ajax({  
        type: "GET",  
        url: "http://localhost:32359/api/Cardetails", //URI  
  
        dataType: "json",  
        success: function (data) {  
            debugger;  
            var datadatavalue = data;  
            var myJsonObject = datavalue;  
            contentType: "application/json";  
            $.each(myJsonObject, function (i, mobj) {  
                $("#Cartbl").append('<tr><td width="50px">' + mobj.CarName +  
                 '</td><td width="50px">' + mobj.CarModel +  
                '</td><td width="50px">' + mobj.CarPrice +  
                '</td>' + '</td><td width="50px">'  
                + mobj.CarColor + '</td></tr>');  
  
            });  
  
        },  
        error: function (xhr) {  
            alert(xhr.responseText);  
        }  
    });  



    @{
        ViewBag.Title = "Index";
        Layout = "~/Views/Shared/_Layout.cshtml";
    }

    <h2>Student Master</h2>
    <div>
        <table id="jqGrid"></table>
        <div id="jqControls"></div>
    </div>

    <br />
    <br />

    <div id="detailGridDiv">
        <h2>Student Details</h2>
        <div>
            <table id="jqGridDetail"></table>
            <div id="jqDetailControls"></div>
        </div>
    </div>
@section scripts{
        <link href="~/Content/themes/base/jquery-ui.css" rel="stylesheet" />
        <link href="~/Content/jquery.jqGrid/ui.jqgrid.css" rel="stylesheet" />
        <script src="~/Scripts/jquery-ui-1.10.0.js"></script>
        <script src="~/Scripts/i18n/grid.locale-en.js"></script>
        <script src="~/Scripts/jquery.jqGrid.min.js"></script>
        <script src="~/Scripts/script.js"></script>
    }

MS-SQL
declare cursor_name cusror for
select name from temp;

open cursor_name

fetch next from cursor_name into @name

while @@fetch_status=0
begin
	<!-- code part-->
	fetch next from cursor_name into @name	
	
end

close cursor_name

deallocate cursor_name


------

ORACLE

cursor cursor_name
is 
select name from dual;

begin
open cursor_name
fetch cursor_name into name

<!-- code part-->

close cursor_name;

end;
fetch 


 public JsonResult GetStudents(string sidx, string sort, int page, int rows)
        {
            SchoolDbEntities db = new SchoolDbEntities();
            sort = (sort == null) ? "" : sort;
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var StudentList = db.Students.Select(
                    t => new
                    {
                        t.StudentId,
                        t.FirstName,
                        t.LastName,
                        t.Gender,
                        t.School,
                        t.Address,
                        t.Age,
                        t.Batch,
                        t.Class                        
                    });
            int totalRecords = StudentList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                StudentList = StudentList.OrderByDescending(t => t.FirstName);
                StudentList = StudentList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                StudentList = StudentList.OrderBy(t => t.FirstName);
                StudentList = StudentList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = StudentList
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

    */