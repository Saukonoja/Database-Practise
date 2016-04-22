<?php 
include ("../Init/header.php"); 

require_once($dbInit);

$_SESSION['id'] = $_POST['ID'];

include($trackUpdateFormQuery);
$result = $conn->query("$sql");

if($row = $result->fetch_assoc()){
?>
	<form action='Tracks.php'><button id='btnBack' class='buttons'><i class='fa fa-arrow-left fa-lg'></i></button></form>
	<div id='addForm'>
		<h1>Update track</h1>
		<form method='post' action='update-track.php'>
			<table border='0' cellpadding='5'>
				<tr id='hiddenTr' valign='top'>
	              <td align='right'>ID</td>
	              <td><?php echo $row['id']?><input type='hidden' name='id' size='30' value='<?php echo $row['id']?>'></td>
            	</tr>
				<tr valign='top'>
				  <td align='right'>Name</td>
				  <td><input type='text' name='nimi' size='30' value='<?php echo $row['track']?>'></td>
				</tr>
				<tr valign='top'>
				  <td align='right'>Artist</td>
				  <td>
				  	<!-- Ini comboBox for artist -->
				  	<select name='esittaja' id="comboArtist"> <option value="<?php echo $row['artist']?>" selected><?php echo $row['artist']?></option>
						  <?php 
						  $result = $conn->query('select nimi from esittaja');
						  while($crow = $result->fetch_assoc()){
				  		  ?>
				  	<option value ='<?php echo $crow['nimi']?>'><?php echo $crow['nimi']?></option>
				  <?php } ?> 
				  </select>
				  <!-- /Ini comboBox for artist -->
				</td>
				</tr>
				<tr valign='top'>
				  <td align='right'>Year</td>
				  <td>
				  	<!-- Ini comboBox for year -->
				  	<select name='vuosi' id="comboYear"> <option value="<?php echo $row['year']?>" selected><?php echo $row['year']?></option>
						  <?php 
						  $result = $conn->query('select vuosi from vuosi order by vuosi desc');
						  while($crow = $result->fetch_assoc()){
				  		  ?>
				  	<option value ='<?php echo $crow['vuosi']?>'><?php echo $crow['vuosi']?></option>
				  <?php } ?> 
				  </select>
				  <!-- /Ini comboBox for year -->
				</td>
				</tr>
				<tr valign='top'>
				  <td align='right'>Album</td>
				  <td>
				  	<!-- Ini comboBox for album -->
				  	<select name='cd' id="comboAlbum"> <option value="<?php echo $row['album']?>" selected><?php echo $row['album']?></option>
						  <?php 
						  $result = $conn->query('select nimi from cd');
						  while($crow = $result->fetch_assoc()){
				  		  ?>
				  	<option value ='<?php echo $crow['nimi']?>'><?php echo $crow['nimi']?></option>
				  <?php } ?> 
				  </select>
				  <!-- /Ini comboBox for album -->
				</td>
				</tr>
				<tr valign='top'>
				  <td align='right'>Genre</td>
				  <td>
				  	<!-- Ini comboBox for genre -->
				  	<select name='genre' id="comboGenre"> <option value="<?php echo $row['genre']?>" selected><?php echo $row['genre']?></option>
						  <?php 
						  $result = $conn->query('select nimi from genre');
						  while($crow = $result->fetch_assoc()){
				  		  ?>
				  	<option value ='<?php echo $crow['nimi']?>'><?php echo $crow['nimi']?></option>
				  <?php } ?> 
				  </select>
				  <!-- /Ini comboBox for genre -->
				  </td>
				</tr>
				<tr valign='top'>
				  <td align='right'>Youtube link</td>
				  <td><input type='text' name='tube' size='30' value='<?php echo $row['tube']?>'></td>
				</tr>
				<tr valign='top'>
				  <td align='right'>Number</td>
				  <td><input type='text' name='number' size='30' value='<?php echo $row['number']?>'></td>
				</tr>
				<tr valign='top'>
				  <td align='right'>Length</td>
				  <td><input type='text' name='length' size='30' value='<?php echo $row['length']?>'></td>
				</tr>
			</table>
				<input type='submit' name='action' value='Save changes' class='buttons' id='updateButton' onclick="javascript: return confirm('Update album <?php $row['nimi'] ?> ?')">
        		<input type='submit' name='action' value='Delete track' class="buttons" id="deleteButton" onclick="javascript: return confirm('Delete album <?php $row['nimi'] ?> ?')"><br>
		</form>
	</div>


<?php } include ($footer); ?>