var ServerName, password, userId, response_string = "", _schemaName;
var first = true;

var tableData;
var d = new Array();
var cell_data = new Array();
function connectWithDatabase()
{
    if (!validateConnection())
        return;
    else {
        ConnectToDatabase('enable');
       
    }
}

function validateConnection()
{

    ServerName = $('#serverName').val();
    console.log(ServerName);
    password = $('#password').val();
    console.log(password);
    userId = $('#userId').val();
    console.log(userId);

    if (ServerName == "dev-aur-clust.cluster-cazqozjhlo6b.us-west-2.rds.amazonaws.com:3306" && password == "LenoraFast3" && userId == "lenora")
        return true;
    else
    return false;

}
function ConnectToDatabase(checkEnable)
{

    debugger;
    $.ajax({
        url: '/Home/ConnectToServer',
        type: 'GET',
        data: { database: ServerName, user: userId, password: password },
        cache: false,
        success: function (response) {
          
            debugger;
           
           
            var data = $.parseJSON(response);
            console.log(data);
            if (data["Message"] == "Connection Successfull") {
                debugger;
                response_string += response;

                if (checkEnable == 'enable') {
                    debugger;
                  
                    $("#connection_success_message").css("display", "block");
                    $("#connection_success_message").empty();
                    $("#connection_success_message").append("Connection is Successfull !!!");

                 
                }
            }
            
        }
     
    }
        );
}

function setSelected() {
    _schemaName = $("#selectedOption  option:selected").text(),

    $.ajax({
       
        url: '/Home/bindTemplate',
        data: { _SelectedSchema: _schemaName },
        cache: false,
        success: function (response) {
          
            var data = $.parseJSON(response);
            debugger;
            var s = "<ul>";
            for (var i=0; i < data.length; i++) {
                s += "<li>"+data[i]+"</li>";
            }
            s += "</ul>";

            $("#modalBody").css("display", "block");
            $("#modalBody").empty();
            $("#modalBody").append(s);
        
            //$("#modalBody").text(s);


    }
        });

}

function loadDataToTable() {

        $.ajax({
            url: '/Files/sample.csv',
            dataType: 'text',
            success: function (data) {
                debugger;
                d = data.split(/\r?\n|\r/);
                tableDisplay(d);
            }
        
        });
}
function tableDisplay(d) {
   
    var row_id = 0;
    var flag = 0;
    tableData = '<table class="table table-bordered table-striped alternate" id="theTable">';
   
    for (var i = 0; i < d.length; i++) {
        row_id++;
        //if (flag != 0  ) {
        //    d[i] += "," + '<button class="btn btn-success edit" onclick="editSelected(\'' + i + '\');">Edit</button>';
        //    d[i] += "," + '<button class="btn btn-success save" onclick="saveSelected(\'' + i + '\');">Save</button>';
        //    first = false;

        //}
        tableData += '<tr row_id="' + row_id + '" bg-color="light-blue">';


        cell_data = d[i].split(",");
        var length = cell_data.length;


        for (var j = 0; j < cell_data.length-2; j++) {

            if (flag == 0) {

                tableData += '<th><b>' + cell_data[j] + '</b></th>';
            }
            else {
                tableData += '<td>' + cell_data[j] + '</td>';
            }
        }
        if (flag != 0) {
            tableData += '<td><button class="btn btn-success edit" onclick="editSelected(\'' + i + '\');">Edit</button></td>';
            tableData += '<td><button class="btn btn-success save" onclick="saveSelected(\'' + i + '\');">Save</button></td>';
            tableData += '<td><button class="btn btn-success delete" onclick="deleteSelected(\'' + i + '\');">Delete</button></td>';
        }
        flag = 1;
        tableData += '</tr>';
    }

    debugger;
    tableData += '</table>';


    $("#NewTable").html(tableData);
}



function editSelected(i) {
    //$('.edit').one("click",function ()
    //{
        debugger;
        cell_data = d[i].split(",");
       
      
        for (var j = 0; j < cell_data.length; j++)
        {
            debugger;
            cell_data[j] = '<input type="text" id="col' + j + '">';
            if (j == 0)
                d[i] = cell_data[j]+',';
            else if (j == cell_data.length - 1)
                d[i] += cell_data[j];
            else
            d[i] += cell_data[j] + ',';
        }
        
        tableDisplay(d);

    //});

 }

function saveSelected(i) {
  
        debugger;
         cell_data = d[i].split(",");
        for (var j = 0; j < cell_data.length; j++)
        {
            debugger;
            cell_data[j] = $('#col' + j).val();
            if (j == 0)
                d[i] = cell_data[j] + ',';
            else if (j == cell_data.length - 1)
                d[i] += cell_data[j];
            else
                d[i] += cell_data[j] + ',';
        }
        tableDisplay(d);
 

}
function deleteSelected(i) {

    debugger;
   
    for (var j = i; j < d.length; j++) {
        if (j + 1 < d.length)
        d[j] = d[j + 1];
    }
    tableDisplay(d);


}

    

    //$('#loadData').click(function () {
    //    $.ajax({
    //        url: "~/Files/sample.csv",
    //        datatype: "text",
    //        success: function (data) {
    //            var data = data.split(/\r?\n|\r/);
    //            var tableData = '<table class ="table table-bordered table-striped">';
    //            for (var i = 0; i < data.length; i++) {
    //                var cell_data = data[i].split(",");
    //                tableData += '<tr>';
    //                for (var j = 0; j < data.length; j++) {
    //                    if (i == 0) {
    //                        tableData += '<th>' + cell_data[j] + '</th>';
    //                    }
    //                    else {
    //                        tableData += '<td>' + cell_data[j] + '</td>';
    //                    }
    //                }
    //                tableData += '</tr>';
    //            }
    //            debugger;
    //            tableData += '</table>';

    //            ('#Newtable').html(tableData);


    //        }
    //    });
    //})
