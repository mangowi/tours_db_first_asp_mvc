<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormClient.aspx.cs" Inherits="Tours_API.WebFormClient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="tours">
    
    </div>
    </form>

    <script src="Scripts/jquery-1.10.2.min.js"></script>
	 <script>
	    $(function(){
		 $.getJSON('/api/tours').done(function (data){
				$.each(data, function(index, tours){
				      for ( tour in tours){
					    $('#tours').append(tour + ': ' + tours[tour] + '<br />');
					  }
						$('#tours').append('<br />');
				});
		 });
		});
	 </script>
</body>
</html>
