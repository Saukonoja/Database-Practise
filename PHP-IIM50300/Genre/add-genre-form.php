<?php 

include ("../Init/header.php"); 
require_once($dbInit);
?>
	<form action='<?php echo $genres ?>'><button id='btnBack' class='buttons'><i class='fa fa-arrow-left fa-lg'></i></button></form>
	<div id='addForm'>
		<h1>Add genre</h1>
		<form method='post' action='add-genre.php'>
			<table border='0' cellpadding='5'>
				<tr valign='top'>
				  <td align='right'>Name</td>
				  <td><input type='text' name='nimi' size='30' value=''></td>
				</tr>
			</table>
			<input type='submit' name='action' value='Save new genre' class='buttons' id='addButton' onclick="javascript: return confirm('Add new genre?')">
		</form>
	</div>


<?php 

include ($footer); 

?>
