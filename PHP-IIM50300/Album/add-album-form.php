<?php 

include ("../Init/header.php"); 

require_once($dbInit);
?>
	<form action='<?php echo $albums ?>'><button id='btnBack' class='buttons'><i class='fa fa-arrow-left fa-lg'></i></button></form>
	<div id='addForm'>
		<h1>Add artist</h1>
		<form method='post' action='<?php echo $addAlbum ?>'>
			<table border='0' cellpadding='5'>
				<tr valign='top'>
				  <td align='right'>Album</td>
				  <td><input type='text' name='nimi' size='30' value=''></td>
				</tr>
				<tr valign='top'>
				  <td align='right'>Artist</td>
				  <td>
				  	<!-- Ini comboBox for year -->
				  	<select name='esittaja' id="comboArtist"> <option value="" selected>Select a artist</option>
						  <?php 
						  $result = $conn->query('select nimi from esittaja');
						  while($row = $result->fetch_assoc()){
				  		  ?>
				  	<option value ='<?php echo $row['nimi']?>'><?php echo $row['nimi']?></option>
				  <?php } ?> 
				  </select>
				  <!-- /Ini comboBox for year -->
				</td>
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
				  <td align='right'>Company</td>
				  <td>
				  	<!-- Ini comboBox for country -->
				  	<select name='yhtio' id="comboCompany"> <option value="" selected>Select a company</option>
						  <?php 
						  $result = $conn->query('select nimi from yhtio');
						  while($row = $result->fetch_assoc()){
				  		  ?>
				  	<option value ='<?php echo $row['nimi']?>'><?php echo $row['nimi']?></option>
				  <?php } ?> 
				  </select>
				  <!-- /Ini comboBox for country -->
				  </td>
				</tr>
				<tr valign='top'>
				  <td align='right'>Image link</td>
				  <td><input type='text' name='imglink' size='30' value=''></td>
				</tr>
			</table>
			<input type='submit' name='action' value='Save new album' class='buttons' id='addButton' onclick="javascript: return confirm('Add new album?')">
		</form>
	</div>


<?php include ($footer); ?>