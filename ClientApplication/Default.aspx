<!DOCTYPE html>
<html>
<head>
    <title></title>
    <meta charset="utf-8" />
    <script src="Scripts/jquery-3.4.1.js"></script>
    <script src="Scripts/jquery-3.4.1.js" type="text/javascript"></script>  
    <script src="Scripts/jquery-3.4.1.min.js" type="text/javascript"></script>  
    <script>  
        $(document).ready(function () {
            $("#txtInput").val(getParameterByName("username"));

            function getParameterByName(name) {
                name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
                var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
                    results = regex.exec(location.search);
                return results == null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
            }
        });
    </script>  
    <script type="text/javascript">
        $(document).ready(function () {
            var ulEmployees = $('#ulEmployees');
            var emailid = $('#txtInput').val();
            $("#txtInput1").val(emailid);

            $('#btn').click(function () {
                $.ajax({
                    type: 'GET',
                    // Make sure to change the port number to
                    // where you have the employee service
                    // running on your local machine
                    url: "https://localhost:44338/api/users/" + emailid+"/",
                    dataType: 'jsonp',
                    success: function (data) {
                        ulEmployees.empty();
                        var fullName = data.FirstName + ' ' + data.LastName;
                        //ulEmployees.append('<li>' + fullName + '</li>')
                        //ulEmployees.append('<li>' + fullName + '</li>')
                        $('#fullname').append("Full Name = " + fullName);
                        $('#email').append("EmailID = " + data.EmailID);
                    }
                });
            });

            $('#btnClear').click(function () {
                $('#fullname').empty();
                $('#email').empty();
            });
        });
    </script>
</head>
<body>
    <input id="btn" type="button" value="Get user details" />
    <input id="btnClear" type="button" value="Clear" />
    <p id="fullname"></p>
    <p id="email"></p>
    <input id="txtInput" type="hidden" /> 
</body>
</html>