<?php session_start();
include ("header.php"); 
require_once("db-init-music.php");

$_SESSION['id'] = $_POST['ID'];

include("select-queries/artist-update-form-query.php");

$result = $conn->query("$sql");


	if($row = $result->fetch_assoc()){
	$forms = <<<FORMEND

<h1>Update artist</h1><form method='post' action='update-artist.php'>
<table border='0' cellpadding='5'>
<tr id='hiddenTr' valign='top'>
  <td align='right'>ID</td>
  <td>{$row['id']}<input type='hidden' name='id' size='30' value='{$row['id']}'></td>
</tr>
<tr valign='top'>
  <td align='right'>Name</td>
  <td><input type='text' name='nimi' size='30' value='{$row['nimi']}'></td>
</tr>
<tr valign='top'>
  <td align='right'>Year</td>
  <td><input type='text' name='vuosi' size='30' value='{$row['vuosi']}'></td>
</tr>
<tr valign='top'>
  <td align='right'>Country</td>
  <td><input type='text' name='maa' size='30' value='{$row['maa']}'></td>
</tr>
</table>
<input type='submit' name='action' value='Save' onclick="javascript: return confirm('Accept add?')"><br>
</form>
FORMEND;
echo $forms;
}


?>






<?php include ("footer.php"); ?>