<?php 
include ("../Init/header.php");

require_once($dbInit);
?>
	<form action='Tracks.php'><button id='btnBack' class='buttons'><i class='fa fa-arrow-left fa-lg'></i></button></form>
	<div id='addForm'>
		<h1>Add track</h1>
		<form method='post' action='add-track.php'>
			<table border='0' cellpadding='5'>
				<tr valign='top'>
				  <td align='right'>Name</td>
				  <td><input type='text' name='nimi' size='30' value=''></td>
				</tr>
				<tr valign='top'>
				  <td align='right'>Artist</td>
				  <td>
				  	<!-- Ini comboBox for artist -->
				  	<select name='esittaja' id="comboArtist"> <option value="" selected>Select a artist</option>
						  <?php 
						  $result = $conn->query('select nimi from esittaja');
						  while($row = $result->fetch_assoc()){
				  		  ?>
				  	<option value ='<?php echo $row['nimi']?>'><?php echo $row['nimi']?></option>
				  <?php } ?> 
				  </select>
				  <!-- /Ini comboBox for artist -->
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
				  <td align='right'>Album</td>
				  <td>
				  	<!-- Ini comboBox for album -->
				  	<select name='cd' id="comboAlbum"> <option value="" selected>Select a album</option>
						  <?php 
						  $result = $conn->query('select nimi from cd');
						  while($row = $result->fetch_assoc()){
				  		  ?>
				  	<option value ='<?php echo $row['nimi']?>'><?php echo $row['nimi']?></option>
				  <?php } ?> 
				  </select>
				  <!-- /Ini comboBox for album -->
				</td>
				</tr>
				<tr valign='top'>
				  <td align='right'>Genre</td>
				  <td>
				  	<!-- Ini comboBox for genre -->
				  	<select name='genre' id="comboGenre"> <option value="" selected>Select a genre</option>
						  <?php 
						  $result = $conn->query('select nimi from genre');
						  while($row = $result->fetch_assoc()){
				  		  ?>
				  	<option value ='<?php echo $row['nimi']?>'><?php echo $row['nimi']?></option>
				  <?php } ?> 
				  </select>
				  <!-- /Ini comboBox for genre -->
				  </td>
				</tr>
				<tr valign='top'>
				  <td align='right'>Youtube link</td>
				  <td><input type='text' name='tube' size='30' value=''></td>
				</tr>
				<tr valign='top'>
				  <td align='right'>Number</td>
				  <td><input type='text' name='number' size='30' value=''></td>
				</tr>
				<tr valign='top'>
				  <td align='right'>Length</td>
				  <td><input type='text' name='length' size='30' value=''></td>
				</tr>
			</table>
			<input type='submit' name='action' value='Save new track' class='buttons' id='addButton' onclick="javascript: return confirm('Add new track?')">
		</form>
	</div>


<?php include ($footer); ?>