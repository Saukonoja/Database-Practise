<?php 

include ("header.php");

$form = <<<FORMEND

	<form action='Artists.php'><button id='btnBack' class='buttons'><i class="fa fa-arrow-left fa-lg"></i></button></form>
	<div id="addForm">
		<h1>Add artist</h1>
		<form method='post' action='add-artist.php'>
			<table border='0' cellpadding='5'>
				<tr valign='top'>
				  <td align='right'>Name</td>
				  <td><input type='text' name='nimi' size='30' value=''></td>
				</tr>
				<tr valign='top'>
				  <td align='right'>Year</td>
				  <td><input type='text' name='vuosi' size='30' value=''></td>
				</tr>
				<tr valign='top'>
				  <td align='right'>Country</td>
				  <td><input type='text' name='maa' size='30' value=''></td>
				</tr>
			</table>
			<input type='submit' name='action' value='Save new artist' class="buttons" id="addButton" onclick="javascript: return confirm('Add new artist?')">
		</form>
	</div>

FORMEND;
echo $form;

include ("footer.php"); 

?>