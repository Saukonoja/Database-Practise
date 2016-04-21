<?php 

include ("../Init/header.php"); 
require_once($dbInit);
?>
	<form action='<?php echo $artists ?>'><button id='btnBack' class='buttons'><i class='fa fa-arrow-left fa-lg'></i></button></form>
	<div id='addForm'>
		<h1>Add artist</h1>
		<form method='post' action='<?php echo $addArtist ?>'>
			<table border='0' cellpadding='5'>
				<tr valign='top'>
				  <td align='right'>Name</td>
				  <td><input type='text' name='nimi' size='30' value=''></td>
				</tr>
				<tr valign='top'>
				  <td align='right'>Year</td>
				  <td>
				  	<!-- Ini comboBox for year -->
				  	<select name='vuosi' id="comboYear"> <option value="" selected>Select a year</option>
						  <?php 
						  $result = $conn->query('select vuosi from vuosi order by vuosi desc');
						  while($row = $result->fetch_assoc()){
				  		  ?>
				  	<option value ='<?php echo $row['vuosi']?>'><?php echo $row['vuosi']?></option>
				  <?php } ?> 
				  </select>
				  <!-- /Ini comboBox for year -->
				</td>
				</tr>
				<tr valign='top'>
				  <td align='right'>Country</td>
				  <td>
				  	<!-- Ini comboBox for country -->
				  	<select name='maa' id="comboCountry"> <option value="" selected>Select a country</option>
						  <?php 
						  $result = $conn->query('select nimi from maa');
						  while($row = $result->fetch_assoc()){
				  		  ?>
				  	<option value ='<?php echo $row['nimi']?>'><?php echo $row['nimi']?></option>
				  <?php } ?> 
				  </select>
				  <!-- /Ini comboBox for country -->
				  </td>
				</tr>
			</table>
			<input type='submit' name='action' value='Save new artist' class='buttons' id='addButton' onclick="javascript: return confirm('Add new artist?')">
		</form>
	</div>


<?php 

include ($footer); 

?>
