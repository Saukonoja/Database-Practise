<?php 
include ("../Init/header.php"); 

require_once($dbInit);

$_SESSION['id'] = $_POST['ID'];


include($albumUpdateFormQuery);
$result = $conn->query("$sql");

if($row=$result->fetch_assoc()){
?>
	<form action='Albums.php'><button id='btnBack' class='buttons'><i class='fa fa-arrow-left fa-lg'></i></button></form>
	<div id='updateForm'>
		<h1>Update album</h1>
		<form method='post' action='update-album.php'>
			<table border='0' cellpadding='5'>
				<tr id='hiddenTr' valign='top'>
	              <td align='right'>ID</td>
	              <td><?php echo $row['id']?><input type='hidden' name='id' size='30' value='<?php echo $row['id']?>'></td>
            	</tr>
				<tr valign='top'>
				  <td align='right'>Album</td>
				  <td><input type='text' name='nimi' size='30' value='<?php echo $row['nimi']?>'></td>
				</tr>
				<tr valign='top'>
				  <td align='right'>Artist</td>
				  <td>
				  	<!-- Ini comboBox for artist -->
				  	<select name='esittaja' id="comboArtist"> <option value="<?php echo $row['esittaja'] ?>" selected><?php echo $row['esittaja'] ?></option>
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
				  	<select name='vuosi' id="comboYear"> <option value="<?php echo $row['vuosi']?>" selected><?php echo $row['vuosi']?></option>
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
				  <td align='right'>Company</td>
				  <td>
				  	<!-- Ini comboBox for company -->
				  	<select name='yhtio' id="comboCompany"> <option value="<?php echo $row['yhtio']?>" selected><?php echo $row['yhtio']?></option>
						  <?php 
						  $result = $conn->query('select nimi from yhtio');
						  while($crow = $result->fetch_assoc()){
				  		  ?>
				  	<option value ='<?php echo $crow['nimi']?>'><?php echo $crow['nimi']?></option>
				  <?php } ?> 
				  </select>
				  <!-- /Ini comboBox for company -->
				  </td>
				</tr>
				<tr valign='top'>
				  <td align='right'>Image link</td>
				  <td><input type='text' name='imglink' size='30' value='<?php echo $row['kuvapath']?>'></td>
				</tr>
			</table>
			<input type='submit' name='action' value='Save changes' class='buttons' id='updateButton' onclick="javascript: return confirm('Update album <?php $row['nimi'] ?> ?')">
        <input type='submit' name='action' value='Delete artist' class="buttons" id="deleteButton" onclick="javascript: return confirm('Delete album <?php $row['nimi'] ?> ?')"><br>
		</form>
	</div>


<?php }include ($footer); ?>